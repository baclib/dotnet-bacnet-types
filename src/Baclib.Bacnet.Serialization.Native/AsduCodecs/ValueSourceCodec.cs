// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ValueSourceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ValueSource>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ValueSource>
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

    public static global::Baclib.Bacnet.Types.Application.ValueSource Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _none = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromNone(_none);
            case 1:
                var _object = Asdu.DecodeConstructed<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromObject(_object);
            case 2:
                var _address = Asdu.DecodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromAddress(_address);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ValueSource Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ValueSource value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.None:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Object:
                Asdu.EncodeConstructed<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref writer, 1, value.Object);
                return;
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Address:
                Asdu.EncodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 2, value.Address);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ValueSource value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ValueSource value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.None:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(0, value.None);
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Object:
                return Asdu.GetConstructedLength<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(1, value.Object);
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Address:
                return Asdu.GetConstructedLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(2, value.Address);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ValueSource value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}