// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned16Codec : NativeCodecBase<ushort>
{
    private Unsigned16Codec() : base(ApplicationTagNumber.Unsigned)
    {
    }

    public static readonly Unsigned16Codec Instance = new();

    protected override int CalculateValueSize(in ushort value) => AsduLength.FromUnsigned16(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in ushort value)
    {
        var length = AsduLength.FromUnsigned16(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        if (length == AsduLength.Unsigned8)
        {
            NativeWriter.WriteUnsigned8(bytes, (byte)value);
            return;
        }
        NativeWriter.WriteUnsigned16(bytes, value);
    }

    protected override ushort DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
            _ => throw new AsduException()
        };
    }

    protected override Optional<ushort> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            return bytes.Length switch
            {
                AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
                AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
                _ => throw new AsduException()
            };
        }
        return default;
    }
}

