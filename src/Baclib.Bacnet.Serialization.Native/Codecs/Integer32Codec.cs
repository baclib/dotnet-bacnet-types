// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer32Codec : NativeCodecBase<int>
{
    private Integer32Codec() : base(ApplicationTagNumber.Signed)
    {
    }

    public static readonly Integer32Codec Instance = new();

    protected override int CalculateValueSize(in int value) => AsduLength.FromInteger32(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in int value)
    {
        var length = AsduLength.FromInteger32(value);
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
                NativeWriter.WriteInteger24(bytes, value);
                break;
            case AsduLength.Signed32:
                NativeWriter.WriteInteger32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 32-bit integer.");
        }
    }

    protected override int DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
            AsduLength.Signed24 => NativePrimitives.ReadInteger24(bytes),
            AsduLength.Signed32 => NativePrimitives.ReadInteger32(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<int> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            return bytes.Length switch
            {
                AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
                AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
                AsduLength.Signed24 => NativePrimitives.ReadInteger24(bytes),
                AsduLength.Signed32 => NativePrimitives.ReadInteger32(bytes),
                _ => throw new AsduException()
            };
        }
        return default;
    }
}

