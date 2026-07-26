// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class ReadPropertyMultipleAckCodecTests
{
    [Fact]
    public void Decode_WithSinglePropertyValueResult_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x29, 0x55,
            0x4E,
            0x21, 0x2A,
            0x4F,
            0x1F,
            0x1F
        ]);

        var result = ReadPropertyMultipleAckCodec.Decode(ref reader);

        Assert.Single(result.ListOfReadAccessResults);
        var accessResult = result.ListOfReadAccessResults[0];
        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), accessResult.ObjectIdentifier);
        Assert.Single(accessResult.ListOfResults);
        var item = accessResult.ListOfResults[0];
        Assert.Equal(PropertyIdentifier.PresentValue, item.PropertyIdentifier);
        Assert.False(item.PropertyArrayIndex.HasValue);
        Assert.Equal(ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyValue, item.ReadResult.Choice);
        Assert.Equal([0x4E, 0x21, 0x2A, 0x4F], item.ReadResult.PropertyValue.EncodedData.Memory.ToArray());
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithSinglePropertyValueResult_WritesExpected()
    {
        var value = new ReadPropertyMultipleAck
        {
            ListOfReadAccessResults = SequenceOf<ReadAccessResult>.Create(
                new ReadAccessResult
                {
                    ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
                    ListOfResults = SequenceOf<ReadAccessResult.TListOfResultsItem>.Create(
                        new ReadAccessResult.TListOfResultsItem
                        {
                            PropertyIdentifier = PropertyIdentifier.PresentValue,
                            PropertyArrayIndex = Optional<uint>.None,
                            ReadResult = ReadAccessResult.TListOfResultsItem.TReadResult.FromPropertyValue(Any.FromValue(42u))
                        })
                })
        };
        byte[] expected =
        [
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x1E,
            0x1E,
            0x29, 0x55,
            0x4E,
            0x21, 0x2A,
            0x4F,
            0x1F,
            0x1F
        ];
        var writer = new AsduWriter(expected.Length);

        ReadPropertyMultipleAckCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }
}