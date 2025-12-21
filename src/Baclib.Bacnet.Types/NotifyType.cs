// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetNotifyType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
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
