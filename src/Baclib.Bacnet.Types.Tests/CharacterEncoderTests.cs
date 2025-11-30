// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Text;

namespace Baclib.Bacnet.Types.Tests;

public class CharacterEncoderTests
{
    [Fact]
    public void Default_ShouldReturnSingletonInstance()
    {
        // Act
        var encoder1 = CharacterEncoder.Default;
        var encoder2 = CharacterEncoder.Default;

        // Assert
        Assert.Same(encoder1, encoder2);
    }

    [Fact]
    public void GetString_Utf8_ShouldDecodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = new byte[] { (byte)CharacterSet.Utf8, 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello"

        // Act
        var result = encoder.GetString(data, out var charSet);

        // Assert
        Assert.Equal("Hello", result);
        Assert.Equal(CharacterSet.Utf8, charSet);
    }

    [Fact]
    public void GetString_Ucs2_ShouldDecodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = new byte[] { (byte)CharacterSet.Ucs2, 0x00, 0x48, 0x00, 0x69 }; // "Hi" in UCS-2 BE

        // Act
        var result = encoder.GetString(data, out var charSet);

        // Assert
        Assert.Equal("Hi", result);
        Assert.Equal(CharacterSet.Ucs2, charSet);
    }

    [Fact]
    public void GetString_Iso_ShouldDecodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = new byte[] { (byte)CharacterSet.Iso, 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" in ISO-8859-1

        // Act
        var result = encoder.GetString(data, out var charSet);

        // Assert
        Assert.Equal("Hello", result);
        Assert.Equal(CharacterSet.Iso, charSet);
    }

    [Fact]
    public void GetString_Dbcs_ShouldDecodeWithCodePage()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        // DBCS with code page 932 (Shift-JIS)
        var data = new byte[] { (byte)CharacterSet.Dbcs, 0x03, 0xA4, 0x48, 0x69 }; // Code page 932, "Hi"

        // Act
        var result = encoder.GetString(data, out var charSet);

        // Assert
        Assert.Equal(CharacterSet.Dbcs, charSet);
        Assert.NotNull(result);
    }

    [Fact]
    public void GetString_EmptyData_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = Array.Empty<byte>();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => encoder.GetString(data, out _));
    }

    [Fact]
    public void GetString_DbcsWithoutCodePage_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = new byte[] { (byte)CharacterSet.Dbcs }; // Missing code page bytes

        // Act & Assert
        Assert.Throws<ArgumentException>(() => encoder.GetString(data, out _));
    }

    [Fact]
    public void GetString_UnsupportedCharSet_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var data = new byte[] { 99, 0x48, 0x65 }; // Invalid charset

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => encoder.GetString(data, out _));
    }

    [Fact]
    public void GetBytes_Utf8_ShouldEncodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Hello";

        // Act
        var result = encoder.GetBytes(value, CharacterSet.Utf8);

        // Assert
        Assert.Equal((byte)CharacterSet.Utf8, result[0]);
        Assert.Equal(6, result.Length); // 1 byte charset + 5 bytes text
        Assert.Equal("Hello", Encoding.UTF8.GetString(result, 1, result.Length - 1));
    }

    [Fact]
    public void GetBytes_Ucs2_ShouldEncodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Hi";

        // Act
        var result = encoder.GetBytes(value, CharacterSet.Ucs2);

        // Assert
        Assert.Equal((byte)CharacterSet.Ucs2, result[0]);
        Assert.True(result.Length > 1);
    }

    [Fact]
    public void GetBytes_Iso_ShouldEncodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Test";

        // Act
        var result = encoder.GetBytes(value, CharacterSet.Iso);

        // Assert
        Assert.Equal((byte)CharacterSet.Iso, result[0]);
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void GetBytes_Jis_ShouldEncodeCorrectly()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Test";

        // Act
        var result = encoder.GetBytes(value, CharacterSet.Jis);

        // Assert
        Assert.Equal((byte)CharacterSet.Jis, result[0]);
        Assert.True(result.Length > 1);
    }

    [Fact]
    public void GetBytes_Dbcs_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Test";

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => encoder.GetBytes(value, CharacterSet.Dbcs));
    }

    [Fact]
    public void GetBytes_WithCodePage_ShouldEncodeWithHeader()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var value = "Test";
        var codePage = 932; // Shift-JIS

        // Act
        var result = encoder.GetBytes(value, codePage);

        // Assert
        Assert.Equal((byte)CharacterSet.Dbcs, result[0]);
        Assert.Equal(0x03, result[1]); // Code page high byte
        Assert.Equal(0xA4, result[2]); // Code page low byte (932 = 0x03A4)
        Assert.True(result.Length > 3);
    }

    [Fact]
    public void GetBytes_NullValue_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => encoder.GetBytes(null!, CharacterSet.Utf8));
        Assert.Throws<ArgumentNullException>(() => encoder.GetBytes(null!, 932));
    }

    [Fact]
    public void GetDbcsEncoding_ShouldCacheEncodings()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;

        // Act
        var encoding1 = encoder.GetDbcsEncoding(932);
        var encoding2 = encoder.GetDbcsEncoding(932);

        // Assert
        Assert.Same(encoding1, encoding2); // Should return cached instance
    }

    [Fact]
    public void GetDbcsEncoding_InvalidCodePage_ShouldThrow()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => encoder.GetDbcsEncoding(99999));
    }

    [Fact]
    public void RoundTrip_Utf8_ShouldPreserveValue()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var original = "Hello, World! 🌍";

        // Act
        var encoded = encoder.GetBytes(original, CharacterSet.Utf8);
        var decoded = encoder.GetString(encoded, out var charSet);

        // Assert
        Assert.Equal(CharacterSet.Utf8, charSet);
        Assert.Equal(original, decoded);
    }

    [Fact]
    public void RoundTrip_Iso_ShouldPreserveValue()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var original = "Hello";

        // Act
        var encoded = encoder.GetBytes(original, CharacterSet.Iso);
        var decoded = encoder.GetString(encoded, out var charSet);

        // Assert
        Assert.Equal(CharacterSet.Iso, charSet);
        Assert.Equal(original, decoded);
    }

    [Fact]
    public void RoundTrip_Dbcs_ShouldPreserveValue()
    {
        // Arrange
        var encoder = CharacterEncoder.Default;
        var original = "Test";

        // Act
        var encoded = encoder.GetBytes(original, 932);
        var decoded = encoder.GetString(encoded, out var charSet);

        // Assert
        Assert.Equal(CharacterSet.Dbcs, charSet);
        Assert.Equal(original, decoded);
    }

    [Fact]
    public void CustomEncoder_CanOverrideJisEncoding()
    {
        // Arrange
        var customEncoder = new CustomJisEncoder();

        // Act
        var encoding = customEncoder.GetJisEncodingPublic();

        // Assert
        Assert.NotNull(encoding);
    }

    // Helper class for testing inheritance
    private class CustomJisEncoder : CharacterEncoder
    {
        public System.Text.Encoding GetJisEncodingPublic() => JisX0208Encoding;
    }
}
