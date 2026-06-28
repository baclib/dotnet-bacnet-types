// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetPropertyReference as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class PropertyReference
{
    /// <summary>
    /// The identifier of the property being referenced.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }

    /// <summary>
    /// The index within an array property, if applicable. Optional.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }
}
