// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class WritePropertyRequestCodecTests
{
    [Fact]
    public void Decode_WithPropertyValueAndPriority_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x55,
            0x29, 0x03,
            0x3E,
            0x21, 0x2A,
            0x3F,
            0x49, 0x08
        ]);

        var result = WritePropertyRequestCodec.Decode(ref reader);

        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), result.ObjectIdentifier);
        Assert.Equal(PropertyIdentifier.PresentValue, result.PropertyIdentifier);
        Assert.True(result.PropertyArrayIndex.HasValue);
        Assert.Equal(3u, result.PropertyArrayIndex.Value);
        Assert.Equal([0x3E, 0x21, 0x2A, 0x3F], result.PropertyValue.EncodedData.Memory.ToArray());
        Assert.True(result.Priority.HasValue);
        Assert.Equal((WritePropertyRequest.TPriority)8, result.Priority.Value);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithPropertyValueAndPriority_WritesExpected()
    {
        var value = new WritePropertyRequest
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.PresentValue,
            PropertyArrayIndex = 3u,
            PropertyValue = Any.FromValue(42u),
            Priority = new WritePropertyRequest.TPriority(8)
        };
        byte[] expected =
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x55,
            0x29, 0x03,
            0x3E,
            0x21, 0x2A,
            0x3F,
            0x49, 0x08
        ];
        var writer = new AsduWriter(expected.Length);

        WritePropertyRequestCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }

    [Fact]
    public void GetEncodedLength_WithPropertyValueAndPriority_IncludesAllFields()
    {
        var value = new WritePropertyRequest
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.PresentValue,
            PropertyArrayIndex = 3u,
            PropertyValue = Any.FromValue(42u),
            Priority = new WritePropertyRequest.TPriority(8)
        };

        var expected =
            AsduElement.GetEncodedLength<ObjectIdentifierCodec, ObjectIdentifier>(0, value.ObjectIdentifier) +
            AsduElement.GetEncodedLength<PropertyIdentifierCodec, PropertyIdentifier>(1, value.PropertyIdentifier) +
            AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex) +
            AsduElement.GetEncodedLength<AnyCodec, Any>(3, value.PropertyValue) +
            AsduElement.GetOptionalEncodedLength<WritePropertyRequestTPriorityCodec, WritePropertyRequest.TPriority>(4, value.Priority);

        Assert.Equal(expected, WritePropertyRequestCodec.GetEncodedLength(value));
    }
}