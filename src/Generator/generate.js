// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { existsSync, readFileSync, writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import { fileURLToPath } from 'url';
import Handlebars from 'handlebars';
import { stringify } from 'querystring';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const partials = Object.freeze([
    'number', 'unsigned', 'integer', 'real', 'double',
    'octet-string', 'character-string', 'bit-string', 'enumerated',
    'choice', 'sequence', 'sequence-of'
]);

/**
 * CsharpTransformer - Generates C# code from BACnet type definitions using Handlebars templates.
 * 
 * This transformer uses two main templates:
 * - basic-class.hbs: For simple type definitions (top-level classes)
 * - nested-class.hbs: For nested type hierarchies
 * 
 * Templates are located in templates/csharp/ and use the Handlebars template engine
 * with helpers registered in TemplateEngine (type mapping, case conversion, etc.)
 */
export class CsharpTransformer {

    constructor() {
        this.fileName = null;
        this.definitions = [];
        this.directory = path.join(__dirname, '..', 'Baclib.Bacnet.Types');
        this.templatesDir = path.join(__dirname, 'templates');

        this.predefinedTypesDir = path.join(__dirname, '..', 'csharp');

        // Initialize template engine properties
        this.typeMapper = null;
        this.templateCache = new Map();

        this.fileObjects = [];
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
        this.registerHelpers();
        this.registerPartials();
    }

    getFileObject(context) {
        const classHierarchy = context.fullname.split('.').map((part, index) => (index ? 'T' : '') + this.toPascalCase(part));
        const fileName = classHierarchy.join('.') + '.cs';
        const className = classHierarchy.pop();
        const typeData = {
            fileName,
            bacnetName: context.thisAlias ?? context.thisName,
            className,
            classHierarchy,
            baseType: context.traits?.base ?? null,
            primitive: context.definition?.primitive ?? null,
            isAnonymous: !context.definition && Object.keys(context.traits).length !== 2,
            isBitString: context.traits?.base === 'bit-string',
            isChoice: context.traits?.base === 'choice',
            isEnumerated: context.traits?.base === 'enumerated',
            isSequence: context.traits?.base === 'sequence'
        };

        if (typeof context.definition?.type === 'string') {
            typeData.baseType = this.toPascalCase(context.definition.type);
            //console.log('##################################\n', typeData, '\n##################################');
        }

        if (typeData.baseType === 'unsigned' && (Object.hasOwn(context.traits, 'minimum') && Object.hasOwn(context.traits, 'maximum'))) {
            typeData.minValue = context.traits?.minimum ?? 0;
            typeData.maxValue = context.traits?.maximum ?? 0xFFFFFFFF;
            if (typeData.maxValue < 256) {
                typeData.underlyingType = 'byte';
            } else if (typeData.maxValue < 65536) {
                typeData.underlyingType = 'ushort';
            } else if (typeData.maxValue < 4294967296) {
                typeData.underlyingType = 'uint';
            }
            else {
                typeData.underlyingType = 'ulong';
            }
        }

        if (typeData.baseType === 'integer' && (Object.hasOwn(context.traits, 'minimum') || Object.hasOwn(context.traits, 'maximum'))) {
            typeData.minValue = context.traits?.minimum ?? 0;
            typeData.maxValue = context.traits?.maximum ?? 2147483647;
            if (typeData.minValue >= -128 && typeData.maxValue <= 127) {
                typeData.underlyingType = 'sbyte';
            } else if (typeData.minValue >= -32768 && typeData.maxValue <= 32767) {
                typeData.underlyingType = 'short';
            }
            else if (typeData.minValue >= -2147483648 && typeData.maxValue <= 2147483647) {
                typeData.underlyingType = 'int';
            }
            else {
                typeData.underlyingType = 'long';
            }
        }

        if (typeData.baseType === 'real' && (Object.hasOwn(context.traits, 'minimum') || Object.hasOwn(context.traits, 'maximum'))) {
            typeData.minValue = (context.traits?.minimum ?? 0) + 'f';
            typeData.maxValue = (context.traits?.maximum ?? 4711) + 'f';
            typeData.underlyingType = 'float';
        }

        if ((typeData.baseType === 'octet-string' || typeData.baseType === 'character-string' || typeData.baseType === 'bit-string') && Object.hasOwn(context.traits, 'length')) {
            typeData.hasLengthRange = !Number.isInteger(context.traits.length);
            typeData.length = context.traits.length;
        }


        return typeData;
    }

