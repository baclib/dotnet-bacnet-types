// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTByPositionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(UnsignedCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition Decode(ref NativeReader reader)
    {
        var _referenceIndex = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader);
        var _count = Asdu.DecodePrimitive<Integer16Codec, short>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition
        {
            ReferenceIndex = _referenceIndex,
            Count = _count
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, value.ReferenceIndex);
        Asdu.EncodePrimitive<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition value)
    {
        return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.ReferenceIndex) + Asdu.GetEncodedLength<Integer16Codec, short>(value.Count);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByPosition value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
