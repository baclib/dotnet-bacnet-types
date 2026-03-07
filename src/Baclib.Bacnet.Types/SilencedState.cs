// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetSilencedState as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum SilencedState : ushort
{
    /// <summary>
    /// Neither audible nor visible alarms are silenced.
    /// </summary>
    Unsilenced = 0,

    /// <summary>
    /// Audible alarms are silenced.
    /// </summary>
    AudibleSilenced = 1,

    /// <summary>
    /// Visible alarms are silenced.
    /// </summary>
    VisibleSilenced = 2,

    /// <summary>
    /// Both audible and visible alarms are silenced.
    /// </summary>
    AllSilenced = 3
}
