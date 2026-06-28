// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTBySequenceNumberCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(UnsignedCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber Decode(ref NativeReader reader)
    {
        var _referenceSequenceNumber = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader);
        var _count = Asdu.DecodePrimitive<Integer16Codec, short>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber
        {
            ReferenceSequenceNumber = _referenceSequenceNumber,
            Count = _count
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, value.ReferenceSequenceNumber);
        Asdu.EncodePrimitive<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber value)
    {
        return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.ReferenceSequenceNumber) + Asdu.GetEncodedLength<Integer16Codec, short>(value.Count);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TBySequenceNumber value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
