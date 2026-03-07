// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private OptionalInteger(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of an integer value.
    /// </summary>
    public static OptionalInteger NewNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)} hat das Template erstellt");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet integer value when present.
    /// </summary>
    public static OptionalInteger NewInteger(int value)
    {
        return new OptionalInteger(Option.Integer, value);
    }
}
