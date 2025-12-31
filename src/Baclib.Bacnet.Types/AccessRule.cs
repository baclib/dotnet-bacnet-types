// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetAccessRule type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// This type defines an access control rule that specifies when and where access is granted,
/// along with whether the rule is enabled. The rule can apply to specific time ranges and locations,
/// or apply always/everywhere based on the specifier values.
/// </remarks>
public readonly record struct AccessRule
{
    /// <summary>
    /// Specifies whether a specific time range is used or the rule applies always.
    /// </summary>
    public enum TimeRangeSpecifier : byte
    {
        /// <summary>
        /// A specific time range is specified via the <see cref="AccessRule.TimeRange"/> property.
        /// </summary>
        Specified = 0,

        /// <summary>
        /// The rule applies at all times (no time restriction).
        /// </summary>
        Always = 1
    }

    /// <summary>
    /// Specifies whether a specific location is used or the rule applies to all locations.
    /// </summary>
    public enum LocationSpecifier : byte
    {
        /// <summary>
        /// A specific location is specified via the <see cref="AccessRule.Location"/> property.
        /// </summary>
        Specified = 0,

        /// <summary>
        /// The rule applies to all locations.
        /// </summary>
        All = 1
    }

    /// <summary>
    /// Gets the time range specifier indicating whether a specific time range is used.
    /// </summary>
    public TimeRangeSpecifier TimeRangeSpec { get; }

    /// <summary>
    /// Gets the time range reference. Must be present when <see cref="TimeRangeSpec"/> is <see cref="TimeRangeSpecifier.Specified"/>.
    /// </summary>
    public DeviceObjectPropertyReference? TimeRange { get; }

    /// <summary>
    /// Gets the location specifier indicating whether a specific location is used.
    /// </summary>
    public LocationSpecifier LocationSpec { get; }

    /// <summary>
    /// Gets the location reference. Must be present when <see cref="LocationSpec"/> is <see cref="LocationSpecifier.Specified"/>.
    /// </summary>
    public DeviceObjectReference? Location { get; }

    /// <summary>
    /// Gets a value indicating whether this access rule is enabled.
    /// </summary>
    public bool Enable { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccessRule"/> struct.
    /// </summary>
    /// <param name="timeRangeSpec">The time range specifier.</param>
    /// <param name="timeRange">
    /// The time range reference. Must be provided when <paramref name="timeRangeSpec"/> is <see cref="TimeRangeSpecifier.Specified"/>.
    /// </param>
    /// <param name="locationSpec">The location specifier.</param>
    /// <param name="location">
    /// The location reference. Must be provided when <paramref name="locationSpec"/> is <see cref="LocationSpecifier.Specified"/>.
    /// </param>
    /// <param name="enable">Whether the access rule is enabled.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="timeRangeSpec"/> is <see cref="TimeRangeSpecifier.Specified"/> but <paramref name="timeRange"/> is null,
    /// or when <paramref name="locationSpec"/> is <see cref="LocationSpecifier.Specified"/> but <paramref name="location"/> is null.
    /// </exception>
    public AccessRule(
        TimeRangeSpecifier timeRangeSpec,
        DeviceObjectPropertyReference? timeRange,
        LocationSpecifier locationSpec,
        DeviceObjectReference? location,
        bool enable)
    {
        if (timeRangeSpec == TimeRangeSpecifier.Specified && timeRange == null)
        {
            throw new ArgumentException(
                "TimeRange must be provided when TimeRangeSpec is Specified.",
                nameof(timeRange));
        }

        if (locationSpec == LocationSpecifier.Specified && location == null)
        {
            throw new ArgumentException(
                "Location must be provided when LocationSpec is Specified.",
                nameof(location));
        }

        TimeRangeSpec = timeRangeSpec;
        TimeRange = timeRange;
        LocationSpec = locationSpec;
        Location = location;
        Enable = enable;
    }

    /// <summary>
    /// Returns a string representation of this <see cref="AccessRule"/>.
    /// </summary>
    /// <returns>A string describing the access rule configuration.</returns>
    public override string ToString()
    {
        var timeInfo = TimeRangeSpec == TimeRangeSpecifier.Always
            ? "Always"
            : $"Specified: {TimeRange}";

        var locationInfo = LocationSpec == LocationSpecifier.All
            ? "All"
            : $"Specified: {Location}";

        return $"AccessRule [Time: {timeInfo}, Location: {locationInfo}, Enabled: {Enable}]";
    }
}