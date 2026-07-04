// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters>
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
            6 or
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
            19 or
            21 or
            22 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @changeOfBitstring = NotificationParametersTChangeOfBitstringCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfBitstring(@changeOfBitstring);
            case 1:
                var @changeOfState = NotificationParametersTChangeOfStateCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfState(@changeOfState);
            case 2:
                var @changeOfValue = NotificationParametersTChangeOfValueCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfValue(@changeOfValue);
            case 3:
                var @commandFailure = NotificationParametersTCommandFailureCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromCommandFailure(@commandFailure);
            case 4:
                var @floatingLimit = NotificationParametersTFloatingLimitCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromFloatingLimit(@floatingLimit);
            case 5:
                var @outOfRange = NotificationParametersTOutOfRangeCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromOutOfRange(@outOfRange);
            case 6:
                var @complexEventType = PropertyValueCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromComplexEventType(@complexEventType);
            case 8:
                var @changeOfLifeSafety = NotificationParametersTChangeOfLifeSafetyCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfLifeSafety(@changeOfLifeSafety);
            case 9:
                var @extended = NotificationParametersTExtendedCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromExtended(@extended);
            case 10:
                var @bufferReady = NotificationParametersTBufferReadyCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromBufferReady(@bufferReady);
            case 11:
                var @unsignedRange = NotificationParametersTUnsignedRangeCodec.Decode(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromUnsignedRange(@unsignedRange);
            case 13:
                var @accessEvent = NotificationParametersTAccessEventCodec.Decode(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromAccessEvent(@accessEvent);
            case 14:
                var @doubleOutOfRange = NotificationParametersTDoubleOutOfRangeCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromDoubleOutOfRange(@doubleOutOfRange);
            case 15:
                var @signedOutOfRange = NotificationParametersTSignedOutOfRangeCodec.Decode(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromSignedOutOfRange(@signedOutOfRange);
            case 16:
                var @unsignedOutOfRange = NotificationParametersTUnsignedOutOfRangeCodec.Decode(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromUnsignedOutOfRange(@unsignedOutOfRange);
            case 17:
                var @changeOfCharacterstring = NotificationParametersTChangeOfCharacterstringCodec.Decode(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfCharacterstring(@changeOfCharacterstring);
            case 18:
                var @changeOfStatusFlags = NotificationParametersTChangeOfStatusFlagsCodec.Decode(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfStatusFlags(@changeOfStatusFlags);
            case 19:
                var @changeOfReliability = NotificationParametersTChangeOfReliabilityCodec.Decode(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfReliability(@changeOfReliability);
            case 21:
                var @changeOfDiscreteValue = NotificationParametersTChangeOfDiscreteValueCodec.Decode(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfDiscreteValue(@changeOfDiscreteValue);
            case 22:
                var @changeOfTimer = NotificationParametersTChangeOfTimerCodec.Decode(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfTimer(@changeOfTimer);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfBitstring:
                NotificationParametersTChangeOfBitstringCodec.Encode(ref writer, 0, value.ChangeOfBitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfState:
                NotificationParametersTChangeOfStateCodec.Encode(ref writer, 1, value.ChangeOfState);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfValue:
                NotificationParametersTChangeOfValueCodec.Encode(ref writer, 2, value.ChangeOfValue);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.CommandFailure:
                NotificationParametersTCommandFailureCodec.Encode(ref writer, 3, value.CommandFailure);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.FloatingLimit:
                NotificationParametersTFloatingLimitCodec.Encode(ref writer, 4, value.FloatingLimit);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.OutOfRange:
                NotificationParametersTOutOfRangeCodec.Encode(ref writer, 5, value.OutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ComplexEventType:
                PropertyValueCodec.Encode(ref writer, 6, value.ComplexEventType);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfLifeSafety:
                NotificationParametersTChangeOfLifeSafetyCodec.Encode(ref writer, 8, value.ChangeOfLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.Extended:
                NotificationParametersTExtendedCodec.Encode(ref writer, 9, value.Extended);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.BufferReady:
                NotificationParametersTBufferReadyCodec.Encode(ref writer, 10, value.BufferReady);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedRange:
                NotificationParametersTUnsignedRangeCodec.Encode(ref writer, 11, value.UnsignedRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.AccessEvent:
                NotificationParametersTAccessEventCodec.Encode(ref writer, 13, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.DoubleOutOfRange:
                NotificationParametersTDoubleOutOfRangeCodec.Encode(ref writer, 14, value.DoubleOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.SignedOutOfRange:
                NotificationParametersTSignedOutOfRangeCodec.Encode(ref writer, 15, value.SignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedOutOfRange:
                NotificationParametersTUnsignedOutOfRangeCodec.Encode(ref writer, 16, value.UnsignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfCharacterstring:
                NotificationParametersTChangeOfCharacterstringCodec.Encode(ref writer, 17, value.ChangeOfCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfStatusFlags:
                NotificationParametersTChangeOfStatusFlagsCodec.Encode(ref writer, 18, value.ChangeOfStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfReliability:
                NotificationParametersTChangeOfReliabilityCodec.Encode(ref writer, 19, value.ChangeOfReliability);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfDiscreteValue:
                NotificationParametersTChangeOfDiscreteValueCodec.Encode(ref writer, 21, value.ChangeOfDiscreteValue);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfTimer:
                NotificationParametersTChangeOfTimerCodec.Encode(ref writer, 22, value.ChangeOfTimer);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
        => AsduConstructed.Encode<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfBitstring
                => NotificationParametersTChangeOfBitstringCodec.GetEncodedLength(value.ChangeOfBitstring, 0),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfState
                => NotificationParametersTChangeOfStateCodec.GetEncodedLength(value.ChangeOfState, 1),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfValue
                => NotificationParametersTChangeOfValueCodec.GetEncodedLength(value.ChangeOfValue, 2),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.CommandFailure
                => NotificationParametersTCommandFailureCodec.GetEncodedLength(value.CommandFailure, 3),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.FloatingLimit
                => NotificationParametersTFloatingLimitCodec.GetEncodedLength(value.FloatingLimit, 4),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.OutOfRange
                => NotificationParametersTOutOfRangeCodec.GetEncodedLength(value.OutOfRange, 5),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ComplexEventType
                => PropertyValueCodec.GetEncodedLength(value.ComplexEventType, 6),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfLifeSafety
                => NotificationParametersTChangeOfLifeSafetyCodec.GetEncodedLength(value.ChangeOfLifeSafety, 8),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.Extended
                => NotificationParametersTExtendedCodec.GetEncodedLength(value.Extended, 9),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.BufferReady
                => NotificationParametersTBufferReadyCodec.GetEncodedLength(value.BufferReady, 10),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedRange
                => NotificationParametersTUnsignedRangeCodec.GetEncodedLength(value.UnsignedRange, 11),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.AccessEvent
                => NotificationParametersTAccessEventCodec.GetEncodedLength(value.AccessEvent, 13),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.DoubleOutOfRange
                => NotificationParametersTDoubleOutOfRangeCodec.GetEncodedLength(value.DoubleOutOfRange, 14),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.SignedOutOfRange
                => NotificationParametersTSignedOutOfRangeCodec.GetEncodedLength(value.SignedOutOfRange, 15),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedOutOfRange
                => NotificationParametersTUnsignedOutOfRangeCodec.GetEncodedLength(value.UnsignedOutOfRange, 16),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfCharacterstring
                => NotificationParametersTChangeOfCharacterstringCodec.GetEncodedLength(value.ChangeOfCharacterstring, 17),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfStatusFlags
                => NotificationParametersTChangeOfStatusFlagsCodec.GetEncodedLength(value.ChangeOfStatusFlags, 18),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfReliability
                => NotificationParametersTChangeOfReliabilityCodec.GetEncodedLength(value.ChangeOfReliability, 19),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfDiscreteValue
                => NotificationParametersTChangeOfDiscreteValueCodec.GetEncodedLength(value.ChangeOfDiscreteValue, 21),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfTimer
                => NotificationParametersTChangeOfTimerCodec.GetEncodedLength(value.ChangeOfTimer, 22),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters value, byte tagNumber)
        => AsduElement.GetEncodedLength<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(tagNumber, value);
}
