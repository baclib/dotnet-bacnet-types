// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetRecipient as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Recipient
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The recipient is a BACnet device identified by object-identifier.
        /// </summary>
        Device,

        /// <summary>
        /// The recipient is specified by a BACnet address.
        /// </summary>
        Address
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private Recipient(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// The recipient is a BACnet device identified by object-identifier.
    /// </summary>
    public ObjectIdentifier Device
    {
        get
        {
            if (Choice != Option.Device)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Device)}.");
            }
            return (ObjectIdentifier)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Device"/>.
    /// </summary>
    public bool TryGetDevice(out ObjectIdentifier value)
    {
        if (Choice == Option.Device)
        {
            value = (ObjectIdentifier)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Device"/> option.
    /// </summary>
    public static Recipient FromDevice(ObjectIdentifier value)
    {
        return new Recipient(Option.Device, value);
    }

    /// <summary>
    /// The recipient is specified by a BACnet address.
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
    /// Tries to get the value when the active choice is <see cref="Option.Address"/>.
    /// </summary>
    public bool TryGetAddress(out Address value)
    {
        if (Choice == Option.Address)
        {
            value = (Address)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Address"/> option.
    /// </summary>
    public static Recipient FromAddress(Address value)
    {
        return new Recipient(Option.Address, value);
    }
}
