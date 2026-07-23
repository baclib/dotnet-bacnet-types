// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { TemplateEngine } from '../core/template-engine.js';
import { codecTemplatesDir, codecsOutputDir, generatorRoot, workingDir } from '../core/paths.js';
import { isBooleanObject } from 'util/types';
import Handlebars from 'handlebars';
import { sourceTypesByName, sourceTypesByIndex, getUnsignedVariant, getIntegerVariant } from './predefined.js';
import { toPascalCase, toCamelCase } from '../core/text.js';
import { describeBitString } from '../core/bit-string-model.js';

function annotateIntegerFamilies(codec) {
    return {
        ...codec,
        isUnsignedFamily: codec.tagName === 'Unsigned',
        isIntegerFamily: codec.tagName === 'Integer'
    };
}

/**
 * Derives the storage/length fields the primitive template needs to emit a bit-string codec.
 * All bit-string codecs (the base `bit-string`, the `bit-string-8/16/32/64` variants, and every
 * refined named type) flow through the shared classifier so they stay in agreement with the types.
 *
 * @param {string} fullname The definition's full name (used to detect the special variable primitives).
 * @param {object|undefined} traits The definition traits (`length`, `bits`), when available.
 */
function bitStringDescriptorFields(fullname, traits) {
    const bits = traits?.bits;
    const inferredFixedLength = Array.isArray(bits) && bits.length > 0
        ? Math.max(...bits.map(bit => bit.position)) + 1
        : null;

    const descriptor = describeBitString({
        lengthTrait: traits?.length,
        inferredFixedLength,
        fullname
    });

    return {
        storageType: descriptor.storageType,
        isArrayStorage: descriptor.isArrayStorage,
        countType: descriptor.countType,
        storageBytes: descriptor.storageBytes,
        isVariable: descriptor.length.isVariable,
        fixedLength: descriptor.length.isVariable ? null : descriptor.length.maximum
    };
}

/** Applies integer-family and (for bit-strings) storage-descriptor annotations to a seeded codec. */
function annotatePrimitiveCodec(codec) {
    const annotated = annotateIntegerFamilies(codec);
    if (!annotated.isBitString) {
        return annotated;
    }

    return { ...annotated, ...bitStringDescriptorFields(annotated.name, undefined) };
}

Handlebars.registerHelper('nameis', function (value, options) {
    return this.name === value ? options.fn(this) : options.inverse(this);
});

BigInt.prototype.toJSON = function () {
    return Number(this);
};

class FixedCodecTransformer extends TemplateEngine {
    constructor() {
        super();
        this.directory = process.env.CODEC_OUTPUT_DIR
            ? path.resolve(generatorRoot, process.env.CODEC_OUTPUT_DIR)
            : codecsOutputDir;
        this.templatesDir = codecTemplatesDir;
        this.primitiveCodecs = sourceTypesByIndex.map(annotatePrimitiveCodec);
        this.predefinedNames = new Set(sourceTypesByIndex.map(codec => codec.name));
    }

    inferBounds(traits) {
        const hasMinimum = Object.hasOwn(traits, 'minimum');
        const hasMaximum = Object.hasOwn(traits, 'maximum');
        if (traits.values) {
            const constants = traits.values.map((value) => value.constant);
            const minimum = hasMinimum ? traits.minimum : Math.min(...constants);
            const maximum = hasMaximum ? traits.maximum : Math.max(...constants);
            return { minimum, maximum };
        }
        else if (hasMinimum || hasMaximum) {
            const minimum = hasMinimum ? traits.minimum : null;
            const maximum = hasMaximum ? traits.maximum : null;
            return { minimum, maximum };
        }
    }

