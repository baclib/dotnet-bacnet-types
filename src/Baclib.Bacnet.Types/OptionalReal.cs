// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private OptionalReal(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a real value.
    /// </summary>
    public static OptionalReal NewNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)} hat das Template erstellt");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet real number value when present.
    /// </summary>
    public static OptionalReal NewReal(float value)
    {
        return new OptionalReal(Option.Real, value);
    }
}
