// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Enumerated32Codec : NativeCodecBase<Enumerated32>
{
    private Enumerated32Codec() : base(ApplicationTagNumber.Unsigned)
    {
    }

    public static readonly Enumerated32Codec Instance = new();

    protected override int CalculateValueSize(in Enumerated32 value) => AsduLength.FromUnsigned32((uint)value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in Enumerated32 value)
    {
        var length = AsduLength.FromUnsigned32((uint)value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Enumerated8:
                NativeWriter.WriteEnumerated8(bytes, (Enumerated8)value);
                break;
            case AsduLength.Enumerated16:
                NativeWriter.WriteEnumerated16(bytes, (Enumerated16)value);
                break;
            case AsduLength.Enumerated24:
                NativeWriter.WriteEnumerated24(bytes, value);
                break;
            case AsduLength.Enumerated32:
                NativeWriter.WriteEnumerated32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    protected override Enumerated32 DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => (Enumerated32)NativePrimitives.ReadEnumerated8(bytes),
            AsduLength.Unsigned16 => (Enumerated32)NativePrimitives.ReadEnumerated16(bytes),
            AsduLength.Unsigned24 => NativePrimitives.ReadEnumerated24(bytes),
            AsduLength.Unsigned32 => NativePrimitives.ReadEnumerated32(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<Enumerated32> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
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
        return default;
    }

    // Override to use ApplicationTagNumber.Enumerated for optional decoding (original behavior)
    // This supports the DecodeOptional flavor which uses tag 9 instead of tag 2
    public override Optional<Enumerated32> DecodeOptional(ref NativeReader decoder)
        => DecodeValueBytesOptional(ref decoder, (byte)ApplicationTagNumber.Enumerated, AsduTagClass.Application);
}

