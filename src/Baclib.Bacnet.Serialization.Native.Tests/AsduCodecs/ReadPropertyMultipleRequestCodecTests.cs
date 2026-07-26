// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class ReadPropertyMultipleRequestCodecTests
{
    [Fact]
    public void Decode_WithSingleAccessSpecification_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x09, 0x55,
            0x1F,
            0x1F
        ]);

        var result = ReadPropertyMultipleRequestCodec.Decode(ref reader);

        Assert.Single(result.ListOfReadAccessSpecifications);
        var spec = result.ListOfReadAccessSpecifications[0];
        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), spec.ObjectIdentifier);
        Assert.Single(spec.ListOfPropertyReferences);
        Assert.Equal(PropertyIdentifier.PresentValue, spec.ListOfPropertyReferences[0].PropertyIdentifier);
        Assert.False(spec.ListOfPropertyReferences[0].PropertyArrayIndex.HasValue);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithSingleAccessSpecification_WritesExpected()
    {
        var value = new ReadPropertyMultipleRequest
        {
            ListOfReadAccessSpecifications = SequenceOf<ReadAccessSpecification>.Create(
                new ReadAccessSpecification
                {
                    ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
                    ListOfPropertyReferences = SequenceOf<PropertyReference>.Create(
                        new PropertyReference
                        {
                            PropertyIdentifier = PropertyIdentifier.PresentValue,
                            PropertyArrayIndex = Optional<uint>.None
                        })
                })
        };
        byte[] expected =
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x09, 0x55,
            0x1F,
            0x1F
        ];
        var writer = new AsduWriter(expected.Length);

        ReadPropertyMultipleRequestCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }

    [Fact]
    public void GetEncodedLength_WithSingleAccessSpecification_ReturnsExpected()
    {
        var value = new ReadPropertyMultipleRequest
        {
            ListOfReadAccessSpecifications = SequenceOf<ReadAccessSpecification>.Create(
                new ReadAccessSpecification
                {
                    ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
                    ListOfPropertyReferences = SequenceOf<PropertyReference>.Create(
                        new PropertyReference
                        {
                            PropertyIdentifier = PropertyIdentifier.PresentValue,
                            PropertyArrayIndex = Optional<uint>.None
                        })
                })
        };

        var expected = AsduElement.GetSequenceOfEncodedLength<ReadAccessSpecificationCodec, ReadAccessSpecification>(value.ListOfReadAccessSpecifications);

        Assert.Equal(expected, ReadPropertyMultipleRequestCodec.GetEncodedLength(value));
    }
}