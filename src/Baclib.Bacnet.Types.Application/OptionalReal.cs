// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalReal as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalReal
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a real value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet real number value when present.
        /// </summary>
        Real
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalReal(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a real value.
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
    public static OptionalReal FromNull(Null value)
    {
        return new OptionalReal(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet real number value when present.
    /// </summary>
    public float Real
    {
        get
        {
            if (Choice != Option.Real)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)}.");
            }
            return (float)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Real"/>.
    /// </summary>
    public bool TryGetReal(out float value)
    {
        if (Choice == Option.Real)
        {
            value = (float)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Real"/> option.
    /// </summary>
    public static OptionalReal FromReal(float value)
    {
        return new OptionalReal(Option.Real, value);
    }
}