    getHierarchy(context) {
        const hierarchy = context.fullname.split('.').map((part, index) => (index ? 'T' : '') + this.toPascalCase(part));
        return hierarchy;
    }

    isSeries(context) {
        return context.traits && Object.hasOwn(context.traits, 'series') && context.traits.series !== false;
    }

    mapToNative(className) {
        switch (className) {
            case 'Integer': return 'int';
            case 'Real': return 'float';
            case 'Double': return 'double';
            case 'String': return 'string';
            default: return className;
        }
    }

    startDefinition(context) {
        if (!context.traits) {
            const fileObject = this.getFileObject(context);
            const nativeName = this.mapToNative(fileObject.className);
            if (nativeName !== fileObject.className) {
                fileObject.nativeType = nativeName;
            }
            this.fileObjects.push(fileObject);
        }
    }

    endDefinition(context) {
    }

    startTraits(context) {
        context.userContext = [];
    }

    endTraits(context) {

        const fileObject = this.getFileObject(context);
        const isSeries = this.isSeries(context);
        if (isSeries) {
            // series of ...
            const seriesObject = this.getFileObject(context);
            seriesObject.baseType = 'sequence-of';
            seriesObject.isSeries = true;
            seriesObject.hasSeriesSize = Number.isInteger(context.traits.series);
            seriesObject.seriesSize = seriesObject.hasSeriesSize ? context.traits.series : null;
            seriesObject.seriesType = seriesObject.isAnonymous ? 'TItem' : this.toPascalCase(context.traits.base);
            this.fileObjects.push(seriesObject);
            if (!fileObject.isAnonymous) {
                return;
            }
            // refine fileObject for series item
            fileObject.fileName = fileObject.fileName.replace(/cs$/, 'TItem.cs');
            fileObject.bacnetName = '???';
            fileObject.className = 'TItem';
            fileObject.classHierarchy.push(seriesObject.className);
        }

        fileObject.items = context.userContext;

        if (fileObject.baseType === 'bit-string') {
            fileObject.hasRange = Object.hasOwn(context.traits, 'length');
            if (fileObject.hasRange) {
                fileObject.minimum = context.traits.length.minimum;
                fileObject.maximum = context.traits.length.maximum;
            }
            else {
                fileObject.length = Math.max(...fileObject.items.map(item => item.position)) + 1;
            }
            //console.log('Bit string', fileObject);
        }

        if (fileObject.baseType === 'enumerated') {
            const maximum = Number.isInteger(context.traits.maximum) ? context.traits.maximum : Math.max(...fileObject.items.map(item => item.constant));
            if (maximum < 256) {
                fileObject.enumBase = 'byte';
            } else if (maximum < 65536) {
                fileObject.enumBase = 'ushort';
            } else {
                fileObject.enumBase = 'uint';
            }
        }

        fileObject.flagBase = 'long';

        this.fileObjects.push(fileObject);
    }


    startItem(context) {
    }

    endItem(context) {
        const traits = context.ancestors.at(-1).traits;
        const base = traits.base;
        if (!['bit-string', 'choice', 'enumerated', 'sequence'].includes(base)) {
            throw new Error('Unexpected item type in endItem');
        }
        const { type, ...itemData } = context.item;
        itemData.name = this.toPascalCase(context.item.name);
        itemData.array = type?.series ?? false;
        if (type !== undefined) {
            if (['bit-string', 'enumerated'].includes(base)) {
                throw new Error(`Type not allowed in ${base} item`);
            }
            itemData.type = typeof type === 'string' ? this.mapToNative(this.toPascalCase(type)) : `T${itemData.name}`;
        }
        context.userContext.push(itemData);
    }

    async afterProcessing(result) {
        const existingFiles = await fs.readdir(this.directory);
        for (const file of existingFiles) {
            if (file.endsWith('.cs') && !file.endsWith('.manual.cs')) {
                await fs.unlink(path.join(this.directory, file));
            }
        }
        const templatePath = path.join(this.templatesDir, 'levels.hbs');
        for (const fileObject of this.fileObjects) {

            // skip bit-string for the moment, as they require special handling and we want to focus on the other types first
            if (fileObject.className.startsWith('BitString') || fileObject.className === 'WeekNDay') {
                console.warn('Skipping bit string', fileObject.className);
                continue;
            }

            //console.log('Processing', fileObject.fileName);
            this.render(templatePath, fileObject).then(content => {
                writeFileSync(path.join(this.directory, fileObject.fileName), content);
            });
        }
    }