    inferLength(traits) {
        const length = traits.length;
        if (Number.isFinite(length)) {
            return { minimum: length, maximum: length };
        }
        const hasLength = Object.hasOwn(traits, 'length');
        const hasMinimum = hasLength && Object.hasOwn(length, 'minimum');
        const hasMaximum = hasLength && Object.hasOwn(length, 'maximum');
        if (traits.bits) {
            const positions = traits.bits.map((bit) => bit.position);
            const maximum = hasMaximum ? length.maximum : Math.max(...positions) + 1;
            const minimum = hasMinimum ? length.minimum : maximum;
            return { minimum, maximum };
        }
        else if (hasMinimum || hasMaximum) {
            const minimum = hasMinimum ? length.minimum : null;
            const maximum = hasMaximum ? length.maximum : null;
            return { minimum, maximum };
        }
    }

    pushPrimitiveCodec(fullname, base, context) {
        const bounds = this.inferBounds(context.traits);
        const length = this.inferLength(context.traits);
        const typeName = fullname.split('.').map((part, index) => (index ? 'T' : '') + toPascalCase(part)).join('.')

        const variant = (bounds && (base === 'unsigned' || base === 'enumerated')) ? getUnsignedVariant(bounds.minimum, bounds.maximum) : null;
 

        const isBitString = base === 'bit-string';
        const isEnumerated = base === 'enumerated';
        const isReal = base === 'real';
        const isOctetString = base === 'octet-string';
        const isCharacterString = base === 'character-string';

        const isDerived = isBitString || isEnumerated || isReal || isOctetString || isCharacterString;

        const fixedSize = base === 'real';
        const lengthConstant = base === 'real' ? 'Real' : null;

        this.primitiveCodecs.push(annotateIntegerFamilies({
            name: fullname,
            typeName,
            className: `${typeName}Codec`.replaceAll('.', ''),
            csharpType: typeName,
            ...(bounds ? { bounds } : {}),
            ...(length ? { length } : {}),
            ...(variant ? { variant } : {}),
            ...(isBitString ? { isBitString, ...bitStringDescriptorFields(fullname, context.traits) } : {}),
            ...(isEnumerated ? { isEnumerated } : {}),
            ...(isReal ? { isReal } : {}),
            ...(isOctetString ? { isOctetString } : {}),
            ...(isCharacterString ? { isCharacterString } : {}),
            ...(isDerived ? { isDerived } : {}),
            ...(fixedSize ? { fixedSize } : {}),
            ...(lengthConstant ? { lengthConstant } : {}),
            //...(st.underlyingType ? { underlyingType: st.underlyingType } : {}),
            tagName: toPascalCase(base),

        }));
    }
   

    startDefinition(context) {
        const name = context.definition.name;
        if (name === 'string' || name === 'create-object-ack') {
            return;
        }

        if (!context.isPrimitive && !this.predefinedNames.has(name)) {
            const typeName = context.definition.type.base ?? context.definition.type;
            if (this.predefinedNames.has(typeName)) {
                this.pushPrimitiveCodec(name, typeName, context);
            }
        }
    }

    endDefinition(context) { }

    startTraits(context) {
        if (!context.definition) {
            const traits = context.traits;
            if (Object.keys(traits).length === 2 && 'base' in traits && 'series' in traits) {
                return;
            }
            const typeName = context.traits.base;
            if (this.predefinedNames.has(typeName)) {
                this.pushPrimitiveCodec(context.fullname, typeName, context);
            }
        }
    }

    endTraits(context) { }

    startItem(context) { }

    endItem(context) { }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    async afterProcessing() {
        const debugOutputPath = path.join(workingDir, 'fixed-codecs-debug.json');
        await fs.writeFile(debugOutputPath, JSON.stringify(this.primitiveCodecs, null, 4) + '\n', 'utf-8');
        for (const codec of this.primitiveCodecs) {
            // console.log(codec);
            const templatePath = path.join(this.templatesDir, 'primitive.hbs');
            const content = await this.render(templatePath, codec);
            const filePath = path.join(this.directory, `${codec.className}.cs`);
            writeFileSync(filePath, content);
        }
    }
}

/** Creates the fixed/primitive codec generator. */
export function createFixedCodecGenerator() {
    return new FixedCodecTransformer();
}


//console.log(sourceTypesByIndex);