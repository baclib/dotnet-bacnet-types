// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTFloatingLimitCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit Decode(ref NativeReader reader)
    {
        var _referenceValue = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _setpointValue = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
        var _errorLimit = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit
        {
            ReferenceValue = _referenceValue,
            StatusFlags = _statusFlags,
            SetpointValue = _setpointValue,
            ErrorLimit = _errorLimit
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit value)
    {
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 0, value.ReferenceValue);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.SetpointValue);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 3, value.ErrorLimit);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit value)
    {
        return Asdu.GetPrimitiveLength<RealCodec, float>(0, value.ReferenceValue) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + Asdu.GetPrimitiveLength<RealCodec, float>(2, value.SetpointValue) + Asdu.GetPrimitiveLength<RealCodec, float>(3, value.ErrorLimit);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
