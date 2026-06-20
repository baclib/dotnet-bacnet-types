// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ReadProperty-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadPropertyAck
{
    /// <summary>
    /// The identifier of the object being read.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier specifying the property being read.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index for the property.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// The value of the property being read.
    /// </summary>
    public required Any PropertyValue { get; init; }
    }
