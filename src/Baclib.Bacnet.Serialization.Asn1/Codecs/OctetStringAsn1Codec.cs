// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class OctetStringAsn1Codec : Asn1CodecBase<OctetString>
{
    private OctetStringAsn1Codec()
    {
    }

    public static readonly OctetStringAsn1Codec Instance = new();

    public override int GetEncodedSize(in OctetString value) => AsduLength.Sum(ApplicationTagNumber.OctetString, value.Length);

    public override int GetEncodedSize(byte tagNumber, in OctetString value) => AsduLength.Sum(tagNumber, value.Length);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in OctetString value)
    {
        var bytes = encoder.Encode(tagNumber, tagClass, value.Length);
        AsduPrimitives.WriteOctetString(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in OctetString value) => Encode(ref encoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in OctetString value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static OctetString Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return new OctetString(bytes);
    }

    public override OctetString Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application);

    public override OctetString Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<OctetString> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return new OctetString(bytes);
        }
        return default;
    }

    public override Optional<OctetString> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application);

    public override Optional<OctetString> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
