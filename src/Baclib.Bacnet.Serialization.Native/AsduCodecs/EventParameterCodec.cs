// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter>
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
            case 20:
            case 21:
            case 22:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.EventParameter Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _changeOfBitstring = Asdu.DecodeConstructed<EventParameterTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfBitstring(_changeOfBitstring);
            case 1:
                var _changeOfState = Asdu.DecodeConstructed<EventParameterTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfState>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfState(_changeOfState);
            case 2:
                var _changeOfValue = Asdu.DecodeConstructed<EventParameterTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfValue(_changeOfValue);
            case 3:
                var _commandFailure = Asdu.DecodeConstructed<EventParameterTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TCommandFailure>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromCommandFailure(_commandFailure);
            case 4:
                var _floatingLimit = Asdu.DecodeConstructed<EventParameterTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromFloatingLimit(_floatingLimit);
            case 5:
                var _outOfRange = Asdu.DecodeConstructed<EventParameterTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromOutOfRange(_outOfRange);
            case 8:
                var _changeOfLifeSafety = Asdu.DecodeConstructed<EventParameterTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfLifeSafety(_changeOfLifeSafety);
            case 9:
                var _extended = Asdu.DecodeConstructed<EventParameterTExtendedCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromExtended(_extended);
            case 10:
                var _bufferReady = Asdu.DecodeConstructed<EventParameterTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromBufferReady(_bufferReady);
            case 11:
                var _unsignedRange = Asdu.DecodeConstructed<EventParameterTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedRange>(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromUnsignedRange(_unsignedRange);
            case 13:
                var _accessEvent = Asdu.DecodeConstructed<EventParameterTAccessEventCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent>(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromAccessEvent(_accessEvent);
            case 14:
                var _doubleOutOfRange = Asdu.DecodeConstructed<EventParameterTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromDoubleOutOfRange(_doubleOutOfRange);
            case 15:
                var _signedOutOfRange = Asdu.DecodeConstructed<EventParameterTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TSignedOutOfRange>(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromSignedOutOfRange(_signedOutOfRange);
            case 16:
                var _unsignedOutOfRange = Asdu.DecodeConstructed<EventParameterTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange>(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromUnsignedOutOfRange(_unsignedOutOfRange);
            case 17:
                var _changeOfCharacterstring = Asdu.DecodeConstructed<EventParameterTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring>(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfCharacterstring(_changeOfCharacterstring);
            case 18:
                var _changeOfStatusFlags = Asdu.DecodeConstructed<EventParameterTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags>(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfStatusFlags(_changeOfStatusFlags);
            case 20:
                var _none = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromNone(_none);
            case 21:
                var _changeOfDiscreteValue = Asdu.DecodeConstructed<EventParameterTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue>(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfDiscreteValue(_changeOfDiscreteValue);
            case 22:
                var _changeOfTimer = Asdu.DecodeConstructed<EventParameterTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer>(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.EventParameter.FromChangeOfTimer(_changeOfTimer);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfBitstring:
                Asdu.EncodeConstructed<EventParameterTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring>(ref writer, 0, value.ChangeOfBitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfState:
                Asdu.EncodeConstructed<EventParameterTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfState>(ref writer, 1, value.ChangeOfState);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfValue:
                Asdu.EncodeConstructed<EventParameterTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue>(ref writer, 2, value.ChangeOfValue);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.CommandFailure:
                Asdu.EncodeConstructed<EventParameterTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TCommandFailure>(ref writer, 3, value.CommandFailure);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.FloatingLimit:
                Asdu.EncodeConstructed<EventParameterTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit>(ref writer, 4, value.FloatingLimit);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.OutOfRange:
                Asdu.EncodeConstructed<EventParameterTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange>(ref writer, 5, value.OutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfLifeSafety:
                Asdu.EncodeConstructed<EventParameterTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety>(ref writer, 8, value.ChangeOfLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.Extended:
                Asdu.EncodeConstructed<EventParameterTExtendedCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended>(ref writer, 9, value.Extended);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.BufferReady:
                Asdu.EncodeConstructed<EventParameterTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady>(ref writer, 10, value.BufferReady);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedRange:
                Asdu.EncodeConstructed<EventParameterTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedRange>(ref writer, 11, value.UnsignedRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.AccessEvent:
                Asdu.EncodeConstructed<EventParameterTAccessEventCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent>(ref writer, 13, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.DoubleOutOfRange:
                Asdu.EncodeConstructed<EventParameterTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange>(ref writer, 14, value.DoubleOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.SignedOutOfRange:
                Asdu.EncodeConstructed<EventParameterTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TSignedOutOfRange>(ref writer, 15, value.SignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedOutOfRange:
                Asdu.EncodeConstructed<EventParameterTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange>(ref writer, 16, value.UnsignedOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfCharacterstring:
                Asdu.EncodeConstructed<EventParameterTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring>(ref writer, 17, value.ChangeOfCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfStatusFlags:
                Asdu.EncodeConstructed<EventParameterTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags>(ref writer, 18, value.ChangeOfStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.None:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 20, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfDiscreteValue:
                Asdu.EncodeConstructed<EventParameterTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue>(ref writer, 21, value.ChangeOfDiscreteValue);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfTimer:
                Asdu.EncodeConstructed<EventParameterTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer>(ref writer, 22, value.ChangeOfTimer);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfBitstring:
                return Asdu.GetConstructedLength<EventParameterTChangeOfBitstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfBitstring>(0, value.ChangeOfBitstring);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfState:
                return Asdu.GetConstructedLength<EventParameterTChangeOfStateCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfState>(1, value.ChangeOfState);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfValue:
                return Asdu.GetConstructedLength<EventParameterTChangeOfValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue>(2, value.ChangeOfValue);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.CommandFailure:
                return Asdu.GetConstructedLength<EventParameterTCommandFailureCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TCommandFailure>(3, value.CommandFailure);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.FloatingLimit:
                return Asdu.GetConstructedLength<EventParameterTFloatingLimitCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit>(4, value.FloatingLimit);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.OutOfRange:
                return Asdu.GetConstructedLength<EventParameterTOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange>(5, value.OutOfRange);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfLifeSafety:
                return Asdu.GetConstructedLength<EventParameterTChangeOfLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety>(8, value.ChangeOfLifeSafety);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.Extended:
                return Asdu.GetConstructedLength<EventParameterTExtendedCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended>(9, value.Extended);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.BufferReady:
                return Asdu.GetConstructedLength<EventParameterTBufferReadyCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady>(10, value.BufferReady);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedRange:
                return Asdu.GetConstructedLength<EventParameterTUnsignedRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedRange>(11, value.UnsignedRange);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.AccessEvent:
                return Asdu.GetConstructedLength<EventParameterTAccessEventCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent>(13, value.AccessEvent);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.DoubleOutOfRange:
                return Asdu.GetConstructedLength<EventParameterTDoubleOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange>(14, value.DoubleOutOfRange);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.SignedOutOfRange:
                return Asdu.GetConstructedLength<EventParameterTSignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TSignedOutOfRange>(15, value.SignedOutOfRange);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.UnsignedOutOfRange:
                return Asdu.GetConstructedLength<EventParameterTUnsignedOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange>(16, value.UnsignedOutOfRange);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfCharacterstring:
                return Asdu.GetConstructedLength<EventParameterTChangeOfCharacterstringCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfCharacterstring>(17, value.ChangeOfCharacterstring);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfStatusFlags:
                return Asdu.GetConstructedLength<EventParameterTChangeOfStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfStatusFlags>(18, value.ChangeOfStatusFlags);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.None:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(20, value.None);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfDiscreteValue:
                return Asdu.GetConstructedLength<EventParameterTChangeOfDiscreteValueCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue>(21, value.ChangeOfDiscreteValue);
            case global::Baclib.Bacnet.Types.Application.EventParameter.Option.ChangeOfTimer:
                return Asdu.GetConstructedLength<EventParameterTChangeOfTimerCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer>(22, value.ChangeOfTimer);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}