    /**
     * Get the content of a template file
     */
    getTemplateContent(templateName) {
        const templatePath = path.join(this.templatesDir, `${templateName}.hbs`);
        return readFileSync(templatePath, 'utf-8');
    }

    /**
     * Register Handlebars helpers
     */
    registerHelpers() {
        Handlebars.registerHelper('nest', function (data, options) {
            const content = options.fn(this);
            if (data.classHierarchy.length === 0) {
                return content;
            }
            let start = ''
            let end = ''
            data.classHierarchy.forEach((className, index) => {
                const indention = ' '.repeat(index * 4);
                start += `${indention}public partial record class ${className}\n${indention}{\n`;
                end = `${indention}}\n` + end;
            });
            const indentation = ' '.repeat(data.classHierarchy.length * 4);
            const indentedContent = start + indentation + content.replace(/\n/g, '\n' + indentation).trim() + '\n' + end;
            return new Handlebars.SafeString(indentedContent);
        });
        Handlebars.registerHelper('apply', function (data) {
            const base = data.baseType;
            if (partials.includes(base)) {
                return base;
            }
            console.error(`Unknown base type: ${base} for ${data.thisName}`);
            return 'global-alias';

        });
    }

    /**
     * Register Handlebars partials
     */
    registerPartials() {
        for (const name of partials) {
            Handlebars.registerPartial(name, this.getTemplateContent(name));
        }
    }

    /**
     * Load a template file
     * @param {string} templatePath - Path to the template file
     * @returns {Promise<Function>} Compiled template function
     */
    async loadTemplate(templatePath) {
        if (this.templateCache.has(templatePath)) {
            return this.templateCache.get(templatePath);
        }
        const templateContent = await fs.readFile(templatePath, 'utf-8');
        const compiledTemplate = Handlebars.compile(templateContent);
        this.templateCache.set(templatePath, compiledTemplate);
        return compiledTemplate;
    }

    /**
     * Render a template with data
     * @param {string} templatePath - Path to the template file
     * @param {Object} data - Data to pass to the template
     * @returns {Promise<string>} Rendered template
     */
    async render(templatePath, data) {
        if (!partials.includes(data.baseType)) {
            switch (data.className) {
                case 'Any':
                    data.baseType = 'object';
                    break;
                case 'BitString':
                    data.baseType = 'object';
                    break;
                case 'Boolean':
                    data.baseType = 'bool';
                    break;
                case 'CharacterString':
                    data.baseType = 'object';
                    break;
                case 'Choice':
                    data.baseType = 'object';
                    break;
                case 'CreateObjectAck':
                    data.baseType = 'Baclib.Bacnet.Types.ObjectIdentifier';
                    break;
                case 'DatePattern':
                    data.baseType = 'object';
                    break;
                case 'Date':
                    data.baseType = 'Baclib.Bacnet.Types.DatePattern';
                    break;
                case 'Double':
                    data.baseType = 'double';
                    break;
                case 'Enumerated':
                    data.baseType = 'object';
                    break;
                case 'Integer':
                    data.baseType = 'int';
                    break;
                case 'Null':
                    data.baseType = 'object';
                    break;
                case 'ObjectIdentifier':
                    data.baseType = 'object';
                    break;
                case 'OctetString':
                    data.baseType = 'object';
                    break;
                case 'Real':
                    data.baseType = 'float';
                    break;
                case 'Sequence':
                    data.baseType = 'object';
                    break;
                case 'String':
                    data.baseType = 'string';
                    break;
                case 'TimePattern':
                    data.baseType = 'object';
                    break;
                case 'Time':
                    data.baseType = 'Baclib.Bacnet.Types.TimePattern';
                    break;
                case 'Unsigned':
                    data.baseType = 'uint';
                    break;
            }
            //console.warn(`${data.className.padEnd(16)} : ${stringify(data)}`);
            templatePath = path.join(path.dirname(templatePath), 'global-alias.hbs');
        }
        const template = await this.loadTemplate(templatePath);
        return template(data);
    }

    /**
     * Convert kebab-case to PascalCase (from BaseTransformer)
     */
    toPascalCase(kebabCase) {
        return kebabCase
            .split('-')
            .map(part => part.charAt(0).toUpperCase() + part.slice(1))
            .join('');
    }
}

// Traverse all definitions using the markdown transformer
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';

const transformer = new CsharpTransformer();
await traverseDefinitions(transformer);
