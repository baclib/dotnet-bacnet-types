using Xunit;

namespace Baclib.Bacnet.Types.Tests;

public class BitFlags32Tests
{
    [Fact]
    public void Constructor_WithValidCount_ShouldCreateInstance()
    {
        // Arrange & Act
        var bitFlags = new BitString32(0b1010, 4);

        // Assert
        Assert.Equal(4, bitFlags.Count);
        Assert.Equal(0b1010u, bitFlags.Flags);
    }

    [Fact]
    public void Constructor_WithCountGreaterThan32_ShouldThrowArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new BitString32(0, 33));
    }

    [Fact]
    public void Constructor_ShouldMaskUnusedBits()
    {
        // Arrange & Act
        var bitFlags = new BitString32(0b11111111, 4); // Pass 8 bits but only use 4

        // Assert
        Assert.Equal(4, bitFlags.Count);
        Assert.Equal(0b1111u, bitFlags.Flags); // Only lower 4 bits should remain
    }

    [Fact]
    public void Constructor_WithCount32_ShouldKeepAllBits()
    {
        // Arrange & Act
        var bitFlags = new BitString32(0xFFFFFFFFu, 32);

        // Assert
        Assert.Equal(32, bitFlags.Count);
        Assert.Equal(0xFFFFFFFFu, bitFlags.Flags);
    }

    [Fact]
    public void Constructor_WithCount0_ShouldCreateEmptyBitFlags()
    {
        // Arrange & Act
        var bitFlags = new BitString32(0xFF, 0);

        // Assert
        Assert.Empty(bitFlags);
        Assert.Equal(0u, bitFlags.Flags);
    }

    [Fact]
    public void Indexer_WithValidIndex_ShouldReturnCorrectBit()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4); // bits: 0,1,0,1 (LSB to MSB)

        // Act & Assert
        Assert.False(bitFlags[0]); // LSB
        Assert.True(bitFlags[1]);
        Assert.False(bitFlags[2]);
        Assert.True(bitFlags[3]);  // MSB within used range
    }

    [Fact]
    public void Indexer_WithNegativeIndex_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[-1]);
    }

    [Fact]
    public void Indexer_WithIndexGreaterThanOrEqualToCount_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[4]);
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[10]);
    }

    // Note: Methods like WithBit, SetBit, ClearBit, ToggleBit are not part of the current API

    [Fact]
    public void GetEnumerator_ShouldIterateOverAllBits()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4);

        // Act
        var bits = bitFlags.ToList();

        // Assert
        Assert.Equal(4, bits.Count);
        Assert.False(bits[0]); // Index 0 (LSB)
        Assert.True(bits[1]);  // Index 1
        Assert.False(bits[2]); // Index 2
        Assert.True(bits[3]);  // Index 3 (MSB in range)
    }

    [Fact]
    public void GetEnumerator_WithEmptyBitFlags_ShouldReturnEmptyEnumeration()
    {
        // Arrange
        var bitFlags = new BitString32(0, 0);

        // Act
        var bits = bitFlags.ToList();

        // Assert
        Assert.Empty(bits);
    }

    [Fact]
    public void ToString_ShouldReturnLSBFirstFormat()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4); // Binary: 1010 (bits: 0,1,0,1 from LSB to MSB)

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("0101", result); // LSB first: index 0,1,2,3 = 0,1,0,1
    }

    [Fact]
    public void ToString_WithAllBitsSet_ShouldReturnAllOnes()
    {
        // Arrange
        var bitFlags = new BitString32(0b1111, 4);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("1111", result);
    }

    [Fact]
    public void ToString_WithNoBitsSet_ShouldReturnAllZeros()
    {
        // Arrange
        var bitFlags = new BitString32(0b0000, 4);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("0000", result);
    }

    [Fact]
    public void ToString_WithEmptyBitFlags_ShouldReturnEmptyString()
    {
        // Arrange
        var bitFlags = new BitString32(0, 0);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ToString_With32Bits_ShouldReturnCorrectFormat()
    {
        // Arrange
        var bitFlags = new BitString32(0b10101010_10101010_10101010_10101010u, 32);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("01010101010101010101010101010101", result); // LSB first
        Assert.Equal(32, result.Length);
    }

    [Fact]
    public void Count_ShouldReturnNumberOfBits()
    {
        // Arrange & Act
        var bitFlags1 = new BitString32(0, 8);
        var bitFlags2 = new BitString32(0, 16);
        var bitFlags3 = new BitString32(0, 32);

        // Assert
        Assert.Equal(8, bitFlags1.Count);
        Assert.Equal(16, bitFlags2.Count);
        Assert.Equal(32, bitFlags3.Count);
    }

    [Fact]
    public void Equality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var bitFlags1 = new BitString32(0b1010, 4);
        var bitFlags2 = new BitString32(0b1010, 4);

        // Act & Assert
        Assert.Equal(bitFlags1, bitFlags2);
        Assert.True(bitFlags1 == bitFlags2);
        Assert.False(bitFlags1 != bitFlags2);
    }

    [Fact]
    public void Equality_WithDifferentFlags_ShouldNotBeEqual()
    {
        // Arrange
        var bitFlags1 = new BitString32(0b1010, 4);
        var bitFlags2 = new BitString32(0b1100, 4);

        // Act & Assert
        Assert.NotEqual(bitFlags1, bitFlags2);
        Assert.False(bitFlags1 == bitFlags2);
        Assert.True(bitFlags1 != bitFlags2);
    }

    [Fact]
    public void Equality_WithDifferentCount_ShouldNotBeEqual()
    {
        // Arrange
        var bitFlags1 = new BitString32(0b1010, 4);
        var bitFlags2 = new BitString32(0b1010, 8);

        // Act & Assert
        Assert.NotEqual(bitFlags1, bitFlags2);
    }

    [Fact]
    public void IReadOnlyCollection_CountProperty_ShouldMatchCount()
    {
        // Arrange
        var bitFlags = new BitString32(0b1010, 4);
        IReadOnlyCollection<bool> collection = bitFlags;

        // Act & Assert
        Assert.Equal(4, collection.Count);
    }

    // Note: Parse and TryParse methods are not part of the current API

    // Note: Bitwise operators (&, |, ^, ~) are not part of the current API

    [Fact]
    public void ComplexScenario_BACnetStatusFlags_ShouldWorkCorrectly()
    {
        // Arrange - BACnet Status Flags: in-alarm, fault, overridden, out-of-service
        var statusFlags = new BitString32(0b1001, 4); // in-alarm and out-of-service set

        // Act & Assert
        Assert.True(statusFlags[0]);   // in-alarm
        Assert.False(statusFlags[1]);  // fault
        Assert.False(statusFlags[2]);  // overridden
        Assert.True(statusFlags[3]);   // out-of-service
        Assert.Equal("1001", statusFlags.ToString()); // LSB first: bits 0,1,2,3 = 1,0,0,1
    }
}
