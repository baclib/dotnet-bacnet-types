// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class BitString8CodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyBitString_ReturnsEmpty()
    {
        // Application tag 8 (BitString), length 2: 0x82, data 0x08 0x00 (all 8 bits unused)
        var reader = new NativeReader([0x82, 0x08, 0x00]);
        var result = BitString8Codec.Instance.Decode(ref reader);
        Assert.Equal(0, result.Length);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleBit_ReturnsValue()
    {
        // Application tag 8, length 2: 0x82
        // Data: unused bits = 7, followed by wire byte 0x80 (decodes to native flags 0x01)
        var reader = new NativeReader([0x82, 0x07, 0x80]);
        var result = BitString8Codec.Instance.Decode(ref reader);
        Assert.Equal(1, result.Length);
        Assert.Equal(0x01u, result.Flags);
    }

    [Fact]
    public void Decode_ApplicationTagged_AllBits_ReturnsValue()
    {
        // Application tag 8, length 2: 0x82
        // Data: unused bits = 0, followed by 1 byte = 0xFF (all bits set)
        var reader = new NativeReader([0x82, 0x00, 0xFF]);
        var result = BitString8Codec.Instance.Decode(ref reader);
        Assert.Equal(8, result.Length);
        Assert.Equal(0xFFu, result.Flags);
    }

    [Fact]
    public void Decode_ApplicationTagged_MixedBits_ReturnsValue()
    {
        // Application tag 8, length 2: 0x82
        // Data: unused bits = 4, followed by wire byte 0xA0 (decodes to native flags 0x05)
        var reader = new NativeReader([0x82, 0x04, 0xA0]);
        var result = BitString8Codec.Instance.Decode(ref reader);
        Assert.Equal(4, result.Length);
        Assert.Equal(0x05u, result.Flags);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 2, length 2: (2 << 4) | 0x08 | 2 = 0x2A
        // Data: unused bits = 0, followed by wire byte 0x55 (decodes to flags 0xAA)
        var reader = new NativeReader([0x2A, 0x00, 0x55]);
        var result = BitString8Codec.Instance.Decode(ref reader, tagNumber: 2);
        Assert.Equal(8, result.Length);
        Assert.Equal(0xAAu, result.Flags);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        var reader = new NativeReader([0x82, 0x06, 0xC0]);
        Optional<BitString8> result = BitString8Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(2, result.Value.Length);
        Assert.Equal(0x03u, result.Value.Flags);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — bitstring decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<BitString8> result = BitString8Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void DecodeOptional_ContextTagged_ReturnsValue()
    {
        // Context tag 0, length 2: 0x0A, data 0x02 0x40
        var reader = new NativeReader([0x0A, 0x02, 0x40]);
        Optional<BitString8> result = BitString8Codec.Instance.DecodeOptional(ref reader, tagNumber: 0);
        Assert.True(result.HasValue);
        Assert.Equal(6, result.Value.Length);
        Assert.Equal(0x02u, result.Value.Flags);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected()
    {
        var bitString = new BitString8(0xFF, count: 8);
        var result = BitString8Codec.Instance.GetEncodedSize(bitString);
        // Tag (1) + Data (1: unused bits) + Data (1: actual bits) = 3
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetEncodedSize_ContextTagged_ReturnsExpected()
    {
        var bitString = new BitString8(0x80, count: 1);
        var result = BitString8Codec.Instance.GetEncodedSize(tagNumber: 0, bitString);
        // Tag (1) + Data (1: unused bits) + Data (1: actual bits) = 3
        Assert.Equal(3, result);
    }
}
