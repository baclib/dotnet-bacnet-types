// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Unsigned16CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x21, 0x2A }, (ushort)42)]
    [InlineData(new byte[] { 0x22, 0x01, 0x00 }, (ushort)256)]
    [InlineData(new byte[] { 0x22, 0xFF, 0xFF }, ushort.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, ushort expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Unsigned16Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 2: 0x0A, data 0x01 0x00 = 256
        var reader = new AsduReader([0x0A, 0x01, 0x00]);
        Assert.Equal((ushort)256, Unsigned16Codec.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        var reader = new AsduReader([0x22, 0x03, 0xE8]);
        Optional<ushort> result = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal((ushort)1000, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — unsigned decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<ushort> result = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader);
        Assert.False(result.HasValue);
    }
}
