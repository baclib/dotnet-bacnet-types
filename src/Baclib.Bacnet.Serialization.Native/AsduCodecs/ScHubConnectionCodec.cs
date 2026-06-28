// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScHubConnectionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ScHubConnection>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ScHubConnection>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ScHubConnection Decode(ref NativeReader reader)
    {
        var _connectionState = Asdu.DecodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref reader, 0);
        var _connectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 1);
        var _disconnectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
        var _error = Asdu.DecodeOptionalElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 3);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.ScHubConnection
        {
            ConnectionState = _connectionState,
            ConnectTimestamp = _connectTimestamp,
            DisconnectTimestamp = _disconnectTimestamp,
            Error = _error,
            ErrorDetails = _errorDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ScHubConnection Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ScHubConnection value)
    {
        Asdu.EncodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref writer, 0, value.ConnectionState);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 1, value.ConnectTimestamp);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.DisconnectTimestamp);
        if (value.Error.HasValue)
        {
            Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 3, value.Error.Value);
        }
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 4, value.ErrorDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ScHubConnection value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScHubConnection value)
    {
        return Asdu.GetPrimitiveLength<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(0, value.ConnectionState) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(1, value.ConnectTimestamp) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.DisconnectTimestamp) + (value.Error.HasValue ? Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(3, value.Error.Value) : 0) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(4, value.ErrorDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScHubConnection value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
