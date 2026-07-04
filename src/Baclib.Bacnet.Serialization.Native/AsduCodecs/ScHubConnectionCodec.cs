// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScHubConnectionCodec :
    IAsduElementCodec<T::ScHubConnection>,
    IAsduConstructedCodec<T::ScHubConnection>
{
    public static T::ScHubConnection Decode(ref AsduReader reader)
    {
        return new T::ScHubConnection
        {
            ConnectionState = AsduElement.Decode<ScConnectionStateCodec, T::ScConnectionState>(ref reader, 0),
            ConnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 1),
            DisconnectTimestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 2),
            Error = AsduElement.DecodeOptional<ErrorCodec, T::Error>(ref reader, 3),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 4)
        };
    }

    public static T::ScHubConnection Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ScHubConnectionCodec, T::ScHubConnection>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ScHubConnection value)
    {
        AsduElement.Encode<ScConnectionStateCodec, T::ScConnectionState>(ref writer, 0, value.ConnectionState);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 1, value.ConnectTimestamp);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 2, value.DisconnectTimestamp);
        AsduElement.EncodeOptional<ErrorCodec, T::Error>(ref writer, 3, value.Error);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 4, value.ErrorDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ScHubConnection value)
        => AsduConstructed.Encode<ScHubConnectionCodec, T::ScHubConnection>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ScHubConnection value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ScConnectionStateCodec, T::ScConnectionState>(0, value.ConnectionState);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(1, value.ConnectTimestamp);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(2, value.DisconnectTimestamp);
        length += AsduElement.GetOptionalEncodedLength<ErrorCodec, T::Error>(3, value.Error);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(4, value.ErrorDetails);
        return length;
    }

    public static int GetEncodedLength(in T::ScHubConnection value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ScHubConnectionCodec, T::ScHubConnection>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
