// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetColorTransition as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ColorTransition : byte
{
    /// <summary>
    /// No color transition.
    /// </summary>
    None = 0,

    /// <summary>
    /// Fade color transition.
    /// </summary>
    Fade = 1,

    /// <summary>
    /// Ramp color transition.
    /// </summary>
    Ramp = 2
}
