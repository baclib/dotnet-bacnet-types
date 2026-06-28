// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfLifeSafetyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety Decode(ref NativeReader reader)
    {
        var _newState = Asdu.DecodePrimitive<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref reader, 0);
        var _newMode = Asdu.DecodePrimitive<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(ref reader, 1);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 2);
        var _operationExpected = Asdu.DecodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety
        {
            NewState = _newState,
            NewMode = _newMode,
            StatusFlags = _statusFlags,
            OperationExpected = _operationExpected
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety value)
    {
        Asdu.EncodePrimitive<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref writer, 0, value.NewState);
        Asdu.EncodePrimitive<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(ref writer, 1, value.NewMode);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 2, value.StatusFlags);
        Asdu.EncodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref writer, 3, value.OperationExpected);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety value)
    {
        return Asdu.GetPrimitiveLength<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(0, value.NewState) + Asdu.GetPrimitiveLength<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(1, value.NewMode) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(2, value.StatusFlags) + Asdu.GetPrimitiveLength<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(3, value.OperationExpected);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
