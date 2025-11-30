using Xunit;

namespace Baclib.Bacnet.Types.Tests;

public class BitFlags16Tests
{
    [Fact]
    public void Constructor_WithValidCount_ShouldCreateInstance()
    {
        // Arrange & Act
        var bitFlags = new BitString16(0b1010, 4);

        // Assert
        Assert.Equal(4, bitFlags.Count);
        Assert.Equal((ushort)0b1010, bitFlags.Flags);
    }

    [Fact]
    public void Constructor_WithCountGreaterThan16_ShouldThrowArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new BitString16(0, 17));
    }

    [Fact]
    public void Constructor_ShouldMaskUnusedBits()
    {
        // Arrange & Act
        var bitFlags = new BitString16(0b11111111, 4); // Pass 8 bits but only use 4

        // Assert
        Assert.Equal(4, bitFlags.Count);
        Assert.Equal((ushort)0b1111, bitFlags.Flags); // Only lower 4 bits should remain
    }

    [Fact]
    public void Constructor_WithCount16_ShouldKeepAllBits()
    {
        // Arrange & Act
        var bitFlags = new BitString16(0xFFFF, 16);

        // Assert
        Assert.Equal(16, bitFlags.Count);
        Assert.Equal((ushort)0xFFFF, bitFlags.Flags);
    }

    [Fact]
    public void Constructor_WithCount0_ShouldCreateEmptyBitFlags()
    {
        // Arrange & Act
        var bitFlags = new BitString16(0xFF, 0);

        // Assert
        Assert.Empty(bitFlags);
        Assert.Equal((ushort)0, bitFlags.Flags);
    }

    [Fact]
    public void Indexer_WithValidIndex_ShouldReturnCorrectBit()
    {
        // Arrange
        var bitFlags = new BitString16(0b1010, 4); // bits: 0,1,0,1 (LSB to MSB)

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
        var bitFlags = new BitString16(0b1010, 4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[-1]);
    }

    [Fact]
    public void Indexer_WithIndexGreaterThanOrEqualToCount_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var bitFlags = new BitString16(0b1010, 4);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[4]);
        Assert.Throws<ArgumentOutOfRangeException>(() => bitFlags[16]);
    }

    // Note: Methods like WithBit, SetBit, ClearBit, ToggleBit are not part of the current API

    [Fact]
    public void GetEnumerator_ShouldIterateOverAllBits()
    {
        // Arrange
        var bitFlags = new BitString16(0b1010, 4);

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
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        var bitFlags = new BitString16(0b1010, 4); // bits: 0,1,0,1 from LSB to MSB

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("0101", result); // LSB first output
    }

    [Fact]
    public void ToString_With16Bits_ShouldReturnCorrectFormat()
    {
        // Arrange
        var bitFlags = new BitString16(0b1010101010101010, 16);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal("0101010101010101", result); // LSB first output
        Assert.Equal(16, result.Length);
    }

    [Fact]
    public void ToString_WithEmptyBitFlags_ShouldReturnEmptyString()
    {
        // Arrange
        var bitFlags = new BitString16(0, 0);

        // Act
        var result = bitFlags.ToString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    // Note: TryParse method is not part of the current API

    // Note: Parse method is not part of the current API

    // Note: Bitwise operators (&, |, ^, ~) are not part of the current API

    [Fact]
    public void Equality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var bitFlags1 = new BitString16(0b1010, 4);
        var bitFlags2 = new BitString16(0b1010, 4);

        // Act & Assert
        Assert.Equal(bitFlags1, bitFlags2);
        Assert.True(bitFlags1 == bitFlags2);
        Assert.False(bitFlags1 != bitFlags2);
    }

    [Fact]
    public void Equality_WithDifferentFlags_ShouldNotBeEqual()
    {
        // Arrange
        var bitFlags1 = new BitString16(0b1010, 4);
        var bitFlags2 = new BitString16(0b1100, 4);

        // Act & Assert
        Assert.NotEqual(bitFlags1, bitFlags2);
        Assert.False(bitFlags1 == bitFlags2);
        Assert.True(bitFlags1 != bitFlags2);
    }
}
