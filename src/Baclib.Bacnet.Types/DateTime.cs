// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnetDateTime composed of a <see cref="Date"/> and a <see cref="Time"/>.
/// </summary>
/// <param name="Date">The BACnet <c>Date</c> component. See Clause 20.2.12 for restrictions.</param>
/// <param name="Time">The BACnet <c>Time</c> component. See Clause 20.2.13 for restrictions.</param>
public readonly record struct DateTime(
    Date Date,
    Time Time)
{
}
