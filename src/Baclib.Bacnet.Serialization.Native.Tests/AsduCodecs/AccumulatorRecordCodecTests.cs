// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class AccumulatorRecordCodecTests
{
    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0E,
            0x0E,
            0xA4, 0x7C, 0x06, 0x12, 0x02,
            0xB4, 0x0E, 0x1E, 0x05, 0x00,
            0x0F,
            0x19, 0x2A,
            0x2A, 0x01, 0x2C,
            0x39, 0x00,
            0x0F
        ]);

        var result = AccumulatorRecordCodec.Decode(ref reader, 0);

        Assert.Equal(new DateOnly(2024, 6, 18), result.Timestamp.Date.ToDateOnly());
        Assert.Equal(42u, result.PresentValue);
        Assert.Equal(300u, result.AccumulatedValue);
        Assert.Equal(AccumulatorRecord.TAccumulatorStatus.Normal, result.AccumulatorStatus);
    }

    [Fact]
    public void GetEncodedLength_ReturnsExpectedSum()
    {
        var value = new AccumulatorRecord
        {
            Timestamp = new Baclib.Bacnet.Types.Application.DateTime
            {
                Date = new Date(new DateOnly(2024, 6, 18)),
                Time = new Time(14, 30, 5, 0)
            },
            PresentValue = 42u,
            AccumulatedValue = 300u,
            AccumulatorStatus = AccumulatorRecord.TAccumulatorStatus.Normal
        };

        var expected =
            AsduElement.GetEncodedLength<DateTimeCodec, Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) +
            AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.PresentValue) +
            AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.AccumulatedValue) +
            AsduElement.GetEncodedLength<AccumulatorRecordTAccumulatorStatusCodec, AccumulatorRecord.TAccumulatorStatus>(3, value.AccumulatorStatus);

        Assert.Equal(expected, AccumulatorRecordCodec.GetEncodedLength(value));
    }
}