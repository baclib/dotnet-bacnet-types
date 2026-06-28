// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence Who-Has-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WhoHasRequest
{
    /// <summary>
    /// Optional range of device instance numbers to limit the search.
    /// </summary>
    public Optional<TLimits> Limits { get; init; }

    /// <summary>
    /// The object to search for, specified by identifier or name.
    /// </summary>
    public required TObject Object { get; init; }
}
