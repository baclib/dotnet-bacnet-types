// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetTimeValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class TimeValue
{
    /// <summary>
    /// The time at which the value is to be applied.
    /// </summary>
    public required Time Time { get; init; }
    
    /// <summary>
    /// The value to be applied at the specified time.
    /// </summary>
    public required Any Value { get; init; }
    }
