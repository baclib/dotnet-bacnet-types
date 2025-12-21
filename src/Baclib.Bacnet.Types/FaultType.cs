// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetFaultType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum FaultType : byte
{
    /// <summary>
    /// No fault.
    /// </summary>
    None = 0,

    /// <summary>
    /// Fault in characterstring.
    /// </summary>
    FaultCharacterstring = 1,

    /// <summary>
    /// Extended fault.
    /// </summary>
    FaultExtended = 2,

    /// <summary>
    /// Life safety fault.
    /// </summary>
    FaultLifeSafety = 3,

    /// <summary>
    /// State fault.
    /// </summary>
    FaultState = 4,

    /// <summary>
    /// Status flags fault.
    /// </summary>
    FaultStatusFlags = 5,

    /// <summary>
    /// Out of range fault.
    /// </summary>
    FaultOutOfRange = 6,

    /// <summary>
    /// Listed fault.
    /// </summary>
    FaultListed = 7
}
