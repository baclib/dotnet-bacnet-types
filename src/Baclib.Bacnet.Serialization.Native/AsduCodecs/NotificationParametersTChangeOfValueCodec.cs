// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue Decode(ref NativeReader reader)
    {
        var _newValue = Asdu.DecodeConstructed<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue
        {
            NewValue = _newValue,
            StatusFlags = _statusFlags
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue value)
    {
        Asdu.EncodeElement<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(ref writer, 0, value.NewValue);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue value)
    {
        return Asdu.GetElementLength<NotificationParametersTChangeOfValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue.TNewValue>(0, value.NewValue) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
