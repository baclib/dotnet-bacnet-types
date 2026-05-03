// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence VTClose-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtCloseError
{
    /// <summary>
    /// The type of error that occurred during VT-Close.
    /// </summary>
    public required Error ErrorType { get; init; }
    
    /// <summary>
    /// Optional list of VT session identifiers related to the error.
    /// </summary>
    public Optional<TListOfVtSessionIdentifiers> ListOfVtSessionIdentifiers { get; init; }
}
