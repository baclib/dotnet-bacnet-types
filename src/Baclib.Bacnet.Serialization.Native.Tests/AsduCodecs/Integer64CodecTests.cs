// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class Integer64CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x31, 0xD6 }, -42L)]
    [InlineData(new byte[] { 0x35, 0x08, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, long.MinValue)]
    [InlineData(new byte[] { 0x35, 0x08, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, long.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, long expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Integer64Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, extended length 8: 0x0D 0x08, then 8-byte payload.
        var reader = new AsduReader([0x0D, 0x08, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF]);
        Assert.Equal(-1L, Integer64Codec.Decode(ref reader, tagNumber: 0));
    }
}
