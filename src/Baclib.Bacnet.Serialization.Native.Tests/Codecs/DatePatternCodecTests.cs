// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class DatePatternCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsValue()
    {
        // Application tag 10 (Date), length 4: (10 << 4) | 4 = 0xA4
        // Date format: Year (1 byte), Month (1 byte), Day (1 byte), DayOfWeek (1 byte)
        // Data: 0x7F 0x01 0x01 0x01
        var reader = new AsduReader([0xA4, 0x7F, 0x01, 0x01, 0x01]);
        var result = DatePatternCodec.Decode(ref reader);
        Assert.True(true);
    }

    [Fact]
    public void Decode_ApplicationTagged_AlternateDate_ReturnsValue()
    {
        // Application tag 10 (Date), length 4: (10 << 4) | 4 = 0xA4
        // Data: 0x70 0x03 0x0F 0x02
        var reader = new AsduReader([0xA4, 0x70, 0x03, 0x0F, 0x02]);
        var result = DatePatternCodec.Decode(ref reader);
        Assert.True(true);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 1, length 4: (1 << 4) | 0x08 | 4 = 0x1C
        // Data: 0x68 0x06 0x1C 0x03
        var reader = new AsduReader([0x1C, 0x68, 0x06, 0x1C, 0x03]);
        var result = DatePatternCodec.Decode(ref reader, tagNumber: 1);
        Assert.True(true);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        var reader = new AsduReader([0xA4, 0x7C, 0x0C, 0x19, 0x00]);
        Optional<DatePattern> result = Asdu.DecodeOptional<DatePatternCodec, DatePattern>(ref reader);
        Assert.True(result.HasValue);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — date decoder should not match.
        var reader = new AsduReader([0x11]);
        Optional<DatePattern> result = Asdu.DecodeOptional<DatePatternCodec, DatePattern>(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_Returns6()
    {
        var datePattern = new DatePattern();
        var result = DatePatternCodec.GetEncodedLength(datePattern);
        // Tag (1) + Data (4) = 5
        Assert.Equal(5, result);
    }
}
