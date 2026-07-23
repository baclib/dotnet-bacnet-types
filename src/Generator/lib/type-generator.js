// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { readFileSync, writeFileSync } from 'fs';
import fs from 'fs/promises';
import path from 'path';
import Handlebars from 'handlebars';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { TemplateEngine } from './core/template-engine.js';
import { toPascalCase } from './core/text.js';
import { generatorRoot, templatesDir, typesOutputDir } from './core/paths.js';
import { fixedAliases, partials, pduTypes, refinedTypes } from './core/constants.js';
import { generateBitStringTypes } from './bit-string-types.js';

/**
 * CsharpTransformer - Generates C# code from BACnet type definitions using Handlebars templates.
 *
 * Templates live in templates/ and are rendered through the shared TemplateEngine. Type-specific
 * Handlebars helpers (type mapping, nesting, case conversion) are registered in registerHelpers.
 */
export class CsharpTransformer extends TemplateEngine {

    constructor() {
        super();
        this.fileName = null;
        this.definitions = [];
        this.directory = typesOutputDir;
        this.templatesDir = templatesDir;
        this.predefinedTypesDir = path.join(generatorRoot, '..', 'csharp');

        // Initialize template engine properties
        this.typeMapper = null;
        this.seriesItemClassNames = new Map();

        this.fileObjects = [];
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
        this.registerHelpers();
        this.registerPartials();
    }

