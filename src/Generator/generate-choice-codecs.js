// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { fileURLToPath } from 'url';
import Handlebars from 'handlebars';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { CodecGeneratorBase } from './codec-generator-common.js';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

class ChoiceCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super(__dirname, {
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
        if (this.isSeries(context) || context.traits?.base !== 'choice') {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        const hierarchy = this.getTypeHierarchy(context.fullname);
        const typeName = hierarchy.join('.');
        const className = hierarchy.join('') + 'Codec';
        const fileName = `${className}.cs`;

        this.codecObjects.push({
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            namespace: 'Baclib.Bacnet.Serialization.Native.AsduCodecs',
            className,
            fileName,
            typeName,
            typeRef: this.getTypeReference(context.fullname),
            items: context.userContext
        });
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        const itemTypeFullname = typeof context.item.type === 'string'
            ? context.item.type
            : context.fullname;
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

        function getAppTagName(name) {
            const map = { 'bool': 'Boolean', 'uint': 'Unsigned', 'int': 'Signed', 'float': 'Real', 'double': 'Double',
                'Time': 'TimePattern', 'Date': 'DatePattern' };
            return map[name] ?? name;
        }



        const templatePath = path.join(this.templatesDir, 'codec-choice.hbs');
        for (const codecObject of this.codecObjects) {
            const resolvedItems = codecObject.items.map(item => ({
                ...item,
                typeName: this.getItemTypeReference(item.sourceFullname),
                appTagName: getAppTagName(this.getItemValueType(item.sourceFullname)),
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

const transformer = new ChoiceCodecTransformer();
await traverseDefinitions(transformer);