// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class TimeTests
{
    [Fact]
    public void Constructor_WithValidFields_ShouldCreateTime()
    {
        // Act
        var time = new Time(14, 30, 45, 50);

        // Assert
        Assert.Equal(14, time.Hour);
        Assert.Equal(30, time.Minute);
        Assert.Equal(45, time.Second);
        Assert.Equal(50, time.Hundredths);
    }

    [Fact]
    public void Constructor_FromTimeSpan_ShouldConvertCorrectly()
    {
        // Arrange
        var timeSpan = new TimeSpan(0, 14, 30, 45, 500); // 14:30:45.500

        // Act
        var time = new Time(timeSpan);

        // Assert
        Assert.Equal(14, time.Hour);
        Assert.Equal(30, time.Minute);
        Assert.Equal(45, time.Second);
        Assert.Equal(50, time.Hundredths); // 500ms = 50 hundredths
    }

    [Fact]
    public void Constructor_FromTimeOnly_ShouldConvertCorrectly()
    {
        // Arrange
        var timeOnly = new TimeOnly(9, 15, 30, 250); // 09:15:30.250

        // Act
        var time = new Time(timeOnly);

        // Assert
        Assert.Equal(9, time.Hour);
        Assert.Equal(15, time.Minute);
        Assert.Equal(30, time.Second);
        Assert.Equal(25, time.Hundredths); // 250ms = 25 hundredths
    }

    [Fact]
    public void Constructor_FromTimeSpan_Negative_ShouldThrow()
    {
        // Arrange
        var negativeTimeSpan = TimeSpan.FromHours(-1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Time(negativeTimeSpan));
    }

    [Fact]
    public void Constructor_FromTimeSpan_TooLarge_ShouldThrow()
    {
        // Arrange
        var tooLarge = TimeSpan.FromDays(1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Time(tooLarge));
    }

    [Fact]
    public void IsValid_AllValidFields_ShouldReturnTrue()
    {
        // Arrange
        var time = new Time(23, 59, 59, 99);

        // Assert
        Assert.True(time.IsValid);
        Assert.True(time.IsHourValid);
        Assert.True(time.IsMinuteValid);
        Assert.True(time.IsSecondValid);
        Assert.True(time.IsHundredthsValid);
    }

    [Fact]
    public void IsValid_InvalidHour_ShouldReturnFalse()
    {
        // Arrange
        var time = new Time(24, 30, 45, 50); // Hour 24 is invalid

        // Assert
        Assert.False(time.IsValid);
        Assert.False(time.IsHourValid);
    }

    [Fact]
    public void IsValid_InvalidMinute_ShouldReturnFalse()
    {
        // Arrange
        var time = new Time(12, 60, 45, 50); // Minute 60 is invalid

        // Assert
        Assert.False(time.IsValid);
        Assert.False(time.IsMinuteValid);
    }

    [Fact]
    public void IsValid_InvalidSecond_ShouldReturnFalse()
    {
        // Arrange
        var time = new Time(12, 30, 60, 50); // Second 60 is invalid

        // Assert
        Assert.False(time.IsValid);
        Assert.False(time.IsSecondValid);
    }

    [Fact]
    public void IsValid_InvalidHundredths_ShouldReturnFalse()
    {
        // Arrange
        var time = new Time(12, 30, 45, 100); // Hundredths 100 is invalid

        // Assert
        Assert.False(time.IsValid);
        Assert.False(time.IsHundredthsValid);
    }

    [Fact]
    public void IsSpecific_AllSpecificFields_ShouldReturnTrue()
    {
        // Arrange
        var time = new Time(14, 30, 45, 50);

        // Assert
        Assert.True(time.IsSpecific);
        Assert.True(time.IsHourSpecific);
        Assert.True(time.IsMinuteSpecific);
        Assert.True(time.IsSecondSpecific);
        Assert.True(time.IsHundredthsSpecific);
    }

    [Fact]
    public void IsSpecific_WithWildcard_ShouldReturnFalse()
    {
        // Arrange
        var time = new Time(Time.Wildcard, 30, 45, 50);

        // Assert
        Assert.False(time.IsSpecific);
        Assert.False(time.IsHourSpecific);
        Assert.True(time.IsHourUnspecified);
    }

    [Fact]
    public void IsUnspecified_AllWildcards_ShouldReturnTrue()
    {
        // Arrange
        var time = new Time(Time.Wildcard, Time.Wildcard, Time.Wildcard, Time.Wildcard);

        // Assert
        Assert.True(time.IsUnspecified);
        Assert.True(time.IsHourUnspecified);
        Assert.True(time.IsMinuteUnspecified);
        Assert.True(time.IsSecondUnspecified);
        Assert.True(time.IsHundredthsUnspecified);
    }

    [Fact]
    public void ToTimeSpan_SpecificTime_ShouldConvert()
    {
        // Arrange
        var time = new Time(14, 30, 45, 50);

        // Act
        var timeSpan = time.ToTimeSpan();

        // Assert
        Assert.Equal(new TimeSpan(0, 14, 30, 45, 500), timeSpan);
    }

    [Fact]
    public void ToTimeSpan_WithWildcard_ShouldThrow()
    {
        // Arrange
        var time = new Time(Time.Wildcard, 30, 45, 50);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => time.ToTimeSpan());
    }

    [Fact]
    public void ToTimeOnly_SpecificTime_ShouldConvert()
    {
        // Arrange
        var time = new Time(14, 30, 45, 50);

        // Act
        var timeOnly = time.ToTimeOnly();

        // Assert
        Assert.Equal(new TimeOnly(14, 30, 45, 500), timeOnly);
    }

    // Note: Matches method tests would go here if the method existed in the API

    [Fact]
    public void ToString_SpecificTime_ShouldFormatCorrectly()
    {
        // Arrange
        var time = new Time(14, 30, 45, 50);

        // Act
        var result = time.ToString();

        // Assert
        Assert.Equal("14:30:45.50", result);
    }

    [Fact]
    public void ToString_WithWildcard_ShouldShowWildcard()
    {
        // Arrange
        var time = new Time(Time.Wildcard, 30, 45, 50);

        // Act
        var result = time.ToString();

        // Assert
        Assert.Contains("*", result);
    }

    [Fact]
    public void Equality_SameValues_ShouldBeEqual()
    {
        // Arrange
        var time1 = new Time(14, 30, 45, 50);
        var time2 = new Time(14, 30, 45, 50);

        // Assert
        Assert.Equal(time1, time2);
        Assert.True(time1 == time2);
        Assert.False(time1 != time2);
    }

    [Fact]
    public void Equality_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var time1 = new Time(14, 30, 45, 50);
        var time2 = new Time(14, 30, 46, 50);

        // Assert
        Assert.NotEqual(time1, time2);
        Assert.False(time1 == time2);
        Assert.True(time1 != time2);
    }

    [Fact]
    public void GetHashCode_SameValues_ShouldHaveSameHashCode()
    {
        // Arrange
        var time1 = new Time(14, 30, 45, 50);
        var time2 = new Time(14, 30, 45, 50);

        // Act & Assert
        Assert.Equal(time1.GetHashCode(), time2.GetHashCode());
    }

    [Theory]
    [InlineData((byte)0, (byte)0, (byte)0, (byte)0)]
    [InlineData((byte)23, (byte)59, (byte)59, (byte)99)]
    [InlineData((byte)12, (byte)30, (byte)45, (byte)50)]
    public void RoundTrip_ToTimeSpanAndBack_ShouldPreserveValue(byte hour, byte minute, byte second, byte hundredths)
    {
        // Arrange
        var time = new Time(hour, minute, second, hundredths);

        // Act
        var timeSpan = time.ToTimeSpan();
        Assert.NotNull(timeSpan); // Should not be null for valid times
        var reconstructed = new Time(timeSpan.Value);

        // Assert
        Assert.Equal(time, reconstructed);
    }
}
