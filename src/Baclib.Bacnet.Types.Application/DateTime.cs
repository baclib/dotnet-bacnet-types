// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetDateTime as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DateTime
{
    /// <summary>
    /// The date component.
    /// </summary>
    public required Date Date { get; init; }

    /// <summary>
    /// The time component.
    /// </summary>
    public required Time Time { get; init; }
}
