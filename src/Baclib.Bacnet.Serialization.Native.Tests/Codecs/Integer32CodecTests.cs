// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// Application-tagged Signed Integer: tag 3, variable length 1–4 bytes.
//   100       → 0x31 0x64              (1 byte, fits in [-128, 127])
//   -1        → 0x31 0xFF              (1 byte)
//   1000      → 0x32 0x03 0xE8        (2 bytes, [-32768, 32767])
//   -200      → 0x32 0xFF 0x38        (2 bytes)
public class Integer32CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x31, 0x64 }, 100)]
    [InlineData(new byte[] { 0x31, 0xFF }, -1)]
    [InlineData(new byte[] { 0x32, 0x03, 0xE8 }, 1000)]
    [InlineData(new byte[] { 0x32, 0xFF, 0x38 }, -200)]
    [InlineData(new byte[] { 0x33, 0x00, 0x80, 0x00 }, 32768)]
    [InlineData(new byte[] { 0x33, 0x80, 0x00, 0x00 }, -8388608)]
    [InlineData(new byte[] { 0x34, 0x7F, 0xFF, 0xFF, 0xFF }, int.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, int expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Integer32Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 0, length 1: 0x09, data 0x64 = 100
        var reader = new AsduReader([0x09, 0x64]);
        Assert.Equal(100, Integer32Codec.Decode(ref reader, tagNumber: 0));
    }

    [Theory]
    [InlineData(new byte[] { 0x31, 0x00 }, 0)]
    [InlineData(new byte[] { 0x31, 0x7F }, 127)]
    [InlineData(new byte[] { 0x32, 0x80, 0x00 }, -32768)]
    public void DecodeOptional_PresentValue_ReturnsExpected(byte[] bytes, int expected)
    {
        var reader = new AsduReader(bytes);
        Optional<int> result = Asdu.DecodeOptional<Integer32Codec, int>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — integer decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<int> result = Asdu.DecodeOptional<Integer32Codec, int>(ref reader);
        Assert.False(result.HasValue);
    }
}
