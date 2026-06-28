// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfCharacterstringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _listOfAlarmValues = Asdu.DecodeSequenceOf<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring
        {
            TimeDelay = _timeDelay,
            ListOfAlarmValues = _listOfAlarmValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        writer.WriteOpeningTag(1);
        foreach (var item in value.ListOfAlarmValues)
        {
            Asdu.EncodeElement<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + (AsduLength.FromTagNumber((byte)1) + (value.ListOfAlarmValues.Items.Sum(static item => Asdu.GetElementLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(1, item))) + AsduLength.FromTagNumber((byte)1));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
