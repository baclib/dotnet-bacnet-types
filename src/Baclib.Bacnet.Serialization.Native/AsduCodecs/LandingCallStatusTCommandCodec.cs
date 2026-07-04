// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingCallStatusTCommandCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 1:
                var @direction = LiftCarDirectionCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.FromDirection(@direction);
            case 2:
                var @destination = Unsigned8Codec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.FromDestination(@destination);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Direction:
                LiftCarDirectionCodec.Encode(ref writer, 1, value.Direction);
                return;
            case global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Destination:
                Unsigned8Codec.Encode(ref writer, 2, value.Destination);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
        => AsduConstructed.Encode<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Direction
                => LiftCarDirectionCodec.GetEncodedLength(value.Direction, 1),
            global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand.Option.Destination
                => Unsigned8Codec.GetEncodedLength(value.Destination, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand value, byte tagNumber)
        => AsduElement.GetEncodedLength<LandingCallStatusTCommandCodec, global::Baclib.Bacnet.Types.Application.LandingCallStatus.TCommand>(tagNumber, value);
}
