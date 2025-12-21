// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetVTClass as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// Specifies the type of virtual terminal emulation supported.
/// </summary>
public enum VtClass : ushort
{
    /// <summary>
    /// Default terminal type with no specific emulation.
    /// </summary>
    DefaultTerminal = 0,

    /// <summary>
    /// ANSI X3.64 terminal emulation.
    /// </summary>
    AnsiX364 = 1,

    /// <summary>
    /// DEC VT52 terminal emulation.
    /// </summary>
    DecVt52 = 2,

    /// <summary>
    /// DEC VT100 terminal emulation.
    /// </summary>
    DecVt100 = 3,

    /// <summary>
    /// DEC VT220 terminal emulation.
    /// </summary>
    DecVt220 = 4,

    /// <summary>
    /// HP 700/94 terminal emulation.
    /// </summary>
    Hp70094 = 5,

    /// <summary>
    /// IBM 3130 terminal emulation.
    /// </summary>
    Ibm3130 = 6
}
