// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 8:
            case 9:
            case 10:
            case 11:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 21:
            case 22:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _changeOfBitstring = Asdu.DecodeConstructed<NotificationParametersTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfBitstring>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfBitstring(_changeOfBitstring);
            case 1:
                var _changeOfState = Asdu.DecodeConstructed<NotificationParametersTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfState(_changeOfState);
            case 2:
                var _changeOfValue = Asdu.DecodeConstructed<NotificationParametersTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfValue(_changeOfValue);
            case 3:
                var _commandFailure = Asdu.DecodeConstructed<NotificationParametersTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TCommandFailure>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromCommandFailure(_commandFailure);
            case 4:
                var _floatingLimit = Asdu.DecodeConstructed<NotificationParametersTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromFloatingLimit(_floatingLimit);
            case 5:
                var _outOfRange = Asdu.DecodeConstructed<NotificationParametersTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TOutOfRange>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromOutOfRange(_outOfRange);
            case 6:
                var _complexEventType = Asdu.DecodeConstructed<NotificationParametersTComplexEventTypeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TComplexEventType>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromComplexEventType(_complexEventType);
            case 8:
                var _changeOfLifeSafety = Asdu.DecodeConstructed<NotificationParametersTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfLifeSafety(_changeOfLifeSafety);
            case 9:
                var _extended = Asdu.DecodeConstructed<NotificationParametersTExtendedCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromExtended(_extended);
            case 10:
                var _bufferReady = Asdu.DecodeConstructed<NotificationParametersTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromBufferReady(_bufferReady);
            case 11:
                var _unsignedRange = Asdu.DecodeConstructed<NotificationParametersTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedRange>(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromUnsignedRange(_unsignedRange);
            case 13:
                var _accessEvent = Asdu.DecodeConstructed<NotificationParametersTAccessEventCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent>(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromAccessEvent(_accessEvent);
            case 14:
                var _doubleOutOfRange = Asdu.DecodeConstructed<NotificationParametersTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromDoubleOutOfRange(_doubleOutOfRange);
            case 15:
                var _signedOutOfRange = Asdu.DecodeConstructed<NotificationParametersTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange>(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromSignedOutOfRange(_signedOutOfRange);
            case 16:
                var _unsignedOutOfRange = Asdu.DecodeConstructed<NotificationParametersTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedOutOfRange>(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromUnsignedOutOfRange(_unsignedOutOfRange);
            case 17:
                var _changeOfCharacterstring = Asdu.DecodeConstructed<NotificationParametersTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfCharacterstring>(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfCharacterstring(_changeOfCharacterstring);
            case 18:
                var _changeOfStatusFlags = Asdu.DecodeConstructed<NotificationParametersTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfStatusFlags>(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfStatusFlags(_changeOfStatusFlags);
            case 19:
                var _changeOfReliability = Asdu.DecodeConstructed<NotificationParametersTChangeOfReliabilityCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability>(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfReliability(_changeOfReliability);
            case 21:
                var _changeOfDiscreteValue = Asdu.DecodeConstructed<NotificationParametersTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue>(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfDiscreteValue(_changeOfDiscreteValue);
            case 22:
                var _changeOfTimer = Asdu.DecodeConstructed<NotificationParametersTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer>(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.FromChangeOfTimer(_changeOfTimer);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfBitstring:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfBitstring>(ref writer, 0, value.ChangeOfBitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfState:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState>(ref writer, 1, value.ChangeOfState);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfValue:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue>(ref writer, 2, value.ChangeOfValue);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.CommandFailure:
                Asdu.EncodeConstructed<NotificationParametersTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TCommandFailure>(ref writer, 3, value.CommandFailure);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.FloatingLimit:
                Asdu.EncodeConstructed<NotificationParametersTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit>(ref writer, 4, value.FloatingLimit);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.OutOfRange:
                Asdu.EncodeConstructed<NotificationParametersTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TOutOfRange>(ref writer, 5, value.OutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ComplexEventType:
                Asdu.EncodeConstructed<NotificationParametersTComplexEventTypeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TComplexEventType>(ref writer, 6, value.ComplexEventType);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfLifeSafety:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety>(ref writer, 8, value.ChangeOfLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.Extended:
                Asdu.EncodeConstructed<NotificationParametersTExtendedCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended>(ref writer, 9, value.Extended);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.BufferReady:
                Asdu.EncodeConstructed<NotificationParametersTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady>(ref writer, 10, value.BufferReady);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedRange:
                Asdu.EncodeConstructed<NotificationParametersTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedRange>(ref writer, 11, value.UnsignedRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.AccessEvent:
                Asdu.EncodeConstructed<NotificationParametersTAccessEventCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent>(ref writer, 13, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.DoubleOutOfRange:
                Asdu.EncodeConstructed<NotificationParametersTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange>(ref writer, 14, value.DoubleOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.SignedOutOfRange:
                Asdu.EncodeConstructed<NotificationParametersTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange>(ref writer, 15, value.SignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedOutOfRange:
                Asdu.EncodeConstructed<NotificationParametersTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedOutOfRange>(ref writer, 16, value.UnsignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfCharacterstring:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfCharacterstring>(ref writer, 17, value.ChangeOfCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfStatusFlags:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfStatusFlags>(ref writer, 18, value.ChangeOfStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfReliability:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfReliabilityCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability>(ref writer, 19, value.ChangeOfReliability);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfDiscreteValue:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue>(ref writer, 21, value.ChangeOfDiscreteValue);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfTimer:
                Asdu.EncodeConstructed<NotificationParametersTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer>(ref writer, 22, value.ChangeOfTimer);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfBitstring:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfBitstring>(0, value.ChangeOfBitstring);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfState:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfState>(1, value.ChangeOfState);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfValue:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfValue>(2, value.ChangeOfValue);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.CommandFailure:
                return Asdu.GetConstructedLength<NotificationParametersTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TCommandFailure>(3, value.CommandFailure);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.FloatingLimit:
                return Asdu.GetConstructedLength<NotificationParametersTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TFloatingLimit>(4, value.FloatingLimit);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.OutOfRange:
                return Asdu.GetConstructedLength<NotificationParametersTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TOutOfRange>(5, value.OutOfRange);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ComplexEventType:
                return Asdu.GetConstructedLength<NotificationParametersTComplexEventTypeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TComplexEventType>(6, value.ComplexEventType);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfLifeSafety:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfLifeSafety>(8, value.ChangeOfLifeSafety);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.Extended:
                return Asdu.GetConstructedLength<NotificationParametersTExtendedCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended>(9, value.Extended);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.BufferReady:
                return Asdu.GetConstructedLength<NotificationParametersTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady>(10, value.BufferReady);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedRange:
                return Asdu.GetConstructedLength<NotificationParametersTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedRange>(11, value.UnsignedRange);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.AccessEvent:
                return Asdu.GetConstructedLength<NotificationParametersTAccessEventCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent>(13, value.AccessEvent);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.DoubleOutOfRange:
                return Asdu.GetConstructedLength<NotificationParametersTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TDoubleOutOfRange>(14, value.DoubleOutOfRange);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.SignedOutOfRange:
                return Asdu.GetConstructedLength<NotificationParametersTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TSignedOutOfRange>(15, value.SignedOutOfRange);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.UnsignedOutOfRange:
                return Asdu.GetConstructedLength<NotificationParametersTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TUnsignedOutOfRange>(16, value.UnsignedOutOfRange);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfCharacterstring:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfCharacterstring>(17, value.ChangeOfCharacterstring);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfStatusFlags:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfStatusFlags>(18, value.ChangeOfStatusFlags);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfReliability:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfReliabilityCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability>(19, value.ChangeOfReliability);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfDiscreteValue:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue>(21, value.ChangeOfDiscreteValue);
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.Option.ChangeOfTimer:
                return Asdu.GetConstructedLength<NotificationParametersTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer>(22, value.ChangeOfTimer);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}