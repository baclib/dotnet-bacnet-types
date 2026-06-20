// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetNotifyType as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum NotifyType : byte
{
    /// <summary>
    /// Alarm notification type.
    /// </summary>
    Alarm = 0,

    /// <summary>
    /// Event notification type.
    /// </summary>
    Event = 1,

    /// <summary>
    /// Acknowledgment notification type.
    /// </summary>
    AckNotification = 2
}
