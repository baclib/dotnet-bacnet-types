// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence WriteAccessSpecification as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WriteAccessSpecification
{
    /// <summary>
    /// The identifier of the BACnet object to be written.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// A list of property values to be written to the object.
    /// </summary>
    public required TListOfProperties ListOfProperties { get; init; }
    }
