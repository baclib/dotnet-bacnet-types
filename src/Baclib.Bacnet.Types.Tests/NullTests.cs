// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class NullTests
{
    [Fact]
    public void Value_ShouldReturnSingletonInstance()
    {
        // Act
        var null1 = Null.Value;
        var null2 = Null.Value;

        // Assert
        Assert.Equal(null1, null2);
    }

    [Fact]
    public void DefaultValue_ShouldEqualSingletonValue()
    {
        // Arrange
        var defaultNull = default(Null);

        // Act & Assert
        Assert.Equal(Null.Value, defaultNull);
    }

    [Fact]
    public void ToString_ShouldReturnNull()
    {
        // Arrange
        var nullValue = Null.Value;

        // Act
        var result = nullValue.ToString();

        // Assert
        Assert.Equal("Null", result);
    }

    [Fact]
    public void Equality_AllInstancesShouldBeEqual()
    {
        // Arrange
        var null1 = Null.Value;
        var null2 = default(Null);
        var null3 = new Null();

        // Assert
        Assert.Equal(null1, null2);
        Assert.Equal(null2, null3);
        Assert.Equal(null1, null3);
    }

    [Fact]
    public void GetHashCode_AllInstancesShouldHaveSameHashCode()
    {
        // Arrange
        var null1 = Null.Value;
        var null2 = default(Null);

        // Act & Assert
        Assert.Equal(null1.GetHashCode(), null2.GetHashCode());
    }
}
