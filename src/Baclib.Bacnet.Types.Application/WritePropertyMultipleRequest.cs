// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence WritePropertyMultiple-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WritePropertyMultipleRequest
{
    /// <summary>
    /// A list of write access specifications, each defining properties to write for a specific object.
    /// </summary>
    public required TListOfWriteAccessSpecifications ListOfWriteAccessSpecifications { get; init; }
    }
