// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class StageLimitValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.StageLimitValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.StageLimitValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(RealCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.StageLimitValue Decode(ref NativeReader reader)
    {
        var _limit = Asdu.DecodePrimitive<RealCodec, float>(ref reader);
        var _values = Asdu.DecodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader);
        var _deadband = Asdu.DecodePrimitive<RealCodec, float>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.StageLimitValue
        {
            Limit = _limit,
            Values = _values,
            Deadband = _deadband
        };
    }

    public static global::Baclib.Bacnet.Types.Application.StageLimitValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.StageLimitValue value)
    {
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, value.Limit);
        Asdu.EncodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, value.Values);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, value.Deadband);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.StageLimitValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.StageLimitValue value)
    {
        return Asdu.GetEncodedLength<RealCodec, float>(value.Limit) + Asdu.GetEncodedLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(value.Values) + Asdu.GetEncodedLength<RealCodec, float>(value.Deadband);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.StageLimitValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
