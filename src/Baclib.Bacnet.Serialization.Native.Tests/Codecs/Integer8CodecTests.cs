// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Integer8CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x31, 0x00 }, (sbyte)0)]
    [InlineData(new byte[] { 0x31, 0x7F }, sbyte.MaxValue)]
    [InlineData(new byte[] { 0x31, 0x80 }, sbyte.MinValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, sbyte expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Integer8Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 1: 0x09, data 0xFF = -1
        var reader = new AsduReader([0x09, 0xFF]);
        Assert.Equal((sbyte)-1, Integer8Codec.Decode(ref reader, tagNumber: 0));
    }
}
