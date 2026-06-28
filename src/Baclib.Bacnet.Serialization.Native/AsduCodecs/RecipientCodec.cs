// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RecipientCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Recipient>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Recipient>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.Recipient Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _device = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.Recipient.FromDevice(_device);
            case 1:
                var _address = Asdu.DecodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.Recipient.FromAddress(_address);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.Recipient Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Recipient value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Device:
                Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.Device);
                return;
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Address:
                Asdu.EncodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 1, value.Address);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Recipient value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Recipient value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Device:
                return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.Device);
            case global::Baclib.Bacnet.Types.Application.Recipient.Option.Address:
                return Asdu.GetConstructedLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(1, value.Address);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Recipient value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}