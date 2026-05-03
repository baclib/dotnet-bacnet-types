// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetPropertyValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class PropertyValue
{
    /// <summary>
    /// The identifier of the property whose value is given.
    /// </summary>
    public required PropertyIdentifier Identifier { get; init; }
    
    /// <summary>
    /// The index within an array property, if applicable. Optional.
    /// </summary>
    public Optional<Unsigned> Index { get; init; }

    /// <summary>
    /// The value of the specified property.
    /// </summary>
    public required Any Value { get; init; }
    
    /// <summary>
    /// The priority of the value, if applicable. Optional.
    /// </summary>
    public Optional<TPriority> Priority { get; init; }
}
