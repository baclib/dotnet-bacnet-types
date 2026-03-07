// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence AddListElement-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AddListElementRequest
{
    /// <summary>
    /// The object identifier containing the list property.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier of the list.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index if the property is an array.
    /// </summary>
    public Unsigned? PropertyArrayIndex { get; init; }

    /// <summary>
    /// The elements to add to the list.
    /// </summary>
    public required Any ListOfElements { get; init; }
    }
