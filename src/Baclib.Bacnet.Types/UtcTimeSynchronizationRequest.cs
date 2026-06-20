// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence UTCTimeSynchronization-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UtcTimeSynchronizationRequest
{
    /// <summary>
    /// The UTC date and time to which the device should be synchronized.
    /// </summary>
    public required DateTime Time { get; init; }
    }
