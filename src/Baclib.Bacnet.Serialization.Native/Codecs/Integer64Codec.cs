// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer64Codec : NativeCodecBase<long>
{
    private Integer64Codec() : base(ApplicationTagNumber.Signed)
    {
    }

    public static readonly Integer64Codec Instance = new();

    protected override int CalculateValueSize(in long value) => AsduLength.FromInteger64(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in long value)
    {
        var length = AsduLength.FromInteger64(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Signed8:
                NativeWriter.WriteInteger8(bytes, (sbyte)value);
                break;
            case AsduLength.Signed16:
                NativeWriter.WriteInteger16(bytes, (short)value);
                break;
            case AsduLength.Signed24:
                NativeWriter.WriteInteger24(bytes, (int)value);
                break;
            case AsduLength.Signed32:
                NativeWriter.WriteInteger32(bytes, (int)value);
                break;
            case AsduLength.Signed40:
                NativeWriter.WriteInteger40(bytes, value);
                break;
            case AsduLength.Signed48:
                NativeWriter.WriteInteger48(bytes, value);
                break;
            case AsduLength.Signed56:
                NativeWriter.WriteInteger56(bytes, value);
                break;
            case AsduLength.Signed64:
                NativeWriter.WriteInteger64(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 64-bit integer.");
        }
    }

    protected override long DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
            AsduLength.Signed24 => NativePrimitives.ReadInteger24(bytes),
            AsduLength.Signed32 => NativePrimitives.ReadInteger32(bytes),
            AsduLength.Signed40 => NativePrimitives.ReadInteger40(bytes),
            AsduLength.Signed48 => NativePrimitives.ReadInteger48(bytes),
            AsduLength.Signed56 => NativePrimitives.ReadInteger56(bytes),
            AsduLength.Signed64 => NativePrimitives.ReadInteger64(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<long> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            return bytes.Length switch
            {
                AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
                AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
                AsduLength.Signed24 => NativePrimitives.ReadInteger24(bytes),
                AsduLength.Signed32 => NativePrimitives.ReadInteger32(bytes),
                AsduLength.Signed40 => NativePrimitives.ReadInteger40(bytes),
                AsduLength.Signed48 => NativePrimitives.ReadInteger48(bytes),
                AsduLength.Signed56 => NativePrimitives.ReadInteger56(bytes),
                AsduLength.Signed64 => NativePrimitives.ReadInteger64(bytes),
                _ => throw new AsduException()
            };
        }
        return default;
    }
}

