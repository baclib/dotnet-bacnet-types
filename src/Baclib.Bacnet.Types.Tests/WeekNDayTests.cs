// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class WeekNDayTests
{
    [Fact]
    public void Constructor_WithValidFields_ShouldCreateWeekNDay()
    {
        // Act
        var weekNDay = new WeekNDay(3, 2, 4); // March, 2nd week, Thursday

        // Assert
        Assert.Equal(3, weekNDay.Month);
        Assert.Equal(2, weekNDay.Week);
        Assert.Equal(4, weekNDay.DayOfWeek);
    }

    [Fact]
    public void HasWildcards_NoWildcards_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, 4);

        // Assert
        Assert.False(weekNDay.HasWildcards);
    }

    [Fact]
    public void HasWildcards_WithMonthWildcard_ShouldReturnTrue()
    {
        // Arrange
        var weekNDay = new WeekNDay(WeekNDay.Wildcard, 2, 4);

        // Assert
        Assert.True(weekNDay.HasWildcards);
    }

    [Fact]
    public void HasWildcards_WithWeekWildcard_ShouldReturnTrue()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, WeekNDay.Wildcard, 4);

        // Assert
        Assert.True(weekNDay.HasWildcards);
    }

    [Fact]
    public void HasWildcards_WithDayOfWeekWildcard_ShouldReturnTrue()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, WeekNDay.Wildcard);

        // Assert
        Assert.True(weekNDay.HasWildcards);
    }

    [Fact]
    public void IsSpecific_AllSpecificValues_ShouldReturnTrue()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, 4);

        // Assert
        Assert.True(weekNDay.IsSpecific);
    }

    [Fact]
    public void IsSpecific_WithWildcard_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(WeekNDay.Wildcard, 2, 4);

        // Assert
        Assert.False(weekNDay.IsSpecific);
    }

    [Fact]
    public void IsSpecific_WithOddMonth_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(WeekNDay.OddMonth, 2, 4);

        // Assert
        Assert.False(weekNDay.IsSpecific);
    }

    [Fact]
    public void IsValid_ValidFields_ShouldReturnTrue()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, 4);

        // Assert
        Assert.True(weekNDay.IsValid);
    }

    [Fact]
    public void IsValid_InvalidMonth_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(15, 2, 4); // Month 15 is invalid

        // Assert
        Assert.False(weekNDay.IsValid);
    }

    [Fact]
    public void IsValid_InvalidWeek_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 10, 4); // Week 10 is invalid

        // Assert
        Assert.False(weekNDay.IsValid);
    }

    [Fact]
    public void IsValid_InvalidDayOfWeek_ShouldReturnFalse()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, 8); // DayOfWeek 8 is invalid

        // Assert
        Assert.False(weekNDay.IsValid);
    }

    [Fact]
    public void OddMonth_ShouldBeValid()
    {
        // Arrange
        var weekNDay = new WeekNDay(WeekNDay.OddMonth, 2, 4);

        // Assert
        Assert.True(weekNDay.IsValid);
        Assert.Equal(WeekNDay.OddMonth, weekNDay.Month);
    }

    [Fact]
    public void EvenMonth_ShouldBeValid()
    {
        // Arrange
        var weekNDay = new WeekNDay(WeekNDay.EvenMonth, 2, 4);

        // Assert
        Assert.True(weekNDay.IsValid);
        Assert.Equal(WeekNDay.EvenMonth, weekNDay.Month);
    }

    [Fact]
    public void LastWeek_ShouldBeValid()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, WeekNDay.LastWeek, 4);

        // Assert
        Assert.True(weekNDay.IsValid);
        Assert.Equal(WeekNDay.LastWeek, weekNDay.Week);
    }

    [Fact]
    public void AllWeekValues_ShouldBeValid()
    {
        // Act & Assert
        for (byte week = 1; week <= 9; week++)
        {
            var weekNDay = new WeekNDay(3, week, 4);
            Assert.True(weekNDay.IsValid, $"Week {week} should be valid");
        }
    }

    // Note: Matches method tests would go here if the method existed in the API

    [Fact]
    public void ToString_ShouldFormatCorrectly()
    {
        // Arrange
        var weekNDay = new WeekNDay(3, 2, 4);

        // Act
        var result = weekNDay.ToString();

        // Assert
        Assert.NotEmpty(result);
        Assert.Contains("3", result);
        Assert.Contains("2", result);
        Assert.Contains("4", result);
    }

    [Fact]
    public void Equality_SameValues_ShouldBeEqual()
    {
        // Arrange
        var wnd1 = new WeekNDay(3, 2, 4);
        var wnd2 = new WeekNDay(3, 2, 4);

        // Assert
        Assert.Equal(wnd1, wnd2);
        Assert.True(wnd1 == wnd2);
        Assert.False(wnd1 != wnd2);
    }

    [Fact]
    public void Equality_DifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var wnd1 = new WeekNDay(3, 2, 4);
        var wnd2 = new WeekNDay(3, 2, 5);

        // Assert
        Assert.NotEqual(wnd1, wnd2);
        Assert.False(wnd1 == wnd2);
        Assert.True(wnd1 != wnd2);
    }

    [Fact]
    public void GetHashCode_SameValues_ShouldHaveSameHashCode()
    {
        // Arrange
        var wnd1 = new WeekNDay(3, 2, 4);
        var wnd2 = new WeekNDay(3, 2, 4);

        // Act & Assert
        Assert.Equal(wnd1.GetHashCode(), wnd2.GetHashCode());
    }

    [Theory]
    [InlineData(1, 1, 1)] // January, week 1, Monday
    [InlineData(12, 5, 7)] // December, week 5, Sunday
    [InlineData(6, 3, 4)] // June, week 3, Thursday
    public void ValidValues_ShouldCreateSuccessfully(byte month, byte week, byte dayOfWeek)
    {
        // Act
        var weekNDay = new WeekNDay(month, week, dayOfWeek);

        // Assert
        Assert.Equal(month, weekNDay.Month);
        Assert.Equal(week, weekNDay.Week);
        Assert.Equal(dayOfWeek, weekNDay.DayOfWeek);
        Assert.True(weekNDay.IsValid);
    }
}
