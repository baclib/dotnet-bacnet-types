// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalDoorValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalDoorValue
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a door value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet door value when present.
        /// </summary>
        DoorValue
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalDoorValue(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a door value.
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
    /// Create function for Indicates the absence of a door value.
    /// </summary>
    public static OptionalDoorValue FromNull(Null value)
    {
        return new OptionalDoorValue(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet door value when present.
    /// </summary>
    public DoorValue DoorValue
    {
        get
        {
            if (Choice != Option.DoorValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoorValue)}.");
            }
            return (DoorValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet door value when present.
    /// </summary>
    public static OptionalDoorValue FromDoorValue(DoorValue value)
    {
        return new OptionalDoorValue(Option.DoorValue, value);
    }
}
