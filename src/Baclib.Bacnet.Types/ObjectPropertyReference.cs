// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnet object property reference that uniquely identifies a property of a specific object.
/// </summary>
/// <param name="ObjectIdentifier">The identifier of the BACnet object being referenced.</param>
/// <param name="PropertyIdentifier">The identifier of the property being referenced.</param>
/// <param name="PropertyArrayIndex">
/// Optional index when the property is an array datatype. 
/// If <see langword="null"/> when referencing an array property, the entire array is referenced.
/// </param>
public readonly record struct ObjectPropertyReference(
    ObjectIdentifier ObjectIdentifier,
    PropertyIdentifier PropertyIdentifier,
    uint? PropertyArrayIndex)
{
}
