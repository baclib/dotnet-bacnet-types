// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScDirectConnectionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ScDirectConnection>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ScDirectConnection>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ScDirectConnection Decode(ref NativeReader reader)
    {
        var _uri = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 0);
        var _connectionState = Asdu.DecodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref reader, 1);
        var _connectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
        var _disconnectTimestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 3);
        var _peerAddress = Asdu.DecodeOptionalElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref reader, 4);
        var _peerVmac = Asdu.DecodeOptional<ScDirectConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerVmac>(ref reader, 5);
        var _peerUuid = Asdu.DecodeOptional<ScDirectConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerUuid>(ref reader, 6);
        var _error = Asdu.DecodeOptionalElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 7);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 8);

        return new global::Baclib.Bacnet.Types.Application.ScDirectConnection
        {
            Uri = _uri,
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

    public static global::Baclib.Bacnet.Types.Application.ScDirectConnection Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ScDirectConnection value)
    {
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 0, value.Uri);
        Asdu.EncodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref writer, 1, value.ConnectionState);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.ConnectTimestamp);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 3, value.DisconnectTimestamp);
        if (value.PeerAddress.HasValue)
        {
            Asdu.EncodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref writer, 4, value.PeerAddress.Value);
        }
        if (value.PeerVmac.HasValue)
        {
            Asdu.EncodePrimitive<ScDirectConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerVmac>(ref writer, 5, value.PeerVmac.Value);
        }
        if (value.PeerUuid.HasValue)
        {
            Asdu.EncodePrimitive<ScDirectConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerUuid>(ref writer, 6, value.PeerUuid.Value);
        }
        if (value.Error.HasValue)
        {
            Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 7, value.Error.Value);
        }
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 8, value.ErrorDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ScDirectConnection value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScDirectConnection value)
    {
        return Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(0, value.Uri) + Asdu.GetPrimitiveLength<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(1, value.ConnectionState) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.ConnectTimestamp) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(3, value.DisconnectTimestamp) + (value.PeerAddress.HasValue ? Asdu.GetElementLength<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(4, value.PeerAddress.Value) : 0) + (value.PeerVmac.HasValue ? Asdu.GetPrimitiveLength<ScDirectConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerVmac>(5, value.PeerVmac.Value) : 0) + (value.PeerUuid.HasValue ? Asdu.GetPrimitiveLength<ScDirectConnectionTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScDirectConnection.TPeerUuid>(6, value.PeerUuid.Value) : 0) + (value.Error.HasValue ? Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(7, value.Error.Value) : 0) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(8, value.ErrorDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScDirectConnection value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
