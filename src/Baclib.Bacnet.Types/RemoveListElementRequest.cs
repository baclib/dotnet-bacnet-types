// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence RemoveListElement-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class RemoveListElementRequest
{
    /// <summary>
    /// The identifier of the object from which elements are to be removed.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier specifying the list.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index for the property list.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// The elements to be removed from the list.
    /// </summary>
    public required Any ListOfElements { get; init; }
    }
