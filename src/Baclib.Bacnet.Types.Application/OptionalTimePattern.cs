// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalTimePattern as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalTimePattern
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a time pattern value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet time pattern value when present.
        /// </summary>
        Timeepattern
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalTimePattern(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a time pattern value.
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
    public static OptionalTimePattern FromNull(Null value)
    {
        return new OptionalTimePattern(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet time pattern value when present.
    /// </summary>
    public TimePattern Timeepattern
    {
        get
        {
            if (Choice != Option.Timeepattern)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Timeepattern)}.");
            }
            return (TimePattern)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Timeepattern"/>.
    /// </summary>
    public bool TryGetTimeepattern(out TimePattern value)
    {
        if (Choice == Option.Timeepattern)
        {
            value = (TimePattern)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Timeepattern"/> option.
    /// </summary>
    public static OptionalTimePattern FromTimeepattern(TimePattern value)
    {
        return new OptionalTimePattern(Option.Timeepattern, value);
    }
}
