// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Unsigned32CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x21, 0x2A }, 42u)]
    [InlineData(new byte[] { 0x22, 0x01, 0x00 }, 256u)]
    [InlineData(new byte[] { 0x23, 0x01, 0x00, 0x00 }, 65536u)]
    [InlineData(new byte[] { 0x24, 0xFF, 0xFF, 0xFF, 0xFF }, uint.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, uint expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Unsigned32Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 2: 0x0A, data 0x01 0x00 = 256
        var reader = new AsduReader([0x0A, 0x01, 0x00]);
        Assert.Equal(256u, Unsigned32Codec.Decode(ref reader, tagNumber: 0));
    }

    [Theory]
    [InlineData(new byte[] { 0x21, 0x00 }, 0u)]
    [InlineData(new byte[] { 0x21, 0x7F }, 127u)]
    [InlineData(new byte[] { 0x24, 0x80, 0x00, 0x00, 0x00 }, 2147483648u)]
    public void DecodeOptional_PresentValue_ReturnsExpected(byte[] bytes, uint expected)
    {
        var reader = new AsduReader(bytes);
        Optional<uint> result = Asdu.DecodeOptional<Unsigned32Codec, uint>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — unsigned decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<uint> result = Asdu.DecodeOptional<Unsigned32Codec, uint>(ref reader);
        Assert.False(result.HasValue);
    }
}
