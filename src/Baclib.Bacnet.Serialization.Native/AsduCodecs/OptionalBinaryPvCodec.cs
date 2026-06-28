// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalBinaryPvCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.BinaryPv:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryPv Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.FromNull(_null);
        }
        // info
        if (reader.PeekTag(BinaryPvCodec.TagNumber))
        {
            //var _binaryPv = Asdu.Decode<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(ref reader);
            var _binaryPv = BinaryPvCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.FromBinaryPv(_binaryPv);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryPv Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.BinaryPv:
                //Asdu.Encode<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(ref writer, value.BinaryPv);
                BinaryPvCodec.Encode(ref writer, value.BinaryPv);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.BinaryPv:
                return Asdu.GetEncodedLength<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(value.BinaryPv);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}