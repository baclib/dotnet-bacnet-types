// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import Handlebars from 'handlebars';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { templatesDir } from './core/paths.js';
import {
    BitStringCategory,
    describeBitString,
    isBitStringSeries,
    isPrimitiveBitString
} from './core/bit-string-model.js';

/** Per-storage-type literals used by the scalar constructor/indexer/helper templates. */
const scalarLiteralTable = new Map([
    ['byte', { maxBits: 8, oneLiteral: '1', maskCast: '(byte)', indexShiftLiteral: '1' }],
    ['ushort', { maxBits: 16, oneLiteral: '1u', maskCast: '(ushort)', indexShiftLiteral: '1' }],
    ['uint', { maxBits: 32, oneLiteral: '1u', maskCast: '', indexShiftLiteral: '1u' }],
    ['ulong', { maxBits: 64, oneLiteral: '1ul', maskCast: '', indexShiftLiteral: '1ul' }]
]);

const csharpKeywords = new Set([
    'abstract', 'as', 'base', 'bool', 'break', 'byte', 'case', 'catch', 'char', 'checked', 'class',
    'const', 'continue', 'decimal', 'default', 'delegate', 'do', 'double', 'else', 'enum', 'event',
    'explicit', 'extern', 'false', 'finally', 'fixed', 'float', 'for', 'foreach', 'goto', 'if',
    'implicit', 'in', 'int', 'interface', 'internal', 'is', 'lock', 'long', 'namespace', 'new',
    'null', 'object', 'operator', 'out', 'override', 'params', 'private', 'protected', 'public',
    'readonly', 'ref', 'return', 'sbyte', 'sealed', 'short', 'sizeof', 'stackalloc', 'static',
    'string', 'struct', 'switch', 'this', 'throw', 'true', 'try', 'typeof', 'uint', 'ulong',
    'unchecked', 'unsafe', 'ushort', 'using', 'virtual', 'void', 'volatile', 'while'
]);

class BitStringTypeGenerator {
    constructor(options = {}) {
        if (!options.outputDirectory) {
            throw new Error('BitStringTypeGenerator requires an outputDirectory.');
        }

        this.outputDirectory = path.resolve(options.outputDirectory);
        this.templatesDir = templatesDir;
        this.templateCache = new Map();
        this.partialsRegistered = false;
        this.fileObjects = [];
    }

    async start() {
        await fs.mkdir(this.outputDirectory, { recursive: true });
        await this.registerPartials();
    }

    endDefinition(context) {}

    startDefinition(context) {
        if (!isPrimitiveBitString(context)) {
            return;
        }

        const fileObject = this.createFileObject(context, []);
        this.fileObjects.push(fileObject);
    }

    startTraits(context) {
        context.userContext = [];
    }

    endTraits(context) {
        if (context.traits?.base !== 'bit-string') {
            return;
        }

        // SEQUENCE OF bit-string definitions represent collection wrappers and should not be emitted as bit-string structs.
        if (isBitStringSeries(context)) {
            return;
        }

        const bits = (context.userContext ?? [])
            .filter(item => Number.isInteger(item.position))
            .sort((left, right) => left.position - right.position);

        const fileObject = this.createFileObject(context, bits);
        this.fileObjects.push(fileObject);
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        if (parent?.traits?.base !== 'bit-string') {
            return;
        }

        const position = this.toInteger(context.item?.position);
        const rawName = String(context.item?.name ?? 'Bit');
        parent.userContext.push({
            position,
            rawName,
            propertyName: this.toSafeIdentifier(this.toPascalCase(rawName)),
            description: this.toSentence(context.item?.description)
        });
    }

    async afterProcessing() {
        this.ensurePrimitiveBitStringFileObject();

        for (const fileObject of this.fileObjects) {
            const content = await this.render(fileObject);
            writeFileSync(path.join(this.outputDirectory, fileObject.fileName), content, 'utf-8');
        }
    }

    ensurePrimitiveBitStringFileObject() {
        const alreadyPresent = this.fileObjects.some(fileObject =>
            fileObject.fileName === 'BitString.cs' || fileObject.fullname === 'bit-string');

        if (alreadyPresent) {
            return;
        }

        this.fileObjects.push({
            fullname: 'bit-string',
            bacnetName: 'BitString',
            fileName: 'BitString.cs',
            typeName: 'BitString',
            classHierarchy: [],
            storageType: 'byte[]',
            minimum: 0,
            maximum: null,
            isVariable: true,
            countType: 'ushort',
            category: BitStringCategory.VariableArray,
            bits: []
        });
    }

    createFileObject(context, bits) {
        const hierarchy = this.getTypeHierarchy(context.fullname);
        const typeName = hierarchy.at(-1);
        const classHierarchy = hierarchy.slice(0, hierarchy.length - 1);
        const fileName = `${hierarchy.join('.')}.cs`;

        const inferredFixedLength = bits.length > 0
            ? Math.max(...bits.map(item => item.position)) + 1
            : null;

        const descriptor = describeBitString({
            lengthTrait: context.traits?.length,
            inferredFixedLength,
            fullname: context.fullname
        });

        const uniqueBits = this.ensureUniquePropertyNames(bits);

        return {
            fullname: context.fullname,
            bacnetName: context.thisAlias ?? context.thisName,
            fileName,
            typeName,
            classHierarchy,
            storageType: descriptor.storageType,
            minimum: descriptor.length.minimum,
            maximum: descriptor.length.maximum,
            isVariable: descriptor.length.isVariable,
            countType: descriptor.countType,
            category: descriptor.category,
            bits: uniqueBits
        };
    }

