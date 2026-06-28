// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtOpenAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtOpenAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtOpenAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned8Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.VtOpenAck Decode(ref NativeReader reader)
    {
        var _remoteVtSessionIdentifier = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.VtOpenAck
        {
            RemoteVtSessionIdentifier = _remoteVtSessionIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtOpenAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtOpenAck value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, value.RemoteVtSessionIdentifier);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtOpenAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtOpenAck value)
    {
        return Asdu.GetEncodedLength<Unsigned8Codec, byte>(value.RemoteVtSessionIdentifier);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtOpenAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
