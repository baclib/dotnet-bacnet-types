// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class DateTests
{
    [Fact]
    public void Constructor_WithValidFields_ShouldCreateDate()
    {
        // Act
        var date = new Date(125, 12, 5, 4); // 2025-12-05, Thursday

        // Assert
        Assert.Equal(125, date.Year);
        Assert.Equal(12, date.Month);
        Assert.Equal(5, date.Day);
        Assert.Equal(4, date.DayOfWeek);
    }

    [Fact]
    public void Constructor_FromDateTime_ShouldConvertCorrectly()
    {
        // Arrange
        var dateTime = new DateTime(2025, 12, 5); // Friday

        // Act
        var date = new Date(dateTime);

        // Assert
        Assert.Equal(125, date.Year); // 2025 - 1900
        Assert.Equal(12, date.Month);
        Assert.Equal(5, date.Day);
        Assert.Equal(5, date.DayOfWeek); // Friday
    }

    [Fact]
    public void Constructor_FromDateOnly_ShouldConvertCorrectly()
    {
        // Arrange
        var dateOnly = new DateOnly(2025, 6, 15);

        // Act
        var date = new Date(dateOnly);

        // Assert
        Assert.Equal(125, date.Year);
        Assert.Equal(6, date.Month);
        Assert.Equal(15, date.Day);
    }

    [Fact]
    public void IsValid_AllValidFields_ShouldReturnTrue()
    {
        // Arrange
        var date = new Date(125, 12, 5, 4);

        // Assert
        Assert.True(date.IsValid);
    }

    [Fact]
    public void IsValid_InvalidMonth_ShouldReturnFalse()
    {
        // Arrange
        var date = new Date(125, 15, 5, 4); // Invalid month

        // Assert
        Assert.False(date.IsValid);
        Assert.False(date.IsMonthValid);
    }

    [Fact]
    public void IsValid_InvalidDay_ShouldReturnFalse()
    {
        // Arrange
        var date = new Date(125, 12, 35, 4); // Invalid day (beyond special values)

        // Assert
        Assert.False(date.IsValid);
        Assert.False(date.IsDayValid);
    }

    [Fact]
    public void IsSpecific_AllSpecificFields_ShouldReturnTrue()
    {
        // Arrange
        var date = new Date(125, 12, 5, 4);

        // Assert
        Assert.True(date.IsSpecific);
        Assert.True(date.IsYearSpecific);
        Assert.True(date.IsMonthSpecific);
        Assert.True(date.IsDaySpecific);
        Assert.True(date.IsDayOfWeekSpecific);
    }

    [Fact]
    public void IsSpecific_WithWildcard_ShouldReturnFalse()
    {
        // Arrange
        var date = new Date(Date.Wildcard, 12, 5, 4);

        // Assert
        Assert.False(date.IsSpecific);
        Assert.False(date.IsYearSpecific);
        Assert.True(date.IsYearUnspecified);
    }

    [Fact]
    public void IsUnspecified_AllWildcards_ShouldReturnTrue()
    {
        // Arrange
        var date = new Date(Date.Wildcard, Date.Wildcard, Date.Wildcard, Date.Wildcard);

        // Assert
        Assert.True(date.IsUnspecified);
    }

    [Fact]
    public void OddMonth_ShouldBeRecognized()
    {
        // Arrange
        var date = new Date(125, Date.OddMonth, 15, 1);

        // Assert
        Assert.True(date.IsMonthOdd);
        Assert.False(date.IsMonthSpecific);
        Assert.True(date.IsMonthValid);
    }

    [Fact]
    public void EvenMonth_ShouldBeRecognized()
    {
        // Arrange
        var date = new Date(125, Date.EvenMonth, 15, 1);

        // Assert
        Assert.True(date.IsMonthEven);
        Assert.False(date.IsMonthSpecific);
        Assert.True(date.IsMonthValid);
    }

    [Fact]
    public void LastDay_ShouldBeRecognized()
    {
        // Arrange
        var date = new Date(125, 12, Date.LastDay, 1);

        // Assert
        Assert.True(date.IsDayLast);
        Assert.False(date.IsDaySpecific);
        Assert.True(date.IsDayValid);
    }

    [Fact]
    public void OddDay_ShouldBeRecognized()
    {
        // Arrange
        var date = new Date(125, 12, Date.OddDay, 1);

        // Assert
        Assert.True(date.IsDayOdd);
        Assert.False(date.IsDaySpecific);
        Assert.True(date.IsDayValid);
    }

    [Fact]
    public void EvenDay_ShouldBeRecognized()
    {
        // Arrange
        var date = new Date(125, 12, Date.EvenDay, 1);

        // Assert
        Assert.True(date.IsDayEven);
        Assert.False(date.IsDaySpecific);
        Assert.True(date.IsDayValid);
    }

    [Fact]
    public void ToDateTime_SpecificDate_ShouldConvert()
    {
        // Arrange
        var date = new Date(125, 12, 5, 5); // 2025-12-05

        // Act
        var dateTime = date.ToDateTime();

        // Assert
        Assert.Equal(new DateTime(2025, 12, 5), dateTime);
    }

    [Fact]
    public void ToDateTime_WithWildcard_ShouldThrow()
    {
        // Arrange
        var date = new Date(Date.Wildcard, 12, 5, 1);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => date.ToDateTime());
    }

    [Fact]
    public void ToDateOnly_SpecificDate_ShouldConvert()
    {
        // Arrange
        var date = new Date(125, 12, 5, 5);

        // Act
        var dateOnly = date.ToDateOnly();

        // Assert
        Assert.Equal(new DateOnly(2025, 12, 5), dateOnly);
    }

    // Note: Matches method tests would go here if the method existed in the API

    [Fact]
    public void ToString_SpecificDate_ShouldFormatCorrectly()
    {
        // Arrange
        var date = new Date(125, 12, 5, 5);

        // Act
        var result = date.ToString();

        // Assert
        Assert.Equal("2025-12-05", result);
    }

    [Fact]
    public void ToString_WithWildcard_ShouldShowWildcard()
    {
        // Arrange
        var date = new Date(Date.Wildcard, 12, 5, 1);

        // Act
        var result = date.ToString();

        // Assert
        Assert.Contains("*", result);
    }

    [Fact]
    public void Equality_SameValues_ShouldBeEqual()
    {
        // Arrange
        var date1 = new Date(125, 12, 5, 4);
        var date2 = new Date(125, 12, 5, 4);

        // Assert
        Assert.Equal(date1, date2);
        Assert.True(date1 == date2);
        Assert.False(date1 != date2);
    }

    [Fact]
    public void Equality_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var date1 = new Date(125, 12, 5, 4);
        var date2 = new Date(125, 12, 6, 4);

        // Assert
        Assert.NotEqual(date1, date2);
        Assert.False(date1 == date2);
        Assert.True(date1 != date2);
    }

    [Fact]
    public void GetHashCode_SameValues_ShouldHaveSameHashCode()
    {
        // Arrange
        var date1 = new Date(125, 12, 5, 4);
        var date2 = new Date(125, 12, 5, 4);

        // Act & Assert
        Assert.Equal(date1.GetHashCode(), date2.GetHashCode());
    }
}
