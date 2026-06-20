// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class OctetStringCodec : INativeCodec<OctetString>
{
    private OctetStringCodec()
    {
    }

    public static readonly OctetStringCodec Instance = new();

    public int GetEncodedSize(in OctetString value) => AsduLength.Sum(ApplicationTagNumber.OctetString, value.Length);

    public int GetEncodedSize(byte tagNumber, in OctetString value) => AsduLength.Sum(tagNumber, value.Length);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in OctetString value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, value.Length);
        AsduEncoder.WriteOctetString(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in OctetString value) => Encode(ref encoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in OctetString value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static OctetString Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return new OctetString(bytes);
    }

    public OctetString Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application);

    public OctetString Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<OctetString> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return new OctetString(bytes);
        }
        return default;
    }

    public Optional<OctetString> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.OctetString, AsduTagClass.Application);

    public Optional<OctetString> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

