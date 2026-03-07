// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System;
using System.Net;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetHostAddress CHOICE type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// <para>
/// BACnetHostAddress ::= CHOICE {
///     none        [0] Null,
///     ip-address  [1] OctetString,      -- 4 octets for B/IP or 16 octets for B/IPv6
///     name        [2] CharacterString   -- Internet host name (see RFC 1123)
/// }
/// </para>
/// <para>
/// This type provides a native .NET representation using <see cref="IPAddress"/> for IP addresses
/// and <see cref="string"/> for DNS host names, making it easy to integrate with .NET networking APIs.
/// </para>
/// </remarks>
public readonly record struct HostAddress
{
    /// <summary>
    /// Defines the discriminator values for the BACnetHostAddress choice.
    /// </summary>
    public enum ChoiceType
    {
        /// <summary>
        /// No host address is specified (Null).
        /// </summary>
        None,

        /// <summary>
        /// An IP address (IPv4 or IPv6).
        /// </summary>
        IpAddress,

        /// <summary>
        /// An Internet host name per RFC 1123.
        /// </summary>
        Name
    }

    private readonly object? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="HostAddress"/> struct with an IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address (IPv4 or IPv6).</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="ipAddress"/> is null.</exception>
    public HostAddress(IPAddress ipAddress)
    {
        ArgumentNullException.ThrowIfNull(ipAddress);
        _value = ipAddress;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HostAddress"/> struct with a host name.
    /// </summary>
    /// <param name="hostName">The Internet host name per RFC 1123.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="hostName"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="hostName"/> is empty or whitespace.</exception>
    public HostAddress(string hostName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(hostName);
        _value = hostName;
    }

    /// <summary>
    /// Gets the active choice discriminator indicating which variant is currently set.
    /// </summary>
    public ChoiceType ActiveChoice => _value switch
    {
        IPAddress => ChoiceType.IpAddress,
        string => ChoiceType.Name,
        _ => ChoiceType.None
    };

    /// <summary>
    /// Gets the IP address value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the choice is not <see cref="ChoiceType.IpAddress"/>.
    /// </exception>
    public IPAddress IpAddress => _value as IPAddress
        ?? throw new InvalidOperationException($"Cannot access IpAddress when choice is {ActiveChoice}.");

    /// <summary>
    /// Gets the host name value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the choice is not <see cref="ChoiceType.Name"/>.
    /// </exception>
    public string Name => _value as string
        ?? throw new InvalidOperationException($"Cannot access Name when choice is {ActiveChoice}.");

    /// <summary>
    /// Gets a value indicating whether this host address is empty (None).
    /// </summary>
    public bool IsNone => _value is null;

    /// <summary>
    /// Implicitly converts an <see cref="IPAddress"/> to a <see cref="HostAddress"/>.
    /// </summary>
    /// <param name="ipAddress">The IP address to convert.</param>
    public static implicit operator HostAddress(IPAddress ipAddress) => new(ipAddress);

    /// <summary>
    /// Implicitly converts a <see cref="string"/> to a <see cref="HostAddress"/>.
    /// </summary>
    /// <param name="hostName">The host name to convert.</param>
    public static implicit operator HostAddress(string hostName) => new(hostName);

    /// <summary>
    /// Returns a string representation of this <see cref="HostAddress"/>.
    /// </summary>
    /// <returns>A string indicating the active choice and its value.</returns>
    public override string ToString() => _value switch
    {
        IPAddress ip => $"IpAddress: {ip}",
        string name => $"Name: {name}",
        _ => "None"
    };

    /// <summary>
    /// Tries to parse the host address as an <see cref="IPAddress"/>.
    /// </summary>
    /// <param name="ipAddress">The parsed IP address, or null if parsing failed.</param>
    /// <returns>True if the host address is a valid IP address or can be parsed as one; otherwise, false.</returns>
    public bool TryGetAsIPAddress(out IPAddress? ipAddress)
    {
        if (_value is IPAddress ip)
        {
            ipAddress = ip;
            return true;
        }

        if (_value is string name && IPAddress.TryParse(name, out ip))
        {
            ipAddress = ip;
            return true;
        }

        ipAddress = null;
        return false;
    }
}
