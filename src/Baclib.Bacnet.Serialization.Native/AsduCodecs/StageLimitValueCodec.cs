// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class StageLimitValueCodec :
    IAsduElementCodec<T::StageLimitValue>,
    IAsduConstructedCodec<T::StageLimitValue>
{
    public static T::StageLimitValue Decode(ref AsduReader reader)
    {
        return new T::StageLimitValue
        {
            Limit = AsduElement.Decode<RealCodec, float>(ref reader),
            Values = AsduElement.Decode<BitStringCodec, T::BitString>(ref reader),
            Deadband = AsduElement.Decode<RealCodec, float>(ref reader)
        };
    }

    public static T::StageLimitValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<StageLimitValueCodec, T::StageLimitValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::StageLimitValue value)
    {
        AsduElement.Encode<RealCodec, float>(ref writer, value.Limit);
        AsduElement.Encode<BitStringCodec, T::BitString>(ref writer, value.Values);
        AsduElement.Encode<RealCodec, float>(ref writer, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::StageLimitValue value)
        => AsduConstructed.Encode<StageLimitValueCodec, T::StageLimitValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::StageLimitValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RealCodec, float>(value.Limit);
        length += AsduElement.GetEncodedLength<BitStringCodec, T::BitString>(value.Values);
        length += AsduElement.GetEncodedLength<RealCodec, float>(value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::StageLimitValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<StageLimitValueCodec, T::StageLimitValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return RealCodec.Matches(ref reader);
    }
}
