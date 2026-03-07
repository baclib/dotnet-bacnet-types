// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetDeviceObjectPropertyReference as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeviceObjectPropertyReference
{
    /// <summary>
    /// The identifier of the BACnet object containing the property.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the property within the object.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// The index within an array property, if applicable. Optional.
    /// </summary>
    public Unsigned? PropertyArrayIndex { get; init; }

    /// <summary>
    /// The identifier of the BACnet device containing the object, if not local. Optional.
    /// </summary>
    public ObjectIdentifier? DeviceIdentifier { get; init; }
}
