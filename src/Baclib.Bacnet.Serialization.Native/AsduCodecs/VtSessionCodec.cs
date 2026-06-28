// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtSessionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtSession>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtSession>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned8Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.VtSession Decode(ref NativeReader reader)
    {
        var _localVtSessionId = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader);
        var _remoteVtSessionId = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader);
        var _remoteVtAddress = Asdu.DecodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.VtSession
        {
            LocalVtSessionId = _localVtSessionId,
            RemoteVtSessionId = _remoteVtSessionId,
            RemoteVtAddress = _remoteVtAddress
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtSession Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtSession value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, value.LocalVtSessionId);
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, value.RemoteVtSessionId);
        Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, value.RemoteVtAddress);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtSession value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtSession value)
    {
        return Asdu.GetEncodedLength<Unsigned8Codec, byte>(value.LocalVtSessionId) + Asdu.GetEncodedLength<Unsigned8Codec, byte>(value.RemoteVtSessionId) + Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(value.RemoteVtAddress);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtSession value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
