// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeStampCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimeStamp>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimeStamp>
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
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.TimeStamp Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @time = TimeCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromTime(@time);
            case 1:
                var @sequenceNumber = TimeStampTSequenceNumberCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromSequenceNumber(@sequenceNumber);
            case 2:
                var @datetime = DateTimeCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.TimeStamp.FromDatetime(@datetime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.TimeStamp Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.TimeStamp value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Time:
                TimeCodec.Encode(ref writer, 0, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.SequenceNumber:
                TimeStampTSequenceNumberCodec.Encode(ref writer, 1, value.SequenceNumber);
                return;
            case global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Datetime:
                DateTimeCodec.Encode(ref writer, 2, value.Datetime);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimeStamp value)
        => AsduConstructed.Encode<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimeStamp value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Time
                => TimeCodec.GetEncodedLength(value.Time, 0),
            global::Baclib.Bacnet.Types.Application.TimeStamp.Option.SequenceNumber
                => TimeStampTSequenceNumberCodec.GetEncodedLength(value.SequenceNumber, 1),
            global::Baclib.Bacnet.Types.Application.TimeStamp.Option.Datetime
                => DateTimeCodec.GetEncodedLength(value.Datetime, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimeStamp value, byte tagNumber)
        => AsduElement.GetEncodedLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(tagNumber, value);
}
