// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet primitive data type Unsigned64 with a range restriction from 0 to 18446744073709551615.
/// </summary>
public readonly record struct Unsigned64 : IComparable<Unsigned64>, IComparable
{
    /// <summary>
    /// The minimum allowed value for an instance of <see cref="Unsigned64"/>.
    /// </summary>
    public const ulong MinValue = 0;

    /// <summary>
    /// The maximum allowed value for an instance of <see cref="Unsigned64"/>.
    /// </summary>
    public const ulong MaxValue = 18446744073709551615;

    /// <summary>
    /// Gets the instance value.
    /// </summary>
    public ulong Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Unsigned64"/> struct.
    /// </summary>
    /// <param name="value">The instance value, must be in the range from 0 to 18446744073709551615.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0) 
    /// or greater than <see cref="MaxValue"/> (18446744073709551615).
    /// </exception>
    public Unsigned64(ulong value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
        Value = value;
    }

    /// <summary>
    /// Compares this instance to another <see cref="Unsigned64"/>.
    /// </summary>
    /// <param name="other">The instance to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="other"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo(Unsigned64 other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Compares this instance to another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="obj"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="Unsigned64"/>.</exception>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is Unsigned64 other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException($"Object must be of type {nameof(Unsigned64)}.", nameof(obj));
    }

    /// <summary>
    /// Implicitly converts a <see cref="Unsigned64"/> instance to a <see cref="ulong"/>.
    /// </summary>
    /// <param name="instance">The instance to convert.</param>
    public static implicit operator ulong(Unsigned64 instance) => instance.Value;

    /// <summary>
    /// Explicitly converts a <see cref="ulong"/> to a <see cref="Unsigned64"/>.
    /// </summary>
    /// <param name="value">The ulong value to convert.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0) 
    /// or greater than <see cref="MaxValue"/> (18446744073709551615).
    /// </exception>
    public static explicit operator Unsigned64(ulong value) => new(value);

    /// <summary>
    /// Returns a string representation of this instance.
    /// </summary>
    /// <returns>A string of <see cref="Value"/>.</returns>
    public override string ToString() => Value.ToString();
}
