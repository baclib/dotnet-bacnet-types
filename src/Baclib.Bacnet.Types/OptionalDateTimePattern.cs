// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalDateTimePattern as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDateTimePattern
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a date-time pattern value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet date-time pattern value when present.
        /// </summary>
        Datetimepattern
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalDateTimePattern(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a date-time pattern value.
    /// </summary>
    public Null Null
    {
        get
        {
            if (Choice != Option.Null)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a date-time pattern value.
    /// </summary>
    public static OptionalDateTimePattern NewNull(Null value)
    {
        return new OptionalDateTimePattern(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet date-time pattern value when present.
    /// </summary>
    public DateTimePattern Datetimepattern
    {
        get
        {
            if (Choice != Option.Datetimepattern)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datetimepattern)} hat das Template erstellt");
            }
            return (DateTimePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet date-time pattern value when present.
    /// </summary>
    public static OptionalDateTimePattern NewDatetimepattern(DateTimePattern value)
    {
        return new OptionalDateTimePattern(Option.Datetimepattern, value);
    }
}
