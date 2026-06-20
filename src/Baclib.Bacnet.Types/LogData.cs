// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetLogData as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LogData
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A log status bit string indicating the operational state of the log.
        /// </summary>
        Status,

        /// <summary>
        /// A series of logged data values, which can be of various types.
        /// </summary>
        Series,

        /// <summary>
        /// Indicates a time change event, with the value representing the time adjustment in seconds.
        /// </summary>
        TimeChange
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private LogData(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A log status bit string indicating the operational state of the log.
    /// </summary>
    public LogStatus Status
    {
        get
        {
            if (Choice != Option.Status)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Status)}.");
            }
            return (LogStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A log status bit string indicating the operational state of the log.
    /// </summary>
    public static LogData FromStatus(LogStatus value)
    {
        return new LogData(Option.Status, value);
    }

    /// <summary>
    /// A series of logged data values, which can be of various types.
    /// </summary>
    public TSeries Series
    {
        get
        {
            if (Choice != Option.Series)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Series)}.");
            }
            return (TSeries)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A series of logged data values, which can be of various types.
    /// </summary>
    public static LogData FromSeries(TSeries value)
    {
        return new LogData(Option.Series, value);
    }

    /// <summary>
    /// Indicates a time change event, with the value representing the time adjustment in seconds.
    /// </summary>
    public float TimeChange
    {
        get
        {
            if (Choice != Option.TimeChange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeChange)}.");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates a time change event, with the value representing the time adjustment in seconds.
    /// </summary>
    public static LogData FromTimeChange(float value)
    {
        return new LogData(Option.TimeChange, value);
    }
}
