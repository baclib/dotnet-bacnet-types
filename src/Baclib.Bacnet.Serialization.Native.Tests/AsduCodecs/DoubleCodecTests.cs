// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class DoubleCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsExpected()
    {
        // Application tag 5, extended length 8: 0x55 0x08. 1.5 = 0x3F F8 00 00 00 00 00 00
        var reader = new AsduReader([0x55, 0x08, 0x3F, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Assert.Equal(1.5d, DoubleCodec.Decode(ref reader));
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsExpected()
    {
        // Context tag 0, length 8: 0x0D 0x08. -2.0 = 0xC0 00 00 00 00 00 00 00
        var reader = new AsduReader([0x0D, 0x08, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Assert.Equal(-2.0d, DoubleCodec.Decode(ref reader, tagNumber: 0));
    }
}
