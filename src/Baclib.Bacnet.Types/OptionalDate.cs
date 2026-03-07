// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalDate as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDate
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a date value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet date value when present.
        /// </summary>
        Date
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalDate(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a date value.
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
    /// Create function for Indicates the absence of a date value.
    /// </summary>
    public static OptionalDate NewNull(Null value)
    {
        return new OptionalDate(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet date value when present.
    /// </summary>
    public Date Date
    {
        get
        {
            if (Choice != Option.Date)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)} hat das Template erstellt");
            }
            return (Date)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet date value when present.
    /// </summary>
    public static OptionalDate NewDate(Date value)
    {
        return new OptionalDate(Option.Date, value);
    }
}
