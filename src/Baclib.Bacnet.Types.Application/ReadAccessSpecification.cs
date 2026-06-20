// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ReadAccessSpecification as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadAccessSpecification
{
    /// <summary>
    /// The identifier of the object to read from.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// A list of property references to be read from the object.
    /// </summary>
    public required TListOfPropertyReferences ListOfPropertyReferences { get; init; }
    }
