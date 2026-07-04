// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class YouAreRequestCodec :
    IAsduElementCodec<T::YouAreRequest>,
    IAsduConstructedCodec<T::YouAreRequest>
{
    public static T::YouAreRequest Decode(ref AsduReader reader)
    {
        return new T::YouAreRequest
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader),
            ModelName = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader),
            SerialNumber = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader),
            DeviceIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            DeviceMacAddress = AsduElement.DecodeOptional<OctetStringCodec, T::OctetString>(ref reader)
        };
    }

    public static T::YouAreRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<YouAreRequestCodec, T::YouAreRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::YouAreRequest value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, value.VendorId);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.ModelName);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.SerialNumber);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.DeviceIdentifier);
        AsduElement.EncodeOptional<OctetStringCodec, T::OctetString>(ref writer, value.DeviceMacAddress);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::YouAreRequest value)
        => AsduConstructed.Encode<YouAreRequestCodec, T::YouAreRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::YouAreRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.ModelName);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.SerialNumber);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.DeviceIdentifier);
        length += AsduElement.GetOptionalEncodedLength<OctetStringCodec, T::OctetString>(value.DeviceMacAddress);
        return length;
    }

    public static int GetEncodedLength(in T::YouAreRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<YouAreRequestCodec, T::YouAreRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned16Codec.Matches(ref reader);
    }
}
