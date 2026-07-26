// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class ReadPropertyRequestCodecTests
{
    [Fact]
    public void Decode_WithArrayIndex_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x55,
            0x29, 0x03
        ]);

        var result = ReadPropertyRequestCodec.Decode(ref reader);

        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), result.ObjectIdentifier);
        Assert.Equal(PropertyIdentifier.PresentValue, result.PropertyIdentifier);
        Assert.True(result.PropertyArrayIndex.HasValue);
        Assert.Equal(3u, result.PropertyArrayIndex.Value);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithoutArrayIndex_WritesExpected()
    {
        var value = new ReadPropertyRequest
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.All,
            PropertyArrayIndex = Optional<uint>.None
        };
        byte[] expected =
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x08
        ];
        var writer = new AsduWriter(expected.Length);

        ReadPropertyRequestCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }

    [Fact]
    public void GetEncodedLength_WithArrayIndex_IncludesOptionalLength()
    {
        var value = new ReadPropertyRequest
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.PresentValue,
            PropertyArrayIndex = 3u
        };

        var expected =
            AsduElement.GetEncodedLength<ObjectIdentifierCodec, ObjectIdentifier>(0, value.ObjectIdentifier) +
            AsduElement.GetEncodedLength<PropertyIdentifierCodec, PropertyIdentifier>(1, value.PropertyIdentifier) +
            AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);

        Assert.Equal(expected, ReadPropertyRequestCodec.GetEncodedLength(value));
    }
}