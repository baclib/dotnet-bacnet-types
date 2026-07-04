// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter>
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
            1 or
            2 or
            3 or
            4 or
            5 or
            8 or
            9 or
            10 or
            11 or
            13 or
            14 or
            15 or
            16 or
            17 or
            18 or
            20 or
            21 or
            22 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @changeOfBitstring = EventParameterTChangeOfBitstringCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfBitstring(@changeOfBitstring);
            case 1:
                var @changeOfState = EventParameterTChangeOfStateCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfState(@changeOfState);
            case 2:
                var @changeOfValue = EventParameterTChangeOfValueCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfValue(@changeOfValue);
            case 3:
                var @commandFailure = EventParameterTCommandFailureCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromCommandFailure(@commandFailure);
            case 4:
                var @floatingLimit = EventParameterTFloatingLimitCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromFloatingLimit(@floatingLimit);
            case 5:
                var @outOfRange = EventParameterTOutOfRangeCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromOutOfRange(@outOfRange);
            case 8:
                var @changeOfLifeSafety = EventParameterTChangeOfLifeSafetyCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfLifeSafety(@changeOfLifeSafety);
            case 9:
                var @extended = EventParameterTExtendedCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromExtended(@extended);
            case 10:
                var @bufferReady = EventParameterTBufferReadyCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromBufferReady(@bufferReady);
            case 11:
                var @unsignedRange = EventParameterTUnsignedRangeCodec.Decode(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromUnsignedRange(@unsignedRange);
            case 13:
                var @accessEvent = EventParameterTAccessEventCodec.Decode(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromAccessEvent(@accessEvent);
            case 14:
                var @doubleOutOfRange = EventParameterTDoubleOutOfRangeCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromDoubleOutOfRange(@doubleOutOfRange);
            case 15:
                var @signedOutOfRange = EventParameterTSignedOutOfRangeCodec.Decode(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromSignedOutOfRange(@signedOutOfRange);
            case 16:
                var @unsignedOutOfRange = EventParameterTUnsignedOutOfRangeCodec.Decode(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromUnsignedOutOfRange(@unsignedOutOfRange);
            case 17:
                var @changeOfCharacterstring = EventParameterTChangeOfCharacterstringCodec.Decode(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfCharacterstring(@changeOfCharacterstring);
            case 18:
                var @changeOfStatusFlags = EventParameterTChangeOfStatusFlagsCodec.Decode(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfStatusFlags(@changeOfStatusFlags);
            case 20:
                var @none = NullCodec.Decode(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromNone(@none);
            case 21:
                var @changeOfDiscreteValue = EventParameterTChangeOfDiscreteValueCodec.Decode(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfDiscreteValue(@changeOfDiscreteValue);
            case 22:
                var @changeOfTimer = EventParameterTChangeOfTimerCodec.Decode(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfTimer(@changeOfTimer);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterCodec, global::Baclib.Bacnet.Types.Application.EventParameter>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfBitstring:
                EventParameterTChangeOfBitstringCodec.Encode(ref writer, 0, value.ChangeOfBitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfState:
                EventParameterTChangeOfStateCodec.Encode(ref writer, 1, value.ChangeOfState);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfValue:
                EventParameterTChangeOfValueCodec.Encode(ref writer, 2, value.ChangeOfValue);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.CommandFailure:
                EventParameterTCommandFailureCodec.Encode(ref writer, 3, value.CommandFailure);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.FloatingLimit:
                EventParameterTFloatingLimitCodec.Encode(ref writer, 4, value.FloatingLimit);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.OutOfRange:
                EventParameterTOutOfRangeCodec.Encode(ref writer, 5, value.OutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfLifeSafety:
                EventParameterTChangeOfLifeSafetyCodec.Encode(ref writer, 8, value.ChangeOfLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.Extended:
                EventParameterTExtendedCodec.Encode(ref writer, 9, value.Extended);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.BufferReady:
                EventParameterTBufferReadyCodec.Encode(ref writer, 10, value.BufferReady);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedRange:
                EventParameterTUnsignedRangeCodec.Encode(ref writer, 11, value.UnsignedRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.AccessEvent:
                EventParameterTAccessEventCodec.Encode(ref writer, 13, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.DoubleOutOfRange:
                EventParameterTDoubleOutOfRangeCodec.Encode(ref writer, 14, value.DoubleOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.SignedOutOfRange:
                EventParameterTSignedOutOfRangeCodec.Encode(ref writer, 15, value.SignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedOutOfRange:
                EventParameterTUnsignedOutOfRangeCodec.Encode(ref writer, 16, value.UnsignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfCharacterstring:
                EventParameterTChangeOfCharacterstringCodec.Encode(ref writer, 17, value.ChangeOfCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfStatusFlags:
                EventParameterTChangeOfStatusFlagsCodec.Encode(ref writer, 18, value.ChangeOfStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.None:
                NullCodec.Encode(ref writer, 20, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfDiscreteValue:
                EventParameterTChangeOfDiscreteValueCodec.Encode(ref writer, 21, value.ChangeOfDiscreteValue);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfTimer:
                EventParameterTChangeOfTimerCodec.Encode(ref writer, 22, value.ChangeOfTimer);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter value)
        => AsduConstructed.Encode<EventParameterCodec, global::Baclib.Bacnet.Types.Application.EventParameter>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfBitstring
                => EventParameterTChangeOfBitstringCodec.GetEncodedLength(value.ChangeOfBitstring, 0),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfState
                => EventParameterTChangeOfStateCodec.GetEncodedLength(value.ChangeOfState, 1),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfValue
                => EventParameterTChangeOfValueCodec.GetEncodedLength(value.ChangeOfValue, 2),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.CommandFailure
                => EventParameterTCommandFailureCodec.GetEncodedLength(value.CommandFailure, 3),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.FloatingLimit
                => EventParameterTFloatingLimitCodec.GetEncodedLength(value.FloatingLimit, 4),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.OutOfRange
                => EventParameterTOutOfRangeCodec.GetEncodedLength(value.OutOfRange, 5),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfLifeSafety
                => EventParameterTChangeOfLifeSafetyCodec.GetEncodedLength(value.ChangeOfLifeSafety, 8),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.Extended
                => EventParameterTExtendedCodec.GetEncodedLength(value.Extended, 9),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.BufferReady
                => EventParameterTBufferReadyCodec.GetEncodedLength(value.BufferReady, 10),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedRange
                => EventParameterTUnsignedRangeCodec.GetEncodedLength(value.UnsignedRange, 11),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.AccessEvent
                => EventParameterTAccessEventCodec.GetEncodedLength(value.AccessEvent, 13),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.DoubleOutOfRange
                => EventParameterTDoubleOutOfRangeCodec.GetEncodedLength(value.DoubleOutOfRange, 14),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.SignedOutOfRange
                => EventParameterTSignedOutOfRangeCodec.GetEncodedLength(value.SignedOutOfRange, 15),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedOutOfRange
                => EventParameterTUnsignedOutOfRangeCodec.GetEncodedLength(value.UnsignedOutOfRange, 16),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfCharacterstring
                => EventParameterTChangeOfCharacterstringCodec.GetEncodedLength(value.ChangeOfCharacterstring, 17),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfStatusFlags
                => EventParameterTChangeOfStatusFlagsCodec.GetEncodedLength(value.ChangeOfStatusFlags, 18),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.None
                => NullCodec.GetEncodedLength(value.None, 20),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfDiscreteValue
                => EventParameterTChangeOfDiscreteValueCodec.GetEncodedLength(value.ChangeOfDiscreteValue, 21),
            global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfTimer
                => EventParameterTChangeOfTimerCodec.GetEncodedLength(value.ChangeOfTimer, 22),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter value, byte tagNumber)
        => AsduElement.GetEncodedLength<EventParameterCodec, global::Baclib.Bacnet.Types.Application.EventParameter>(tagNumber, value);
}
