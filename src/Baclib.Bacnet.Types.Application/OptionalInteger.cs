// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalInteger as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalInteger
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of an integer value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet integer value when present.
        /// </summary>
        Integer
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalInteger(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of an integer value.
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
    public static OptionalInteger FromNull(Null value)
    {
        return new OptionalInteger(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet integer value when present.
    /// </summary>
    public int Integer
    {
        get
        {
            if (Choice != Option.Integer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)}.");
            }
            return (int)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Integer"/>.
    /// </summary>
    public bool TryGetInteger(out int value)
    {
        if (Choice == Option.Integer)
        {
            value = (int)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Integer"/> option.
    /// </summary>
    public static OptionalInteger FromInteger(int value)
    {
        return new OptionalInteger(Option.Integer, value);
    }
}
