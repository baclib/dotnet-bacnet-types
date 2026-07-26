// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

// StatusFlags is a fixed-scalar bit string (fixed 4-bit length, byte storage, no length field).
public class StatusFlagsCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_InAlarm_ReturnsExpected()
    {
        // Application tag 8 (BitString), length 2: (8 << 4) | 2 = 0x82.
        // Payload: unusedBits = 4, data byte = 0x80 (bit 0 set in wire MSB-first order).
        var reader = new AsduReader([0x82, 0x04, 0x80]);
        var result = StatusFlagsCodec.Decode(ref reader);
        Assert.True(result.InAlarm);
        Assert.False(result.Fault);
        Assert.Equal(4, result.Length);
        Assert.Equal((byte)0x01, result.Flags);
    }

    [Theory]
    [InlineData((byte)0x00)]
    [InlineData((byte)0x01)]
    [InlineData((byte)0x0A)]
    [InlineData((byte)0x0F)]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(byte flags)
    {
        var original = new StatusFlags(flags);

        var buffer = new byte[StatusFlagsCodec.GetEncodedValueLength(original)];
        StatusFlagsCodec.EncodeValue(buffer, original);
        var decoded = StatusFlagsCodec.DecodeValue(buffer);

        Assert.Equal(original, decoded);
    }
}
