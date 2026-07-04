// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalCharacterStringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalCharacterString>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalCharacterString>
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
            ApplicationTagNumber.CharacterString => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalCharacterString Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalCharacterString.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalCharacterString.FromCharacterstring(@characterstring);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalCharacterString Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalCharacterStringCodec, global::Baclib.Bacnet.Types.Application.OptionalCharacterString>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalCharacterString value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalCharacterString.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalCharacterString.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalCharacterString value)
        => AsduConstructed.Encode<OptionalCharacterStringCodec, global::Baclib.Bacnet.Types.Application.OptionalCharacterString>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalCharacterString value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalCharacterString.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalCharacterString.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalCharacterString value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalCharacterStringCodec, global::Baclib.Bacnet.Types.Application.OptionalCharacterString>(tagNumber, value);
}
