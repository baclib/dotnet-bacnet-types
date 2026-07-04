// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScFailedConnectionRequestCodec :
    IAsduElementCodec<T::ScFailedConnectionRequest>,
    IAsduConstructedCodec<T::ScFailedConnectionRequest>
{
    public static T::ScFailedConnectionRequest Decode(ref AsduReader reader)
    {
        return new T::ScFailedConnectionRequest
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            PeerAddress = AsduElement.Decode<HostNPortCodec, T::HostNPort>(ref reader, 1),
            PeerVmac = AsduElement.DecodeOptional<ScFailedConnectionRequestTPeerVmacCodec, T::ScFailedConnectionRequest.TPeerVmac>(ref reader, 2),
            PeerUuid = AsduElement.DecodeOptional<ScFailedConnectionRequestTPeerUuidCodec, T::ScFailedConnectionRequest.TPeerUuid>(ref reader, 3),
            Error = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 4),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 5)
        };
    }

    public static T::ScFailedConnectionRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ScFailedConnectionRequestCodec, T::ScFailedConnectionRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ScFailedConnectionRequest value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<HostNPortCodec, T::HostNPort>(ref writer, 1, value.PeerAddress);
        AsduElement.EncodeOptional<ScFailedConnectionRequestTPeerVmacCodec, T::ScFailedConnectionRequest.TPeerVmac>(ref writer, 2, value.PeerVmac);
        AsduElement.EncodeOptional<ScFailedConnectionRequestTPeerUuidCodec, T::ScFailedConnectionRequest.TPeerUuid>(ref writer, 3, value.PeerUuid);
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 4, value.Error);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 5, value.ErrorDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ScFailedConnectionRequest value)
        => AsduConstructed.Encode<ScFailedConnectionRequestCodec, T::ScFailedConnectionRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ScFailedConnectionRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<HostNPortCodec, T::HostNPort>(1, value.PeerAddress);
        length += AsduElement.GetOptionalEncodedLength<ScFailedConnectionRequestTPeerVmacCodec, T::ScFailedConnectionRequest.TPeerVmac>(2, value.PeerVmac);
        length += AsduElement.GetOptionalEncodedLength<ScFailedConnectionRequestTPeerUuidCodec, T::ScFailedConnectionRequest.TPeerUuid>(3, value.PeerUuid);
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(4, value.Error);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(5, value.ErrorDetails);
        return length;
    }

    public static int GetEncodedLength(in T::ScFailedConnectionRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ScFailedConnectionRequestCodec, T::ScFailedConnectionRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
