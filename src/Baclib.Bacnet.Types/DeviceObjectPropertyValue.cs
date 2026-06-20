// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetDeviceObjectPropertyValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeviceObjectPropertyValue
{
    /// <summary>
    /// The identifier of the BACnet device containing the object.
    /// </summary>
    public required ObjectIdentifier DeviceIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the BACnet object containing the property.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the property whose value is given.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// The index within an array property, if applicable. Optional.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// The value of the specified property.
    /// </summary>
    public required Any PropertyValue { get; init; }
    }
