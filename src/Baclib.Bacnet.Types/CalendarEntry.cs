// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Runtime.InteropServices;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnetCalendarEntry which is a CHOICE of a single <see cref="Date"/>,
/// a <see cref="DateRange"/>, or a <see cref="WeekNDay"/> pattern.
/// </summary>
public readonly record struct CalendarEntry
{
    /// <summary>
    /// Gets the discriminator indicating which variant is present.
    /// </summary>
    public Option Choice { get; }

    private readonly Union _value;

    /// <summary>
    /// Enumerates the possible variants of a <see cref="CalendarEntry"/>.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The entry is a single <see cref="Date"/>.
        /// </summary>
        Date = 0,

        /// <summary>
        /// The entry is a <see cref="DateRange"/>.
        /// </summary>
        DateRange = 1,

        /// <summary>
        /// The entry is a <see cref="WeekNDay"/>.
        /// </summary>
        WeekNDay = 2
    }

    private CalendarEntry(Option choice, Union value)
    {
        _value = value;
        Choice = choice;
    }

    /// <summary>
    /// Creates a <see cref="CalendarEntry"/> carrying a single <see cref="Date"/>.
    /// </summary>
    /// <param name="date">The <see cref="Date"/> value.</param>
    public static CalendarEntry FromDate(Date date) => new(Option.Date, new Union(date));

    /// <summary>
    /// Creates a <see cref="CalendarEntry"/> carrying a <see cref="DateRange"/>.
    /// </summary>
    /// <param name="dateRange">The <see cref="DateRange"/> value.</param>
    public static CalendarEntry FromDateRange(DateRange dateRange) => new(Option.DateRange, new Union(dateRange));

    /// <summary>
    /// Creates a <see cref="CalendarEntry"/> carrying a <see cref="WeekNDay"/>.
    /// </summary>
    /// <param name="weekNDay">The <see cref="WeekNDay"/> value.</param>
    public static CalendarEntry FromWeekNDay(WeekNDay weekNDay) => new(Option.WeekNDay, new Union(weekNDay));

    /// <summary>
    /// Gets the <see cref="Date"/> value if <see cref="Choice"/> is <see cref="Option.Date"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the active choice is not <see cref="Option.Date"/>.</exception>
    public Date Date => Choice == Option.Date ? _value.Date : throw new InvalidOperationException();

    /// <summary>
    /// Gets the <see cref="DateRange"/> value if <see cref="Choice"/> is <see cref="Option.DateRange"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the active choice is not <see cref="Option.DateRange"/>.</exception>
    public DateRange DateRange => Choice == Option.DateRange ? _value.DateRange : throw new InvalidOperationException();

    /// <summary>
    /// Gets the <see cref="WeekNDay"/> value if <see cref="Choice"/> is <see cref="Option.WeekNDay"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the active choice is not <see cref="Option.WeekNDay"/>.</exception>
    public WeekNDay WeekNDay => Choice == Option.WeekNDay ? _value.WeekNDay : throw new InvalidOperationException();

    /// <summary>
    /// Internal union-like storage for the variant payloads.
    /// </summary>
    /// <remarks>
    /// Uses explicit layout to overlay the variant fields, mirroring a native union.
    /// Only the field matching the active <see cref="Option"/> must be read.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    private readonly struct Union
    {
        /// <summary>
        /// Overlaid field for <see cref="Date"/>.
        /// </summary>
        [FieldOffset(0)]
        public readonly Date Date;

        /// <summary>
        /// Overlaid field for <see cref="DateRange"/>.
        /// </summary>
        [FieldOffset(0)]
        public readonly DateRange DateRange;

        /// <summary>
        /// Overlaid field for <see cref="WeekNDay"/>.
        /// </summary>
        [FieldOffset(0)]
        public readonly WeekNDay WeekNDay;

        /// <summary>
        /// Constructs a union containing a <see cref="Date"/>.
        /// </summary>
        /// <param name="date">The <see cref="Date"/> to store.</param>
        public Union(Date date)
        {
            DateRange = default;
            WeekNDay = default;
            Date = date;
        }

        /// <summary>
        /// Constructs a union containing a <see cref="DateRange"/>.
        /// </summary>
        /// <param name="dateRange">The <see cref="DateRange"/> to store.</param>
        public Union(DateRange dateRange)
        {
            Date = default;
            WeekNDay = default;
            DateRange = dateRange;
        }

        /// <summary>
        /// Constructs a union containing a <see cref="WeekNDay"/>.
        /// </summary>
        /// <param name="weekNDay">The <see cref="WeekNDay"/> to store.</param>
        public Union(WeekNDay weekNDay)
        {
            Date = default;
            DateRange = default;
            WeekNDay = weekNDay;
        }
    }

    /// <summary>
    /// Determines whether the specified <see cref="CalendarEntry"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">The <see cref="CalendarEntry"/> to compare with the current instance.</param>
    /// <returns><c>true</c> if the specified instance is equal to the current instance; otherwise, <c>false</c>.</returns>
    public bool Equals(CalendarEntry other)
    {
        if (Choice != other.Choice) return false;
        return Choice switch
        {
            Option.Date => _value.Date.Equals(other._value.Date),
            Option.DateRange => _value.DateRange.Equals(other._value.DateRange),
            Option.WeekNDay => _value.WeekNDay.Equals(other._value.WeekNDay),
            _ => false
        };
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
    {
        return Choice switch
        {
            Option.Date => HashCode.Combine(Choice, _value.Date),
            Option.DateRange => HashCode.Combine(Choice, _value.DateRange),
            Option.WeekNDay => HashCode.Combine(Choice, _value.WeekNDay),
            _ => Choice.GetHashCode()
        };
    }

    /// <summary>
    /// Returns a string that represents the current object, based on the selected option.
    /// </summary>
    /// <returns>A string representation of the current value, corresponding to the selected option. The format depends on
    /// whether the option is a date, date range, or week and day.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the current option is not recognized.</exception>
    public override string ToString()
    {
        return Choice switch
        {
            Option.Date => Date.ToString(),
            Option.DateRange => DateRange.ToString(),
            Option.WeekNDay => WeekNDay.ToString(),
            _ => throw new InvalidOperationException()
        };
    }
}
