// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetValueSource as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ValueSource
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No value source specified.
        /// </summary>
        None,

        /// <summary>
        /// The value source is a device object reference.
        /// </summary>
        Object,

        /// <summary>
        /// The value source is a network address.
        /// </summary>
        Address
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private ValueSource(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No value source specified.
    /// </summary>
    public Null None
    {
        get
        {
            if (Choice != Option.None)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.None)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for No value source specified.
    /// </summary>
    public static ValueSource FromNone(Null value)
    {
        return new ValueSource(Option.None, value);
    }

    /// <summary>
    /// The value source is a device object reference.
    /// </summary>
    public DeviceObjectReference Object
    {
        get
        {
            if (Choice != Option.Object)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Object)}.");
            }
            return (DeviceObjectReference)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The value source is a device object reference.
    /// </summary>
    public static ValueSource FromObject(DeviceObjectReference value)
    {
        return new ValueSource(Option.Object, value);
    }

    /// <summary>
    /// The value source is a network address.
    /// </summary>
    public Address Address
    {
        get
        {
            if (Choice != Option.Address)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Address)}.");
            }
            return (Address)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The value source is a network address.
    /// </summary>
    public static ValueSource FromAddress(Address value)
    {
        return new ValueSource(Option.Address, value);
    }
}
