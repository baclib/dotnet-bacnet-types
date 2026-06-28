// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfValueTCovCriteriaCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _bitmask = Asdu.DecodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.FromBitmask(_bitmask);
            case 1:
                var _referencedPropertyIncrement = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.FromReferencedPropertyIncrement(_referencedPropertyIncrement);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.Bitmask:
                Asdu.EncodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, 0, value.Bitmask);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.ReferencedPropertyIncrement:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 1, value.ReferencedPropertyIncrement);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.Bitmask:
                return Asdu.GetPrimitiveLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(0, value.Bitmask);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria.Option.ReferencedPropertyIncrement:
                return Asdu.GetPrimitiveLength<RealCodec, float>(1, value.ReferencedPropertyIncrement);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}