// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Unsigned8CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x21, 0x00 }, (byte)0)]
    [InlineData(new byte[] { 0x21, 0x7F }, (byte)127)]
    [InlineData(new byte[] { 0x21, 0xFF }, byte.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, byte expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Unsigned8Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 1: 0x09, data 0x2A = 42
        var reader = new AsduReader([0x09, 0x2A]);
        Assert.Equal((byte)42, Unsigned8Codec.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        var reader = new AsduReader([0x21, 0x2A]);
        Optional<byte> result = Asdu.DecodeOptional<Unsigned8Codec, byte>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal((byte)42, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — unsigned decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<byte> result = Asdu.DecodeOptional<Unsigned8Codec, byte>(ref reader);
        Assert.False(result.HasValue);
    }
}