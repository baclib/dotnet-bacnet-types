// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetTimeStamp as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class TimeStamp
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A time value as the timestamp.
        /// </summary>
        Time,

        /// <summary>
        /// A sequence number as the timestamp.
        /// </summary>
        SequenceNumber,

        /// <summary>
        /// A date and time value as the timestamp.
        /// </summary>
        Datetime
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private TimeStamp(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A time value as the timestamp.
    /// </summary>
    public Time Time
    {
        get
        {
            if (Choice != Option.Time)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Time)}.");
            }
            return (Time)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A time value as the timestamp.
    /// </summary>
    public static TimeStamp FromTime(Time value)
    {
        return new TimeStamp(Option.Time, value);
    }

    /// <summary>
    /// A sequence number as the timestamp.
    /// </summary>
    public TSequenceNumber SequenceNumber
    {
        get
        {
            if (Choice != Option.SequenceNumber)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SequenceNumber)}.");
            }
            return (TSequenceNumber)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A sequence number as the timestamp.
    /// </summary>
    public static TimeStamp FromSequenceNumber(TSequenceNumber value)
    {
        return new TimeStamp(Option.SequenceNumber, value);
    }

    /// <summary>
    /// A date and time value as the timestamp.
    /// </summary>
    public DateTime Datetime
    {
        get
        {
            if (Choice != Option.Datetime)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datetime)}.");
            }
            return (DateTime)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date and time value as the timestamp.
    /// </summary>
    public static TimeStamp FromDatetime(DateTime value)
    {
        return new TimeStamp(Option.Datetime, value);
    }
}
