// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// DaysOfWeek is a fixed-scalar bit string (fixed 7-bit length, byte storage, no length field).
public class DaysOfWeekCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_Monday_ReturnsExpected()
    {
        // Application tag 8 (BitString), length 2: (8 << 4) | 2 = 0x82.
        // Payload: unusedBits = 1, data byte = 0x80 (bit 0 set in wire MSB-first order).
        var reader = new AsduReader([0x82, 0x01, 0x80]);
        var result = DaysOfWeekCodec.Decode(ref reader);
        Assert.Equal(7, result.Length);
        Assert.Equal((byte)0x01, result.Flags);
    }

    [Theory]
    [InlineData((byte)0x00)]
    [InlineData((byte)0x01)]
    [InlineData((byte)0x2A)]
    [InlineData((byte)0x7F)]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(byte flags)
    {
        var original = new DaysOfWeek(flags);

        var buffer = new byte[DaysOfWeekCodec.GetEncodedValueLength(original)];
        DaysOfWeekCodec.EncodeValue(buffer, original);
        var decoded = DaysOfWeekCodec.DecodeValue(buffer);

        Assert.Equal(original, decoded);
    }
}
