// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class OctetStringTests
{
    [Fact]
    public void Constructor_WithByteArray_ShouldCreateCopy()
    {
        // Arrange
        var data = new byte[] { 1, 2, 3, 4 };

        // Act
        var octetString = new OctetString(data);
        data[0] = 99; // Modify original

        // Assert
        Assert.Equal(1, octetString[0]); // Should not be affected
        Assert.Equal(4, octetString.Length);
    }

    [Fact]
    public void Constructor_WithByteArray_NullData_ShouldThrow()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new OctetString((byte[])null!));
    }

    [Fact]
    public void Constructor_WithReadOnlySpan_ShouldCreateCopy()
    {
        // Arrange
        ReadOnlySpan<byte> data = stackalloc byte[] { 5, 6, 7 };

        // Act
        var octetString = new OctetString(data);

        // Assert
        Assert.Equal(3, octetString.Length);
        Assert.Equal(5, octetString[0]);
        Assert.Equal(7, octetString[2]);
    }

    [Fact]
    public void Empty_ShouldHaveZeroLength()
    {
        // Act
        var empty = OctetString.Empty;

        // Assert
        Assert.Equal(0, empty.Length);
        Assert.True(empty.IsEmpty);
    }

    [Fact]
    public void Indexer_ValidIndex_ShouldReturnByte()
    {
        // Arrange
        var octetString = new OctetString([10, 20, 30]);

        // Act & Assert
        Assert.Equal(10, octetString[0]);
        Assert.Equal(20, octetString[1]);
        Assert.Equal(30, octetString[2]);
    }

    [Fact]
    public void Indexer_NegativeIndex_ShouldThrow()
    {
        // Arrange
        var octetString = new OctetString([1, 2, 3]);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => octetString[-1]);
    }

    [Fact]
    public void Indexer_IndexTooLarge_ShouldThrow()
    {
        // Arrange
        var octetString = new OctetString([1, 2, 3]);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => octetString[3]);
        Assert.Throws<ArgumentOutOfRangeException>(() => octetString[10]);
    }

    [Fact]
    public void FromHex_ValidHexString_ShouldCreateOctetString()
    {
        // Act
        var octetString = OctetString.FromHex("48656C6C6F"); // "Hello"

        // Assert
        Assert.Equal(5, octetString.Length);
        Assert.Equal(0x48, octetString[0]); // 'H'
        Assert.Equal(0x65, octetString[1]); // 'e'
    }

    [Fact]
    public void FromHex_EmptyString_ShouldCreateEmpty()
    {
        // Act
        var octetString = OctetString.FromHex("");

        // Assert
        Assert.True(octetString.IsEmpty);
    }

    [Fact]
    public void FromHex_NullString_ShouldThrow()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => OctetString.FromHex(null!));
    }

    [Fact]
    public void FromHex_InvalidHexString_ShouldThrow()
    {
        // Act & Assert
        Assert.Throws<FormatException>(() => OctetString.FromHex("ZZ"));
        Assert.Throws<FormatException>(() => OctetString.FromHex("12G"));
    }

    [Fact]
    public void AsSpan_ShouldReturnReadOnlySpan()
    {
        // Arrange
        var octetString = new OctetString([1, 2, 3, 4]);

        // Act
        var span = octetString.AsSpan();

        // Assert
        Assert.Equal(4, span.Length);
        Assert.Equal(1, span[0]);
        Assert.Equal(4, span[3]);
    }

    [Fact]
    public void ToArray_ShouldReturnCopy()
    {
        // Arrange
        var octetString = new OctetString([1, 2, 3]);

        // Act
        var array = octetString.ToArray();
        array[0] = 99; // Modify copy

        // Assert
        Assert.Equal(1, octetString[0]); // Original unchanged
        Assert.Equal(99, array[0]);
    }

    [Fact]
    public void ToHexString_ShouldReturnUppercaseHex()
    {
        // Arrange
        var octetString = new OctetString([0x48, 0x65, 0x6C, 0x6C, 0x6F]);

        // Act
        var hex = octetString.ToHexString();

        // Assert
        Assert.Equal("48656C6C6F", hex);
    }

    [Fact]
    public void ToHexString_EmptyOctetString_ShouldReturnEmpty()
    {
        // Arrange
        var octetString = OctetString.Empty;

        // Act
        var hex = octetString.ToHexString();

        // Assert
        Assert.Equal(string.Empty, hex);
    }

    [Fact]
    public void ToString_ShouldReturnHexString()
    {
        // Arrange
        var octetString = new OctetString([0xAB, 0xCD]);

        // Act
        var result = octetString.ToString();

        // Assert
        Assert.Equal("ABCD", result);
    }

    [Fact]
    public void Equality_SameData_ShouldBeEqual()
    {
        // Arrange
        var oct1 = new OctetString([1, 2, 3]);
        var oct2 = new OctetString([1, 2, 3]);

        // Assert
        Assert.Equal(oct1, oct2);
        Assert.True(oct1 == oct2);
        Assert.False(oct1 != oct2);
    }

    [Fact]
    public void Equality_DifferentData_ShouldNotBeEqual()
    {
        // Arrange
        var oct1 = new OctetString([1, 2, 3]);
        var oct2 = new OctetString([1, 2, 4]);

        // Assert
        Assert.NotEqual(oct1, oct2);
        Assert.False(oct1 == oct2);
        Assert.True(oct1 != oct2);
    }

    [Fact]
    public void Equality_DifferentLength_ShouldNotBeEqual()
    {
        // Arrange
        var oct1 = new OctetString([1, 2, 3]);
        var oct2 = new OctetString([1, 2]);

        // Assert
        Assert.NotEqual(oct1, oct2);
    }

    // Note: Implicit/Explicit conversion tests would go here if they existed in the API
}
