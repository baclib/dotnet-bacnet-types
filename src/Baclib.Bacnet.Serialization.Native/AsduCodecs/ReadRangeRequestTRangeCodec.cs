// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 3:
            case 6:
            case 7:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 3:
                var _byPosition = Asdu.DecodeConstructed<ReadRangeRequestTRangeTByPositionCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromByPosition(_byPosition);
            case 6:
                var _bySequenceNumber = Asdu.DecodeConstructed<ReadRangeRequestTRangeTBySequenceNumberCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromBySequenceNumber(_bySequenceNumber);
            case 7:
                var _byTime = Asdu.DecodeConstructed<ReadRangeRequestTRangeTByTimeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.FromByTime(_byTime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByPosition:
                Asdu.EncodeConstructed<ReadRangeRequestTRangeTByPositionCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition>(ref writer, 3, value.ByPosition);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.BySequenceNumber:
                Asdu.EncodeConstructed<ReadRangeRequestTRangeTBySequenceNumberCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber>(ref writer, 6, value.BySequenceNumber);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByTime:
                Asdu.EncodeConstructed<ReadRangeRequestTRangeTByTimeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime>(ref writer, 7, value.ByTime);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByPosition:
                return Asdu.GetConstructedLength<ReadRangeRequestTRangeTByPositionCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition>(3, value.ByPosition);
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.BySequenceNumber:
                return Asdu.GetConstructedLength<ReadRangeRequestTRangeTBySequenceNumberCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber>(6, value.BySequenceNumber);
            case global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.Option.ByTime:
                return Asdu.GetConstructedLength<ReadRangeRequestTRangeTByTimeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime>(7, value.ByTime);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}