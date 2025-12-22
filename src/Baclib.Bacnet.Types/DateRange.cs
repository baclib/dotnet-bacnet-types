// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnetDateRange composed of a start <see cref="Date"/> and an end <see cref="Date"/>.
/// The range denotes the inclusive interval from <paramref name="StartDate"/> to <paramref name="EndDate"/>.
/// </summary>
/// <param name="StartDate">The BACnet <c>Date</c> representing the start of the range. See Clause 20.2.12 for restrictions.</param>
/// <param name="EndDate">The BACnet <c>Date</c> representing the end of the range. See Clause 20.2.12 for restrictions.</param>
public readonly record struct DateRange(
    Date StartDate,
    Date EndDate)
{
}
