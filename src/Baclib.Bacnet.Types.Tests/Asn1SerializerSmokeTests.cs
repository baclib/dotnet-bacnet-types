// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Serialization.Asn1;

namespace Baclib.Bacnet.Types.Tests;

public class Asn1SerializerSmokeTests
{
    [Fact]
    public void EncodeDecode_Boolean_RoundTrips()
    {
        // Act
        byte[] encoded = Asn1Serializer.Encode(true);
        bool decoded = Asn1Serializer.Decode<bool>(encoded);

        // Assert
        Assert.Equal(new byte[] { 0x11 }, encoded);
        Assert.True(decoded);
    }

    [Fact]
    public void EncodeDecode_Unsigned32_RoundTrips()
    {
        const uint value = 300;

        // Act
        byte[] encoded = Asn1Serializer.Encode(value);
        uint decoded = Asn1Serializer.Decode<uint>(encoded);

        // Assert
        Assert.Equal(value, decoded);
    }

    [Fact]
    public void EncodeDecode_CharacterString_RoundTrips()
    {
        CharacterString value = new("BACnet", CharacterSet.Utf8);

        // Act
        byte[] encoded = Asn1Serializer.Encode(value);
        CharacterString decoded = Asn1Serializer.Decode<CharacterString>(encoded);

        // Assert
        Assert.Equal(value, decoded);
    }

    [Fact]
    public void Decode_WithRuntimeType_Works()
    {
        byte[] encoded = Asn1Serializer.Encode((uint)42);

        // Act
        object decoded = Asn1Serializer.Decode(encoded, typeof(uint));

        // Assert
        Assert.IsType<uint>(decoded);
        Assert.Equal((uint)42, (uint)decoded);
    }

    [Fact]
    public void TryDecode_WithWrongType_ReturnsFalse()
    {
        byte[] encoded = Asn1Serializer.Encode((uint)42);

        // Act
        bool success = Asn1Serializer.TryDecode<bool>(encoded, out bool decoded);

        // Assert
        Assert.False(success);
        Assert.False(decoded);
    }
}
