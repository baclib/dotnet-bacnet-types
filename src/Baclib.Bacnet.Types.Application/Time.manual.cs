// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents a BACnet time value consisting of a specific or unspecified time.
/// Defined in ANSI/ASHRAE 135-2024 Clause 21.5.
/// </summary>
public readonly partial record struct Time
{
    private const int MaxTicksPerDay = 8_640_000; // 24 * 60 * 60 * 100

    private readonly int _centiseconds = 0;

    /// <summary>
    /// Gets the total number of centiseconds since midnight (0-8639999) or -1 if unspecified.
    /// </summary>
    public int TotalCentiseconds { get; }

    /// <summary>
    /// Gets the hour field (0-23).
    /// </summary>
    public byte Hour { get; }

    /// <summary>
    /// Gets the minute field (0-59).
    /// </summary>
    public byte Minute { get; }

    /// <summary>
    /// Gets the second field (0-59).
    /// </summary>
    public byte Second { get; }

    /// <summary>
    /// Gets the hundredths of a second field (0-99).
    /// </summary>
    public byte Hundredths { get; }

    /// <summary>
    /// Gets a value indicating whether this time represents a fully specified time.
    /// </summary>
    public bool IsSpecific => _centiseconds >= 0;

    /// <summary>
    /// Gets a value indicating whether this time is completely unspecified.
    /// </summary>
    public bool IsUnspecified => !IsSpecific;

    /// <summary>
    /// Gets a value indicating whether the individual fields are within the valid BACnet ranges.
    /// </summary>
    public bool IsValid => Hour < 24 && Minute < 60 && Second < 60 && Hundredths < 100;

    /// <summary>
    /// Creates a BACnet Time from individual field values.
    /// </summary>
    /// <param name="hour">Hour value (0-23).</param>
    /// <param name="minute">Minute value (0-59).</param>
    /// <param name="second">Second value (0-59).</param>
    /// <param name="hundredths">Hundredths of a second value (0-99).</param>
    public Time(byte hour, byte minute, byte second, byte hundredths)
    {
        int total = (hour * 360000) + (minute * 6000) + (second * 100) + hundredths;
        if (total < 0 || total >= MaxTicksPerDay)
        {
            throw new ArgumentOutOfRangeException();
        }
        _centiseconds = total;
        TotalCentiseconds = total;
        Hour = hour;
        Minute = minute;
        Second = second;
        Hundredths = hundredths;
    }

    /// <summary>
    /// Converts the BACnet Time to a .NET <see cref="TimeSpan"/> if it represents a specific time.
    /// </summary>
    /// <returns>A TimeSpan if the time is specific; otherwise, null.</returns>
    public TimeSpan? ToTimeSpan()
    {
        if (IsSpecific)
        {
            return new TimeSpan(0, Hour, Minute, Second, Hundredths * 10);
        }

        return null;
    }

    /// <summary>
    /// Converts the BACnet Time to a .NET <see cref="TimeOnly"/> if it represents a specific time.
    /// </summary>
    /// <returns>A TimeOnly if the time is specific; otherwise, null.</returns>
    public TimeOnly? ToTimeOnly()
    {
        if (IsSpecific)
        {
            return new TimeOnly(Hour, Minute, Second, Hundredths * 10);
        }

        return null;
    }

    /// <summary>
    /// Returns a string representation of the BACnet Time.
    /// </summary>
    /// <returns>A string in the format "HH:MM:SS.hh" with wildcard indicators.</returns>
    /// <remarks>
    /// Wildcards are shown as "**".
    /// Example outputs: "14:30:15.50", "**:**:**.00", "09:30:**.**".
    /// </remarks>
    public override string ToString()
    {
        return "???";
    }

    /*
    /// <summary>
    /// Implicitly converts a .NET TimeSpan to a BACnet Time.
    /// </summary>
    /// <param name="time">The TimeSpan to convert.</param>
    public static implicit operator Time(TimeSpan time) => new(time);

    /// <summary>
    /// Implicitly converts a .NET TimeOnly to a BACnet Time.
    /// </summary>
    /// <param name="time">The TimeOnly to convert.</param>
    public static implicit operator Time(TimeOnly time) => new(time);
    */
}
