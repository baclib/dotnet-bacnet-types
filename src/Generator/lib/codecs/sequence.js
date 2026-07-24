// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { CodecGeneratorBase, partials } from './base.js';

class SequenceCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super({
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
        if (context.traits?.base !== 'sequence') {
            return;
        }

        // A nested SEQUENCE used as a series (SEQUENCE OF) with an inline element definition
        // produces a dedicated element type named "T<field>Item". A top-level SEQUENCE OF produces
        // both a nested element type "<Type>.TItem" and a wrapper type "<Type>" that implements
        // ISequenceOf<TItem>.
        const isSeries = this.isSeries(context);
        const isTopLevel = !context.fullname.includes('.');

        // Resolve the element/own codec fullname. Top-level series elements are nested under the
        // wrapper as "<fullname>.item" (=> "<Type>.TItem"); nested series elements use the sibling
        // "<fullname>-item" naming (=> "T<field>Item").
        let elementFullname;
        if (isSeries) {
            elementFullname = isTopLevel ? `${context.fullname}.item` : `${context.fullname}-item`;
        }
        else {
            elementFullname = context.fullname;
        }

        if (this.matchesFilter(elementFullname)) {
            const hierarchy = this.getTypeHierarchy(elementFullname);
            const className = hierarchy.join('') + 'Codec';

            this.codecObjects.push({
                fullname: elementFullname,
                bacnetName: context.thisAlias ?? context.thisName,
                namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
                className,
                fileName: `${className}.cs`,
                typeRef: this.getTypeReference(elementFullname),
                aliasTypeRef: this.getTypeReference(elementFullname).replace("global::Baclib.Bacnet.Types.Application.", "T::"),
                items: context.userContext
            });
        }

        // A top-level SEQUENCE OF additionally needs a wrapper codec that reads/writes the element
        // codec repeatedly and constructs the ISequenceOf wrapper type.
        if (isSeries && isTopLevel && this.matchesFilter(context.fullname)) {
            const wrapperHierarchy = this.getTypeHierarchy(context.fullname);
            const wrapperClassName = wrapperHierarchy.join('') + 'Codec';
            const elementHierarchy = this.getTypeHierarchy(elementFullname);

            this.codecObjects.push({
                isSeriesWrapper: true,
                fullname: context.fullname,
                bacnetName: context.thisAlias ?? context.thisName,
                namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
                className: wrapperClassName,
                fileName: `${wrapperClassName}.cs`,
                typeRef: this.getTypeReference(context.fullname),
                aliasTypeRef: this.getTypeReference(context.fullname).replace("global::Baclib.Bacnet.Types.Application.", "T::"),
                elementCodecRef: elementHierarchy.join('') + 'Codec',
                elementTypeRef: this.getTypeReference(elementFullname)
            });
        }
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

        this.codecTypes = [];
        const templatePath = path.join(this.templatesDir, 'codec-sequence.hbs');
        const wrapperTemplatePath = path.join(this.templatesDir, 'codec-sequence-of-wrapper.hbs');
        for (const codecObject of this.codecObjects) {
            if (codecObject.isSeriesWrapper) {
                this.codecTypes.push({ codec: codecObject.className, type: codecObject.typeRef.replace("global::Baclib.Bacnet.Types.Application.", "") });
                const content = await this.render(wrapperTemplatePath, codecObject);
                writeFileSync(path.join(this.directory, codecObject.fileName), content);
                continue;
            }

            const items = codecObject.items.map(item => {
                const aliasTypeName = this.getItemTypeReference(item.sourceFullname).replace("global::Baclib.Bacnet.Types.Application.", "T::"); 
                const codecRef = this.getCodecReference(item.sourceFullname);
                const modifier = (item.optional ? 'Optional' : '') + (item.isSeries ? 'SequenceOf' : '');
                const parameters = 'ref reader' + (item.hasContextTag ? `, ${item.tagNumber}` : '');
                return {
                    ...item,
                    aliasTypeName,
                    codecRef,
                    modifier,
                    parameters
                };
            });

            const firstRequiredIndex = items.findIndex(item => !item.optional);
            const matchSourceItems = firstRequiredIndex === -1
                ? items
                : items.slice(0, firstRequiredIndex + 1);

            const matchItems = matchSourceItems.map(item => ({
                name: item.name,
                hasContextTagNumber: item.hasContextTag,
                contextTagNumber: item.tagNumber,
                codecRef: item.codecRef
            }));

            const lengthSumExpressions = items.map(item => item.lengthExpression);

            const content = await this.render(templatePath, {
                ...codecObject,
                items,
                matchItems,
                lengthSumExpressions
            });
            this.codecTypes.push({ codec: codecObject.className, type: codecObject.typeRef.replace("global::Baclib.Bacnet.Types.Application.", "") });
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
        this.codecTypes.sort((a, b) => a.codec.localeCompare(b.codec));
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
                // The inline element type of a SEQUENCE OF field is emitted as a sibling subtype
                // named "<field>-item" directly under the enclosing type, so append "-item" to the
                // field's own fullname rather than nesting it under the field segment.
                return {
                    sourceFullname: context.fullname.endsWith('-item')
                        ? context.fullname
                        : `${context.fullname}-item`,
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
}

/** Creates the SEQUENCE codec generator. */
export function createSequenceCodecGenerator() {
    return new SequenceCodecTransformer();
}
