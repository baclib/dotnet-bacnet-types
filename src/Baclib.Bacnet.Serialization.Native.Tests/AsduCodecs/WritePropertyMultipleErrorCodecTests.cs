// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class WritePropertyMultipleErrorCodecTests
{
    [Fact]
    public void Decode_WithObjectPropertyReference_ReturnsExpected()
    {
        var reader = new AsduReader(
        [
            0x0E,
            0x91, 0x02,
            0x91, 0x20,
            0x0F,
            0x1E,
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x55,
            0x1F
        ]);

        var result = WritePropertyMultipleErrorCodec.Decode(ref reader);

        Assert.Equal(Error.TErrorClass.Property, result.ErrorType.ErrorClass);
        Assert.Equal(Error.TErrorCode.UnknownProperty, result.ErrorType.ErrorCode);
        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), result.FirstFailedWriteAttempt.ObjectIdentifier);
        Assert.Equal(PropertyIdentifier.PresentValue, result.FirstFailedWriteAttempt.PropertyIdentifier);
        Assert.False(result.FirstFailedWriteAttempt.PropertyArrayIndex.HasValue);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_WithObjectPropertyReference_WritesExpected()
    {
        var value = new WritePropertyMultipleError
        {
            ErrorType = new Error
            {
                ErrorClass = Error.TErrorClass.Property,
                ErrorCode = Error.TErrorCode.UnknownProperty
            },
            FirstFailedWriteAttempt = new ObjectPropertyReference
            {
                ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
                PropertyIdentifier = PropertyIdentifier.PresentValue,
                PropertyArrayIndex = Optional<uint>.None
            }
        };
        byte[] expected =
        [
            0x0E,
            0x91, 0x02,
            0x91, 0x20,
            0x0F,
            0x1E,
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x55,
            0x1F
        ];
        var writer = new AsduWriter(expected.Length);

        WritePropertyMultipleErrorCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }
}