// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class Enumerated32CodecTests
{
    [Theory]
    [InlineData(new byte[] { 0x91, 0x2A }, (Enumerated32)42)]
    [InlineData(new byte[] { 0x92, 0x01, 0x00 }, (Enumerated32)256)]
    [InlineData(new byte[] { 0x93, 0x01, 0x00, 0x00 }, (Enumerated32)65536)]
    [InlineData(new byte[] { 0x94, 0xFF, 0xFF, 0xFF, 0xFF }, (Enumerated32)uint.MaxValue)]
    public void Decode_ApplicationTagged_ReturnsExpected(byte[] bytes, Enumerated32 expected)
    {
        var reader = new AsduReader(bytes);
        Assert.Equal(expected, Enumerated32Codec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 1: 0x09, data 0x2A = 42
        var reader = new AsduReader([0x09, 0x2A]);
        Assert.Equal((Enumerated32)42, Enumerated32Codec.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        // Application tag 9 (Enumerated), length 1: 0x91, data 0x2A = 42
        var reader = new AsduReader([0x91, 0x2A]);
        Optional<Enumerated32> result = Asdu.DecodeOptional<Enumerated32Codec, Enumerated32>(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal((Enumerated32)42, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — enumerated decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<Enumerated32> result = Asdu.DecodeOptional<Enumerated32Codec, Enumerated32>(ref reader);
        Assert.False(result.HasValue);
    }
}
