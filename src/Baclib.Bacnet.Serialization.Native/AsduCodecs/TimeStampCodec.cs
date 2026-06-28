// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeStampCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimeStamp>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimeStamp>
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

    public static global::Baclib.Bacnet.Types.Application.TimeStamp Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _time = Asdu.DecodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromTime(_time);
            case 1:
                var _sequenceNumber = Asdu.DecodePrimitive<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromSequenceNumber(_sequenceNumber);
            case 2:
                var _datetime = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromDatetime(_datetime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.TimeStamp Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.TimeStamp value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Time:
                Asdu.EncodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, 0, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.SequenceNumber:
                Asdu.EncodePrimitive<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref writer, 1, value.SequenceNumber);
                return;
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Datetime:
                Asdu.EncodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.Datetime);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimeStamp value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeStamp value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Time:
                return Asdu.GetPrimitiveLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(0, value.Time);
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.SequenceNumber:
                return Asdu.GetPrimitiveLength<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(1, value.SequenceNumber);
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Datetime:
                return Asdu.GetConstructedLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.Datetime);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeStamp value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}