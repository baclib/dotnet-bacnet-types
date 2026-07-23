// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class EnumeratedCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsExpected()
    {
        var reader = new AsduReader([0x92, 0x01, 0x00]);

        Assert.Equal((Enumerated16)256, Enumerated16Codec.Decode(ref reader));
    }

    [Theory]
    [InlineData((byte)AuthenticationFactorType.Guid, 1)]
    public void AuthenticationFactorType_RoundTrip_UsesExpectedPayloadLength(byte rawValue, int expectedLength)
    {
        var original = (AuthenticationFactorType)rawValue;

        var buffer = new byte[AuthenticationFactorTypeCodec.GetEncodedValueLength(original)];
        AuthenticationFactorTypeCodec.EncodeValue(buffer, original);
        var decoded = AuthenticationFactorTypeCodec.DecodeValue(buffer);

        Assert.Equal(expectedLength, buffer.Length);
        Assert.Equal(original, decoded);
    }

    [Theory]
    [InlineData((ushort)42, 1)]
    [InlineData((ushort)256, 2)]
    public void EngineeringUnits_RoundTrip_UsesExpectedPayloadLength(ushort rawValue, int expectedLength)
    {
        var original = (EngineeringUnits)rawValue;

        var buffer = new byte[EngineeringUnitsCodec.GetEncodedValueLength(original)];
        EngineeringUnitsCodec.EncodeValue(buffer, original);
        var decoded = EngineeringUnitsCodec.DecodeValue(buffer);

        Assert.Equal(expectedLength, buffer.Length);
        Assert.Equal(original, decoded);
    }

    [Theory]
    [InlineData(42u, 1)]
    [InlineData(256u, 2)]
    [InlineData(65536u, 3)]
    [InlineData(uint.MaxValue, 4)]
    public void Enumerated_RoundTrip_UsesExpectedPayloadLength(uint rawValue, int expectedLength)
    {
        var original = (Enumerated)rawValue;

        var buffer = new byte[EnumeratedCodec.GetEncodedValueLength(original)];
        EnumeratedCodec.EncodeValue(buffer, original);
        var decoded = EnumeratedCodec.DecodeValue(buffer);

        Assert.Equal(expectedLength, buffer.Length);
        Assert.Equal(original, decoded);
    }

    [Theory]
    [InlineData(42ul, 1)]
    [InlineData(65536ul, 3)]
    [InlineData(4294967296ul, 5)]
    public void Enumerated64_RoundTrip_UsesExpectedPayloadLength(ulong rawValue, int expectedLength)
    {
        var original = (Enumerated64)rawValue;

        var buffer = new byte[Enumerated64Codec.GetEncodedValueLength(original)];
        Enumerated64Codec.EncodeValue(buffer, original);
        var decoded = Enumerated64Codec.DecodeValue(buffer);

        Assert.Equal(expectedLength, buffer.Length);
        Assert.Equal(original, decoded);
    }
}