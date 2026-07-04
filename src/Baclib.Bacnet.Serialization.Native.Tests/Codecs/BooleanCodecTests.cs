// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// Application-tagged Boolean: tag byte encodes the value in the length/value/type nibble.
//   true  → 0x11  (tag 1, app class, value = 1)
//   false → 0x10  (tag 1, app class, value = 0)
public class BooleanCodecTests
{
    [Fact]
    public void Decode_True_ReturnsTrue()
    {
        var reader = new AsduReader([0x11]);
        Assert.True(BooleanCodec.Decode(ref reader));
    }

    [Fact]
    public void Decode_False_ReturnsFalse()
    {
        var reader = new AsduReader([0x10]);
        Assert.False(BooleanCodec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_True_ReturnsTrue()
    {
        // Context tag 0, length 1: (0 << 4) | 0x08 | 1 = 0x09, data byte 0x01 = true
        var reader = new AsduReader([0x09, 0x01]);
        Assert.True(BooleanCodec.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void Decode_ContextTagged_False_ReturnsFalse()
    {
        // Context tag 0, length 1: 0x09, data byte 0x00 = false
        var reader = new AsduReader([0x09, 0x00]);
        Assert.False(BooleanCodec.Decode(ref reader, tagNumber: 0));
    }

    [Theory]
    [InlineData(new byte[] { 0x11 }, true)]
    [InlineData(new byte[] { 0x10 }, false)]
    public void DecodeOptional_PresentValue_ReturnsExpected(byte[] bytes, bool expected)
    {
        var reader = new AsduReader(bytes);
        Optional<bool> result = Asdu.DecodeOptional<BooleanCodec, bool>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Wrong tag (Unsigned tag = 0x21) — boolean decoder should not match.
        var reader = new AsduReader([0x21, 0x2A]);
        Optional<bool> result = Asdu.DecodeOptional<BooleanCodec, bool>(ref reader);
        Assert.False(result.HasValue);
    }
}
