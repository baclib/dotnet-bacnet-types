// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScHubFunctionConnectionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection Decode(ref NativeReader reader)
    {
        var _connectionState = Asdu.DecodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref reader, 0);
        var _connectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 1);
        var _disconnectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
        var _peerAddress = Asdu.DecodeConstructed<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref reader, 3);
        var _peerVmac = Asdu.DecodePrimitive<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref reader, 4);
        var _peerUuid = Asdu.DecodePrimitive<ScHubFunctionConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerUuid>(ref reader, 5);
        var _error = Asdu.DecodeOptionalElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 6);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 7);

        return new global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection
        {
            ConnectionState = _connectionState,
            ConnectTimestamp = _connectTimestamp,
            DisconnectTimestamp = _disconnectTimestamp,
            PeerAddress = _peerAddress,
            PeerVmac = _peerVmac,
            PeerUuid = _peerUuid,
            Error = _error,
            ErrorDetails = _errorDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection value)
    {
        Asdu.EncodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref writer, 0, value.ConnectionState);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 1, value.ConnectTimestamp);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.DisconnectTimestamp);
        Asdu.EncodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref writer, 3, value.PeerAddress);
        Asdu.EncodePrimitive<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref writer, 4, value.PeerVmac);
        Asdu.EncodePrimitive<ScHubFunctionConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerUuid>(ref writer, 5, value.PeerUuid);
        if (value.Error.HasValue)
        {
            Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 6, value.Error.Value);
        }
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 7, value.ErrorDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection value)
    {
        return Asdu.GetPrimitiveLength<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(0, value.ConnectionState) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(1, value.ConnectTimestamp) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.DisconnectTimestamp) + Asdu.GetElementLength<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(3, value.PeerAddress) + Asdu.GetPrimitiveLength<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(4, value.PeerVmac) + Asdu.GetPrimitiveLength<ScHubFunctionConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerUuid>(5, value.PeerUuid) + (value.Error.HasValue ? Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(6, value.Error.Value) : 0) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(7, value.ErrorDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
