// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class WritePropertyMultipleRequestCodecTests
{
    [Fact]
    public void Decode_WithSinglePropertyValue_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x09, 0x55,
            0x2E,
            0x21, 0x2A,
            0x2F,
            0x1F,
            0x1F
        ]);

        var result = WritePropertyMultipleRequestCodec.Decode(ref reader);

        Assert.Single(result.ListOfWriteAccessSpecifications);
        var spec = result.ListOfWriteAccessSpecifications[0];
        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), spec.ObjectIdentifier);
        Assert.Single(spec.ListOfProperties);
        var property = spec.ListOfProperties[0];
        Assert.Equal(PropertyIdentifier.PresentValue, property.Identifier);
        Assert.False(property.Index.HasValue);
        Assert.Equal([0x2E, 0x21, 0x2A, 0x2F], property.Value.EncodedData.Memory.ToArray());
        Assert.False(property.Priority.HasValue);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithSinglePropertyValue_WritesExpected()
    {
        var value = new WritePropertyMultipleRequest
        {
            ListOfWriteAccessSpecifications = SequenceOf<WriteAccessSpecification>.Create(
                new WriteAccessSpecification
                {
                    ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
                    ListOfProperties = SequenceOf<PropertyValue>.Create(
                        new PropertyValue
                        {
                            Identifier = PropertyIdentifier.PresentValue,
                            Index = Optional<uint>.None,
                            Value = Any.FromValue(42u),
                            Priority = Optional<PropertyValue.TPriority>.None
                        })
                })
        };
        byte[] expected =
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x09, 0x55,
            0x2E,
            0x21, 0x2A,
            0x2F,
            0x1F,
            0x1F
        ];
        var writer = new AsduWriter(expected.Length);

        WritePropertyMultipleRequestCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }
}