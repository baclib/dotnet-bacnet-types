// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class HostAddressCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.HostAddress>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.HostAddress>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.HostAddress Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @none = NullCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromNone(@none);
            case 1:
                var @ipAddress = OctetStringCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromIpAddress(@ipAddress);
            case 2:
                var @name = CharacterStringCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.HostAddress.FromName(@name);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.HostAddress Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.HostAddress value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.None:
                NullCodec.Encode(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.IpAddress:
                OctetStringCodec.Encode(ref writer, 1, value.IpAddress);
                return;
            case global::Baclib.Bacnet.Types.Application.HostAddress.Option.Name:
                CharacterStringCodec.Encode(ref writer, 2, value.Name);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.HostAddress value)
        => AsduConstructed.Encode<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.HostAddress value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.HostAddress.Option.None
                => NullCodec.GetEncodedLength(value.None, 0),
            global::Baclib.Bacnet.Types.Application.HostAddress.Option.IpAddress
                => OctetStringCodec.GetEncodedLength(value.IpAddress, 1),
            global::Baclib.Bacnet.Types.Application.HostAddress.Option.Name
                => CharacterStringCodec.GetEncodedLength(value.Name, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.HostAddress value, byte tagNumber)
        => AsduElement.GetEncodedLength<HostAddressCodec, global::Baclib.Bacnet.Types.Application.HostAddress>(tagNumber, value);
}
