// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalDateTime as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDateTime
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a date-time value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet date-time value when present.
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

    private OptionalDateTime(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a date-time value.
    /// </summary>
    public Null Null
    {
        get
        {
            if (Choice != Option.Null)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a date-time value.
    /// </summary>
    public static OptionalDateTime FromNull(Null value)
    {
        return new OptionalDateTime(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet date-time value when present.
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
    /// Create function for Specifies the BACnet date-time value when present.
    /// </summary>
    public static OptionalDateTime FromDatetime(DateTime value)
    {
        return new OptionalDateTime(Option.Datetime, value);
    }
}
