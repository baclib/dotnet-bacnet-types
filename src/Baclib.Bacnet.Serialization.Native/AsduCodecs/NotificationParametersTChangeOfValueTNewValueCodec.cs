// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfValueTNewValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>
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

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _changedBits = Asdu.DecodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.FromChangedBits(_changedBits);
            case 1:
                var _changedValue = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.FromChangedValue(_changedValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedBits:
                Asdu.EncodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, 0, value.ChangedBits);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedValue:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 1, value.ChangedValue);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedBits:
                return Asdu.GetPrimitiveLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(0, value.ChangedBits);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedValue:
                return Asdu.GetPrimitiveLength<RealCodec, float>(1, value.ChangedValue);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}