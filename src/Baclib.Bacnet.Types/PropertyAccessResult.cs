// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetPropertyAccessResult as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class PropertyAccessResult
{
    /// <summary>
    /// The identifier of the object whose property was accessed.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier specifying the property accessed.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index for the property.
    /// </summary>
    public Unsigned? PropertyArrayIndex { get; init; }

    /// <summary>
    /// Optional identifier of the device associated with the property.
    /// </summary>
    public ObjectIdentifier? DeviceIdentifier { get; init; }

    /// <summary>
    /// The result of accessing the property, either a value or an error.
    /// </summary>
    public required TAccessResult AccessResult { get; init; }
    }
