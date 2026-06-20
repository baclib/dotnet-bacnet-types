// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class RealCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsExpected()
    {
        // Application tag 4, length 4: 0x44. 1.5f = 0x3F C0 00 00
        var reader = new NativeReader(new byte[] { 0x44, 0x3F, 0xC0, 0x00, 0x00 });
        Assert.Equal(1.5f, RealCodec.Instance.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 4: 0x0C. -2.0f = 0xC0 00 00 00
        var reader = new NativeReader(new byte[] { 0x0C, 0xC0, 0x00, 0x00, 0x00 });
        Assert.Equal(-2.0f, RealCodec.Instance.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        // Application tag 4, length 4: 0x44. 0.5f = 0x3F 00 00 00
        var reader = new NativeReader(new byte[] { 0x44, 0x3F, 0x00, 0x00, 0x00 });
        Optional<float> result = RealCodec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(0.5f, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — real decoder should not match.
        var reader = new NativeReader(new byte[] { 0x11 });
        Optional<float> result = RealCodec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }
}
