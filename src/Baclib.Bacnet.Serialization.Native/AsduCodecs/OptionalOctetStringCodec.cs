// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalOctetStringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalOctetString>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalOctetString>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.OctetString:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.OptionalOctetString Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalOctetString.FromNull(_null);
        }
        // info
        if (reader.PeekTag(OctetStringCodec.TagNumber))
        {
            //var _octetstring = Asdu.Decode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
            var _octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalOctetString.FromOctetstring(_octetstring);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalOctetString Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Octetstring:
                //Asdu.Encode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.Octetstring);
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Octetstring:
                return Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.Octetstring);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.OptionalOctetString value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}