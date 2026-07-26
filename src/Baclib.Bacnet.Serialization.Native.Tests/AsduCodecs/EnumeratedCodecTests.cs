// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class EnumeratedCodecTests
{
    [Fact]
    public void Enumerated8_Decode_ApplicationTagged_ReturnsExpected()
    {
        var reader = new AsduReader([0x91, 0x2A]);

        Assert.Equal((Enumerated8)42, Enumerated8Codec.Decode(ref reader));
    }

    [Fact]
    public void Enumerated16_Decode_ApplicationTagged_ReturnsExpected()
    {
        var reader = new AsduReader([0x92, 0x01, 0x00]);

        Assert.Equal((Enumerated16)256, Enumerated16Codec.Decode(ref reader));
    }

    [Fact]
    public void Enumerated32_Decode_ApplicationTagged_ReturnsExpected()
    {
        var reader = new AsduReader([0x93, 0x01, 0x00, 0x00]);

        Assert.Equal((Enumerated32)65536u, Enumerated32Codec.Decode(ref reader));
    }

    [Fact]
    public void Enumerated_Decode_ContextTagged_ReturnsExpected()
    {
        var reader = new AsduReader([0x0A, 0x01, 0x00]);

        Assert.Equal((Enumerated)256u, EnumeratedCodec.Decode(ref reader, tagNumber: 0));
    }

    [Theory]
    [InlineData((byte)42)]
    [InlineData(byte.MaxValue)]
    public void Enumerated8_RoundTrip_PreservesValue(byte rawValue)
    {
        var original = (Enumerated8)rawValue;

        AssertRoundTrip(
            original,
            expectedLength: 1,
            value => Enumerated8Codec.GetEncodedValueLength(value),
            (destination, value) => Enumerated8Codec.EncodeValue(destination, value),
            value => Enumerated8Codec.DecodeValue(value));
    }

    [Theory]
    [InlineData((ushort)42, 1)]
    [InlineData((ushort)256, 2)]
    [InlineData(ushort.MaxValue, 2)]
    public void Enumerated16_RoundTrip_UsesExpectedPayloadLength(ushort rawValue, int expectedLength)
    {
        var original = (Enumerated16)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => Enumerated16Codec.GetEncodedValueLength(value),
            (destination, value) => Enumerated16Codec.EncodeValue(destination, value),
            value => Enumerated16Codec.DecodeValue(value));
    }

    [Theory]
    [InlineData(42u, 1)]
    [InlineData(256u, 2)]
    [InlineData(65536u, 3)]
    [InlineData(uint.MaxValue, 4)]
    public void Enumerated32_RoundTrip_UsesExpectedPayloadLength(uint rawValue, int expectedLength)
    {
        var original = (Enumerated32)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => Enumerated32Codec.GetEncodedValueLength(value),
            (destination, value) => Enumerated32Codec.EncodeValue(destination, value),
            value => Enumerated32Codec.DecodeValue(value));
    }

    [Theory]
    [InlineData((byte)AuthenticationFactorType.Guid, 1)]
    public void AuthenticationFactorType_RoundTrip_UsesExpectedPayloadLength(byte rawValue, int expectedLength)
    {
        var original = (AuthenticationFactorType)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => AuthenticationFactorTypeCodec.GetEncodedValueLength(value),
            (destination, value) => AuthenticationFactorTypeCodec.EncodeValue(destination, value),
            value => AuthenticationFactorTypeCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData((byte)AbortReason.Other, 1)]
    [InlineData((byte)AbortReason.InvalidApduInThisState, 1)]
    public void AbortReason_RoundTrip_UsesExpectedPayloadLength(byte rawValue, int expectedLength)
    {
        var original = (AbortReason)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => AbortReasonCodec.GetEncodedValueLength(value),
            (destination, value) => AbortReasonCodec.EncodeValue(destination, value),
            value => AbortReasonCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData((ushort)42, 1)]
    [InlineData((ushort)256, 2)]
    public void EngineeringUnits_RoundTrip_UsesExpectedPayloadLength(ushort rawValue, int expectedLength)
    {
        var original = (EngineeringUnits)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => EngineeringUnitsCodec.GetEncodedValueLength(value),
            (destination, value) => EngineeringUnitsCodec.EncodeValue(destination, value),
            value => EngineeringUnitsCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData((ushort)ObjectType.Device, 1)]
    [InlineData((ushort)256, 2)]
    public void ObjectType_RoundTrip_UsesExpectedPayloadLength(ushort rawValue, int expectedLength)
    {
        var original = (ObjectType)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => ObjectTypeCodec.GetEncodedValueLength(value),
            (destination, value) => ObjectTypeCodec.EncodeValue(destination, value),
            value => ObjectTypeCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData(42u, 1)]
    [InlineData(256u, 2)]
    [InlineData(65536u, 3)]
    [InlineData(uint.MaxValue, 4)]
    public void Enumerated_RoundTrip_UsesExpectedPayloadLength(uint rawValue, int expectedLength)
    {
        var original = (Enumerated)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => EnumeratedCodec.GetEncodedValueLength(value),
            (destination, value) => EnumeratedCodec.EncodeValue(destination, value),
            value => EnumeratedCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData((uint)PropertyIdentifier.All, 1)]
    [InlineData(256u, 2)]
    [InlineData(65536u, 3)]
    [InlineData(uint.MaxValue, 4)]
    public void PropertyIdentifier_RoundTrip_UsesExpectedPayloadLength(uint rawValue, int expectedLength)
    {
        var original = (PropertyIdentifier)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => PropertyIdentifierCodec.GetEncodedValueLength(value),
            (destination, value) => PropertyIdentifierCodec.EncodeValue(destination, value),
            value => PropertyIdentifierCodec.DecodeValue(value));
    }

    [Theory]
    [InlineData(42ul, 1)]
    [InlineData(65536ul, 3)]
    [InlineData(4294967296ul, 5)]
    [InlineData(ulong.MaxValue, 8)]
    public void Enumerated64_RoundTrip_UsesExpectedPayloadLength(ulong rawValue, int expectedLength)
    {
        var original = (Enumerated64)rawValue;

        AssertRoundTrip(
            original,
            expectedLength,
            value => Enumerated64Codec.GetEncodedValueLength(value),
            (destination, value) => Enumerated64Codec.EncodeValue(destination, value),
            value => Enumerated64Codec.DecodeValue(value));
    }

    private static void AssertRoundTrip<TEnum>(
        TEnum original,
        int expectedLength,
        Func<TEnum, int> getEncodedValueLength,
        Action<Span<byte>, TEnum> encodeValue,
        Func<ReadOnlySpan<byte>, TEnum> decodeValue)
        where TEnum : struct, Enum
    {
        var buffer = new byte[getEncodedValueLength(original)];

        Assert.Equal(expectedLength, buffer.Length);

        encodeValue(buffer, original);
        var decoded = decodeValue(buffer);

        Assert.Equal(original, decoded);
    }
}