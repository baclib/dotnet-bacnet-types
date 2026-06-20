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

    private object _choiceValue
    {
        get;
    }

    private Recipient(Option choice, object value)
    {
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
    /// Create function for The recipient is a BACnet device identified by object-identifier.
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
    /// Create function for The recipient is specified by a BACnet address.
    /// </summary>
    public static Recipient FromAddress(Address value)
    {
        return new Recipient(Option.Address, value);
    }
}
