// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class DeviceObjectPropertyReferenceCodecTests
{
    [Fact]
    public void Decode_WithoutOptionalFields_ReturnsNoneForOptionals()
    {
        var reader = new AsduReader(
        [
            0x0E,
            0x0C, 0x00, 0x00, 0x00, 0x02,
            0x19, 0x08,
            0x0F
        ]);

        var result = DeviceObjectPropertyReferenceCodec.Decode(ref reader, 0);

        Assert.Equal(new ObjectIdentifier(ObjectType.AnalogInput, 2), result.ObjectIdentifier);
        Assert.Equal(PropertyIdentifier.All, result.PropertyIdentifier);
        Assert.False(result.PropertyArrayIndex.HasValue);
        Assert.False(result.DeviceIdentifier.HasValue);
    }

    [Fact]
    public void GetEncodedLength_WithOptionalFields_IncludesOptionalLengths()
    {
        var value = new DeviceObjectPropertyReference
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.All,
            PropertyArrayIndex = 3u,
            DeviceIdentifier = new ObjectIdentifier(ObjectType.Device, 1)
        };

        var expected =
            AsduElement.GetEncodedLength<ObjectIdentifierCodec, ObjectIdentifier>(0, value.ObjectIdentifier) +
            AsduElement.GetEncodedLength<PropertyIdentifierCodec, PropertyIdentifier>(1, value.PropertyIdentifier) +
            AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex) +
            AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, ObjectIdentifier>(3, value.DeviceIdentifier);

        Assert.Equal(expected, DeviceObjectPropertyReferenceCodec.GetEncodedLength(value));
    }

    [Fact]
    public void GetEncodedLength_WithoutOptionalFields_OmitsOptionalLengths()
    {
        var value = new DeviceObjectPropertyReference
        {
            ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
            PropertyIdentifier = PropertyIdentifier.All,
            PropertyArrayIndex = Optional<uint>.None,
            DeviceIdentifier = Optional<ObjectIdentifier>.None
        };

        var expected =
            AsduElement.GetEncodedLength<ObjectIdentifierCodec, ObjectIdentifier>(0, value.ObjectIdentifier) +
            AsduElement.GetEncodedLength<PropertyIdentifierCodec, PropertyIdentifier>(1, value.PropertyIdentifier);

        Assert.Equal(expected, DeviceObjectPropertyReferenceCodec.GetEncodedLength(value));
    }
}