// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetShedState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ShedState : byte
{
    /// <summary>
    /// No shed request is active.
    /// </summary>
    ShedInactive = 0,

    /// <summary>
    /// A shed request is pending.
    /// </summary>
    ShedRequestPending = 1,

    /// <summary>
    /// The device is compliant with the shed request.
    /// </summary>
    ShedCompliant = 2,

    /// <summary>
    /// The device is not compliant with the shed request.
    /// </summary>
    ShedNonCompliant = 3
}
