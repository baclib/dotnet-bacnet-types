// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class CalendarEntryCodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x0C, 0x7C, 0x06, 0x12, 0x02 })]
    [InlineData(new byte[] { 0x1E, 0xA4, 0x7C, 0x06, 0x12, 0x02, 0xA4, 0x7C, 0x06, 0x13, 0x03, 0x1F })]
    [InlineData(new byte[] { 0x2B, 0x03, 0x02, 0x02 })]
    public void Matches_SupportedChoice_ReturnsTrue(byte[] bytes)
    {
        var reader = new AsduReader(bytes);

        Assert.True(CalendarEntryCodec.Matches(ref reader));
    }

    [Fact]
    public void Matches_ApplicationTag_ReturnsFalse()
    {
        var reader = new AsduReader([0xA4, 0x7C, 0x06, 0x12, 0x02]);

        Assert.False(CalendarEntryCodec.Matches(ref reader));
    }

    [Fact]
    public void GetEncodedLength_DateChoice_MatchesInnerCodecLength()
    {
        var date = new DatePattern(new DateOnly(2024, 6, 18));
        var value = CalendarEntry.FromDate(date);

        Assert.Equal(DatePatternCodec.GetEncodedLength(date, 0), CalendarEntryCodec.GetEncodedLength(value));
    }

    [Fact]
    public void GetEncodedLength_DateRangeChoice_MatchesInnerCodecLength()
    {
        var dateRange = new DateRange
        {
            StartDate = new Date(new DateOnly(2024, 6, 18)),
            EndDate = new Date(new DateOnly(2024, 6, 19))
        };
        var value = CalendarEntry.FromDateRange(dateRange);

        Assert.Equal(DateRangeCodec.GetEncodedLength(dateRange, 1), CalendarEntryCodec.GetEncodedLength(value));
    }

    [Fact]
    public void GetEncodedLength_WeekNDayChoice_MatchesInnerCodecLength()
    {
        var weekNDay = new WeekNDay(3, WeekNDay.Week2, 2);
        var value = CalendarEntry.FromWeeknday(weekNDay);

        Assert.Equal(WeekNDayCodec.GetEncodedLength(weekNDay, 2), CalendarEntryCodec.GetEncodedLength(value));
    }
}