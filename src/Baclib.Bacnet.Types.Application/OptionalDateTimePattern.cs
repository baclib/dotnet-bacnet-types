// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private OptionalDateTimePattern(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
            }
            return (Null)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Null"/>.
    /// </summary>
    public bool TryGetNull(out Null value)
    {
        if (Choice == Option.Null)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Null"/> option.
    /// </summary>
    public static OptionalDateTimePattern FromNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datetimepattern)}.");
            }
            return (DateTimePattern)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Datetimepattern"/>.
    /// </summary>
    public bool TryGetDatetimepattern(out DateTimePattern value)
    {
        if (Choice == Option.Datetimepattern)
        {
            value = (DateTimePattern)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Datetimepattern"/> option.
    /// </summary>
    public static OptionalDateTimePattern FromDatetimepattern(DateTimePattern value)
    {
        return new OptionalDateTimePattern(Option.Datetimepattern, value);
    }
}
