// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter>
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
            7 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @none = NullCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromNone(@none);
            case 1:
                var @faultCharacterstring = FaultParameterTFaultCharacterstringCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultCharacterstring(@faultCharacterstring);
            case 2:
                var @faultExtended = FaultParameterTFaultExtendedCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultExtended(@faultExtended);
            case 3:
                var @faultLifeSafety = FaultParameterTFaultLifeSafetyCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultLifeSafety(@faultLifeSafety);
            case 4:
                var @faultState = FaultParameterTFaultStateCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultState(@faultState);
            case 5:
                var @faultStatusFlags = FaultParameterTFaultStatusFlagsCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultStatusFlags(@faultStatusFlags);
            case 6:
                var @faultOutOfRange = FaultParameterTFaultOutOfRangeCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultOutOfRange(@faultOutOfRange);
            case 7:
                var @faultListed = FaultParameterTFaultListedCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.FromFaultListed(@faultListed);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterCodec, global::Baclib.Bacnet.Types.Application.FaultParameter>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.None:
                NullCodec.Encode(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultCharacterstring:
                FaultParameterTFaultCharacterstringCodec.Encode(ref writer, 1, value.FaultCharacterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultExtended:
                FaultParameterTFaultExtendedCodec.Encode(ref writer, 2, value.FaultExtended);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultLifeSafety:
                FaultParameterTFaultLifeSafetyCodec.Encode(ref writer, 3, value.FaultLifeSafety);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultState:
                FaultParameterTFaultStateCodec.Encode(ref writer, 4, value.FaultState);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultStatusFlags:
                FaultParameterTFaultStatusFlagsCodec.Encode(ref writer, 5, value.FaultStatusFlags);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultOutOfRange:
                FaultParameterTFaultOutOfRangeCodec.Encode(ref writer, 6, value.FaultOutOfRange);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultListed:
                FaultParameterTFaultListedCodec.Encode(ref writer, 7, value.FaultListed);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter value)
        => AsduConstructed.Encode<FaultParameterCodec, global::Baclib.Bacnet.Types.Application.FaultParameter>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.None
                => NullCodec.GetEncodedLength(value.None, 0),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultCharacterstring
                => FaultParameterTFaultCharacterstringCodec.GetEncodedLength(value.FaultCharacterstring, 1),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultExtended
                => FaultParameterTFaultExtendedCodec.GetEncodedLength(value.FaultExtended, 2),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultLifeSafety
                => FaultParameterTFaultLifeSafetyCodec.GetEncodedLength(value.FaultLifeSafety, 3),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultState
                => FaultParameterTFaultStateCodec.GetEncodedLength(value.FaultState, 4),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultStatusFlags
                => FaultParameterTFaultStatusFlagsCodec.GetEncodedLength(value.FaultStatusFlags, 5),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultOutOfRange
                => FaultParameterTFaultOutOfRangeCodec.GetEncodedLength(value.FaultOutOfRange, 6),
            global::Baclib.Bacnet.Types.Application.FaultParameter.Option.FaultListed
                => FaultParameterTFaultListedCodec.GetEncodedLength(value.FaultListed, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter value, byte tagNumber)
        => AsduElement.GetEncodedLength<FaultParameterCodec, global::Baclib.Bacnet.Types.Application.FaultParameter>(tagNumber, value);
}
