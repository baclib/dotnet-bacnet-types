// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ReadAccessResult as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadAccessResult
{
    /// <summary>
    /// The identifier of the object from which properties were read.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }

    /// <summary>
    /// A list of results for the properties read from the object.
    /// </summary>
    public required SequenceOf<TListOfResultsItem> ListOfResults { get; init; }
}
