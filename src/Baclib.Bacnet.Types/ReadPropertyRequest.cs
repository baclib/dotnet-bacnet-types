// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ReadProperty-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadPropertyRequest
{
    /// <summary>
    /// The identifier of the object to read from.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier specifying the property to read.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index for the property.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }
}
