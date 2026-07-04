// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            3 or
            6 or
            7 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 3:
                var @byPosition = ReadRangeRequestTRangeTByPositionCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromByPosition(@byPosition);
            case 6:
                var @bySequenceNumber = ReadRangeRequestTRangeTBySequenceNumberCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromBySequenceNumber(@bySequenceNumber);
            case 7:
                var @byTime = ReadRangeRequestTRangeTByTimeCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromByTime(@byTime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByPosition:
                ReadRangeRequestTRangeTByPositionCodec.Encode(ref writer, 3, value.ByPosition);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.BySequenceNumber:
                ReadRangeRequestTRangeTBySequenceNumberCodec.Encode(ref writer, 6, value.BySequenceNumber);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByTime:
                ReadRangeRequestTRangeTByTimeCodec.Encode(ref writer, 7, value.ByTime);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
        => AsduConstructed.Encode<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByPosition
                => ReadRangeRequestTRangeTByPositionCodec.GetEncodedLength(value.ByPosition, 3),
            global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.BySequenceNumber
                => ReadRangeRequestTRangeTBySequenceNumberCodec.GetEncodedLength(value.BySequenceNumber, 6),
            global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByTime
                => ReadRangeRequestTRangeTByTimeCodec.GetEncodedLength(value.ByTime, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value, byte tagNumber)
        => AsduElement.GetEncodedLength<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(tagNumber, value);
}
