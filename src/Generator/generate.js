// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { existsSync, readFileSync, writeFileSync } from 'fs';
import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import { fileURLToPath } from 'url';
import Handlebars from 'handlebars';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const partials = Object.freeze([
    'number', 'unsigned', 'integer', 'real', 'double',
    'octet-string', 'character-string', 'bit-string', 'enumerated',
    'choice', 'sequence', 'sequence-of'
]);


const pduTypes = Object.freeze([
    'confirmed-request-pdu',
    'unconfirmed-request-pdu',
    'simple-ack-pdu',
    'complex-ack-pdu',
    'segment-ack-pdu',
    'error-pdu',
    'reject-pdu',
    'abort-pdu'
]);

const refinedTypes = Object.freeze([
    'any', 'choice', 'sequence', 'sequence-of',
    'null',
    'octet-string', 'character-string', 'bit-string', 'bit-string-8', 'bit-string-16', 'bit-string-32', 'bit-string-64',
    'date-pattern', 'time-pattern',
    'object-identifier',
    'week-n-day'
]);

const fixedAliases = Object.freeze({
    'boolean': 'bool',
    'unsigned': 'uint',
    'unsigned-8': 'byte',
    'unsigned-16': 'ushort',
    'unsigned-32': 'uint',
    'unsigned-64': 'ulong',
    'integer': 'int',
    'integer-8': 'sbyte',
    'integer-16': 'short',
    'integer-32': 'int',
    'integer-64': 'long',
    'real': 'float',
    'double': 'double',
    'string': 'string',
    'enumerated': 'uint',
    'enumerated-8': 'byte',
    'enumerated-16': 'ushort',
    'enumerated-32': 'uint',
    'enumerated-64': 'ulong',
    'enumeration': 'uint'
});

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
            isBitString: context.traits?.base === 'bit-string',
            isChoice: context.traits?.base === 'choice',
            isEnumerated: context.traits?.base === 'enumerated',
            isSequence: context.traits?.base === 'sequence'
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
            this.render(templatePath, fileObject).then(content => {
                if (content.trim() === '') {
                    console.warn(`Generated empty content for ${fileObject.fullname}, skipping file creation.`);
                    return;
                }
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
        Handlebars.registerHelper('eq', function (left, right) {
            return left === right;
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


        const parts = data.fullname.split('.');
        if (parts.length > 1 && pduTypes.includes(parts[0])) {
            return ''
        }


        const globalAliasPath = path.join(path.dirname(templatePath), 'global-alias.hbs');
        if (fixedAliases.hasOwnProperty(data.fullname)) {
            data.aliasBase = fixedAliases[data.fullname];
            if (data.fullname.startsWith('enum')) {
                data.enumBase = data.aliasBase;
                templatePath = path.join(path.dirname(templatePath), 'enumerated-n.hbs');
                console.log(JSON.stringify(data, null, 2));
            }
            else {
                templatePath = globalAliasPath;
            }
        }
        else if (refinedTypes.includes(data.fullname)) {
            templatePath = path.join(path.dirname(templatePath), 'predefined.hbs');
        }
        else if (pduTypes.includes(data.fullname)) {
            //console.log(`PDU type: ${JSON.stringify(data, null, 2)}`);
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
     * Normalize generated text to the current OS line ending.
     */
    normalizeLineEndings(content) {
        return content.replace(/\r\n|\n|\r/g, EOL);
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

/**
 * Static codec specifications for all primitive BACnet types.
 * Each entry maps a type fullname to the parameters needed to render its codec template.
 */
const codecSpecs = new Map([
    ['boolean', {
        template: 'codec-boolean',
        className: 'Boolean',
        csharpType: 'bool',
        tagName: 'Boolean',
        lengthConst: 'Boolean',
    }],
    ['null', {
        template: 'codec-null',
        className: 'Null',
        csharpType: 'Null',
        tagName: 'Null',
        lengthConst: 'Null',
    }],
    ['real', {
        template: 'codec-fixed-numeric',
        className: 'Real',
        csharpType: 'float',
        tagName: 'Real',
        lengthConst: 'Real',
        writeMethod: 'WriteReal',
        readMethod: 'ReadReal',
    }],
    ['double', {
        template: 'codec-fixed-numeric',
        className: 'Double',
        csharpType: 'double',
        tagName: 'Double',
        lengthConst: 'Double',
        writeMethod: 'WriteDouble',
        readMethod: 'ReadDouble',
    }],
    ['unsigned-8', {
        template: 'codec-fixed-byte',
        className: 'Unsigned8',
        csharpType: 'byte',
        tagName: 'Unsigned',
        lengthConst: 'Unsigned8',
        fromLengthMethod: 'FromUnsigned8',
        writeMethod: 'WriteUnsigned8',
        readMethod: 'ReadUnsigned8',
    }],
    ['unsigned-16', {
        template: 'codec-variable-2',
        className: 'Unsigned16',
        csharpType: 'ushort',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned16',
        levels: [
            { lengthConst: 'Unsigned8', writeMethod: 'WriteUnsigned8', cast: '(byte)', readMethod: 'ReadUnsigned8' },
            { lengthConst: 'Unsigned16', writeMethod: 'WriteUnsigned16', cast: '', readMethod: 'ReadUnsigned16' },
        ],
    }],
    ['unsigned-32', {
        template: 'codec-variable-n',
        className: 'Unsigned32',
        csharpType: 'uint',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned32',
        errorMsg: 'Invalid length for unsigned 32-bit integer.',
        levels: [
            { lengthConst: 'Unsigned8',  writeMethod: 'WriteUnsigned8',  cast: '(byte)',   readMethod: 'ReadUnsigned8' },
            { lengthConst: 'Unsigned16', writeMethod: 'WriteUnsigned16', cast: '(ushort)', readMethod: 'ReadUnsigned16' },
            { lengthConst: 'Unsigned24', writeMethod: 'WriteUnsigned24', cast: '',         readMethod: 'ReadUnsigned24' },
            { lengthConst: 'Unsigned32', writeMethod: 'WriteUnsigned32', cast: '',         readMethod: 'ReadUnsigned32' },
        ],
    }],
    ['unsigned-64', {
        template: 'codec-variable-n',
        className: 'Unsigned64',
        csharpType: 'ulong',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned64',
        errorMsg: 'Invalid length for unsigned 64-bit integer.',
        levels: [
            { lengthConst: 'Unsigned8',  writeMethod: 'WriteUnsigned8',  cast: '(byte)',   readMethod: 'ReadUnsigned8' },
            { lengthConst: 'Unsigned16', writeMethod: 'WriteUnsigned16', cast: '(ushort)', readMethod: 'ReadUnsigned16' },
            { lengthConst: 'Unsigned24', writeMethod: 'WriteUnsigned24', cast: '(uint)',   readMethod: 'ReadUnsigned24' },
            { lengthConst: 'Unsigned32', writeMethod: 'WriteUnsigned32', cast: '(uint)',   readMethod: 'ReadUnsigned32' },
            { lengthConst: 'Unsigned40', writeMethod: 'WriteUnsigned40', cast: '',         readMethod: 'ReadUnsigned40' },
            { lengthConst: 'Unsigned48', writeMethod: 'WriteUnsigned48', cast: '',         readMethod: 'ReadUnsigned48' },
            { lengthConst: 'Unsigned56', writeMethod: 'WriteUnsigned56', cast: '',         readMethod: 'ReadUnsigned56' },
            { lengthConst: 'Unsigned64', writeMethod: 'WriteUnsigned64', cast: '',         readMethod: 'ReadUnsigned64' },
        ],
    }],
    ['integer-8', {
        template: 'codec-fixed-byte',
        className: 'Integer8',
        csharpType: 'sbyte',
        tagName: 'Signed',
        lengthConst: 'Signed8',
        fromLengthMethod: 'FromInteger8',
        writeMethod: 'WriteInteger8',
        readMethod: 'ReadSigned8',
    }],
    ['integer-16', {
        template: 'codec-variable-2',
        className: 'Integer16',
        csharpType: 'short',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger16',
        levels: [
            { lengthConst: 'Signed8',  writeMethod: 'WriteInteger8',  cast: '(sbyte)', readMethod: 'ReadSigned8' },
            { lengthConst: 'Signed16', writeMethod: 'WriteInteger16', cast: '',        readMethod: 'ReadSigned16' },
        ],
    }],
    ['integer-32', {
        template: 'codec-variable-n',
        className: 'Integer32',
        csharpType: 'int',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger32',
        errorMsg: 'Invalid length for signed 32-bit integer.',
        levels: [
            { lengthConst: 'Signed8',  writeMethod: 'WriteInteger8',  cast: '(sbyte)', readMethod: 'ReadSigned8' },
            { lengthConst: 'Signed16', writeMethod: 'WriteInteger16', cast: '(short)', readMethod: 'ReadSigned16' },
            { lengthConst: 'Signed24', writeMethod: 'WriteInteger24', cast: '',        readMethod: 'ReadSigned24' },
            { lengthConst: 'Signed32', writeMethod: 'WriteInteger32', cast: '',        readMethod: 'ReadSigned32' },
        ],
    }],
    ['integer-64', {
        template: 'codec-variable-n',
        className: 'Integer64',
        csharpType: 'long',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger64',
        errorMsg: 'Invalid length for signed 64-bit integer.',
        levels: [
            { lengthConst: 'Signed8',  writeMethod: 'WriteInteger8',  cast: '(sbyte)', readMethod: 'ReadSigned8' },
            { lengthConst: 'Signed16', writeMethod: 'WriteInteger16', cast: '(short)', readMethod: 'ReadSigned16' },
            { lengthConst: 'Signed24', writeMethod: 'WriteInteger24', cast: '(int)',   readMethod: 'ReadSigned24' },
            { lengthConst: 'Signed32', writeMethod: 'WriteInteger32', cast: '(int)',   readMethod: 'ReadSigned32' },
            { lengthConst: 'Signed40', writeMethod: 'WriteInteger40', cast: '',        readMethod: 'ReadSigned40' },
            { lengthConst: 'Signed48', writeMethod: 'WriteInteger48', cast: '',        readMethod: 'ReadSigned48' },
            { lengthConst: 'Signed56', writeMethod: 'WriteInteger56', cast: '',        readMethod: 'ReadSigned56' },
            { lengthConst: 'Signed64', writeMethod: 'WriteInteger64', cast: '',        readMethod: 'ReadSigned64' },
        ],
    }],
    ['bit-string-8', {
        template: 'codec-bit-string',
        className: 'BitString8',
        csharpType: 'BitString8',
        tagName: 'BitString',
        lengthConst: 'BitString8',
        bits: 8,
        readFlagsMethod: 'ReadBitFlags8',
        writeFlagsMethod: 'WriteBitStringFromFlags8',
    }],
    ['bit-string-16', {
        template: 'codec-bit-string',
        className: 'BitString16',
        csharpType: 'BitString16',
        tagName: 'BitString',
        lengthConst: 'BitString16',
        bits: 16,
        readFlagsMethod: 'ReadBitFlags16',
        writeFlagsMethod: 'WriteBitStringFromFlags16',
    }],
    ['bit-string-32', {
        template: 'codec-bit-string',
        className: 'BitString32',
        csharpType: 'BitString32',
        tagName: 'BitString',
        lengthConst: 'BitString32',
        bits: 32,
        readFlagsMethod: 'ReadBitFlags32',
        writeFlagsMethod: 'WriteBitStringFromFlags32',
    }],
    ['bit-string-64', {
        template: 'codec-bit-string',
        className: 'BitString64',
        csharpType: 'BitString64',
        tagName: 'BitString',
        lengthConst: 'BitString64',
        bits: 64,
        readFlagsMethod: 'ReadBitFlags64',
        writeFlagsMethod: 'WriteBitStringFromFlags64',
    }],
    ['octet-string', {
        template: 'codec-octet-string',
        className: 'OctetString',
        csharpType: 'OctetString',
        tagName: 'OctetString',
    }],
    ['character-string', {
        template: 'codec-character-string',
        className: 'CharacterString',
        csharpType: 'CharacterString',
        tagName: 'CharacterString',
    }],
    ['object-identifier', {
        template: 'codec-fixed-tagged',
        className: 'ObjectIdentifier',
        csharpType: 'ObjectIdentifier',
        tagName: 'ObjectIdentifier',
        lengthConst: 'ObjectIdentifier',
        writeMethod: 'WriteObjectIdentifier',
        readMethod: 'ReadObjectIdentifier',
    }],
    ['date-pattern', {
        template: 'codec-fixed-tagged',
        className: 'DatePattern',
        csharpType: 'DatePattern',
        tagName: 'Date',
        lengthConst: 'Date',
        writeMethod: 'WriteDate',
        readMethod: 'ReadDatePattern',
    }],
    ['time-pattern', {
        template: 'codec-fixed-tagged',
        className: 'TimePattern',
        csharpType: 'TimePattern',
        tagName: 'Time',
        lengthConst: 'Time',
        writeMethod: 'WriteTime',
        readMethod: 'ReadTimePattern',
    }],
]);

/**
 * Asn1CodecTransformer - Generates ASN.1 codec classes for BACnet types by iterating
 * type definitions and rendering Handlebars templates from templates/codecs/.
 */
export class Asn1CodecTransformer {

    constructor() {
        this.directory = path.join(__dirname, '..', 'Baclib.Bacnet.Serialization.Asn1', 'Codecs');
        this.templatesDir = path.join(__dirname, 'templates', 'codecs');
        this.templateCache = new Map();
        this.codecObjects = [];
        this.processed = new Set();
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    /**
     * Called for top-level type definitions that have no explicit traits (simple aliases, primitives).
     */
    startDefinition(context) {
        if (!context.traits) {
            this.processType(context.fullname);
        }
    }

    endDefinition(context) {}

    startTraits(context) {}

    /**
     * Called after all traits for a type have been processed.
     * Covers types with explicit trait blocks (ranged types, sequences, etc.).
     */
    endTraits(context) {
        this.processType(context.fullname);
    }

    startItem(context) {}

    endItem(context) {}

    /**
     * Checks whether this type has a known codec spec and queues it for generation.
     */
    processType(fullname) {
        if (this.processed.has(fullname)) return;
        const spec = codecSpecs.get(fullname);
        if (spec) {
            this.processed.add(fullname);
            this.codecObjects.push({ ...spec });
        }
    }

    async afterProcessing(result) {
        // Only overwrite files that will be (re)generated; leave others untouched.
        const generatedFileNames = new Set(this.codecObjects.map(o => `${o.className}Asn1Codec.cs`));
        const existingFiles = await fs.readdir(this.directory);
        for (const file of existingFiles) {
            if (generatedFileNames.has(file)) {
                await fs.unlink(path.join(this.directory, file));
            }
        }
        for (const codecObject of this.codecObjects) {
            const templatePath = path.join(this.templatesDir, `${codecObject.template}.hbs`);
            const content = await this.render(templatePath, codecObject);
            writeFileSync(path.join(this.directory, `${codecObject.className}Asn1Codec.cs`), content);
        }
    }

    async loadTemplate(templatePath) {
        if (this.templateCache.has(templatePath)) {
            return this.templateCache.get(templatePath);
        }
        const templateContent = await fs.readFile(templatePath, 'utf-8');
        const compiled = Handlebars.compile(templateContent, { noEscape: true });
        this.templateCache.set(templatePath, compiled);
        return compiled;
    }

    async render(templatePath, data) {
        const template = await this.loadTemplate(templatePath);
        return this.normalizeLineEndings(template(data));
    }

    normalizeLineEndings(content) {
        return content.replace(/\r\n|\n|\r/g, EOL);
    }
}

const codecTransformer = new Asn1CodecTransformer();
await traverseDefinitions(codecTransformer);
