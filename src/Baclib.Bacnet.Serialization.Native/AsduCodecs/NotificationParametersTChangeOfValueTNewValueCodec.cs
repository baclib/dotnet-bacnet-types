// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfValueTNewValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>
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

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @changedBits = BitStringCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.FromChangedBits(@changedBits);
            case 1:
                var @changedValue = RealCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.FromChangedValue(@changedValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedBits:
                BitStringCodec.Encode(ref writer, 0, value.ChangedBits);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedValue:
                RealCodec.Encode(ref writer, 1, value.ChangedValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedBits
                => BitStringCodec.GetEncodedLength(value.ChangedBits, 0),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue.Option.ChangedValue
                => RealCodec.GetEncodedLength(value.ChangedValue, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(tagNumber, value);
}
