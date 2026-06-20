// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetShedLevel as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ShedLevel
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The percent of load to be shed.
        /// </summary>
        Percent,

        /// <summary>
        /// The discrete level of load to be shed.
        /// </summary>
        Level,

        /// <summary>
        /// The absolute amount of load to be shed.
        /// </summary>
        Amount
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private ShedLevel(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// The percent of load to be shed.
    /// </summary>
    public Unsigned Percent
    {
        get
        {
            if (Choice != Option.Percent)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Percent)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The percent of load to be shed.
    /// </summary>
    public static ShedLevel FromPercent(Unsigned value)
    {
        return new ShedLevel(Option.Percent, value);
    }

    /// <summary>
    /// The discrete level of load to be shed.
    /// </summary>
    public Unsigned Level
    {
        get
        {
            if (Choice != Option.Level)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Level)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The discrete level of load to be shed.
    /// </summary>
    public static ShedLevel FromLevel(Unsigned value)
    {
        return new ShedLevel(Option.Level, value);
    }

    /// <summary>
    /// The absolute amount of load to be shed.
    /// </summary>
    public float Amount
    {
        get
        {
            if (Choice != Option.Amount)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Amount)}.");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The absolute amount of load to be shed.
    /// </summary>
    public static ShedLevel FromAmount(float value)
    {
        return new ShedLevel(Option.Amount, value);
    }
}
