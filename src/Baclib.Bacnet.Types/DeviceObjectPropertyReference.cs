// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnet Device Object Property Reference as defined in the BACnet protocol specification.
/// This structure is used to uniquely identify a property of an object, optionally within a specific device
/// and optionally at a specific array index.
/// </summary>
/// <param name="ObjectIdentifier">The BACnet object identifier specifying the object being referenced.</param>
/// <param name="PropertyIdentifier">The BACnet property identifier specifying which property of the object is being referenced.</param>
/// <param name="PropertyArrayIndex">
/// Optional array index used only when the property is an array datatype.
/// If omitted when referencing an array property, the entire array is referenced.
/// </param>
/// <param name="DeviceIdentifier">
/// Optional BACnet device identifier specifying the device containing the object.
/// If omitted, the object is assumed to be in the local device.
/// </param>
public readonly record struct DeviceObjectPropertyReference(
    ObjectIdentifier ObjectIdentifier,
    PropertyIdentifier PropertyIdentifier,
    uint? PropertyArrayIndex,
    ObjectIdentifier? DeviceIdentifier)
{
}
