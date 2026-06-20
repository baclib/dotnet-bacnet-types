// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class DoubleCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsExpected()
    {
        // Application tag 5, extended length 8: 0x55 0x08. 1.5 = 0x3F F8 00 00 00 00 00 00
        var reader = new NativeReader([0x55, 0x08, 0x3F, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Assert.Equal(1.5d, DoubleCodec.Instance.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 8: 0x0D 0x08. -2.0 = 0xC0 00 00 00 00 00 00 00
        var reader = new NativeReader([0x0D, 0x08, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Assert.Equal(-2.0d, DoubleCodec.Instance.Decode(ref reader, tagNumber: 0));
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsExpected()
    {
        // Application tag 5, extended length 8: 0x55 0x08. 0.5 = 0x3F E0 00 00 00 00 00 00
        var reader = new NativeReader([0x55, 0x08, 0x3F, 0xE0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Optional<double> result = DoubleCodec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(0.5d, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — double decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<double> result = DoubleCodec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }
}
