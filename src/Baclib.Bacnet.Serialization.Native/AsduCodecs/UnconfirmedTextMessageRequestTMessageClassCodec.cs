// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedTextMessageRequestTMessageClassCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @numeric = UnsignedCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.FromNumeric(@numeric);
            case 1:
                var @character = CharacterStringCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.FromCharacter(@character);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.Option.Numeric:
                UnsignedCodec.Encode(ref writer, 0, value.Numeric);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.Option.Character:
                CharacterStringCodec.Encode(ref writer, 1, value.Character);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass value)
        => AsduConstructed.Encode<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.Option.Numeric
                => UnsignedCodec.GetEncodedLength(value.Numeric, 0),
            global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass.Option.Character
                => CharacterStringCodec.GetEncodedLength(value.Character, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass value, byte tagNumber)
        => AsduElement.GetEncodedLength<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(tagNumber, value);
}
