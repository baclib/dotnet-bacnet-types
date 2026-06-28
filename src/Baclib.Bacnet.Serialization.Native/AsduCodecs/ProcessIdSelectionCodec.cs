// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ProcessIdSelectionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ProcessIdSelection>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ProcessIdSelection>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Null:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ProcessIdSelection Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(Unsigned32Codec.TagNumber))
        {
            //var _processIdentifier = Asdu.Decode<Unsigned32Codec, uint>(ref reader);
            var _processIdentifier = Unsigned32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ProcessIdSelection.FromProcessIdentifier(_processIdentifier);
        }
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _nullValue = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _nullValue = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ProcessIdSelection.FromNullValue(_nullValue);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ProcessIdSelection Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.ProcessIdentifier:
                //Asdu.Encode<Unsigned32Codec, uint>(ref writer, value.ProcessIdentifier);
                Unsigned32Codec.Encode(ref writer, value.ProcessIdentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.NullValue:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.NullValue);
                NullCodec.Encode(ref writer, value.NullValue);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.ProcessIdentifier:
                return Asdu.GetEncodedLength<Unsigned32Codec, uint>(value.ProcessIdentifier);
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.NullValue:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.NullValue);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}