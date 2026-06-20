// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Integer16CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x31, 0x2A }, (short)42)]
    [InlineData(new byte[] { 0x32, 0x80, 0x00 }, short.MinValue)]
    [InlineData(new byte[] { 0x32, 0x7F, 0xFF }, short.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, short expected)
    {
        var reader = new NativeReader(bytes);
        Assert.Equal(expected, Integer16Codec.Instance.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 2: 0x0A, data 0xFF 0x38 = -200
        var reader = new NativeReader([0x0A, 0xFF, 0x38]);
        Assert.Equal((short)-200, Integer16Codec.Instance.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        var reader = new NativeReader([0x32, 0x03, 0xE8]);
        Optional<short> result = Integer16Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal((short)1000, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — signed decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<short> result = Integer16Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }
}
