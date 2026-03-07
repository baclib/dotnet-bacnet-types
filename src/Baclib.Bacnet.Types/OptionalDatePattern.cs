// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalDatePattern as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDatePattern
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a date pattern value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet date pattern value when present.
        /// </summary>
        Datepattern
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalDatePattern(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a date pattern value.
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
    /// Create function for Indicates the absence of a date pattern value.
    /// </summary>
    public static OptionalDatePattern NewNull(Null value)
    {
        return new OptionalDatePattern(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet date pattern value when present.
    /// </summary>
    public DatePattern Datepattern
    {
        get
        {
            if (Choice != Option.Datepattern)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datepattern)} hat das Template erstellt");
            }
            return (DatePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet date pattern value when present.
    /// </summary>
    public static OptionalDatePattern NewDatepattern(DatePattern value)
    {
        return new OptionalDatePattern(Option.Datepattern, value);
    }
}
