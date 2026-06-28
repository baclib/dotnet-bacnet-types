// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence VT-Close-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtCloseRequest
{
    /// <summary>
    /// List of remote VT session identifiers to be closed.
    /// </summary>
    public required SequenceOf<Unsigned8> ListOfRemoteVtSessionIdentifiers { get; init; }
}
