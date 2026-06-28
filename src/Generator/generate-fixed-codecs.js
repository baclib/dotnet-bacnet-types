// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import { fileURLToPath } from 'url';
import Handlebars from 'handlebars';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const fixedCodecSpecs = Object.freeze([
    {
        className: 'BooleanCodec',
        csharpType: 'bool',
        tagName: 'Boolean',
        template: 'codec-boolean-native'
    },
    {
        className: 'NullCodec',
        csharpType: 'Null',
        tagName: 'Null',
        template: 'codec-null-native'
    },
    {
        className: 'DatePatternCodec',
        csharpType: 'DatePattern',
        tagName: 'DatePattern',
        template: 'codec-date-pattern-native'
    },
    {
        className: 'DateCodec',
        csharpType: 'Date',
        tagName: 'DatePattern',
        template: 'codec-date-pattern-native'
    },
    {
        className: 'TimePatternCodec',
        csharpType: 'TimePattern',
        tagName: 'TimePattern',
        template: 'codec-time-pattern-native'
    },
    {
        className: 'TimeCodec',
        csharpType: 'Time',
        tagName: 'TimePattern',
        template: 'codec-time-pattern-native'
    },
    {
        className: 'ObjectIdentifierCodec',
        csharpType: 'ObjectIdentifier',
        tagName: 'ObjectIdentifier',
        template: 'codec-object-identifier-native'
    },
    {
        className: 'OctetStringCodec',
        csharpType: 'OctetString',
        tagName: 'OctetString',
        template: 'codec-octet-string-native'
    },
    {
        className: 'CharacterStringCodec',
        csharpType: 'CharacterString',
        tagName: 'CharacterString',
        template: 'codec-character-string-native'
    },
    {
        className: 'BitStringCodec',
        csharpType: 'BitString',
        tagName: 'BitString',
        template: 'codec-bit-string-native'
    },
    {
        className: 'Unsigned8Codec',
        csharpType: 'byte',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned8',
        levels: [
            { lengthConst: 'Unsigned8', readMethod: 'ReadUnsigned8', writeMethod: 'WriteUnsigned8', castType: 'byte' }
        ]
    },
    {
        className: 'Unsigned16Codec',
        csharpType: 'ushort',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned16',
        levels: [
            { lengthConst: 'Unsigned8', readMethod: 'ReadUnsigned8', writeMethod: 'WriteUnsigned8', castType: 'byte' },
            { lengthConst: 'Unsigned16', readMethod: 'ReadUnsigned16', writeMethod: 'WriteUnsigned16', castType: 'ushort' }
        ]
    },
    {
        className: 'Unsigned32Codec',
        csharpType: 'uint',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned32',
        levels: [
            { lengthConst: 'Unsigned8', readMethod: 'ReadUnsigned8', writeMethod: 'WriteUnsigned8', castType: 'byte' },
            { lengthConst: 'Unsigned16', readMethod: 'ReadUnsigned16', writeMethod: 'WriteUnsigned16', castType: 'ushort' },
            { lengthConst: 'Unsigned24', readMethod: 'ReadUnsigned24', writeMethod: 'WriteUnsigned24', castType: 'uint' },
            { lengthConst: 'Unsigned32', readMethod: 'ReadUnsigned32', writeMethod: 'WriteUnsigned32', castType: 'uint' }
        ]
    },
    {
        className: 'Unsigned64Codec',
        csharpType: 'ulong',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned64',
        levels: [
            { lengthConst: 'Unsigned8', readMethod: 'ReadUnsigned8', writeMethod: 'WriteUnsigned8', castType: 'byte' },
            { lengthConst: 'Unsigned16', readMethod: 'ReadUnsigned16', writeMethod: 'WriteUnsigned16', castType: 'ushort' },
            { lengthConst: 'Unsigned24', readMethod: 'ReadUnsigned24', writeMethod: 'WriteUnsigned24', castType: 'uint' },
            { lengthConst: 'Unsigned32', readMethod: 'ReadUnsigned32', writeMethod: 'WriteUnsigned32', castType: 'uint' },
            { lengthConst: 'Unsigned40', readMethod: 'ReadUnsigned40', writeMethod: 'WriteUnsigned40', castType: 'ulong' },
            { lengthConst: 'Unsigned48', readMethod: 'ReadUnsigned48', writeMethod: 'WriteUnsigned48', castType: 'ulong' },
            { lengthConst: 'Unsigned56', readMethod: 'ReadUnsigned56', writeMethod: 'WriteUnsigned56', castType: 'ulong' },
            { lengthConst: 'Unsigned64', readMethod: 'ReadUnsigned64', writeMethod: 'WriteUnsigned64', castType: 'ulong' }
        ]
    },
    {
        className: 'Integer8Codec',
        csharpType: 'sbyte',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger8',
        levels: [
            { lengthConst: 'Signed8', readMethod: 'ReadInteger8', writeMethod: 'WriteInteger8', castType: 'sbyte' }
        ]
    },
    {
        className: 'Integer16Codec',
        csharpType: 'short',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger16',
        levels: [
            { lengthConst: 'Signed8', readMethod: 'ReadInteger8', writeMethod: 'WriteInteger8', castType: 'sbyte' },
            { lengthConst: 'Signed16', readMethod: 'ReadInteger16', writeMethod: 'WriteInteger16', castType: 'short' }
        ]
    },
    {
        className: 'Integer32Codec',
        csharpType: 'int',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger32',
        levels: [
            { lengthConst: 'Signed8', readMethod: 'ReadInteger8', writeMethod: 'WriteInteger8', castType: 'sbyte' },
            { lengthConst: 'Signed16', readMethod: 'ReadInteger16', writeMethod: 'WriteInteger16', castType: 'short' },
            { lengthConst: 'Signed24', readMethod: 'ReadInteger24', writeMethod: 'WriteInteger24', castType: 'int' },
            { lengthConst: 'Signed32', readMethod: 'ReadInteger32', writeMethod: 'WriteInteger32', castType: 'int' }
        ]
    },
    {
        className: 'Integer64Codec',
        csharpType: 'long',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger64',
        levels: [
            { lengthConst: 'Signed8', readMethod: 'ReadInteger8', writeMethod: 'WriteInteger8', castType: 'sbyte' },
            { lengthConst: 'Signed16', readMethod: 'ReadInteger16', writeMethod: 'WriteInteger16', castType: 'short' },
            { lengthConst: 'Signed24', readMethod: 'ReadInteger24', writeMethod: 'WriteInteger24', castType: 'int' },
            { lengthConst: 'Signed32', readMethod: 'ReadInteger32', writeMethod: 'WriteInteger32', castType: 'int' },
            { lengthConst: 'Signed40', readMethod: 'ReadInteger40', writeMethod: 'WriteInteger40', castType: 'long' },
            { lengthConst: 'Signed48', readMethod: 'ReadInteger48', writeMethod: 'WriteInteger48', castType: 'long' },
            { lengthConst: 'Signed56', readMethod: 'ReadInteger56', writeMethod: 'WriteInteger56', castType: 'long' },
            { lengthConst: 'Signed64', readMethod: 'ReadInteger64', writeMethod: 'WriteInteger64', castType: 'long' }
        ]
    },
    {
        className: 'UnsignedCodec',
        csharpType: 'uint',
        tagName: 'Unsigned',
        fromLengthMethod: 'FromUnsigned32',
        levels: [
            { lengthConst: 'Unsigned8', readMethod: 'ReadUnsigned8', writeMethod: 'WriteUnsigned8', castType: 'byte' },
            { lengthConst: 'Unsigned16', readMethod: 'ReadUnsigned16', writeMethod: 'WriteUnsigned16', castType: 'ushort' },
            { lengthConst: 'Unsigned24', readMethod: 'ReadUnsigned24', writeMethod: 'WriteUnsigned24', castType: 'uint' },
            { lengthConst: 'Unsigned32', readMethod: 'ReadUnsigned32', writeMethod: 'WriteUnsigned32', castType: 'uint' }
        ]
    },
    {
        className: 'IntegerCodec',
        csharpType: 'int',
        tagName: 'Signed',
        fromLengthMethod: 'FromInteger32',
        levels: [
            { lengthConst: 'Signed8', readMethod: 'ReadInteger8', writeMethod: 'WriteInteger8', castType: 'sbyte' },
            { lengthConst: 'Signed16', readMethod: 'ReadInteger16', writeMethod: 'WriteInteger16', castType: 'short' },
            { lengthConst: 'Signed24', readMethod: 'ReadInteger24', writeMethod: 'WriteInteger24', castType: 'int' },
            { lengthConst: 'Signed32', readMethod: 'ReadInteger32', writeMethod: 'WriteInteger32', castType: 'int' }
        ]
    },
    {
        className: 'RealCodec',
        csharpType: 'float',
        tagName: 'Real',
        fixedLengthConst: 'Real',
        fixedReadMethod: 'ReadReal',
        fixedWriteMethod: 'WriteReal'
    },
    {
        className: 'DoubleCodec',
        csharpType: 'double',
        tagName: 'Double',
        fixedLengthConst: 'Double',
        fixedReadMethod: 'ReadDouble',
        fixedWriteMethod: 'WriteDouble'
    }
]);

