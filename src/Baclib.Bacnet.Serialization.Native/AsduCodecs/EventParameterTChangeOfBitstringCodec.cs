// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfBitstringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _bitmask = Asdu.DecodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader, 1);
        var _listOfBitstringValues = Asdu.DecodeSequenceOf<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring
        {
            TimeDelay = _timeDelay,
            Bitmask = _bitmask,
            ListOfBitstringValues = _listOfBitstringValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, 1, value.Bitmask);
        writer.WriteOpeningTag(2);
        foreach (var item in value.ListOfBitstringValues)
        {
            Asdu.EncodeElement<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetPrimitiveLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(1, value.Bitmask) + (AsduLength.FromTagNumber((byte)2) + (value.ListOfBitstringValues.Items.Sum(static item => Asdu.GetElementLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(2, item))) + AsduLength.FromTagNumber((byte)2));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
