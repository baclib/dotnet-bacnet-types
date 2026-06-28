// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class BitString32CodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_EmptyBitString_ReturnsEmpty()
    {
        // Application tag 8 (BitString), extended length 5: 0x85 0x05
        // data 0x20 followed by 4 zeros (all 32 bits unused, unused bits = 32 = 0x20)
        var reader = new NativeReader([0x85, 0x05, 0x20, 0x00, 0x00, 0x00, 0x00]);
        var result = BitString32Codec.Instance.Decode(ref reader);
        Assert.Equal(0, result.Length);
    }

    [Fact]
    public void Decode_ApplicationTagged_SingleBit_ReturnsValue()
    {
        // Application tag 8, extended length 5: 0x85 0x05
        // Data: unused bits = 31, followed by wire bytes 0x80 0x00 0x00 0x00 (decodes to native flags 0x00000001)
        var reader = new NativeReader([0x85, 0x05, 0x1F, 0x80, 0x00, 0x00, 0x00]);
        var result = BitString32Codec.Instance.Decode(ref reader);
        Assert.Equal(1, result.Length);
        Assert.Equal(0x00000001u, result.Flags);
    }

    [Fact]
    public void Decode_ApplicationTagged_AllBits_ReturnsValue()
    {
        // Application tag 8, extended length 5: 0x85 0x05
        // Data: unused bits = 0, followed by 4 bytes = 0xFF 0xFF 0xFF 0xFF
        var reader = new NativeReader([0x85, 0x05, 0x00, 0xFF, 0xFF, 0xFF, 0xFF]);
        var result = BitString32Codec.Instance.Decode(ref reader);
        Assert.Equal(32, result.Length);
        Assert.Equal(0xFFFFFFFFu, result.Flags);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsValue()
    {
        // Context tag 4, extended length 5: 0x4D 0x05
        // Data: unused bits = 0, followed by wire bytes 0x1E 0x6A 0x2C 0x48 (decodes to flags 0x12345678)
        var reader = new NativeReader([0x4D, 0x05, 0x00, 0x1E, 0x6A, 0x2C, 0x48]);
        var result = BitString32Codec.Instance.Decode(ref reader, tagNumber: 4);
        Assert.Equal(32, result.Length);
        Assert.Equal(0x12345678u, result.Flags);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsValue()
    {
        var reader = new NativeReader([0x85, 0x05, 0x08, 0xF0, 0x00, 0x00, 0x00]);
        Optional<BitString32> result = BitString32Codec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(24, result.Value.Length);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — bitstring decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<BitString32> result = BitString32Codec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_ReturnsExpected()
    {
        var bitString = new BitString32(0xFFFFFFFF, count: 32);
        var result = BitString32Codec.Instance.GetEncodedSize(bitString);
        // Tag (1) + Length indicator (1) + Data (1: unused bits) + Data (4: actual bits) = 7
        Assert.Equal(7, result);
    }
}
