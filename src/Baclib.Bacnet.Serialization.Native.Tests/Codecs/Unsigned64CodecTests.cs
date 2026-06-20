// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Unsigned64CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x21, 0x2A }, 42ul)]
    [InlineData(new byte[] { 0x25, 0x08, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, ulong.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, ulong expected)
    {
        var reader = new NativeReader(bytes);
        Assert.Equal(expected, Unsigned64Codec.Instance.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, extended length 8: 0x0D 0x08, then 8 bytes.
        var reader = new NativeReader([0x0D, 0x08, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Assert.Equal(0x8000000000000000ul, Unsigned64Codec.Instance.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        var reader = new NativeReader([0x25, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01]);
        Optional<ulong> result = Unsigned64Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(1ul, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — unsigned decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<ulong> result = Unsigned64Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }
}
