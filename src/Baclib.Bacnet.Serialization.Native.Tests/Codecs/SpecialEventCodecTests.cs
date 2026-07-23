// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class SpecialEventCodecTests
{
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