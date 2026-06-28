// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTDoubleOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange Decode(ref NativeReader reader)
    {
        var _exceedingValue = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _deadband = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 2);
        var _exceededLimit = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange
        {
            ExceedingValue = _exceedingValue,
            StatusFlags = _statusFlags,
            Deadband = _deadband,
            ExceededLimit = _exceededLimit
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange value)
    {
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 0, value.ExceedingValue);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 2, value.Deadband);
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 3, value.ExceededLimit);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange value)
    {
        return Asdu.GetPrimitiveLength<DoubleCodec, double>(0, value.ExceedingValue) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + Asdu.GetPrimitiveLength<DoubleCodec, double>(2, value.Deadband) + Asdu.GetPrimitiveLength<DoubleCodec, double>(3, value.ExceededLimit);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
