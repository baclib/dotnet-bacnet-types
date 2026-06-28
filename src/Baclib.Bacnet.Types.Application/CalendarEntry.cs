// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetCalendarEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CalendarEntry
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A specific date or date pattern.
        /// </summary>
        Date,

        /// <summary>
        /// A range defined by a start date and an end date.
        /// </summary>
        DateRange,

        /// <summary>
        /// A combination of month, week, and day.
        /// </summary>
        Weeknday
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private CalendarEntry(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A specific date or date pattern.
    /// </summary>
    public DatePattern Date
    {
        get
        {
            if (Choice != Option.Date)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)}.");
            }
            return (DatePattern)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Date"/>.
    /// </summary>
    public bool TryGetDate(out DatePattern value)
    {
        if (Choice == Option.Date)
        {
            value = (DatePattern)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Date"/> option.
    /// </summary>
    public static CalendarEntry FromDate(DatePattern value)
    {
        return new CalendarEntry(Option.Date, value);
    }

    /// <summary>
    /// A range defined by a start date and an end date.
    /// </summary>
    public DateRange DateRange
    {
        get
        {
            if (Choice != Option.DateRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DateRange)}.");
            }
            return (DateRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.DateRange"/>.
    /// </summary>
    public bool TryGetDateRange(out DateRange value)
    {
        if (Choice == Option.DateRange)
        {
            value = (DateRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.DateRange"/> option.
    /// </summary>
    public static CalendarEntry FromDateRange(DateRange value)
    {
        return new CalendarEntry(Option.DateRange, value);
    }

    /// <summary>
    /// A combination of month, week, and day.
    /// </summary>
    public WeekNDay Weeknday
    {
        get
        {
            if (Choice != Option.Weeknday)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Weeknday)}.");
            }
            return (WeekNDay)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Weeknday"/>.
    /// </summary>
    public bool TryGetWeeknday(out WeekNDay value)
    {
        if (Choice == Option.Weeknday)
        {
            value = (WeekNDay)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Weeknday"/> option.
    /// </summary>
    public static CalendarEntry FromWeeknday(WeekNDay value)
    {
        return new CalendarEntry(Option.Weeknday, value);
    }
}
