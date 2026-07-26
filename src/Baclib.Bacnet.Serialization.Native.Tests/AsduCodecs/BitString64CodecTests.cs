// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

// BitString64 is a bounded-scalar bit string (variable length up to 64 bits, ulong storage, length field).
public class BitString64CodecTests
{
    [Theory]
    [InlineData(0x0000000000000000UL, (byte)64)]
    [InlineData(0x00000000000000FFUL, (byte)8)]
    [InlineData(0x0123456789ABCDEFUL, (byte)64)]
    [InlineData(0x0000000000000005UL, (byte)3)]
    [InlineData(0x0000000000000000UL, (byte)0)]
    [InlineData(0x00000000DEADBEEFUL, (byte)40)]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(ulong flags, byte count)
    {
        var original = new BitString64(flags, count);

        var buffer = new byte[BitString64Codec.GetEncodedValueLength(original)];
        BitString64Codec.EncodeValue(buffer, original);
        var decoded = BitString64Codec.DecodeValue(buffer);

        Assert.Equal(original, decoded);
        Assert.Equal(original.Length, decoded.Length);
    }
}
