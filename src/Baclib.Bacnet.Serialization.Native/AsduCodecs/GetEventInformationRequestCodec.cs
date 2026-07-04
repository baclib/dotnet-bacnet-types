// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEventInformationRequestCodec :
    IAsduElementCodec<T::GetEventInformationRequest>,
    IAsduConstructedCodec<T::GetEventInformationRequest>
{
    public static T::GetEventInformationRequest Decode(ref AsduReader reader)
    {
        return new T::GetEventInformationRequest
        {
            LastReceivedObjectIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0)
        };
    }

    public static T::GetEventInformationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEventInformationRequestCodec, T::GetEventInformationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEventInformationRequest value)
    {
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.LastReceivedObjectIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEventInformationRequest value)
        => AsduConstructed.Encode<GetEventInformationRequestCodec, T::GetEventInformationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEventInformationRequest value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.LastReceivedObjectIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::GetEventInformationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEventInformationRequestCodec, T::GetEventInformationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
