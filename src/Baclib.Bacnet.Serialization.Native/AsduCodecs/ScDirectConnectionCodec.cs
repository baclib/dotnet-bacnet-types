// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScDirectConnectionCodec :
    IAsduElementCodec<T::ScDirectConnection>,
    IAsduConstructedCodec<T::ScDirectConnection>
{
    public static T::ScDirectConnection Decode(ref AsduReader reader)
    {
        return new T::ScDirectConnection
        {
            Uri = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 0),
            ConnectionState = AsduElement.Decode<ScConnectionStateCodec, T::ScConnectionState>(ref reader, 1),
            ConnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 2),
            DisconnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 3),
            PeerAddress = AsduElement.DecodeOptional<HostNPortCodec, T::HostNPort>(ref reader, 4),
            PeerVmac = AsduElement.DecodeOptional<ScDirectConnectionTPeerVmacCodec, T::ScDirectConnection.TPeerVmac>(ref reader, 5),
            PeerUuid = AsduElement.DecodeOptional<ScDirectConnectionTPeerUuidCodec, T::ScDirectConnection.TPeerUuid>(ref reader, 6),
            Error = AsduElement.DecodeOptional<ErrorCodec, T::Error>(ref reader, 7),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 8)
        };
    }

    public static T::ScDirectConnection Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ScDirectConnectionCodec, T::ScDirectConnection>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ScDirectConnection value)
    {
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 0, value.Uri);
        AsduElement.Encode<ScConnectionStateCodec, T::ScConnectionState>(ref writer, 1, value.ConnectionState);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 2, value.ConnectTimestamp);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 3, value.DisconnectTimestamp);
        AsduElement.EncodeOptional<HostNPortCodec, T::HostNPort>(ref writer, 4, value.PeerAddress);
        AsduElement.EncodeOptional<ScDirectConnectionTPeerVmacCodec, T::ScDirectConnection.TPeerVmac>(ref writer, 5, value.PeerVmac);
        AsduElement.EncodeOptional<ScDirectConnectionTPeerUuidCodec, T::ScDirectConnection.TPeerUuid>(ref writer, 6, value.PeerUuid);
        AsduElement.EncodeOptional<ErrorCodec, T::Error>(ref writer, 7, value.Error);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 8, value.ErrorDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ScDirectConnection value)
        => AsduConstructed.Encode<ScDirectConnectionCodec, T::ScDirectConnection>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ScDirectConnection value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(0, value.Uri);
        length += AsduElement.GetEncodedLength<ScConnectionStateCodec, T::ScConnectionState>(1, value.ConnectionState);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(2, value.ConnectTimestamp);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(3, value.DisconnectTimestamp);
        length += AsduElement.GetOptionalEncodedLength<HostNPortCodec, T::HostNPort>(4, value.PeerAddress);
        length += AsduElement.GetOptionalEncodedLength<ScDirectConnectionTPeerVmacCodec, T::ScDirectConnection.TPeerVmac>(5, value.PeerVmac);
        length += AsduElement.GetOptionalEncodedLength<ScDirectConnectionTPeerUuidCodec, T::ScDirectConnection.TPeerUuid>(6, value.PeerUuid);
        length += AsduElement.GetOptionalEncodedLength<ErrorCodec, T::Error>(7, value.Error);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(8, value.ErrorDetails);
        return length;
    }

    public static int GetEncodedLength(in T::ScDirectConnection value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ScDirectConnectionCodec, T::ScDirectConnection>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
