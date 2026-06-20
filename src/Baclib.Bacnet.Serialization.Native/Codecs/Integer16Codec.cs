// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer16Codec : INativeCodec<short>
{
    private Integer16Codec()
    {
    }

    public static readonly Integer16Codec Instance = new();

    public int GetEncodedSize(in short value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger16(value));

    public int GetEncodedSize(byte tagNumber, in short value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger16(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in short value)
    {
        var length = AsduLength.FromInteger16(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        if (length == AsduLength.Signed8)
        {
            AsduEncoder.WriteInteger8(bytes, (sbyte)value);
            return;
        }

        AsduEncoder.WriteInteger16(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in short value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in short value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static short ReadInteger16(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
            _ => throw new AsduException()
        };
    }

    private static short Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadInteger16(ref bytes);
    }

    public short Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public short Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<short> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadInteger16(ref bytes);
        }
        return default;
    }

    public Optional<short> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public Optional<short> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

