// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTSignedOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange Decode(ref NativeReader reader)
    {
        var _exceedingValue = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _deadband = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _exceededLimit = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange
        {
            ExceedingValue = _exceedingValue,
            StatusFlags = _statusFlags,
            Deadband = _deadband,
            ExceededLimit = _exceededLimit
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange value)
    {
        Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 0, value.ExceedingValue);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.Deadband);
        Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 3, value.ExceededLimit);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange value)
    {
        return Asdu.GetPrimitiveLength<IntegerCodec, int>(0, value.ExceedingValue) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.Deadband) + Asdu.GetPrimitiveLength<IntegerCodec, int>(3, value.ExceededLimit);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
