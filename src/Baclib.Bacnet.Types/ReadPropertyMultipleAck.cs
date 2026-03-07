// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ReadPropertyMultiple-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadPropertyMultipleAck
{
    /// <summary>
    /// A list of access results for the properties read from objects.
    /// </summary>
    public required TListOfReadAccessResults ListOfReadAccessResults { get; init; }
    }
