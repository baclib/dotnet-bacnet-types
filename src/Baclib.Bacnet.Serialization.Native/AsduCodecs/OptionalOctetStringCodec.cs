// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalOctetStringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalOctetString>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalOctetString>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Null or
            ApplicationTagNumber.OctetString => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalOctetString Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalOctetString.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalOctetString.FromOctetstring(@octetstring);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalOctetString Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalOctetStringCodec, global::Baclib.Bacnet.Types.Application.OptionalOctetString>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
        => AsduConstructed.Encode<OptionalOctetStringCodec, global::Baclib.Bacnet.Types.Application.OptionalOctetString>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalOctetString value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalOctetString.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalOctetString value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalOctetStringCodec, global::Baclib.Bacnet.Types.Application.OptionalOctetString>(tagNumber, value);
}
