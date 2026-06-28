// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAccessRule as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AccessRule
{
    /// <summary>
    /// Specifies how the time range is determined.
    /// </summary>
    public required TTimeRangeSpecifier TimeRangeSpecifier { get; init; }

    /// <summary>
    /// Reference to the time range object/property when specified.
    /// </summary>
    public Optional<DeviceObjectPropertyReference> TimeRange { get; init; }

    /// <summary>
    /// Specifies how the location is determined.
    /// </summary>
    public required TLocationSpecifier LocationSpecifier { get; init; }

    /// <summary>
    /// Reference to the location object when specified.
    /// </summary>
    public Optional<DeviceObjectReference> Location { get; init; }

    /// <summary>
    /// Indicates whether this access rule is enabled.
    /// </summary>
    public required Boolean Enable { get; init; }
}
