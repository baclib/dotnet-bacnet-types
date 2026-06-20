// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Enumerated32Codec : INativeCodec<Enumerated32>
{
    private Enumerated32Codec()
    {
    }

    public static readonly Enumerated32Codec Instance = new();

    public int GetEncodedSize(in Enumerated32 value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned32((uint)value));

    public int GetEncodedSize(byte tagNumber, in Enumerated32 value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned32((uint)value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in Enumerated32 value)
    {
        var length = AsduLength.FromUnsigned32((uint)value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Enumerated8:
                AsduEncoder.WriteEnumerated8(bytes, (Enumerated8)value);
                break;
            case AsduLength.Enumerated16:
                AsduEncoder.WriteEnumerated16(bytes, (Enumerated16)value);
                break;
            case AsduLength.Enumerated24:
                AsduEncoder.WriteEnumerated24(bytes, value);
                break;
            case AsduLength.Enumerated32:
                AsduEncoder.WriteEnumerated32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    public void Encode(ref AsduEncoder encoder, in Enumerated32 value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in Enumerated32 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static Enumerated32 ReadEnumerated32(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => (Enumerated32)NativePrimitives.ReadEnumerated8(bytes),
            AsduLength.Unsigned16 => (Enumerated32)NativePrimitives.ReadEnumerated16(bytes),
            AsduLength.Unsigned24 => NativePrimitives.ReadEnumerated24(bytes),
            AsduLength.Unsigned32 => NativePrimitives.ReadEnumerated32(bytes),
            _ => throw new AsduException()
        };
    }

    private static Enumerated32 Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadEnumerated32(ref bytes);
    }

    public Enumerated32 Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public Enumerated32 Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<Enumerated32> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadEnumerated32(ref bytes);
        }

        return default;
    }

    public Optional<Enumerated32> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Enumerated, AsduTagClass.Application);

    public Optional<Enumerated32> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

