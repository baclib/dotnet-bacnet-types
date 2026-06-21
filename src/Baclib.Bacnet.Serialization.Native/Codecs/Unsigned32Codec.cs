// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned32Codec : NativeCodecBase<uint>
{
    private Unsigned32Codec() : base(ApplicationTagNumber.Unsigned)
    {
    }

    public static readonly Unsigned32Codec Instance = new();

    protected override int CalculateValueSize(in uint value) => AsduLength.FromUnsigned32(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in uint value)
    {
        var length = AsduLength.FromUnsigned32(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Unsigned8:
                NativeWriter.WriteUnsigned8(bytes, (byte)value);
                break;
            case AsduLength.Unsigned16:
                NativeWriter.WriteUnsigned16(bytes, (ushort)value);
                break;
            case AsduLength.Unsigned24:
                NativeWriter.WriteUnsigned24(bytes, value);
                break;
            case AsduLength.Unsigned32:
                NativeWriter.WriteUnsigned32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    protected override uint DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
            AsduLength.Unsigned24 => NativePrimitives.ReadUnsigned24(bytes),
            AsduLength.Unsigned32 => NativePrimitives.ReadUnsigned32(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<uint> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            return bytes.Length switch
            {
                AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
                AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
                AsduLength.Unsigned24 => NativePrimitives.ReadUnsigned24(bytes),
                AsduLength.Unsigned32 => NativePrimitives.ReadUnsigned32(bytes),
                _ => throw new AsduException()
            };
        }
        return default;
    }
}

