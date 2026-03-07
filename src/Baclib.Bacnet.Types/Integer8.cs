// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet primitive data type Integer8 with a range restriction from -128 to 127.
/// </summary>
public readonly record struct Integer8 : IComparable<Integer8>, IComparable
{
    /// <summary>
    /// The minimum allowed value for an instance of <see cref="Integer8"/>.
    /// </summary>
    public const sbyte MinValue = -128;

    /// <summary>
    /// The maximum allowed value for an instance of <see cref="Integer8"/>.
    /// </summary>
    public const sbyte MaxValue = 127;

    /// <summary>
    /// Gets the instance value.
    /// </summary>
    public sbyte Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Integer8"/> struct.
    /// </summary>
    /// <param name="value">The instance value, must be in the range from -128 to 127.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (-128) 
    /// or greater than <see cref="MaxValue"/> (127).
    /// </exception>
    public Integer8(sbyte value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
        Value = value;
    }

    /// <summary>
    /// Compares this instance to another <see cref="Integer8"/>.
    /// </summary>
    /// <param name="other">The instance to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="other"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo(Integer8 other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Compares this instance to another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="obj"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="Integer8"/>.</exception>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is Integer8 other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException($"Object must be of type {nameof(Integer8)}.", nameof(obj));
    }

    /// <summary>
    /// Implicitly converts a <see cref="Integer8"/> instance to a <see cref="sbyte"/>.
    /// </summary>
    /// <param name="instance">The instance to convert.</param>
    public static implicit operator sbyte(Integer8 instance) => instance.Value;

    /// <summary>
    /// Explicitly converts a <see cref="sbyte"/> to a <see cref="Integer8"/>.
    /// </summary>
    /// <param name="value">The sbyte value to convert.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (-128) 
    /// or greater than <see cref="MaxValue"/> (127).
    /// </exception>
    public static explicit operator Integer8(sbyte value) => new(value);

    /// <summary>
    /// Returns a string representation of this instance.
    /// </summary>
    /// <returns>A string of <see cref="Value"/>.</returns>
    public override string ToString() => Value.ToString();
}
