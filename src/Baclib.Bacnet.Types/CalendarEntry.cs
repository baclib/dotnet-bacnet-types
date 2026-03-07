// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private CalendarEntry(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)} hat das Template erstellt");
            }
            return (DatePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A specific date or date pattern.
    /// </summary>
    public static CalendarEntry NewDate(DatePattern value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DateRange)} hat das Template erstellt");
            }
            return (DateRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A range defined by a start date and an end date.
    /// </summary>
    public static CalendarEntry NewDateRange(DateRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Weeknday)} hat das Template erstellt");
            }
            return (WeekNDay)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A combination of month, week, and day.
    /// </summary>
    public static CalendarEntry NewWeeknday(WeekNDay value)
    {
        return new CalendarEntry(Option.Weeknday, value);
    }
}
