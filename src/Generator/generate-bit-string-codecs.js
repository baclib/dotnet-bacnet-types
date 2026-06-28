// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import { fileURLToPath } from 'url';
import { traverseDefinitions } from '@baclib/generic-bacnet-types/src/traverse.js';
import { CodecGeneratorBase } from './codec-generator-common.js';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const specialVariableLengths = new Map([
    ['bit-string-8', 8],
    ['bit-string-16', 16],
    ['bit-string-32', 32],
    ['bit-string-64', 64]
]);

class BitStringCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super(__dirname, {
            filterEnvName: 'BITSTRING_CODEC_FILTER',
            noEscape: true
        });
        this.codecObjects = new Map();
    }

    async start() {
        await fs.mkdir(this.directory, { recursive: true });
    }

    startDefinition(context) {
        this.registerType(context);

        if (!this.isPrimitiveBitString(context)) {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        this.registerCodecObject(context, null);
    }

    endDefinition(context) {}

    startTraits(context) {
        this.registerType(context);
        context.userContext = [];
    }

    endTraits(context) {
        if (context.traits?.base !== 'bit-string' || this.isSeries(context)) {
            return;
        }

        if (!this.matchesFilter(context.fullname)) {
            return;
        }

        const bits = (context.userContext ?? [])
            .filter(item => Number.isInteger(item.position))
            .sort((left, right) => left.position - right.position);

        this.registerCodecObject(context, bits);
    }

    startItem(context) {}

    endItem(context) {
        const parent = context.ancestors.at(-1);
        if (parent?.traits?.base !== 'bit-string') {
            return;
        }

        parent.userContext.push({
            position: this.toInteger(context.item?.position)
        });
    }

    async afterProcessing() {
        this.ensurePrimitiveBitStringCodecObject();

        const generatedFileNames = new Set([...this.codecObjects.values()].map(item => item.fileName));
        const existingFiles = await fs.readdir(this.directory);

        for (const file of existingFiles) {
            if (generatedFileNames.has(file)) {
                await fs.unlink(path.join(this.directory, file));
            }
        }

        for (const codecObject of this.codecObjects.values()) {
            const content = this.renderCodec(codecObject);
            writeFileSync(path.join(this.directory, codecObject.fileName), content);
        }
    }

    ensurePrimitiveBitStringCodecObject() {
        if (this.codecObjects.has('bit-string')) {
            return;
        }

        this.codecObjects.set('bit-string', {
            fullname: 'bit-string',
            className: 'BitStringCodec',
            fileName: 'BitStringCodec.cs',
            csharpType: 'T.BitString',
            fixedLength: null,
            isVariable: true,
            storageType: 'byte[]',
            countType: 'ushort',
            storageBytes: null
        });
    }

    isPrimitiveBitString(context) {
        if (context.traits !== undefined) {
            return false;
        }

        return context.definition?.primitive === 8 || context.fullname === 'bit-string';
    }

    registerCodecObject(context, bits) {
        const fullname = context.fullname;
        const hierarchy = this.getTypeHierarchy(fullname);
        const typeName = hierarchy.join('.');
        const className = `${hierarchy.join('')}Codec`;
        const fileName = `${className}.cs`;

        const inferredFixedLength = Array.isArray(bits) && bits.length > 0
            ? Math.max(...bits.map(item => item.position)) + 1
            : null;

        const isSpecialVariable = specialVariableLengths.has(fullname);
        const lengthInfo = this.resolveLengthInfo(context.traits?.length, inferredFixedLength, isSpecialVariable, fullname);
        const storageType = this.resolveStorageType(lengthInfo.maximum ?? lengthInfo.minimum);

        this.codecObjects.set(fullname, {
            fullname,
            className,
            fileName,
            csharpType: `T.${typeName}`,
            fixedLength: lengthInfo.isVariable ? null : lengthInfo.maximum,
            isVariable: lengthInfo.isVariable,
            storageType,
            countType: this.getCountType(lengthInfo.maximum),
            storageBytes: this.getStorageBytes(storageType)
        });
    }

    resolveLengthInfo(lengthTrait, inferredFixedLength, isSpecialVariable, fullname) {
        if (isSpecialVariable) {
            const max = specialVariableLengths.get(fullname);
            return { minimum: 0, maximum: max, isVariable: true };
        }

        if (Number.isInteger(lengthTrait)) {
            return { minimum: lengthTrait, maximum: lengthTrait, isVariable: false };
        }

        if (lengthTrait && typeof lengthTrait === 'object') {
            const minimum = this.toInteger(lengthTrait.minimum) ?? 0;
            const maximum = this.toInteger(lengthTrait.maximum);
            if (minimum === maximum && maximum !== null) {
                return { minimum, maximum, isVariable: false };
            }
            return { minimum, maximum, isVariable: true };
        }

        if (Number.isInteger(inferredFixedLength)) {
            return { minimum: inferredFixedLength, maximum: inferredFixedLength, isVariable: false };
        }

        return { minimum: 0, maximum: null, isVariable: true };
    }

    resolveStorageType(maxLength) {
        if (!Number.isInteger(maxLength)) {
            return 'byte[]';
        }

        if (maxLength <= 8) {
            return 'byte';
        }
        if (maxLength <= 16) {
            return 'ushort';
        }
        if (maxLength <= 32) {
            return 'uint';
        }
        if (maxLength <= 64) {
            return 'ulong';
        }

        return 'byte[]';
    }

    getStorageBytes(storageType) {
        switch (storageType) {
            case 'byte':
                return 1;
            case 'ushort':
                return 2;
            case 'uint':
                return 4;
            case 'ulong':
                return 8;
            default:
                return null;
        }
    }

    getCountType(maximum) {
        if (!Number.isInteger(maximum)) {
            return 'ushort';
        }

        return maximum > 255 ? 'ushort' : 'byte';
    }

    toInteger(value) {
        if (typeof value === 'number' && Number.isInteger(value)) {
            return value;
        }

        if (typeof value === 'bigint') {
            const asNumber = Number(value);
            return Number.isInteger(asNumber) ? asNumber : null;
        }

        if (typeof value === 'string') {
            const parsed = Number.parseInt(value, 10);
            return Number.isInteger(parsed) ? parsed : null;
        }

        return null;
    }

    renderCodec(codecObject) {
        const decodeValueBody = this.buildDecodeValueBody(codecObject)
            .split('\n')
            .map(line => `        ${line}`)
            .join('\n');

        const encodeValueBody = this.buildEncodeValueBody(codecObject)
            .split('\n')
            .map(line => `        ${line}`)
            .join('\n');

        const helperMethods = this.buildHelperMethods(codecObject);
        const encodedValueLengthExpression = codecObject.fixedLength === null
            ? '1 + ((value.Length + 7) / 8)'
            : `1 + (((${codecObject.csharpType}.FixedLength) + 7) / 8)`;

        const content = `// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="${codecObject.csharpType}"/> values.
/// </summary>
public sealed class ${codecObject.className} :
    IAsduElementCodec<${codecObject.csharpType}>,
    IAsduPrimitiveCodec<${codecObject.csharpType}>
{
    /// <summary>
    /// Decodes a <see cref="${codecObject.csharpType}"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static ${codecObject.csharpType} Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<${codecObject.className}, ${codecObject.csharpType}>(ref reader);

    /// <summary>
    /// Decodes a <see cref="${codecObject.csharpType}"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static ${codecObject.csharpType} Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<${codecObject.className}, ${codecObject.csharpType}>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="${codecObject.csharpType}"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    public static ${codecObject.csharpType} DecodeValue(ReadOnlySpan<byte> source)
    {
${decodeValueBody}
    }

    /// <summary>
    /// Encodes a <see cref="${codecObject.csharpType}"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in ${codecObject.csharpType} value)
        => Asdu.EncodePrimitive<${codecObject.className}, ${codecObject.csharpType}>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="${codecObject.csharpType}"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in ${codecObject.csharpType} value)
        => Asdu.EncodePrimitive<${codecObject.className}, ${codecObject.csharpType}>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="${codecObject.csharpType}"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    public static void EncodeValue(Span<byte> destination, in ${codecObject.csharpType} value)
    {
${encodeValueBody}
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="${codecObject.csharpType}"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in ${codecObject.csharpType} value)
        => ${encodedValueLengthExpression};

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in ${codecObject.csharpType} value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in ${codecObject.csharpType} value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Determines whether the next value in the reader matches this codec's application tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref NativeReader reader)
        => reader.PeekPrimitiveTag(TagNumber);

    /// <summary>
    /// Determines whether the next value in the reader matches a specific context tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekPrimitiveTag(tagNumber);

    /// <summary>
    /// Gets the BACnet application tag number handled by this codec.
    /// </summary>
    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.BitString;

${helperMethods}}
`;

        return content.replace(/\r\n|\n|\r/g, EOL);
    }

    buildDecodeValueBody(codecObject) {
        const lines = [
            'var bitString = new BitString(source);'
        ];

        if (codecObject.fixedLength !== null) {
            lines.push(`if (bitString.Length != ${codecObject.csharpType}.FixedLength)`);
            lines.push('{');
            lines.push('    throw new ArgumentOutOfRangeException(nameof(source));');
            lines.push('}');
        }

        if (codecObject.storageType === 'byte[]') {
            if (codecObject.fixedLength !== null) {
                lines.push(`return new ${codecObject.csharpType}(bitString.Flags);`);
            }
            else {
                lines.push(`return new ${codecObject.csharpType}(bitString.Flags, (${codecObject.countType})bitString.Length);`);
            }
            return lines.join('\n');
        }

        lines.push('var flags = ReadFlags(bitString.Flags);');
        if (codecObject.fixedLength !== null) {
            lines.push(`return new ${codecObject.csharpType}(flags);`);
        }
        else {
            lines.push(`return new ${codecObject.csharpType}(flags, (${codecObject.countType})bitString.Length);`);
        }

        return lines.join('\n');
    }

    buildEncodeValueBody(codecObject) {
        const bitCountExpression = codecObject.fixedLength === null
            ? 'value.Length'
            : `${codecObject.csharpType}.FixedLength`;

        const lines = [
            `int bitCount = ${bitCountExpression};`,
            'ArgumentOutOfRangeException.ThrowIfNegative(bitCount, nameof(value));',
            'ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, ushort.MaxValue, nameof(value));'
        ];

        if (codecObject.storageType === 'byte[]') {
            lines.push('var bitString = new BitString(value.Flags, checked((ushort)bitCount));');
            lines.push('bitString.CopyTo(destination);');
            return lines.join('\n');
        }

        lines.push('var flagsBytes = WriteFlags(value.Flags, bitCount);');
        lines.push('var bitString = new BitString(flagsBytes, checked((ushort)bitCount));');
        lines.push('bitString.CopyTo(destination);');
        return lines.join('\n');
    }

    buildHelperMethods(codecObject) {
        if (codecObject.storageType === 'byte[]') {
            return '';
        }

        return `    private static ${codecObject.storageType} ReadFlags(ReadOnlySpan<byte> source)
    {
        int bytesToRead = Math.Min(source.Length, ${codecObject.storageBytes});
        ulong flags = 0;

        for (int i = 0; i < bytesToRead; i++)
        {
            flags |= (ulong)source[i] << (i * 8);
        }

        return (${codecObject.storageType})flags;
    }

    private static byte[] WriteFlags(${codecObject.storageType} value, int bitCount)
    {
        int byteCount = (bitCount + 7) / 8;
        var flags = new byte[byteCount];
        ulong source = value;

        for (int i = 0; i < byteCount; i++)
        {
            flags[i] = (byte)(source >> (i * 8));
        }

        return flags;
    }

`;
    }
}

const transformer = new BitStringCodecTransformer();
await traverseDefinitions(transformer);
