// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtDataRequestCodec :
    IAsduElementCodec<T::VtDataRequest>,
    IAsduConstructedCodec<T::VtDataRequest>
{
    public static T::VtDataRequest Decode(ref AsduReader reader)
    {
        return new T::VtDataRequest
        {
            VtSessionIdentifier = AsduElement.Decode<Unsigned8Codec, byte>(ref reader),
            VtNewData = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader),
            VtDataFlag = AsduElement.Decode<VtDataRequestTVtDataFlagCodec, T::VtDataRequest.TVtDataFlag>(ref reader)
        };
    }

    public static T::VtDataRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtDataRequestCodec, T::VtDataRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtDataRequest value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.VtSessionIdentifier);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, value.VtNewData);
        AsduElement.Encode<VtDataRequestTVtDataFlagCodec, T::VtDataRequest.TVtDataFlag>(ref writer, value.VtDataFlag);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtDataRequest value)
        => AsduConstructed.Encode<VtDataRequestCodec, T::VtDataRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtDataRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.VtSessionIdentifier);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(value.VtNewData);
        length += AsduElement.GetEncodedLength<VtDataRequestTVtDataFlagCodec, T::VtDataRequest.TVtDataFlag>(value.VtDataFlag);
        return length;
    }

    public static int GetEncodedLength(in T::VtDataRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtDataRequestCodec, T::VtDataRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned8Codec.Matches(ref reader);
    }
}
