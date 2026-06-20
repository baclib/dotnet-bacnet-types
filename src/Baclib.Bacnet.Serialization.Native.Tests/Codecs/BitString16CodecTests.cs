// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class BitString16CodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyBitString_ReturnsEmpty()
    {
        // Application tag 8 (BitString), length 3: 0x83, data 0x10 0x00 (all 16 bits unused)
        var reader = new NativeReader([0x83, 0x10, 0x00, 0x00]);
        var result = BitString16Codec.Instance.Decode(ref reader);
        Assert.Equal(0, result.Count);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleBit_ReturnsValue()
    {
        // Application tag 8, length 3: 0x83
        // Data: unused bits = 15, followed by wire bytes 0x80 0x00 (decodes to native flags 0x0001)
        var reader = new NativeReader([0x83, 0x0F, 0x80, 0x00]);
        var result = BitString16Codec.Instance.Decode(ref reader);
        Assert.Equal(1, result.Count);
        Assert.Equal((ushort)0x0001, result.Flags);
    }

    [Fact]
    public void Decode_ApplicationTagged_AllBits_ReturnsValue()
    {
        // Application tag 8, length 3: 0x83
        // Data: unused bits = 0, followed by 2 bytes = 0xFF 0xFF
        var reader = new NativeReader([0x83, 0x00, 0xFF, 0xFF]);
        var result = BitString16Codec.Instance.Decode(ref reader);
        Assert.Equal(16, result.Count);
        Assert.Equal(0xFFFFu, result.Flags);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 3, length 3: (3 << 4) | 0x08 | 3 = 0x3B
        // Data: unused bits = 0, followed by wire bytes 0x2C 0x48 (decodes to flags 0x1234)
        var reader = new NativeReader([0x3B, 0x00, 0x2C, 0x48]);
        var result = BitString16Codec.Instance.Decode(ref reader, tagNumber: 3);
        Assert.Equal(16, result.Count);
        Assert.Equal(0x1234u, result.Flags);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        var reader = new NativeReader([0x83, 0x04, 0xF0, 0x00]);
        Optional<BitString16> result = BitString16Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(12, result.Value.Count);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — bitstring decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<BitString16> result = BitString16Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected()
    {
        var bitString = new BitString16(0xFFFF, count: 16);
        var result = BitString16Codec.Instance.GetEncodedSize(bitString);
        // Tag (1) + Data (1: unused bits) + Data (2: actual bits) = 4
        Assert.Equal(4, result);
    }
}
