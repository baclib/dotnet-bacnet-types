// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalUnsignedCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalUnsigned>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalUnsigned>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.Unsigned:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.OptionalUnsigned Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalUnsigned.FromNull(_null);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalUnsigned.FromUnsigned(_unsigned);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalUnsigned Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}