    getFileObject(context) {
        const parts = context.fullname.split('.');
        const classHierarchy = parts.map((part, index) => {
            const fullName = parts.slice(0, index + 1).join('.');
            const defaultName = (index ? 'T' : '') + this.toPascalCase(part);
            return this.seriesItemClassNames.get(fullName) ?? defaultName;
        });
        const fileName = classHierarchy.join('.') + '.cs';
        const className = classHierarchy.pop();
        const typeData = {
            fullname: context.fullname,
            namespace: 'Baclib.Bacnet.Types.Application',
            fileName,
            bacnetName: context.thisAlias ?? context.thisName,
            className,
            classHierarchy,
            aliasBase: null,
            baseType: context.traits?.base ?? null,
            primitive: context.definition?.primitive ?? null,
            isAnonymous: !context.definition && Object.keys(context.traits).length !== 2,
            isChoice: context.traits?.base === 'choice',
            isEnumerated: context.traits?.base === 'enumerated',
            isSequence: context.traits?.base === 'sequence',
            isTopLevel: classHierarchy.length === 0
        };

        if (typeof context.definition?.type === 'string') {
            typeData.baseType = this.toPascalCase(context.definition.type);
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
        if (this.isSeries(context)) {
            const parts = context.fullname.split('.');
            const defaultClassName = (parts.length > 1 ? 'T' : '') + this.toPascalCase(parts.at(-1));
            const isAnonymousSeries = !context.definition && Object.keys(context.traits).length !== 2;
            if (isAnonymousSeries) {
                this.seriesItemClassNames.set(context.fullname, `${defaultClassName}Item`);
            }
        }
        context.userContext = [];
    }

    endTraits(context) {

        const fileObject = this.getFileObject(context);

        // Dedicated bit-string generator handles these types.
        if (context.traits?.base === 'bit-string') {
            return;
        }

        const isSeries = this.isSeries(context);
        if (isSeries) {
            if (fileObject.isAnonymous) {
                // Anonymous SEQUENCE OF element type becomes T<PropertyName>Item and is emitted as nested subtype.
                fileObject.fileName = [...fileObject.classHierarchy, fileObject.className].join('.') + '.cs';
            }
            else {
                // Do not generate dummy sequence-of wrapper types for nested non-anonymous series.
                if (!fileObject.isTopLevel) {
                    return;
                }

                const seriesObject = this.getFileObject(context);
                seriesObject.baseType = 'sequence-of';
                seriesObject.isSeries = true;
                seriesObject.hasSeriesSize = Number.isInteger(context.traits.series);
                seriesObject.seriesSize = seriesObject.hasSeriesSize ? context.traits.series : null;
                seriesObject.seriesType = this.mapToNative(this.toPascalCase(context.traits.base));
                this.fileObjects.push(seriesObject);

                // For top-level SEQUENCE OF with anonymous element definitions, emit nested TItem type.
                if (fileObject.isTopLevel) {
                    fileObject.fileName = fileObject.fileName.replace(/cs$/, 'TItem.cs');
                    fileObject.bacnetName = 'item';
                    fileObject.className = 'TItem';
                    fileObject.classHierarchy.push(seriesObject.className);
                    fileObject.seriesType = seriesObject.seriesType;
                }
            }

        }

        fileObject.items = context.userContext;

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
        if (base === 'bit-string') {
            // Bit-string item members are handled by lib/bit-string-types.js.
            return;
        }

        if (!['choice', 'enumerated', 'sequence'].includes(base)) {
            throw new Error('Unexpected item type in endItem');
        }
        const { type, ...itemData } = context.item;
        itemData.name = this.toPascalCase(context.item.name);
        if (type !== undefined) {
            if (base === 'enumerated') {
                throw new Error(`Type not allowed in ${base} item`);
            }

            let resolvedType;
            let isSeries = false;

            if (typeof type === 'string') {
                resolvedType = this.mapToNative(this.toPascalCase(type));
            }
            else {
                isSeries = Boolean(type.series);
                if (isSeries && typeof type.base === 'string' && partials.includes(type.base)) {
                    // Series of partial-base types are represented by generated nested series types:
                    // - non-anonymous: T<PropertyName>
                    // - anonymous inline element definition: T<PropertyName>Item
                    const keys = Object.keys(type);
                    const hasInlineDefinition = keys.some(k => !['base', 'series'].includes(k));
                    resolvedType = hasInlineDefinition
                        ? `T${itemData.name}Item`
                        : this.mapToNative(this.toPascalCase(type.base));
                }
                else if (typeof type.series === 'string') {
                    // Parser may encode the element type name in the series marker.
                    resolvedType = this.mapToNative(this.toPascalCase(type.series));
                }
                else if (typeof type.base === 'string' && !partials.includes(type.base)) {
                    // Referenced named type, e.g. { base: "property-value", series: true }
                    resolvedType = this.mapToNative(this.toPascalCase(type.base));
                }
                else {
                    // Anonymous inline type (non-series).
                    resolvedType = `T${itemData.name}`;
                }
            }

            itemData.type = resolvedType;
            itemData.array = isSeries;
            itemData.isSeries = isSeries;
            itemData.seriesType = isSeries ? resolvedType : null;
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
            const content = await this.render(templatePath, fileObject);
            if (content.trim() === '') {
                continue;
            }
            writeFileSync(path.join(this.directory, fileObject.fileName), content);
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
        Handlebars.registerHelper('eq', function (left, right) {
            return left === right;
        });
        Handlebars.registerHelper('isReferenceType', function (typeName) {
            const valueTypes = new Set([
                'bool', 'byte', 'sbyte', 'short', 'ushort',
                'int', 'uint', 'long', 'ulong', 'nint', 'nuint',
                'float', 'double', 'decimal', 'char'
            ]);

            if (typeof typeName !== 'string') {
                return true;
            }

            const trimmed = typeName.trim();

            // Nullable value types are represented as T? and can be null.
            if (trimmed.endsWith('?')) {
                return true;
            }

            return !valueTypes.has(trimmed);
        });
        Handlebars.registerHelper('ifString', function (value, options) {
            return value === 'string' ? options.fn(this) : options.inverse(this);
        });
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
     * Render a template with data
     * @param {string} templatePath - Path to the template file
     * @param {Object} data - Data to pass to the template
     * @returns {Promise<string>} Rendered template
     */
    async render(templatePath, data) {
        const parts = data.fullname.split('.');
        if (parts.length > 1 && pduTypes.includes(parts[0])) {
            return ''
        }

        // Nested SEQUENCE OF wrappers are legacy dummy types and should not be emitted.
        if (data.baseType === 'sequence-of' && !data.isTopLevel) {
            return '';
        }

        if (['pdu', 'confirmed-request-pdu', 'unconfirmed-request-pdu', 'simple-ack-pdu', 'complex-ack-pdu', 'segment-ack-pdu',
            'error-pdu', 'reject-pdu', 'abort-pdu'].includes(data.fullname)) {
            return '';
        }

        const globalAliasPath = path.join(path.dirname(templatePath), 'global-alias.hbs');
        if (fixedAliases.hasOwnProperty(data.fullname)) {
            data.aliasBase = fixedAliases[data.fullname];
            if (data.fullname.startsWith('enum')) {
                data.enumBase = data.aliasBase;
                templatePath = path.join(path.dirname(templatePath), 'enumerated-n.hbs');
            }
            else {
                templatePath = globalAliasPath;
            }
        }
        else if (refinedTypes.includes(data.fullname)) {
            templatePath = path.join(path.dirname(templatePath), 'predefined.hbs');
        }
        else if (pduTypes.includes(data.fullname)) {
            templatePath = path.join(path.dirname(templatePath), 'pdu.hbs');
        }
        else if (!partials.includes(data.baseType)) {
            if (data.baseType) {
                data.aliasBase = data.namespace + '.' + this.toPascalCase(data.baseType);
                templatePath = globalAliasPath;
            }
            else {
                throw new Error(`No base type for ${data.fullname}`);
            }
        }
        const template = await this.loadTemplate(templatePath);
        return this.normalizeLineEndings(template(data));
    }

    /**
     * Convert kebab-case to PascalCase
     */
    toPascalCase(kebabCase) {
        return toPascalCase(kebabCase);
    }
}

/**
 * Generates all BACnet application types (including bit-string structs) into the types output folder.
 */
export async function generateTypes() {
    const transformer = new CsharpTransformer();
    await traverseDefinitions(transformer);
    await generateBitStringTypes({
        outputDirectory: transformer.directory
    });
}
