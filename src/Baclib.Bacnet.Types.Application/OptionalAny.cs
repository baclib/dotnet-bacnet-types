// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalAny as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalAny
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies a BACnet value of any type when present.
        /// </summary>
        Any
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalAny(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a value.
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
    public static OptionalAny FromNull(Null value)
    {
        return new OptionalAny(Option.Null, value);
    }

    /// <summary>
    /// Specifies a BACnet value of any type when present.
    /// </summary>
    public Any Any
    {
        get
        {
            if (Choice != Option.Any)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Any)}.");
            }
            return (Any)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Any"/>.
    /// </summary>
    public bool TryGetAny(out Any value)
    {
        if (Choice == Option.Any)
        {
            value = (Any)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Any"/> option.
    /// </summary>
    public static OptionalAny FromAny(Any value)
    {
        return new OptionalAny(Option.Any, value);
    }
}
