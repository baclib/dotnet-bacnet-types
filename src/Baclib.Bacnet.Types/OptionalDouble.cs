// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private OptionalDouble(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a double value.
    /// </summary>
    public static OptionalDouble NewNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)} hat das Template erstellt");
            }
            return (double)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet double value when present.
    /// </summary>
    public static OptionalDouble NewDouble(double value)
    {
        return new OptionalDouble(Option.Double, value);
    }
}
