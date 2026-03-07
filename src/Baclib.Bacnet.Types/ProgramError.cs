// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetProgramError as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum ProgramError : ushort
{
    /// <summary>
    /// No program error.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Program load failed.
    /// </summary>
    LoadFailed = 1,

    /// <summary>
    /// Internal program error.
    /// </summary>
    Internal = 2,

    /// <summary>
    /// Program error.
    /// </summary>
    Program = 3,

    /// <summary>
    /// Other program error.
    /// </summary>
    Other = 4
}
