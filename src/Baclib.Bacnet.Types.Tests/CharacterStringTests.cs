// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Text;

namespace Baclib.Bacnet.Types.Tests;

public class CharacterStringTests
{
    [Fact]
    public void Constructor_WithString_ShouldCreateUtf8()
    {
        // Arrange
        var value = "Hello";

        // Act
        var charString = new CharacterString(value);

        // Assert
        Assert.Equal("Hello", charString.Value);
        Assert.Equal(CharacterSet.Utf8, charString.CharSet);
    }

    [Fact]
    public void Constructor_WithStringAndCharSet_ShouldUseSpecifiedCharSet()
    {
        // Arrange
        var value = "Hello";

        // Act
        var charString = new CharacterString(value, CharacterSet.Iso);

        // Assert
        Assert.Equal("Hello", charString.Value);
        Assert.Equal(CharacterSet.Iso, charString.CharSet);
    }

    [Fact]
    public void Constructor_WithStringAndCharSet_Dbcs_ShouldThrow()
    {
        // Arrange
        var value = "Hello";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new CharacterString(value, CharacterSet.Dbcs));
    }

    [Fact]
    public void Constructor_WithStringAndCodePage_ShouldCreateDbcs()
    {
        // Arrange
        var value = "Hello";
        var codePage = 932;

        // Act
        var charString = new CharacterString(value, codePage);

        // Assert
        Assert.Equal("Hello", charString.Value);
        Assert.Equal(CharacterSet.Dbcs, charString.CharSet);
        Assert.Equal(932, charString.CodePage);
    }

    [Fact]
    public void Constructor_WithStringAndCodePage_InvalidCodePage_ShouldThrow()
    {
        // Arrange
        var value = "Hello";

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new CharacterString(value, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new CharacterString(value, 65536));
    }

    [Fact]
    public void Constructor_WithBytes_ShouldDecodeCorrectly()
    {
        // Arrange
        var bytes = new byte[] { (byte)CharacterSet.Utf8, 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello"

        // Act
        var charString = new CharacterString(bytes);

        // Assert
        Assert.Equal("Hello", charString.Value);
        Assert.Equal(CharacterSet.Utf8, charString.CharSet);
    }

    [Fact]
    public void Constructor_WithEmptyBytes_ShouldThrow()
    {
        // Arrange
        byte[] bytes = Array.Empty<byte>();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CharacterString((ReadOnlySpan<byte>)bytes));
    }

    [Fact]
    public void Constructor_NullString_ShouldThrow()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new CharacterString((string)null!));
        Assert.Throws<ArgumentNullException>(() => new CharacterString((string)null!, CharacterSet.Utf8));
        Assert.Throws<ArgumentNullException>(() => new CharacterString((string)null!, 932));
    }

    [Fact]
    public void CodePage_ForNonDbcs_ShouldThrow()
    {
        // Arrange
        var charString = new CharacterString("Hello", CharacterSet.Utf8);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => charString.CodePage);
    }

    [Fact]
    public void CodePage_ForDbcs_ShouldReturnCodePage()
    {
        // Arrange
        var charString = new CharacterString("Hello", 1252);

        // Act
        var codePage = charString.CodePage;

        // Assert
        Assert.Equal(1252, codePage);
    }

    [Fact]
    public void ToBytes_ShouldEncodeCorrectly()
    {
        // Arrange
        var charString = new CharacterString("Hi", CharacterSet.Utf8);

        // Act
        var bytes = charString.ToBytes();

        // Assert
        Assert.Equal((byte)CharacterSet.Utf8, bytes[0]);
        Assert.Equal("Hi", Encoding.UTF8.GetString(bytes, 1, bytes.Length - 1));
    }

    [Fact]
    public void ToBytes_EmptyString_ShouldReturnCharSetOnly()
    {
        // Arrange
        var charString = new CharacterString("", CharacterSet.Utf8);

        // Act
        var bytes = charString.ToBytes();

        // Assert
        Assert.Single(bytes);
        Assert.Equal((byte)CharacterSet.Utf8, bytes[0]);
    }

    [Fact]
    public void ToBytes_Dbcs_ShouldIncludeCodePage()
    {
        // Arrange
        var charString = new CharacterString("Hi", 932);

        // Act
        var bytes = charString.ToBytes();

        // Assert
        Assert.Equal((byte)CharacterSet.Dbcs, bytes[0]);
        Assert.Equal(0x03, bytes[1]); // Code page high byte
        Assert.Equal(0xA4, bytes[2]); // Code page low byte (932 = 0x03A4)
    }

    [Fact]
    public void ToString_ShouldReturnValue()
    {
        // Arrange
        var charString = new CharacterString("Hello");

        // Act
        var result = charString.ToString();

        // Assert
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void ImplicitConversion_FromString_ShouldWork()
    {
        // Arrange
        string value = "Hello";

        // Act
        CharacterString charString = value;

        // Assert
        Assert.Equal("Hello", charString.Value);
        Assert.Equal(CharacterSet.Utf8, charString.CharSet);
    }

    [Fact]
    public void Equality_SameValueAndCharSet_ShouldBeEqual()
    {
        // Arrange
        var cs1 = new CharacterString("Hello", CharacterSet.Utf8);
        var cs2 = new CharacterString("Hello", CharacterSet.Utf8);

        // Assert
        Assert.Equal(cs1, cs2);
        Assert.True(cs1 == cs2);
        Assert.False(cs1 != cs2);
    }

    [Fact]
    public void Equality_DifferentValue_ShouldNotBeEqual()
    {
        // Arrange
        var cs1 = new CharacterString("Hello", CharacterSet.Utf8);
        var cs2 = new CharacterString("World", CharacterSet.Utf8);

        // Assert
        Assert.NotEqual(cs1, cs2);
        Assert.False(cs1 == cs2);
        Assert.True(cs1 != cs2);
    }

    [Fact]
    public void Equality_DifferentCharSet_ShouldNotBeEqual()
    {
        // Arrange
        var cs1 = new CharacterString("Hello", CharacterSet.Utf8);
        var cs2 = new CharacterString("Hello", CharacterSet.Iso);

        // Assert
        Assert.NotEqual(cs1, cs2);
    }

    [Fact]
    public void RoundTrip_Utf8_ShouldPreserveValue()
    {
        // Arrange
        var original = new CharacterString("Hello, World! 🌍", CharacterSet.Utf8);

        // Act
        var bytes = original.ToBytes();
        var reconstructed = new CharacterString(bytes);

        // Assert
        Assert.Equal(original.Value, reconstructed.Value);
        Assert.Equal(original.CharSet, reconstructed.CharSet);
    }

    [Fact]
    public void RoundTrip_Iso_ShouldPreserveValue()
    {
        // Arrange
        var original = new CharacterString("Hello", CharacterSet.Iso);

        // Act
        var bytes = original.ToBytes();
        var reconstructed = new CharacterString(bytes);

        // Assert
        Assert.Equal(original.Value, reconstructed.Value);
        Assert.Equal(original.CharSet, reconstructed.CharSet);
    }

    [Fact]
    public void RoundTrip_Dbcs_ShouldPreserveValue()
    {
        // Arrange
        var original = new CharacterString("Test", 932);

        // Act
        var bytes = original.ToBytes();
        var reconstructed = new CharacterString(bytes);

        // Assert
        Assert.Equal(original.Value, reconstructed.Value);
        Assert.Equal(original.CharSet, reconstructed.CharSet);
        Assert.Equal(original.CodePage, reconstructed.CodePage);
    }

    [Fact]
    public void CustomEncoder_ShouldBeUsed()
    {
        // Arrange
        var originalEncoder = CharacterString.Encoder;
        var customEncoder = new TestEncoder();
        
        try
        {
            CharacterString.Encoder = customEncoder;
            var bytes = new byte[] { (byte)CharacterSet.Utf8, 0x48, 0x69 };

            // Act
            var charString = new CharacterString(bytes);

            // Assert
            Assert.True(customEncoder.WasCalled);
        }
        finally
        {
            // Restore original encoder
            CharacterString.Encoder = originalEncoder;
        }
    }

    [Fact]
    public void Encoder_SetNull_ShouldThrow()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => CharacterString.Encoder = null!);
    }

    // Helper class for testing custom encoder
    private class TestEncoder : CharacterEncoder
    {
        public bool WasCalled { get; private set; }

        public override string GetString(ReadOnlySpan<byte> data, out CharacterSet charSet)
        {
            WasCalled = true;
            return base.GetString(data, out charSet);
        }
    }

    [Theory]
    [InlineData(CharacterSet.Utf8)]
    [InlineData(CharacterSet.Ucs2)]
    [InlineData(CharacterSet.Ucs4)]
    [InlineData(CharacterSet.Iso)]
    [InlineData(CharacterSet.Jis)]
    public void AllCharSets_ShouldWorkCorrectly(CharacterSet charSet)
    {
        // Arrange
        var value = "Test";

        // Act
        var charString = new CharacterString(value, charSet);
        var bytes = charString.ToBytes();
        var reconstructed = new CharacterString(bytes);

        // Assert
        Assert.Equal(value, reconstructed.Value);
        Assert.Equal(charSet, reconstructed.CharSet);
    }
}
