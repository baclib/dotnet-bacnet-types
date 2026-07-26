// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class SpecialEventCodecTests
{
    [Fact]
    public void Decode_CalendarReferencePeriodWithSingleTimeValue_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x1C, 0x01, 0x80, 0x00, 0x01,
            0x2E,
            0x2E,
            0xB4, 0x0C, 0x1E, 0x00, 0x00,
            0x21, 0x2A,
            0x2F,
            0x2F,
            0x39, 0x05
        ]);

        var result = SpecialEventCodec.Decode(ref reader);

        Assert.True(result.Period.TryGetCalendarReference(out var calendarReference));
        Assert.Equal(new ObjectIdentifier(ObjectType.Calendar, 1), calendarReference);
        Assert.Single(result.ListOfTimeValues);
        Assert.Equal(new Time(12, 30, 0, 0), result.ListOfTimeValues[0].Time);
        Assert.Equal([0x21, 0x2A], result.ListOfTimeValues[0].Value.EncodedData.Memory.ToArray());
        Assert.Equal((SpecialEvent.TEventPriority)5, result.EventPriority);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_CalendarReferencePeriodWithSingleTimeValue_WritesExpected()
    {
        var value = new SpecialEvent
        {
            Period = SpecialEvent.TPeriod.FromCalendarReference(new ObjectIdentifier(ObjectType.Calendar, 1)),
            ListOfTimeValues = SequenceOf<TimeValue>.Create(
                new TimeValue
                {
                    Time = new Time(12, 30, 0, 0),
                    Value = Any.FromValue(42u)
                }),
            EventPriority = new SpecialEvent.TEventPriority(5)
        };
        byte[] expected =
        [
            0x1C, 0x01, 0x80, 0x00, 0x01,
            0x2E,
            0x2E,
            0xB4, 0x0C, 0x1E, 0x00, 0x00,
            0x21, 0x2A,
            0x2F,
            0x2F,
            0x39, 0x05
        ];
        var writer = new AsduWriter(expected.Length);

        SpecialEventCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }

    [Theory]
    [InlineData(new byte[] { 0x0C, 0x7C, 0x06, 0x12, 0x02 })]
    [InlineData(new byte[] { 0x1C, 0x02, 0x00, 0x00, 0x01 })]
    public void Matches_SupportedPeriodChoice_ReturnsTrue(byte[] bytes)
    {
        var reader = new AsduReader(bytes);

        Assert.True(SpecialEventCodec.Matches(ref reader));
    }

    [Fact]
    public void Matches_UnsupportedTag_ReturnsFalse()
    {
        var reader = new AsduReader([0x39, 0x05]);

        Assert.False(SpecialEventCodec.Matches(ref reader));
    }

    [Fact]
    public void GetEncodedLength_EmptyTimeValuesWithCalendarEntryPeriod_ReturnsExpected()
    {
        var period = SpecialEvent.TPeriod.FromCalendarEntry(
            CalendarEntry.FromDate(new DatePattern(new DateOnly(2024, 6, 18))));
        var value = new SpecialEvent
        {
            Period = period,
            ListOfTimeValues = SequenceOf<TimeValue>.Empty,
            EventPriority = new SpecialEvent.TEventPriority(5)
        };

        var expected =
            AsduElement.GetEncodedLength<SpecialEventTPeriodCodec, SpecialEvent.TPeriod>(value.Period) +
            AsduElement.GetSequenceOfEncodedLength<TimeValueCodec, TimeValue>(2, value.ListOfTimeValues) +
            AsduElement.GetEncodedLength<SpecialEventTEventPriorityCodec, SpecialEvent.TEventPriority>(3, value.EventPriority);

        Assert.Equal(expected, SpecialEventCodec.GetEncodedLength(value));
    }

    [Fact]
    public void GetEncodedLength_EmptyTimeValuesWithCalendarReferencePeriod_ReturnsExpected()
    {
        var period = SpecialEvent.TPeriod.FromCalendarReference(new ObjectIdentifier(ObjectType.Device, 1));
        var value = new SpecialEvent
        {
            Period = period,
            ListOfTimeValues = SequenceOf<TimeValue>.Empty,
            EventPriority = new SpecialEvent.TEventPriority(7)
        };

        var expected =
            AsduElement.GetEncodedLength<SpecialEventTPeriodCodec, SpecialEvent.TPeriod>(value.Period) +
            AsduElement.GetSequenceOfEncodedLength<TimeValueCodec, TimeValue>(2, value.ListOfTimeValues) +
            AsduElement.GetEncodedLength<SpecialEventTEventPriorityCodec, SpecialEvent.TEventPriority>(3, value.EventPriority);

        Assert.Equal(expected, SpecialEventCodec.GetEncodedLength(value));
    }
}