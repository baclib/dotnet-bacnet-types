// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private OptionalDate(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
    public static OptionalDate FromNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)}.");
            }
            return (Date)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Date"/>.
    /// </summary>
    public bool TryGetDate(out Date value)
    {
        if (Choice == Option.Date)
        {
            value = (Date)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Date"/> option.
    /// </summary>
    public static OptionalDate FromDate(Date value)
    {
        return new OptionalDate(Option.Date, value);
    }
}
