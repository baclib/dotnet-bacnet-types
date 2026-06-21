// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer16Codec : NativeCodecBase<short>
{
    private Integer16Codec() : base(ApplicationTagNumber.Signed)
    {
    }

    public static readonly Integer16Codec Instance = new();

    protected override int CalculateValueSize(in short value) => AsduLength.FromInteger16(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in short value)
    {
        var length = AsduLength.FromInteger16(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        if (length == AsduLength.Signed8)
        {
            NativeWriter.WriteInteger8(bytes, (sbyte)value);
            return;
        }
        NativeWriter.WriteInteger16(bytes, value);
    }

    protected override short DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<short> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            return bytes.Length switch
            {
                AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
                AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
                _ => throw new AsduException()
            };
        }
        return default;
    }
}

