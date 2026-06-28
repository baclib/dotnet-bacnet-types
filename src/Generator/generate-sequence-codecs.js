// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { fileURLToPath } from 'url';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { CodecGeneratorBase, partials } from './codec-generator-common.js';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

class SequenceCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super(__dirname, {
            filterEnvName: 'SEQUENCE_CODEC_FILTER',
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
        if (this.isSeries(context) || context.traits?.base !== 'sequence') {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        const hierarchy = this.getTypeHierarchy(context.fullname);
        const className = hierarchy.join('') + 'Codec';
        const fileName = `${className}.cs`;

        this.codecObjects.push({
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className,
            fileName,
            typeRef: this.getTypeReference(context.fullname),
            items: context.userContext
        });
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        if (parent?.traits?.base !== 'sequence') {
            return;
        }

        const itemName = this.toPascalCase(context.item.name);
        const typeInfo = this.resolveSourceType(context);

        parent.userContext.push({
            name: itemName,
            variableName: this.toCamelCase(itemName),
            hasContextTag: Object.hasOwn(context.item, 'context'),
            tagNumber: Object.hasOwn(context.item, 'context') ? context.item.context : null,
            optional: Boolean(context.item.optional),
            isSeries: Boolean(typeInfo.isSeries),
            sourceFullname: typeInfo.sourceFullname
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

        const templatePath = path.join(this.templatesDir, 'codec-sequence.hbs');
        for (const codecObject of this.codecObjects) {
            const items = codecObject.items.map(item => {
                const typeName = this.getItemTypeReference(item.sourceFullname);
                const kind = this.resolveKind(item.sourceFullname);
                const codecRef = this.getCodecReference(item.sourceFullname);
                const encodeBody = this.buildEncodeBody(item, codecRef, typeName, kind);

                return {
                    ...item,
                    typeName,
                    kind,
                    codecRef,
                    decodeExpression: this.buildDecodeExpression(item, codecRef, typeName, kind),
                    encodeBody: this.indentBlock(encodeBody, 8),
                    lengthExpression: this.buildLengthExpression(item, codecRef, typeName, kind),
                    matchExpression: this.buildMatchExpression(item, codecRef, kind)
                };
            });

            const firstRequiredItem = items.find(item => !item.optional) ?? null;
            const lengthSumExpression = items.length
                ? items.map(item => item.lengthExpression).join(' + ')
                : '0';

            const content = await this.render(templatePath, {
                ...codecObject,
                items,
                firstRequiredItem,
                hasFirstRequiredItem: firstRequiredItem !== null,
                lengthSumExpression
            });
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
    }

    resolveSourceType(context) {
        const type = context.item.type;

        if (typeof type === 'string') {
            return {
                sourceFullname: type,
                isSeries: false
            };
        }

        if (!type || typeof type !== 'object') {
            return {
                sourceFullname: context.fullname,
                isSeries: false
            };
        }

        const isSeries = Boolean(type.series);
        const keys = Object.keys(type);
        const hasInlineDefinition = keys.some(key => !['base', 'series'].includes(key));

        if (isSeries && hasInlineDefinition) {
            const itemName = context.item?.name;
            if (typeof itemName === 'string') {
                const itemSuffix = `${itemName}-item`;
                const itemTypeCandidate = context.fullname.endsWith(`.${itemSuffix}`)
                    ? context.fullname
                    : `${context.fullname}.${itemSuffix}`;
                return {
                    sourceFullname: itemTypeCandidate,
                    isSeries
                };
            }
        }

        if (typeof type.series === 'string') {
            return {
                sourceFullname: type.series,
                isSeries
            };
        }

        if (typeof type.base === 'string') {
            if (partials.includes(type.base) && hasInlineDefinition) {
                return {
                    sourceFullname: context.fullname,
                    isSeries
                };
            }

            return {
                sourceFullname: type.base,
                isSeries
            };
        }

        return {
            sourceFullname: context.fullname,
            isSeries
        };
    }

    buildDecodeExpression(item, codecRef, typeName, kind) {
        if (item.isSeries) {
            if (item.optional) {
                if (item.hasContextTag) {
                    return `reader.PeekOpeningTag(${item.tagNumber}) ? Asdu.DecodeSequenceOf<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber}) : Optional<SequenceOf<${typeName}>>.None`;
                }

                return `reader.End ? Optional<SequenceOf<${typeName}>>.None : Asdu.DecodeSequenceOf<${codecRef}, ${typeName}>(ref reader)`;
            }

            if (item.hasContextTag) {
                return `Asdu.DecodeSequenceOf<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber})`;
            }

            return `Asdu.DecodeSequenceOf<${codecRef}, ${typeName}>(ref reader)`;
        }

        if (kind === 'primitive') {
            if (item.optional) {
                if (item.hasContextTag) {
                    return `Asdu.DecodeOptional<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber})`;
                }
                return `Asdu.DecodeOptional<${codecRef}, ${typeName}>(ref reader)`;
            }

            if (item.hasContextTag) {
                return `Asdu.DecodePrimitive<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber})`;
            }
            return `Asdu.DecodePrimitive<${codecRef}, ${typeName}>(ref reader)`;
        }

        if (item.optional) {
            if (item.hasContextTag) {
                return `Asdu.DecodeOptionalElement<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber})`;
            }
            return `Asdu.DecodeOptionalElement<${codecRef}, ${typeName}>(ref reader)`;
        }

        if (item.hasContextTag) {
            return `Asdu.DecodeConstructed<${codecRef}, ${typeName}>(ref reader, ${item.tagNumber})`;
        }
        return `Asdu.DecodeElement<${codecRef}, ${typeName}>(ref reader)`;
    }

    buildEncodeBody(item, codecRef, typeName, kind) {
        if (item.isSeries) {
            const source = item.optional ? `value.${item.name}.Value` : `value.${item.name}`;
            const encodeItem = item.hasContextTag
                ? `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, ${item.tagNumber}, item);`
                : `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, item);`;

            if (item.hasContextTag) {
                const body = [
                    `writer.WriteOpeningTag(${item.tagNumber});`,
                    `foreach (var item in ${source})`,
                    '{',
                    `    ${encodeItem}`,
                    '}',
                    `writer.WriteClosingTag(${item.tagNumber});`
                ];

                if (item.optional) {
                    return [
                        `if (value.${item.name}.HasValue)`,
                        '{',
                        ...body.map(line => `    ${line}`),
                        '}'
                    ].join('\n');
                }

                return body.join('\n');
            }

            const body = [
                `foreach (var item in ${source})`,
                '{',
                `    ${encodeItem}`,
                '}'
            ];

            if (item.optional) {
                return [
                    `if (value.${item.name}.HasValue)`,
                    '{',
                    ...body.map(line => `    ${line}`),
                    '}'
                ].join('\n');
            }

            return body.join('\n');
        }

        if (item.optional) {
            const encodeCall = kind === 'primitive'
                ? (item.hasContextTag
                    ? `Asdu.EncodePrimitive<${codecRef}, ${typeName}>(ref writer, ${item.tagNumber}, value.${item.name}.Value);`
                    : `Asdu.EncodePrimitive<${codecRef}, ${typeName}>(ref writer, value.${item.name}.Value);`)
                : (item.hasContextTag
                    ? `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, ${item.tagNumber}, value.${item.name}.Value);`
                    : `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, value.${item.name}.Value);`);

            return [
                `if (value.${item.name}.HasValue)`,
                '{',
                `    ${encodeCall}`,
                '}'
            ].join('\n');
        }

        if (kind === 'primitive') {
            if (item.hasContextTag) {
                return `Asdu.EncodePrimitive<${codecRef}, ${typeName}>(ref writer, ${item.tagNumber}, value.${item.name});`;
            }
            return `Asdu.EncodePrimitive<${codecRef}, ${typeName}>(ref writer, value.${item.name});`;
        }

        if (item.hasContextTag) {
            return `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, ${item.tagNumber}, value.${item.name});`;
        }
        return `Asdu.EncodeElement<${codecRef}, ${typeName}>(ref writer, value.${item.name});`;
    }

    buildLengthExpression(item, codecRef, typeName, kind) {
        if (item.isSeries) {
            const valueExpr = item.optional ? `value.${item.name}.Value` : `value.${item.name}`;
            const itemLengthExpr = item.hasContextTag
                ? `Asdu.GetElementLength<${codecRef}, ${typeName}>(${item.tagNumber}, item)`
                : `Asdu.GetElementLength<${codecRef}, ${typeName}>(item)`;

            let sumExpr = `(${valueExpr}.Items.Sum(static item => ${itemLengthExpr}))`;
            if (item.hasContextTag) {
                sumExpr = `(AsduLength.FromTagNumber((byte)${item.tagNumber}) + ${sumExpr} + AsduLength.FromTagNumber((byte)${item.tagNumber}))`;
            }

            if (item.optional) {
                return `(value.${item.name}.HasValue ? ${sumExpr} : 0)`;
            }
            return sumExpr;
        }

        if (item.optional) {
            if (kind === 'primitive') {
                if (item.hasContextTag) {
                    return `(value.${item.name}.HasValue ? Asdu.GetPrimitiveLength<${codecRef}, ${typeName}>(${item.tagNumber}, value.${item.name}.Value) : 0)`;
                }
                return `(value.${item.name}.HasValue ? Asdu.GetEncodedLength<${codecRef}, ${typeName}>(value.${item.name}.Value) : 0)`;
            }

            if (item.hasContextTag) {
                return `(value.${item.name}.HasValue ? Asdu.GetElementLength<${codecRef}, ${typeName}>(${item.tagNumber}, value.${item.name}.Value) : 0)`;
            }
            return `(value.${item.name}.HasValue ? Asdu.GetElementLength<${codecRef}, ${typeName}>(value.${item.name}.Value) : 0)`;
        }

        if (kind === 'primitive') {
            if (item.hasContextTag) {
                return `Asdu.GetPrimitiveLength<${codecRef}, ${typeName}>(${item.tagNumber}, value.${item.name})`;
            }
            return `Asdu.GetEncodedLength<${codecRef}, ${typeName}>(value.${item.name})`;
        }

        if (item.hasContextTag) {
            return `Asdu.GetElementLength<${codecRef}, ${typeName}>(${item.tagNumber}, value.${item.name})`;
        }
        return `Asdu.GetElementLength<${codecRef}, ${typeName}>(value.${item.name})`;
    }

    indentBlock(block, spaces) {
        const prefix = ' '.repeat(spaces);
        return block
            .split('\n')
            .map(line => `${prefix}${line}`)
            .join('\n');
    }

    buildMatchExpression(item, codecRef, kind) {
        if (item.hasContextTag) {
            if (item.isSeries) {
                return `reader.PeekOpeningTag(${item.tagNumber})`;
            }
            if (kind === 'primitive') {
                return `reader.PeekTag((byte)${item.tagNumber})`;
            }
            return `reader.PeekOpeningTag((byte)${item.tagNumber})`;
        }

        if (kind === 'primitive') {
            return `reader.PeekTag(${codecRef}.TagNumber)`;
        }

        return `${codecRef}.Matches(ref reader)`;
    }

}

const transformer = new SequenceCodecTransformer();
await traverseDefinitions(transformer);
