// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class OctetStringCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyString_ReturnsEmpty()
    {
        // Application tag 6 (OctetString), length 0: (6 << 4) | 0 = 0x60
        var reader = new AsduReader([0x60]);
        var result = OctetStringCodec.Decode(ref reader);
        Assert.True(result.IsEmpty);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleByte_ReturnsValue()
    {
        // Application tag 6 (OctetString), length 1: (6 << 4) | 1 = 0x61, data 0xFF
        var reader = new AsduReader([0x61, 0xFF]);
        var result = OctetStringCodec.Decode(ref reader);
        Assert.Equal("FF", result.ToHexString());
    }

    [Fact]
    public void Decode_ApplicationTagged_MultipleByte_ReturnsValue()
    {
        // Application tag 6, length 5: (6 << 4) | 0x05 = 0x65, length byte 0x05, data 0x01 0x02 0x03 0x04 0x05
        var reader = new AsduReader([0x65, 0x05, 0x01, 0x02, 0x03, 0x04, 0x05]);
        var result = OctetStringCodec.Decode(ref reader);
        Assert.Equal("0102030405", result.ToHexString());
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 1, length 3: (1 << 4) | 0x08 | 3 = 0x1B, data 0xAA 0xBB 0xCC
        var reader = new AsduReader([0x1B, 0xAA, 0xBB, 0xCC]);
        var result = OctetStringCodec.Decode(ref reader, tagNumber: 1);
        Assert.Equal("AABBCC", result.ToHexString());
    }

    [Theory]
    [InlineData(new byte[] { }, 1)]
    [InlineData(new byte[] { 0xFF }, 2)]
    [InlineData(new byte[] { 0x01, 0x02, 0x03 }, 4)]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected(byte[] data, int expected)
    {
        var octetString = new OctetString(data);
        var result = OctetStringCodec.GetEncodedLength(octetString);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new byte[] { }, 1)]
    [InlineData(new byte[] { 0xFF }, 2)]
    [InlineData(new byte[] { 0x01, 0x02, 0x03 }, 4)]
    public void GetEncodedSize_ContextTagged_ReturnsExpected(byte[] data, int expected)
    {
        var octetString = new OctetString(data);
        var result = OctetStringCodec.GetEncodedLength(octetString, tagNumber: 0);
        Assert.Equal(expected, result);
    }
}
