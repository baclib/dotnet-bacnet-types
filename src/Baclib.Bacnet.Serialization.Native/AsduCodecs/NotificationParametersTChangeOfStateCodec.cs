// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfStateCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState Decode(ref NativeReader reader)
    {
        var _newState = Asdu.DecodeConstructed<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState
        {
            NewState = _newState,
            StatusFlags = _statusFlags
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState value)
    {
        Asdu.EncodeElement<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref writer, 0, value.NewState);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState value)
    {
        return Asdu.GetElementLength<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(0, value.NewState) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
