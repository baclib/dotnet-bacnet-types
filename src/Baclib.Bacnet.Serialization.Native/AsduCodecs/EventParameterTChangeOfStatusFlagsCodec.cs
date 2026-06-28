// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfStatusFlagsCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _selectedFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags
        {
            TimeDelay = _timeDelay,
            SelectedFlags = _selectedFlags
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.SelectedFlags);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.SelectedFlags);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
