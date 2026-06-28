// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedTextMessageRequestTMessageClassCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _numeric = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.FromNumeric(_numeric);
            case 1:
                var _character = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.FromCharacter(_character);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Numeric:
                Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.Numeric);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Character:
                Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 1, value.Character);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Numeric:
                return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.Numeric);
            case global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass.Option.Character:
                return Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(1, value.Character);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest.TMessageClass value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}