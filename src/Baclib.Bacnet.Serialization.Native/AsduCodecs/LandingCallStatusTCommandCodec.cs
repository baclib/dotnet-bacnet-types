// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingCallStatusTCommandCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 1:
                var _direction = Asdu.DecodePrimitive<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.FromDirection(_direction);
            case 2:
                var _destination = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.FromDestination(_destination);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Direction:
                Asdu.EncodePrimitive<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(ref writer, 1, value.Direction);
                return;
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Destination:
                Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 2, value.Destination);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Direction:
                return Asdu.GetPrimitiveLength<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(1, value.Direction);
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Destination:
                return Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(2, value.Destination);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}