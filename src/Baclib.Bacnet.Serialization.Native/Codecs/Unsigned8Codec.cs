// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned8Codec : INativeCodec<byte>
{
    private Unsigned8Codec()
    {
    }

    public static readonly Unsigned8Codec Instance = new();

    public int GetEncodedSize(in byte value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned8(value));

    public int GetEncodedSize(byte tagNumber, in byte value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned8(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in byte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Unsigned8);
        AsduEncoder.WriteUnsigned8(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in byte value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in byte value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static byte Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Unsigned8)
        {
            throw new AsduException();
        }
        return NativePrimitives.ReadUnsigned8(bytes);
    }

    public byte Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public byte Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<byte> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Unsigned8)
            {
                throw new AsduException();
            }
            return NativePrimitives.ReadUnsigned8(bytes);
        }
        return default;
    }

    public Optional<byte> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public Optional<byte> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

