// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedTextMessageRequestTMessageClassCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>
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

    public static global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @numeric = UnsignedCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.FromNumeric(@numeric);
            case 1:
                var @character = CharacterStringCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.FromCharacter(@character);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Numeric:
                UnsignedCodec.Encode(ref writer, 0, value.Numeric);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Character:
                CharacterStringCodec.Encode(ref writer, 1, value.Character);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
        => AsduConstructed.Encode<ConfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Numeric
                => UnsignedCodec.GetEncodedLength(value.Numeric, 0),
            global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Character
                => CharacterStringCodec.GetEncodedLength(value.Character, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value, byte tagNumber)
        => AsduElement.GetEncodedLength<ConfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>(tagNumber, value);
}