class FixedCodecTransformer {
    constructor() {
        this.directory = process.env.CODEC_OUTPUT_DIR
            ? path.resolve(__dirname, process.env.CODEC_OUTPUT_DIR)
            : path.join(__dirname, '..', 'Baclib.Bacnet.Serialization.Native', 'AsduCodecs');
        this.templatesDir = path.join(__dirname, 'templates', 'codecs');
        this.templateCache = new Map();
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    async afterProcessing() {
        for (const codec of fixedCodecSpecs) {
            const fileName = `${codec.className}.cs`;
            const templateName = codec.template ?? 'codec-fixed-native';
            const templatePath = path.join(this.templatesDir, `${templateName}.hbs`);
            const content = await this.render(templatePath, codec);
            writeFileSync(path.join(this.directory, fileName), content);
        }
    }

    async loadTemplate(templatePath) {
        if (this.templateCache.has(templatePath)) {
            return this.templateCache.get(templatePath);
        }

        const templateContent = await fs.readFile(templatePath, 'utf-8');
        const compiledTemplate = Handlebars.compile(templateContent);
        this.templateCache.set(templatePath, compiledTemplate);
        return compiledTemplate;
    }

    async render(templatePath, data) {
        const template = await this.loadTemplate(templatePath);
        return this.normalizeLineEndings(template(data));
    }

    normalizeLineEndings(content) {
        return content.replace(/\r\n|\n|\r/g, EOL);
    }
}

const transformer = new FixedCodecTransformer();
await transformer.start();
await transformer.afterProcessing();
