// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

// BitString is the variable-array base bit string (arbitrary length, byte[] storage, length field).
public class BitStringCodecTests
{
    public static TheoryData<byte[], ushort> Samples =>
        new()
        {
            { [], 0 },
            { [0x01], 8 },
            { [0xAB, 0x03], 10 },
            { [0xFF, 0xFF, 0x0F], 20 },
        };

    [Theory]
    [MemberData(nameof(Samples))]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(byte[] flags, ushort count)
    {
        var original = new BitString(flags, count);

        var buffer = new byte[BitStringCodec.GetEncodedValueLength(original)];
        BitStringCodec.EncodeValue(buffer, original);
        var decoded = BitStringCodec.DecodeValue(buffer);

        Assert.Equal(original.Length, decoded.Length);
        Assert.True(original.Flags.AsSpan().SequenceEqual(decoded.Flags));
    }

    [Fact]
    public void Decode_ApplicationTagged_ReturnsExpectedBits()
    {
        // Application tag 8 (BitString), length 3: (8 << 4) | 3 = 0x83.
        // Payload: unusedBits = 6, data bytes 0x80 0x00 -> 10 bits, bit 0 set.
        var reader = new AsduReader([0x83, 0x06, 0x80, 0x00]);
        var result = BitStringCodec.Decode(ref reader);
        Assert.Equal(10, result.Length);
        Assert.True(result[0]);
        Assert.False(result[1]);
    }
}
