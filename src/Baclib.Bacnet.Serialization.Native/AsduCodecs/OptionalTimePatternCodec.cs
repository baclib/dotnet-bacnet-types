// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalTimePatternCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalTimePattern>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalTimePattern>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.TimePattern:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.OptionalTimePattern Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalTimePattern.FromNull(_null);
        }
        // info
        if (reader.PeekTag(TimePatternCodec.TagNumber))
        {
            //var _timeepattern = Asdu.Decode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref reader);
            var _timeepattern = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalTimePattern.FromTimeepattern(_timeepattern);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalTimePattern Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalTimePattern value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalTimePattern.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalTimePattern.Option.Timeepattern:
                //Asdu.Encode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref writer, value.Timeepattern);
                TimePatternCodec.Encode(ref writer, value.Timeepattern);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalTimePattern value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalTimePattern value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalTimePattern.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.OptionalTimePattern.Option.Timeepattern:
                return Asdu.GetEncodedLength<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(value.Timeepattern);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalTimePattern value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}