    ensureUniquePropertyNames(bits) {
        const seen = new Map();
        const result = [];

        for (const bit of bits) {
            const key = bit.propertyName;
            const count = seen.get(key) ?? 0;
            seen.set(key, count + 1);
            result.push({
                ...bit,
                propertyName: count === 0 ? key : `${key}${count + 1}`
            });
        }

        return result;
    }

    async render(fileObject) {
        const content = await this.renderType(fileObject);
        const wrapped = this.wrapInHierarchy(fileObject.classHierarchy, content);
        return this.normalizeLineEndings([
            '// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors',
            '// SPDX-License-Identifier: EPL-2.0',
            '',
            'namespace Baclib.Bacnet.Types.Application;',
            '',
            wrapped,
            ''
        ].join('\n'));
    }

    async renderType(fileObject) {
        const templatePath = path.join(this.templatesDir, 'bit-string-type.hbs');
        const template = await this.loadTemplate(templatePath);
        const model = this.toTemplateModel(fileObject);
        return template(model);
    }

    toTemplateModel(fileObject) {
        const isArrayStorage = fileObject.storageType === 'byte[]';
        const scalar = isArrayStorage ? null : scalarLiteralTable.get(fileObject.storageType);

        return {
            ...fileObject,
            hasBits: fileObject.bits.length > 0,
            isArrayStorage,
            scalar,
            maxLengthLiteral: fileObject.maximum ?? 'int.MaxValue'
        };
    }

    async registerPartials() {
        if (this.partialsRegistered) {
            return;
        }

        const partials = [
            ['bitstring-length', 'bit-string-length.hbs'],
            ['bitstring-constructor', 'bit-string-constructor.hbs'],
            ['bitstring-bit-properties', 'bit-string-bit-properties.hbs'],
            ['bitstring-indexer', 'bit-string-indexer.hbs'],
            ['bitstring-helpers', 'bit-string-helpers.hbs']
        ];

        for (const [name, fileName] of partials) {
            const partialPath = path.join(this.templatesDir, fileName);
            const partialContent = await fs.readFile(partialPath, 'utf-8');
            Handlebars.registerPartial(name, partialContent);
        }

        this.partialsRegistered = true;
    }

    async loadTemplate(templatePath) {
        if (this.templateCache.has(templatePath)) {
            return this.templateCache.get(templatePath);
        }

        const templateContent = await fs.readFile(templatePath, 'utf-8');
        const compiledTemplate = Handlebars.compile(templateContent, { noEscape: true });
        this.templateCache.set(templatePath, compiledTemplate);
        return compiledTemplate;
    }

    wrapInHierarchy(classHierarchy, content) {
        if (!classHierarchy.length) {
            return content;
        }

        let start = '';
        let end = '';
        for (let i = 0; i < classHierarchy.length; i++) {
            const indentation = ' '.repeat(i * 4);
            start += `${indentation}public partial record class ${classHierarchy[i]}\n${indentation}{\n`;
            end = `${indentation}}\n` + end;
        }

        const contentIndent = ' '.repeat(classHierarchy.length * 4);
        const indented = content
            .split('\n')
            .map(line => `${contentIndent}${line}`)
            .join('\n');

        return `${start}${indented}\n${end}`;
    }

    getTypeHierarchy(fullname) {
        return fullname
            .split('.')
            .map((part, index) => (index ? 'T' : '') + this.toPascalCase(part));
    }

    toInteger(value) {
        if (typeof value === 'number' && Number.isInteger(value)) {
            return value;
        }
        if (typeof value === 'string' && /^-?\d+$/.test(value.trim())) {
            return Number.parseInt(value.trim(), 10);
        }
        return null;
    }

    toSentence(value) {
        const text = String(value ?? '').trim();
        if (!text) {
            return 'Named bit.';
        }
        return text
            .replace(/\s+/g, ' ')
            .replace(/[\r\n]+/g, ' ');
    }

    toSafeIdentifier(input) {
        let value = input.replace(/[^A-Za-z0-9_]/g, '');
        if (!value) {
            value = 'Bit';
        }
        if (/^\d/.test(value)) {
            value = `N${value}`;
        }
        if (csharpKeywords.has(value.toLowerCase())) {
            value = `${value}_`;
        }
        return value;
    }

    toPascalCase(value) {
        return String(value)
            .split(/[^A-Za-z0-9]+/g)
            .filter(Boolean)
            .map(part => part.charAt(0).toUpperCase() + part.slice(1))
            .join('');
    }

    normalizeLineEndings(content) {
        return content.replace(/\r\n|\n|\r/g, EOL);
    }
}

export async function generateBitStringTypes(options = {}) {
    const generator = new BitStringTypeGenerator(options);
    await traverseDefinitions(generator);
}
