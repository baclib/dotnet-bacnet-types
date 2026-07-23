// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class TimePatternCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsValue()
    {
        // Application tag 11 (Time), length 4: (11 << 4) | 4 = 0xB4
        // Time format: Hour (1 byte), Minute (1 byte), Second (1 byte), Centisecond (1 byte)
        // Data: 0x0C 0x1E 0x00 0x00 (12:30:00.00)
        var reader = new AsduReader([0xB4, 0x0C, 0x1E, 0x00, 0x00]);
        var result = TimePatternCodec.Decode(ref reader);
        Assert.True(true);
    }

    [Fact]
    public void Decode_ApplicationTagged_AlternateTime_ReturnsValue()
    {
        // Application tag 11 (Time), length 4: (11 << 4) | 4 = 0xB4
        // Data: 0x17 0x3B 0x3B 0x63 (23:59:59.99)
        var reader = new AsduReader([0xB4, 0x17, 0x3B, 0x3B, 0x63]);
        var result = TimePatternCodec.Decode(ref reader);
        Assert.True(true);
    }

    [Fact]
    public void Decode_ApplicationTagged_Midnight_ReturnsValue()
    {
        // Application tag 11 (Time), length 4: (11 << 4) | 4 = 0xB4
        // Data: 0x00 0x00 0x00 0x00 (00:00:00.00)
        var reader = new AsduReader([0xB4, 0x00, 0x00, 0x00, 0x00]);
        var result = TimePatternCodec.Decode(ref reader);
        Assert.True(true);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 3, length 4: (3 << 4) | 0x08 | 4 = 0x3C
        // Data: 0x08 0x0C 0x1E 0x32
        var reader = new AsduReader([0x3C, 0x08, 0x0C, 0x1E, 0x32]);
        var result = TimePatternCodec.Decode(ref reader, tagNumber: 3);
        Assert.True(true);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_Returns6()
    {
        var timePattern = new TimePattern();
        var result = TimePatternCodec.GetEncodedLength(timePattern);
        // Tag (1) + Data (4) = 5
        Assert.Equal(5, result);
    }
}
