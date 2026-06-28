// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScFailedConnectionRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _peerAddress = Asdu.DecodeConstructed<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref reader, 1);
        var _peerVmac = Asdu.DecodeOptional<ScFailedConnectionRequestTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerVmac>(ref reader, 2);
        var _peerUuid = Asdu.DecodeOptional<ScFailedConnectionRequestTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerUuid>(ref reader, 3);
        var _error = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 4);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest
        {
            Timestamp = _timestamp,
            PeerAddress = _peerAddress,
            PeerVmac = _peerVmac,
            PeerUuid = _peerUuid,
            Error = _error,
            ErrorDetails = _errorDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref writer, 1, value.PeerAddress);
        if (value.PeerVmac.HasValue)
        {
            Asdu.EncodePrimitive<ScFailedConnectionRequestTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerVmac>(ref writer, 2, value.PeerVmac.Value);
        }
        if (value.PeerUuid.HasValue)
        {
            Asdu.EncodePrimitive<ScFailedConnectionRequestTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerUuid>(ref writer, 3, value.PeerUuid.Value);
        }
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 4, value.Error);
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 5, value.ErrorDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(1, value.PeerAddress) + (value.PeerVmac.HasValue ? Asdu.GetPrimitiveLength<ScFailedConnectionRequestTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerVmac>(2, value.PeerVmac.Value) : 0) + (value.PeerUuid.HasValue ? Asdu.GetPrimitiveLength<ScFailedConnectionRequestTPeerUuidCodec, global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest.TPeerUuid>(3, value.PeerUuid.Value) : 0) + Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(4, value.Error) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(5, value.ErrorDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ScFailedConnectionRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
