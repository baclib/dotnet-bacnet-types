// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class OctetStringCodec : NativeCodecBase<OctetString>
{
    private OctetStringCodec() : base(ApplicationTagNumber.OctetString)
    {
    }

    public static readonly OctetStringCodec Instance = new();

    protected override int CalculateValueSize(in OctetString value) => value.Length;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in OctetString value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, value.Length);
        NativeWriter.WriteOctetString(bytes, value);
    }

    protected override OctetString DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return new OctetString(bytes);
    }

    protected override Optional<OctetString> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
            return new OctetString(bytes);
        return default;
    }
}

