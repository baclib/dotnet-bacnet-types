// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetHostAddress as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class HostAddress
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No host address specified.
        /// </summary>
        None,

        /// <summary>
        /// An IP address represented as an octet string (IPv4 or IPv6).
        /// </summary>
        IpAddress,

        /// <summary>
        /// A hostname or domain name as a character string.
        /// </summary>
        Name
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private HostAddress(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No host address specified.
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
    /// Tries to get the value when the active choice is <see cref="Option.None"/>.
    /// </summary>
    public bool TryGetNone(out Null value)
    {
        if (Choice == Option.None)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.None"/> option.
    /// </summary>
    public static HostAddress FromNone(Null value)
    {
        return new HostAddress(Option.None, value);
    }

    /// <summary>
    /// An IP address represented as an octet string (IPv4 or IPv6).
    /// </summary>
    public OctetString IpAddress
    {
        get
        {
            if (Choice != Option.IpAddress)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IpAddress)}.");
            }
            return (OctetString)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.IpAddress"/>.
    /// </summary>
    public bool TryGetIpAddress(out OctetString value)
    {
        if (Choice == Option.IpAddress)
        {
            value = (OctetString)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.IpAddress"/> option.
    /// </summary>
    public static HostAddress FromIpAddress(OctetString value)
    {
        return new HostAddress(Option.IpAddress, value);
    }

    /// <summary>
    /// A hostname or domain name as a character string.
    /// </summary>
    public CharacterString Name
    {
        get
        {
            if (Choice != Option.Name)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Name)}.");
            }
            return (CharacterString)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Name"/>.
    /// </summary>
    public bool TryGetName(out CharacterString value)
    {
        if (Choice == Option.Name)
        {
            value = (CharacterString)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Name"/> option.
    /// </summary>
    public static HostAddress FromName(CharacterString value)
    {
        return new HostAddress(Option.Name, value);
    }
}
