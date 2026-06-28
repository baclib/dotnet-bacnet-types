// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter>
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
            case 7:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.FaultParameter Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _none = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromNone(_none);
            case 1:
                var _faultCharacterstring = Asdu.DecodeConstructed<FaultParameterTFaultCharacterstringCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultCharacterstring>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultCharacterstring(_faultCharacterstring);
            case 2:
                var _faultExtended = Asdu.DecodeConstructed<FaultParameterTFaultExtendedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultExtended(_faultExtended);
            case 3:
                var _faultLifeSafety = Asdu.DecodeConstructed<FaultParameterTFaultLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultLifeSafety(_faultLifeSafety);
            case 4:
                var _faultState = Asdu.DecodeConstructed<FaultParameterTFaultStateCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultState(_faultState);
            case 5:
                var _faultStatusFlags = Asdu.DecodeConstructed<FaultParameterTFaultStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultStatusFlags(_faultStatusFlags);
            case 6:
                var _faultOutOfRange = Asdu.DecodeConstructed<FaultParameterTFaultOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultOutOfRange(_faultOutOfRange);
            case 7:
                var _faultListed = Asdu.DecodeConstructed<FaultParameterTFaultListedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultListed>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultListed(_faultListed);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.None:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultCharacterstring:
                Asdu.EncodeConstructed<FaultParameterTFaultCharacterstringCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultCharacterstring>(ref writer, 1, value.FaultCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultExtended:
                Asdu.EncodeConstructed<FaultParameterTFaultExtendedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended>(ref writer, 2, value.FaultExtended);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultLifeSafety:
                Asdu.EncodeConstructed<FaultParameterTFaultLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety>(ref writer, 3, value.FaultLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultState:
                Asdu.EncodeConstructed<FaultParameterTFaultStateCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState>(ref writer, 4, value.FaultState);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultStatusFlags:
                Asdu.EncodeConstructed<FaultParameterTFaultStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags>(ref writer, 5, value.FaultStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultOutOfRange:
                Asdu.EncodeConstructed<FaultParameterTFaultOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange>(ref writer, 6, value.FaultOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultListed:
                Asdu.EncodeConstructed<FaultParameterTFaultListedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultListed>(ref writer, 7, value.FaultListed);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.None:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(0, value.None);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultCharacterstring:
                return Asdu.GetConstructedLength<FaultParameterTFaultCharacterstringCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultCharacterstring>(1, value.FaultCharacterstring);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultExtended:
                return Asdu.GetConstructedLength<FaultParameterTFaultExtendedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended>(2, value.FaultExtended);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultLifeSafety:
                return Asdu.GetConstructedLength<FaultParameterTFaultLifeSafetyCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety>(3, value.FaultLifeSafety);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultState:
                return Asdu.GetConstructedLength<FaultParameterTFaultStateCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState>(4, value.FaultState);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultStatusFlags:
                return Asdu.GetConstructedLength<FaultParameterTFaultStatusFlagsCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags>(5, value.FaultStatusFlags);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultOutOfRange:
                return Asdu.GetConstructedLength<FaultParameterTFaultOutOfRangeCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange>(6, value.FaultOutOfRange);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultListed:
                return Asdu.GetConstructedLength<FaultParameterTFaultListedCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultListed>(7, value.FaultListed);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}