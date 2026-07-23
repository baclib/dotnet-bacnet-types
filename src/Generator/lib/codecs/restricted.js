// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { CodecGeneratorBase } from './base.js';

// Codec class names that are provided by the fixed codec generator and must never be
// re-emitted as restriction wrappers.
const predefinedCodecNames = new Set([
    'UnsignedCodec', 'IntegerCodec', 'RealCodec', 'DoubleCodec',
    'OctetStringCodec', 'CharacterStringCodec', 'BitStringCodec',
    'Unsigned8Codec', 'Unsigned16Codec', 'Unsigned32Codec', 'Unsigned64Codec',
    'Integer8Codec', 'Integer16Codec', 'Integer32Codec', 'Integer64Codec'
]);

class RestrictedCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super({
            filterEnvName: 'RESTRICTED_CODEC_FILTER',
            noEscape: true
        });
        this.codecObjects = [];
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    startDefinition(context) {
        this.registerType(context);
    }

    endDefinition(context) {}

    startTraits(context) {
        this.registerType(context);
        context.userContext = [];
    }

    endTraits(context) {
        // Restriction wrappers are only emitted for nested subtypes. Top-level restricted
        // primitives (e.g. week-n-day, date-pattern) are owned by the fixed codec generator
        // or by codec overrides, so emitting a delegating wrapper for them would collide.
        if (!context.fullname.includes('.')) {
            return;
        }

        const baseCodec = this.resolveBaseCodec(context);
        if (baseCodec === null) {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        const hierarchy = this.getTypeHierarchy(context.fullname);
        const className = hierarchy.join('') + 'Codec';

        // Top-level predefined primitives are owned by the fixed codec generator.
        if (predefinedCodecNames.has(className)) {
            return;
        }

        this.codecObjects.push({
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className,
            fileName: `${className}.cs`,
            typeRef: this.getTypeReference(context.fullname),
            baseCodec
        });
    }

    startItem(context) {}

    endItem(context) {}

    // Resolves the underlying primitive codec for a length- or range-restricted primitive type,
    // mirroring the underlying type selection used by the type generator. Returns null when the
    // context is not a restriction wrapper.
    resolveBaseCodec(context) {
        const traits = context.traits;
        if (!traits || this.isSeries(context)) {
            return null;
        }

        const base = traits.base;

        if (base === 'unsigned') {
            if (!(Object.hasOwn(traits, 'minimum') && Object.hasOwn(traits, 'maximum'))) {
                return null;
            }
            const max = Number(traits.maximum);
            if (max < 256) return 'Unsigned8Codec';
            if (max < 65536) return 'Unsigned16Codec';
            if (max < 4294967296) return 'Unsigned32Codec';
            return 'Unsigned64Codec';
        }

        if (base === 'integer') {
            if (!(Object.hasOwn(traits, 'minimum') || Object.hasOwn(traits, 'maximum'))) {
                return null;
            }
            const min = Number(traits.minimum ?? 0);
            const max = Number(traits.maximum ?? 2147483647);
            if (min >= -128 && max <= 127) return 'Integer8Codec';
            if (min >= -32768 && max <= 32767) return 'Integer16Codec';
            if (min >= -2147483648 && max <= 2147483647) return 'Integer32Codec';
            return 'Integer64Codec';
        }

        if (base === 'real') {
            if (!(Object.hasOwn(traits, 'minimum') || Object.hasOwn(traits, 'maximum'))) {
                return null;
            }
            return 'RealCodec';
        }

        if (base === 'octet-string') {
            return Object.hasOwn(traits, 'length') ? 'OctetStringCodec' : null;
        }

        if (base === 'character-string') {
            return Object.hasOwn(traits, 'length') ? 'CharacterStringCodec' : null;
        }

        return null;
    }

    async afterProcessing() {
        const generatedFileNames = new Set(this.codecObjects.map(item => item.fileName));
        const existingFiles = await fs.readdir(this.directory);
        for (const file of existingFiles) {
            if (generatedFileNames.has(file)) {
                await fs.unlink(path.join(this.directory, file));
            }
        }

        const templatePath = path.join(this.templatesDir, 'codec-restricted-native.hbs');
        for (const codecObject of this.codecObjects) {
            const content = await this.render(templatePath, codecObject);
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
    }
}

/** Creates the restricted-primitive codec generator. */
export function createRestrictedCodecGenerator() {
    return new RestrictedCodecTransformer();
}
