// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class CharacterStringCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyString_ReturnsEmpty()
    {
        // Application tag 7 (CharacterString), length 1: UTF-8 charset marker only
        var reader = new NativeReader([0x71, 0x00]);
        var result = CharacterStringCodec.Instance.Decode(ref reader);
        Assert.Equal(string.Empty, result.Value);
        Assert.Equal(CharacterSet.Utf8, result.CharSet);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleByte_ReturnsValue()
    {
        // Application tag 7, length 2: UTF-8 marker + 'A'
        var reader = new NativeReader([0x72, 0x00, 0x41]);
        var result = CharacterStringCodec.Instance.Decode(ref reader);
        Assert.Equal("A", result.Value);
        Assert.Equal(CharacterSet.Utf8, result.CharSet);
    }

    [Fact]
    public void Decode_ApplicationTagged_MultipleBytes_ReturnsValue()
    {
        // Application tag 7, extended length 6: 0x75 0x06, UTF-8 marker + "Hello"
        var reader = new NativeReader([0x75, 0x06, 0x00, 0x48, 0x65, 0x6C, 0x6C, 0x6F]);
        var result = CharacterStringCodec.Instance.Decode(ref reader);
        Assert.Equal("Hello", result.Value);
        Assert.Equal(CharacterSet.Utf8, result.CharSet);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 2, extended length 5: 0x2D 0x05, UTF-8 marker + "Test"
        var reader = new NativeReader([0x2D, 0x05, 0x00, 0x54, 0x65, 0x73, 0x74]);
        var result = CharacterStringCodec.Instance.Decode(ref reader, tagNumber: 2);
        Assert.Equal("Test", result.Value);
        Assert.Equal(CharacterSet.Utf8, result.CharSet);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        // Application tag 7, length 3: UTF-8 marker + "HI"
        var reader = new NativeReader([0x73, 0x00, 0x48, 0x49]);
        Optional<CharacterString> result = CharacterStringCodec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal("HI", result.Value.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — character string decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<CharacterString> result = CharacterStringCodec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void DecodeOptional_ContextTagged_ReturnsValue()
    {
        // Context tag 0, length 4: 0x0C, UTF-8 marker + "XYZ"
        var reader = new NativeReader([0x0C, 0x00, 0x58, 0x59, 0x5A]);
        Optional<CharacterString> result = CharacterStringCodec.Instance.DecodeOptional(ref reader, tagNumber: 0);
        Assert.True(result.HasValue);
        Assert.Equal("XYZ", result.Value.Value);
    }

    [Theory]
    [InlineData("", 2)]
    [InlineData("A", 3)]
    [InlineData("Hi", 4)]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected(string value, int expected)
    {
        var charString = new CharacterString(value);
        var result = CharacterStringCodec.Instance.GetEncodedSize(charString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", 2)]
    [InlineData("A", 3)]
    [InlineData("Hi", 4)]
    public void GetEncodedSize_ContextTagged_ReturnsExpected(string value, int expected)
    {
        var charString = new CharacterString(value);
        var result = CharacterStringCodec.Instance.GetEncodedSize(tagNumber: 0, charString);
        Assert.Equal(expected, result);
    }
}
