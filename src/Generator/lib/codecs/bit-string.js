// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

import { writeFileSync } from 'fs';
import fs from 'fs/promises';
import { EOL } from 'os';
import path from 'path';
import { CodecGeneratorBase } from './base.js';
import {
    describeBitString,
    isPrimitiveBitString,
    toInteger
} from '../core/bit-string-model.js';

class BitStringCodecTransformer extends CodecGeneratorBase {
    constructor() {
        super({
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

        if (!isPrimitiveBitString(context)) {
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
            position: toInteger(context.item?.position)
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

    registerCodecObject(context, bits) {
        const fullname = context.fullname;
        const hierarchy = this.getTypeHierarchy(fullname);
        const typeName = hierarchy.join('.');
        const className = `${hierarchy.join('')}Codec`;
        const fileName = `${className}.cs`;

        const inferredFixedLength = Array.isArray(bits) && bits.length > 0
            ? Math.max(...bits.map(item => item.position)) + 1
            : null;

        const descriptor = describeBitString({
            lengthTrait: context.traits?.length,
            inferredFixedLength,
            fullname
        });

        this.codecObjects.set(fullname, {
            fullname,
            className,
            fileName,
            csharpType: `T.${typeName}`,
            fixedLength: descriptor.length.isVariable ? null : descriptor.length.maximum,
            isVariable: descriptor.length.isVariable,
            storageType: descriptor.storageType,
            countType: descriptor.countType,
            storageBytes: descriptor.storageBytes
        });
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
    public static ${codecObject.csharpType} Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<${codecObject.className}, ${codecObject.csharpType}>(ref reader);

    /// <summary>
    /// Decodes a <see cref="${codecObject.csharpType}"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static ${codecObject.csharpType} Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<${codecObject.className}, ${codecObject.csharpType}>(ref reader, tagNumber);

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
    public static void Encode(ref AsduWriter writer, in ${codecObject.csharpType} value)
        => AsduPrimitive.Encode<${codecObject.className}, ${codecObject.csharpType}>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="${codecObject.csharpType}"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in ${codecObject.csharpType} value)
        => AsduPrimitive.Encode<${codecObject.className}, ${codecObject.csharpType}>(ref writer, tagNumber, value);

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
    public static int GetEncodedLength(in ${codecObject.csharpType} value)
        => AsduPrimitive.GetEncodedLength<${codecObject.className}, ${codecObject.csharpType}>(value);

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in ${codecObject.csharpType} value, byte tagNumber)
        => AsduPrimitive.GetEncodedLength<${codecObject.className}, ${codecObject.csharpType}>(tagNumber, value);

    /// <summary>
    /// Determines whether the next value in the reader matches this codec's application tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

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

/** Creates the bit-string codec generator. */
export function createBitStringCodecGenerator() {
    return new BitStringCodecTransformer();
}
