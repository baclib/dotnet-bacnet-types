// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { TemplateEngine } from '../core/template-engine.js';
import { toPascalCase } from '../core/text.js';
import { codecTemplatesDir, generatorRoot, workingDir } from '../core/paths.js';

class EnumCodecTransformer extends TemplateEngine {
    constructor() {
        super();
        this.directory = process.env.CODEC_OUTPUT_DIR
            ? path.resolve(generatorRoot, process.env.CODEC_OUTPUT_DIR)
            : path.join(workingDir, 'enums');
        this.templatesDir = codecTemplatesDir;
        this.codecObjects = [];
        this.filter = process.env.ENUM_CODEC_FILTER ?? null;
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    startDefinition(context) {}

    endDefinition(context) {}

    startTraits(context) {
        context.userContext = [];
    }

    endTraits(context) {
        if (this.isSeries(context) || context.traits?.base !== 'enumerated') {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        const hierarchy = this.getTypeHierarchy(context.fullname);
        const className = `${hierarchy.join('')}Codec`;
        const fileName = `${className}.cs`;

        const underlyingType = this.resolveUnderlyingType(context);
        const levelSpec = this.getLevelSpec(underlyingType);

        this.codecObjects.push({
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className,
            fileName,
            typeName: hierarchy.join('.'),
            typeRef: this.getTypeReference(context.fullname),
            underlyingType,
            fromLengthMethod: levelSpec.fromLengthMethod,
            levels: levelSpec.levels
        });
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        if (parent?.traits?.base !== 'enumerated') {
            return;
        }

        const constant = context.item?.constant;
        if (constant !== undefined && constant !== null) {
            parent.userContext.push(constant);
        }
    }

    async afterProcessing() {
        // The generic BACnet `enumerated` application type maps to the `Enumerated` C# type
        // (see codecOverrides). It has no standalone definition with enumerated traits, so emit
        // its codec explicitly using the 32-bit variable-length encoding spec.
        this.codecObjects.push(this.buildGenericEnumeratedCodec());

        const generatedFileNames = new Set(this.codecObjects.map(item => item.fileName));
        const existingFiles = await fs.readdir(this.directory);
        for (const file of existingFiles) {
            if (generatedFileNames.has(file)) {
                await fs.unlink(path.join(this.directory, file));
            }
        }

        const templatePath = path.join(this.templatesDir, 'codec-enum-native.hbs');
        for (const codecObject of this.codecObjects) {
            const content = await this.render(templatePath, codecObject);
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
    }

    isSeries(context) {
        return context.traits && Object.hasOwn(context.traits, 'series') && context.traits.series !== false;
    }

    buildGenericEnumeratedCodec() {
        const underlyingType = 'uint';
        const levelSpec = this.getLevelSpec(underlyingType);
        return {
            fullname: 'enumerated',
            bacnetName: 'enumerated',
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className: 'EnumeratedCodec',
            fileName: 'EnumeratedCodec.cs',
            typeName: 'Enumerated',
            typeRef: 'T.Enumerated',
            underlyingType,
            fromLengthMethod: levelSpec.fromLengthMethod,
            levels: levelSpec.levels
        };
    }

    matchesFilter(fullname) {
        if (!this.filter) {
            return true;
        }

        return fullname === this.filter || this.getTypeHierarchy(fullname).join('.') === this.filter;
    }

    resolveUnderlyingType(context) {
        const values = [];

        if (this.isIntegerLike(context.traits?.maximum)) {
            values.push(this.toBigInt(context.traits.maximum));
        }

        if (Array.isArray(context.userContext)) {
            for (const constant of context.userContext) {
                if (this.isIntegerLike(constant)) {
                    values.push(this.toBigInt(constant));
                }
            }
        }

        let maximum = values.length ? values[0] : 0n;
        for (const candidate of values) {
            if (candidate > maximum) {
                maximum = candidate;
            }
        }

        if (maximum <= 0xFFn) {
            return 'byte';
        }
        if (maximum <= 0xFFFFn) {
            return 'ushort';
        }
        if (maximum <= 0xFFFFFFFFn) {
            return 'uint';
        }

        return 'ulong';
    }

    getLevelSpec(underlyingType) {
        if (underlyingType === 'byte') {
            return {
                fromLengthMethod: 'FromUnsigned8',
                levels: [
                    {
                        lengthConst: 'Enumerated8',
                        readMethod: 'ReadUnsigned8',
                        writeMethod: 'WriteUnsigned8',
                        castType: 'byte'
                    }
                ]
            };
        }

        if (underlyingType === 'ushort') {
            return {
                fromLengthMethod: 'FromUnsigned16',
                levels: [
                    {
                        lengthConst: 'Enumerated8',
                        readMethod: 'ReadUnsigned8',
                        writeMethod: 'WriteUnsigned8',
                        castType: 'byte'
                    },
                    {
                        lengthConst: 'Enumerated16',
                        readMethod: 'ReadUnsigned16',
                        writeMethod: 'WriteUnsigned16',
                        castType: 'ushort'
                    }
                ]
            };
        }

        if (underlyingType === 'uint') {
            return {
                fromLengthMethod: 'FromUnsigned32',
                levels: [
                    {
                        lengthConst: 'Enumerated8',
                        readMethod: 'ReadUnsigned8',
                        writeMethod: 'WriteUnsigned8',
                        castType: 'byte'
                    },
                    {
                        lengthConst: 'Enumerated16',
                        readMethod: 'ReadUnsigned16',
                        writeMethod: 'WriteUnsigned16',
                        castType: 'ushort'
                    },
                    {
                        lengthConst: 'Enumerated24',
                        readMethod: 'ReadUnsigned24',
                        writeMethod: 'WriteUnsigned24',
                        castType: 'uint'
                    },
                    {
                        lengthConst: 'Enumerated32',
                        readMethod: 'ReadUnsigned32',
                        writeMethod: 'WriteUnsigned32',
                        castType: 'uint'
                    }
                ]
            };
        }

        return {
            fromLengthMethod: 'FromUnsigned64',
            levels: [
                {
                    lengthConst: 'Enumerated8',
                    readMethod: 'ReadUnsigned8',
                    writeMethod: 'WriteUnsigned8',
                    castType: 'byte'
                },
                {
                    lengthConst: 'Enumerated16',
                    readMethod: 'ReadUnsigned16',
                    writeMethod: 'WriteUnsigned16',
                    castType: 'ushort'
                },
                {
                    lengthConst: 'Enumerated24',
                    readMethod: 'ReadUnsigned24',
                    writeMethod: 'WriteUnsigned24',
                    castType: 'uint'
                },
                {
                    lengthConst: 'Enumerated32',
                    readMethod: 'ReadUnsigned32',
                    writeMethod: 'WriteUnsigned32',
                    castType: 'uint'
                },
                {
                    lengthConst: 'Enumerated40',
                    readMethod: 'ReadUnsigned40',
                    writeMethod: 'WriteUnsigned40',
                    castType: 'ulong'
                },
                {
                    lengthConst: 'Enumerated48',
                    readMethod: 'ReadUnsigned48',
                    writeMethod: 'WriteUnsigned48',
                    castType: 'ulong'
                },
                {
                    lengthConst: 'Enumerated56',
                    readMethod: 'ReadUnsigned56',
                    writeMethod: 'WriteUnsigned56',
                    castType: 'ulong'
                },
                {
                    lengthConst: 'Enumerated64',
                    readMethod: 'ReadUnsigned64',
                    writeMethod: 'WriteUnsigned64',
                    castType: 'ulong'
                }
            ]
        };
    }

    isIntegerLike(value) {
        if (typeof value === 'bigint') {
            return true;
        }

        if (typeof value === 'number') {
            return Number.isInteger(value);
        }

        if (typeof value === 'string') {
            return /^[0-9]+$/.test(value.trim());
        }

        return false;
    }

    toBigInt(value) {
        if (typeof value === 'bigint') {
            return value;
        }

        if (typeof value === 'number') {
            return BigInt(value);
        }

        return BigInt(value.trim());
    }

    getTypeReference(fullname) {
        //return `global::Baclib.Bacnet.Types.Application.${this.getTypeHierarchy(fullname).join('.')}`;
        return `T.${this.getTypeHierarchy(fullname).join('.')}`;
    }

    getTypeHierarchy(fullname) {
        return fullname.split('.').map((part, index) => (index ? 'T' : '') + this.toPascalCase(part));
    }

    toPascalCase(kebabCase) {
        return toPascalCase(kebabCase);
    }
}

/** Creates the enumerated codec generator. */
export function createEnumCodecGenerator() {
    return new EnumCodecTransformer();
}
