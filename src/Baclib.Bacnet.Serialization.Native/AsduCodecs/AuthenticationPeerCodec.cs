// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationPeerCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationPeer>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationPeer>
{
    public static bool Matches(ref NativeReader reader)
    {
        return HostNPortCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationPeer Decode(ref NativeReader reader)
    {
        var _host = Asdu.DecodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref reader);
        var _device = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader);
        var _authAware = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);
        var _router = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);
        var _hub = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationPeer
        {
            Host = _host,
            Device = _device,
            AuthAware = _authAware,
            Router = _router,
            Hub = _hub
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationPeer Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationPeer value)
    {
        Asdu.EncodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref writer, value.Host);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, value.Device);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.AuthAware);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.Router);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.Hub);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationPeer value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationPeer value)
    {
        return Asdu.GetElementLength<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(value.Host) + Asdu.GetEncodedLength<Unsigned32Codec, uint>(value.Device) + Asdu.GetEncodedLength<BooleanCodec, bool>(value.AuthAware) + Asdu.GetEncodedLength<BooleanCodec, bool>(value.Router) + Asdu.GetEncodedLength<BooleanCodec, bool>(value.Hub);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationPeer value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
