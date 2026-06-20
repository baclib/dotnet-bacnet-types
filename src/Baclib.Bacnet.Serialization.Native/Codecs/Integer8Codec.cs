// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer8Codec : INativeCodec<sbyte>
{
    private Integer8Codec()
    {
    }

    public static readonly Integer8Codec Instance = new();

    public int GetEncodedSize(in sbyte value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger8(value));

    public int GetEncodedSize(byte tagNumber, in sbyte value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger8(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in sbyte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Signed8);
        AsduEncoder.WriteInteger8(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in sbyte value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in sbyte value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static sbyte Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Signed8)
        {
            throw new AsduException();
        }
        return NativePrimitives.ReadInteger8(bytes);
    }

    public sbyte Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public sbyte Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<sbyte> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Signed8)
            {
                throw new AsduException();
            }
            return NativePrimitives.ReadInteger8(bytes);
        }
        return default;
    }

    public Optional<sbyte> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public Optional<sbyte> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

