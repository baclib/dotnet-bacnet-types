// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import Handlebars from 'handlebars';
import { CodecGeneratorBase } from './base.js';

// BACnet context tag numbers above 254 require an extended tag encoding that the current
// byte-based tag infrastructure does not support, so such CHOICE options are omitted.
const MAX_SUPPORTED_CONTEXT_TAG = 254;

// Types whose codecs are intentionally skipped. CHOICE options referencing these are omitted
// so the generated codecs compile without the (currently unsupported) referenced codec.
const EXCLUDED_CODEC_TYPES = new Set(['create-object-ack']);

class ChoiceCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super({
            filterEnvName: 'CHOICE_CODEC_FILTER',
            noEscape: false
        });
        this.codecObjects = [];
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
        this.registerHelpers();
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
        if (context.traits?.base !== 'choice') {
            return;
        }

        // A SEQUENCE OF CHOICE produces a dedicated element type named "<field>-item" for nested
        // fields. Top-level series choices are handled elsewhere and have no standalone codec.
        const isSeries = this.isSeries(context);
        if (isSeries && !context.fullname.includes('.')) {
            return;
        }

        const codecFullname = isSeries ? `${context.fullname}-item` : context.fullname;

        if (!this.matchesFilter(codecFullname)) {
            return;
        }

        const hierarchy = this.getTypeHierarchy(codecFullname);
        const typeName = hierarchy.join('.');
        const className = hierarchy.join('') + 'Codec';
        const fileName = `${className}.cs`;

        this.codecObjects.push({
            fullname: codecFullname,
            bacnetName: context.thisAlias ?? context.thisName,
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className,
            fileName,
            typeName,
            typeRef: this.getTypeReference(codecFullname),
            items: context.userContext
        });
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        const itemType = context.item.type;
        let itemTypeFullname;
        if (typeof itemType === 'string') {
            itemTypeFullname = itemType;
        }
        else if (itemType && typeof itemType === 'object') {
            // An option whose type only references a base type (optionally as a series) does not
            // introduce a dedicated nested type; reference the base type directly. Options that carry
            // an inline definition (extra keys beyond base/series) keep their own nested codec. When
            // such an inline option is itself a series, the type generator names the nested element
            // type with an "-item" suffix (e.g. LogData.TSeriesItem), so align the reference here.
            const hasInlineDefinition = Object.keys(itemType).some(key => !['base', 'series'].includes(key));
            if (hasInlineDefinition) {
                itemTypeFullname = itemType.series ? `${context.fullname}-item` : context.fullname;
            }
            else {
                itemTypeFullname = itemType.base;
            }
        }
        else {
            itemTypeFullname = context.fullname;
        }

        // Skip options that cannot be represented by the byte-based context tag infrastructure
        // (context tag numbers > 254 need extended tag encoding that is not yet supported).
        if (Object.hasOwn(context.item, 'context') && context.item.context > MAX_SUPPORTED_CONTEXT_TAG) {
            return;
        }

        // Skip options referencing types that are excluded from codec generation.
        if (EXCLUDED_CODEC_TYPES.has(itemTypeFullname)) {
            return;
        }

        const itemName = this.toPascalCase(context.item.name);

        parent.userContext.push({
            name: itemName,
            variableName: this.toCamelCase(itemName),
            hasContextTag: Object.hasOwn(context.item, 'context'),
            tagNumber: Object.hasOwn(context.item, 'context') ? context.item.context : null,
            sourceFullname: itemTypeFullname
        });
    }

    async afterProcessing() {
        const generatedFileNames = new Set(this.codecObjects.map(item => item.fileName));
        const existingFiles = await fs.readdir(this.directory);
        for (const file of existingFiles) {
            if (generatedFileNames.has(file)) {
                await fs.unlink(path.join(this.directory, file));
            }
        }

        const templatePath = path.join(this.templatesDir, 'codec-choice.hbs');
        for (const codecObject of this.codecObjects) {
            const resolvedItems = codecObject.items.map(item => ({
                ...item,
                typeName: this.getItemTypeReference(item.sourceFullname),
                appTagName: this.resolveKind(item.sourceFullname) === 'primitive' ? this.getApplicationTagName(item.sourceFullname) : null,
                typeRef: this.getTypeReference(item.sourceFullname),
                codecRef: this.getCodecReference(item.sourceFullname),
                kind: this.resolveKind(item.sourceFullname)
            }));

            const content = await this.render(templatePath, {
                ...codecObject,
                items: resolvedItems,
                applicationItems: resolvedItems.filter(item => !item.hasContextTag && item.kind === 'primitive'),
                contextItems: resolvedItems.filter(item => item.hasContextTag)
            });
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
    }

    registerHelpers() {
        Handlebars.registerHelper('eq', (left, right) => left === right);
    }
}

/** Creates the CHOICE codec generator. */
export function createChoiceCodecGenerator() {
    return new ChoiceCodecTransformer();
}
