// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private HostAddress(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.None)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for No host address specified.
    /// </summary>
    public static HostAddress NewNone(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IpAddress)} hat das Template erstellt");
            }
            return (OctetString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An IP address represented as an octet string (IPv4 or IPv6).
    /// </summary>
    public static HostAddress NewIpAddress(OctetString value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Name)} hat das Template erstellt");
            }
            return (CharacterString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A hostname or domain name as a character string.
    /// </summary>
    public static HostAddress NewName(CharacterString value)
    {
        return new HostAddress(Option.Name, value);
    }
}
