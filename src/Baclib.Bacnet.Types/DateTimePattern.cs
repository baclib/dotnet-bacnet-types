// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetDateTimePattern as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DateTimePattern
{
    /// <summary>
    /// The date pattern component, which may include wildcards.
    /// </summary>
    public required DatePattern Date { get; init; }
    
    /// <summary>
    /// The time pattern component, which may include wildcards.
    /// </summary>
    public required TimePattern Time { get; init; }
    }
