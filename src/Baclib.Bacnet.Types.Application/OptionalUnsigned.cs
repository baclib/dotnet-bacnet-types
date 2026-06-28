// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalUnsigned as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalUnsigned
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of an unsigned value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the unsigned integer value when present.
        /// </summary>
        Unsigned
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalUnsigned(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of an unsigned value.
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
    public static OptionalUnsigned FromNull(Null value)
    {
        return new OptionalUnsigned(Option.Null, value);
    }

    /// <summary>
    /// Specifies the unsigned integer value when present.
    /// </summary>
    public Unsigned Unsigned
    {
        get
        {
            if (Choice != Option.Unsigned)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Unsigned"/>.
    /// </summary>
    public bool TryGetUnsigned(out Unsigned value)
    {
        if (Choice == Option.Unsigned)
        {
            value = (Unsigned)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Unsigned"/> option.
    /// </summary>
    public static OptionalUnsigned FromUnsigned(Unsigned value)
    {
        return new OptionalUnsigned(Option.Unsigned, value);
    }
}
