// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// BitString8 is a bounded-scalar bit string (variable length up to 8 bits, byte storage, length field).
public class BitString8CodecTests
{
    [Theory]
    [InlineData((byte)0x00, (byte)8)]
    [InlineData((byte)0x05, (byte)8)]
    [InlineData((byte)0x05, (byte)5)]
    [InlineData((byte)0xFF, (byte)8)]
    [InlineData((byte)0x00, (byte)0)]
    [InlineData((byte)0x0A, (byte)6)]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(byte flags, byte count)
    {
        var original = new BitString8(flags, count);

        var buffer = new byte[BitString8Codec.GetEncodedValueLength(original)];
        BitString8Codec.EncodeValue(buffer, original);
        var decoded = BitString8Codec.DecodeValue(buffer);

        Assert.Equal(original, decoded);
        Assert.Equal(original.Length, decoded.Length);
    }
}
