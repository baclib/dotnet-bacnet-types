// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalDouble as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDouble
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a double value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet double value when present.
        /// </summary>
        Double
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalDouble(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a double value.
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
    public static OptionalDouble FromNull(Null value)
    {
        return new OptionalDouble(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet double value when present.
    /// </summary>
    public double Double
    {
        get
        {
            if (Choice != Option.Double)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)}.");
            }
            return (double)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Double"/>.
    /// </summary>
    public bool TryGetDouble(out double value)
    {
        if (Choice == Option.Double)
        {
            value = (double)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Double"/> option.
    /// </summary>
    public static OptionalDouble FromDouble(double value)
    {
        return new OptionalDouble(Option.Double, value);
    }
}
