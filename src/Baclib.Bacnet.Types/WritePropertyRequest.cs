// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence WriteProperty-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WritePropertyRequest
{
    /// <summary>
    /// The identifier of the BACnet object whose property is to be written.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the property to be written.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// The index within an array property, if applicable. Optional.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// The value to write to the property.
    /// </summary>
    public required Any PropertyValue { get; init; }
    
    /// <summary>
    /// The priority of the write operation, if applicable. Optional.
    /// </summary>
    public Optional<TPriority> Priority { get; init; }
}
