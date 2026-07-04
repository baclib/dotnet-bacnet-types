// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScHubFunctionConnectionCodec :
    IAsduElementCodec<T::ScHubFunctionConnection>,
    IAsduConstructedCodec<T::ScHubFunctionConnection>
{
    public static T::ScHubFunctionConnection Decode(ref AsduReader reader)
    {
        return new T::ScHubFunctionConnection
        {
            ConnectionState = AsduElement.Decode<ScConnectionStateCodec, T::ScConnectionState>(ref reader, 0),
            ConnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 1),
            DisconnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 2),
            PeerAddress = AsduElement.Decode<HostNPortCodec, T::HostNPort>(ref reader, 3),
            PeerVmac = AsduElement.Decode<ScHubFunctionConnectionTPeerVmacCodec, T::ScHubFunctionConnection.TPeerVmac>(ref reader, 4),
            PeerUuid = AsduElement.Decode<ScHubFunctionConnectionTPeerUuidCodec, T::ScHubFunctionConnection.TPeerUuid>(ref reader, 5),
            Error = AsduElement.DecodeOptional<ErrorCodec, T::Error>(ref reader, 6),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 7)
        };
    }

    public static T::ScHubFunctionConnection Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ScHubFunctionConnectionCodec, T::ScHubFunctionConnection>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ScHubFunctionConnection value)
    {
        AsduElement.Encode<ScConnectionStateCodec, T::ScConnectionState>(ref writer, 0, value.ConnectionState);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 1, value.ConnectTimestamp);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 2, value.DisconnectTimestamp);
        AsduElement.Encode<HostNPortCodec, T::HostNPort>(ref writer, 3, value.PeerAddress);
        AsduElement.Encode<ScHubFunctionConnectionTPeerVmacCodec, T::ScHubFunctionConnection.TPeerVmac>(ref writer, 4, value.PeerVmac);
        AsduElement.Encode<ScHubFunctionConnectionTPeerUuidCodec, T::ScHubFunctionConnection.TPeerUuid>(ref writer, 5, value.PeerUuid);
        AsduElement.EncodeOptional<ErrorCodec, T::Error>(ref writer, 6, value.Error);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 7, value.ErrorDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ScHubFunctionConnection value)
        => AsduConstructed.Encode<ScHubFunctionConnectionCodec, T::ScHubFunctionConnection>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ScHubFunctionConnection value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ScConnectionStateCodec, T::ScConnectionState>(0, value.ConnectionState);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(1, value.ConnectTimestamp);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(2, value.DisconnectTimestamp);
        length += AsduElement.GetEncodedLength<HostNPortCodec, T::HostNPort>(3, value.PeerAddress);
        length += AsduElement.GetEncodedLength<ScHubFunctionConnectionTPeerVmacCodec, T::ScHubFunctionConnection.TPeerVmac>(4, value.PeerVmac);
        length += AsduElement.GetEncodedLength<ScHubFunctionConnectionTPeerUuidCodec, T::ScHubFunctionConnection.TPeerUuid>(5, value.PeerUuid);
        length += AsduElement.GetOptionalEncodedLength<ErrorCodec, T::Error>(6, value.Error);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(7, value.ErrorDetails);
        return length;
    }

    public static int GetEncodedLength(in T::ScHubFunctionConnection value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ScHubFunctionConnectionCodec, T::ScHubFunctionConnection>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
