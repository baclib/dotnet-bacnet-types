// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Tests;

public class ObjectIdentifierTests
{
    [Fact]
    public void Constructor_WithTypeAndInstance_ShouldPackCorrectly()
    {
        // Act
        var objId = new ObjectIdentifier(ObjectType.AnalogInput, 123);

        // Assert
        Assert.Equal(ObjectType.AnalogInput, objId.Type);
        Assert.Equal(123u, objId.Instance);
    }

    [Fact]
    public void Constructor_WithEncodedValue_ShouldUnpackCorrectly()
    {
        // Arrange
        uint encoded = 0x00C0007B; // AnalogInput (0) << 22 | 123

        // Act
        var objId = new ObjectIdentifier(encoded);

        // Assert
        Assert.Equal(ObjectType.AnalogInput, objId.Type);
        Assert.Equal(123u, objId.Instance);
        Assert.Equal(encoded, objId.Value);
    }

    [Fact]
    public void Constructor_MaxInstanceNumber_ShouldWork()
    {
        // Act
        var objId = new ObjectIdentifier(ObjectType.Device, ObjectIdentifier.MaxInstanceNumber);

        // Assert
        Assert.Equal(ObjectIdentifier.MaxInstanceNumber, objId.Instance);
        Assert.Equal(ObjectType.Device, objId.Type);
    }

    [Fact]
    public void Constructor_MaxObjectType_ShouldWork()
    {
        // Act
        var objId = new ObjectIdentifier(ObjectIdentifier.MaxObjectType, 100);

        // Assert
        Assert.Equal(ObjectIdentifier.MaxObjectType, objId.Type);
        Assert.Equal(100u, objId.Instance);
    }

    [Fact]
    public void Constructor_InstanceTooLarge_ShouldThrow()
    {
        // Arrange
        uint tooLarge = ObjectIdentifier.MaxInstanceNumber + 1;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new ObjectIdentifier(ObjectType.AnalogInput, tooLarge));
    }

    [Fact]
    public void Constructor_TypeTooLarge_ShouldThrow()
    {
        // Arrange
        var tooLarge = (ObjectType)((uint)ObjectIdentifier.MaxObjectType + 1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            new ObjectIdentifier(tooLarge, 100));
    }

    [Fact]
    public void Value_ShouldReturnPackedValue()
    {
        // Arrange
        var objId = new ObjectIdentifier(ObjectType.AnalogInput, 42);

        // Act
        var value = objId.Value;

        // Assert
        // AnalogInput = 0, so (0 << 22) | 42 = 42
        Assert.Equal(42u, value);
    }

    [Fact]
    public void Type_ShouldExtractHighBits()
    {
        // Arrange - AnalogOutput is type 1
        var objId = new ObjectIdentifier(ObjectType.AnalogOutput, 100);

        // Act
        var type = objId.Type;

        // Assert
        Assert.Equal(ObjectType.AnalogOutput, type);
    }

    [Fact]
    public void Instance_ShouldExtractLowBits()
    {
        // Arrange
        var objId = new ObjectIdentifier(ObjectType.Device, 4194303);

        // Act
        var instance = objId.Instance;

        // Assert
        Assert.Equal(4194303u, instance);
    }

    [Fact]
    public void ToString_ShouldReturnTypeAndInstance()
    {
        // Arrange
        var objId = new ObjectIdentifier(ObjectType.AnalogInput, 42);

        // Act
        var result = objId.ToString();

        // Assert
        Assert.Equal("AnalogInput:42", result);
    }

    [Fact]
    public void Equality_SameTypeAndInstance_ShouldBeEqual()
    {
        // Arrange
        var objId1 = new ObjectIdentifier(ObjectType.Device, 1234);
        var objId2 = new ObjectIdentifier(ObjectType.Device, 1234);

        // Assert
        Assert.Equal(objId1, objId2);
        Assert.True(objId1 == objId2);
        Assert.False(objId1 != objId2);
    }

    [Fact]
    public void Equality_DifferentInstance_ShouldNotBeEqual()
    {
        // Arrange
        var objId1 = new ObjectIdentifier(ObjectType.Device, 1234);
        var objId2 = new ObjectIdentifier(ObjectType.Device, 5678);

        // Assert
        Assert.NotEqual(objId1, objId2);
        Assert.False(objId1 == objId2);
        Assert.True(objId1 != objId2);
    }

    [Fact]
    public void Equality_DifferentType_ShouldNotBeEqual()
    {
        // Arrange
        var objId1 = new ObjectIdentifier(ObjectType.Device, 1234);
        var objId2 = new ObjectIdentifier(ObjectType.AnalogInput, 1234);

        // Assert
        Assert.NotEqual(objId1, objId2);
    }

    [Fact]
    public void GetHashCode_SameValue_ShouldHaveSameHashCode()
    {
        // Arrange
        var objId1 = new ObjectIdentifier(ObjectType.Device, 1234);
        var objId2 = new ObjectIdentifier(ObjectType.Device, 1234);

        // Act & Assert
        Assert.Equal(objId1.GetHashCode(), objId2.GetHashCode());
    }

    [Theory]
    [InlineData(ObjectType.AnalogInput, 0)]
    [InlineData(ObjectType.AnalogOutput, 1)]
    [InlineData(ObjectType.Device, 8)]
    [InlineData(ObjectType.AnalogInput, 100)]
    [InlineData(ObjectType.Device, 4194303)]
    public void RoundTrip_ShouldPreserveValues(ObjectType type, uint instance)
    {
        // Arrange
        var objId = new ObjectIdentifier(type, instance);

        // Act
        var reconstructed = new ObjectIdentifier(objId.Value);

        // Assert
        Assert.Equal(type, reconstructed.Type);
        Assert.Equal(instance, reconstructed.Instance);
        Assert.Equal(objId, reconstructed);
    }
}
