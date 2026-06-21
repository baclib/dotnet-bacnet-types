// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer8Codec : NativeCodecBase<sbyte>
{
    private Integer8Codec() : base(ApplicationTagNumber.Signed)
    {
    }

    public static readonly Integer8Codec Instance = new();

    protected override int CalculateValueSize(in sbyte value) => AsduLength.FromInteger8(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in sbyte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Signed8);
        NativeWriter.WriteInteger8(bytes, value);
    }

    protected override sbyte DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Signed8)
            throw new AsduException();
        return NativePrimitives.ReadInteger8(bytes);
    }

    protected override Optional<sbyte> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Signed8)
                throw new AsduException();
            return NativePrimitives.ReadInteger8(bytes);
        }
        return default;
    }
}

