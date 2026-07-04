// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfValueTCovCriteriaCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @bitmask = BitStringCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.FromBitmask(@bitmask);
            case 1:
                var @referencedPropertyIncrement = RealCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.FromReferencedPropertyIncrement(@referencedPropertyIncrement);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.Bitmask:
                BitStringCodec.Encode(ref writer, 0, value.Bitmask);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.ReferencedPropertyIncrement:
                RealCodec.Encode(ref writer, 1, value.ReferencedPropertyIncrement);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
        => AsduConstructed.Encode<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.Bitmask
                => BitStringCodec.GetEncodedLength(value.Bitmask, 0),
            global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.ReferencedPropertyIncrement
                => RealCodec.GetEncodedLength(value.ReferencedPropertyIncrement, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value, byte tagNumber)
        => AsduElement.GetEncodedLength<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(tagNumber, value);
}
