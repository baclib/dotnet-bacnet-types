// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingCallStatusCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus Decode(ref NativeReader reader)
    {
        var _floorNumber = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 0);
        var _command = Asdu.DecodeElement<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(ref reader);
        var _floorText = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.LandingCallStatus
        {
            FloorNumber = _floorNumber,
            Command = _command,
            FloorText = _floorText
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LandingCallStatus value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 0, value.FloorNumber);
        Asdu.EncodeElement<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(ref writer, value.Command);
        if (value.FloorText.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 3, value.FloorText.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LandingCallStatus value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus value)
    {
        return Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(0, value.FloorNumber) + Asdu.GetElementLength<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(value.Command) + (value.FloorText.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(3, value.FloorText.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
