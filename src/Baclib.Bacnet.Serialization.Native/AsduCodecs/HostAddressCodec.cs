// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class HostAddressCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.HostAddress>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.HostAddress>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.HostAddress Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _none = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromNone(_none);
            case 1:
                var _ipAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromIpAddress(_ipAddress);
            case 2:
                var _name = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromName(_name);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.HostAddress Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.HostAddress value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.None:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.IpAddress:
                Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 1, value.IpAddress);
                return;
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.Name:
                Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 2, value.Name);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.HostAddress value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.HostAddress value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.None:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(0, value.None);
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.IpAddress:
                return Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(1, value.IpAddress);
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.Name:
                return Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(2, value.Name);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.HostAddress value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}