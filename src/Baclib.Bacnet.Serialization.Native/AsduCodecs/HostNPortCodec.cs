// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class HostNPortCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.HostNPort>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.HostNPort>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.HostNPort Decode(ref NativeReader reader)
    {
        var _host = Asdu.DecodeConstructed<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(ref reader, 0);
        var _port = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.HostNPort
        {
            Host = _host,
            Port = _port
        };
    }

    public static global::Baclib.Bacnet.Types.Application.HostNPort Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.HostNPort value)
    {
        Asdu.EncodeElement<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(ref writer, 0, value.Host);
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 1, value.Port);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.HostNPort value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.HostNPort value)
    {
        return Asdu.GetElementLength<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(0, value.Host) + Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(1, value.Port);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.HostNPort value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
