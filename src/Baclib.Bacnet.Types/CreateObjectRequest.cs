// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence CreateObject-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CreateObjectRequest
{
    /// <summary>
    /// Specifies the object to be created, either by type alone or by complete identifier.
    /// </summary>
    public required TObjectSpecifier ObjectSpecifier { get; init; }
    
    /// <summary>
    /// An optional list of initial property values to be set when the object is created.
    /// </summary>
    public Optional<TListOfInitialValues> ListOfInitialValues { get; init; }
}
