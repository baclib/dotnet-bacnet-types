// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class BitString64CodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyBitString_ReturnsEmpty()
    {
        // Application tag 8 (BitString), extended length 9: 0x85 0x09
        // data 0x40 (unused bits) followed by 8 data bytes (all zeros)
        var reader = new NativeReader([0x85, 0x09, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        var result = BitString64Codec.Instance.Decode(ref reader);
        Assert.Equal(0, result.Length);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleBit_ReturnsValue()
    {
        // Application tag 8, extended length 9: 0x85 0x09
        // Data: unused bits = 63, followed by wire bytes starting with 0x80 (decodes to native flags 0x0000000000000001)
        var reader = new NativeReader([0x85, 0x09, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        var result = BitString64Codec.Instance.Decode(ref reader);
        Assert.Equal(1, result.Length);
        Assert.Equal(0x0000000000000001uL, result.Flags);
    }

    [Fact]
    public void Decode_ApplicationTagged_AllBits_ReturnsValue()
    {
        // Application tag 8, extended length 9: 0x85 0x09
        // Data: unused bits = 0, followed by 8 bytes = 0xFF (all bits set)
        var reader = new NativeReader([0x85, 0x09, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF]);
        var result = BitString64Codec.Instance.Decode(ref reader);
        Assert.Equal(64, result.Length);
        Assert.Equal(0xFFFFFFFFFFFFFFFFuL, result.Flags);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        var reader = new NativeReader([0x85, 0x09, 0x10, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Optional<BitString64> result = BitString64Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(48, result.Value.Length);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 5, extended length 9: 0x5D 0x09
        // Data: unused bits = 0, followed by wire bytes that decode to flags 0x123456789ABCDEF0
        var reader = new NativeReader([0x5D, 0x09, 0x00, 0x0F, 0x7B, 0x3D, 0x59, 0x1E, 0x6A, 0x2C, 0x48]);
        var result = BitString64Codec.Instance.Decode(ref reader, tagNumber: 5);
        Assert.Equal(64, result.Length);
        Assert.Equal(0x123456789ABCDEF0uL, result.Flags);
    }

    [Fact]
    public void DecodeOptional_ContextTagged_ReturnsValue()
    {
        // Context tag 3, extended length 9: 0x3D 0x09
        var reader = new NativeReader([0x3D, 0x09, 0x30, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]);
        Optional<BitString64> result = BitString64Codec.Instance.DecodeOptional(ref reader, tagNumber: 3);
        Assert.True(result.HasValue);
        Assert.Equal(16, result.Value.Length);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — bitstring decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<BitString64> result = BitString64Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected()
    {
        var bitString = new BitString64(0xFFFFFFFFFFFFFFFF, count: 64);
        var result = BitString64Codec.Instance.GetEncodedSize(bitString);
        // Tag (1) + Length indicator (1) + Data (1: unused bits) + Data (8: actual bits) = 11
        Assert.Equal(11, result);
    }
}
