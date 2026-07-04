// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RecipientCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Recipient>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Recipient>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Recipient Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @device = ObjectIdentifierCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.Recipient.FromDevice(@device);
            case 1:
                var @address = AddressCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.Recipient.FromAddress(@address);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.Recipient Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.Recipient value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Device:
                ObjectIdentifierCodec.Encode(ref writer, 0, value.Device);
                return;
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Address:
                AddressCodec.Encode(ref writer, 1, value.Address);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Recipient value)
        => AsduConstructed.Encode<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.Recipient value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.Recipient.Option.Device
                => ObjectIdentifierCodec.GetEncodedLength(value.Device, 0),
            global::Baclib.Bacnet.Types.Application.Recipient.Option.Address
                => AddressCodec.GetEncodedLength(value.Address, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.Recipient value, byte tagNumber)
        => AsduElement.GetEncodedLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(tagNumber, value);
}
