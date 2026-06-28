// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private OptionalDatePattern(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
    public static OptionalDatePattern FromNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datepattern)}.");
            }
            return (DatePattern)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Datepattern"/>.
    /// </summary>
    public bool TryGetDatepattern(out DatePattern value)
    {
        if (Choice == Option.Datepattern)
        {
            value = (DatePattern)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Datepattern"/> option.
    /// </summary>
    public static OptionalDatePattern FromDatepattern(DatePattern value)
    {
        return new OptionalDatePattern(Option.Datepattern, value);
    }
}
