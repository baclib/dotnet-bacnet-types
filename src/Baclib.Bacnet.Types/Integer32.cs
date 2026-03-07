// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet primitive data type Integer32 with a range restriction from -2147483648 to 2147483647.
/// </summary>
public readonly record struct Integer32 : IComparable<Integer32>, IComparable
{
    /// <summary>
    /// The minimum allowed value for an instance of <see cref="Integer32"/>.
    /// </summary>
    public const int MinValue = -2147483648;

    /// <summary>
    /// The maximum allowed value for an instance of <see cref="Integer32"/>.
    /// </summary>
    public const int MaxValue = 2147483647;

    /// <summary>
    /// Gets the instance value.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Integer32"/> struct.
    /// </summary>
    /// <param name="value">The instance value, must be in the range from -2147483648 to 2147483647.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (-2147483648) 
    /// or greater than <see cref="MaxValue"/> (2147483647).
    /// </exception>
    public Integer32(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
        Value = value;
    }

    /// <summary>
    /// Compares this instance to another <see cref="Integer32"/>.
    /// </summary>
    /// <param name="other">The instance to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="other"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo(Integer32 other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Compares this instance to another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>
    /// A negative value if this instance is less than <paramref name="obj"/>, 
    /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="Integer32"/>.</exception>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is Integer32 other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException($"Object must be of type {nameof(Integer32)}.", nameof(obj));
    }

    /// <summary>
    /// Implicitly converts a <see cref="Integer32"/> instance to a <see cref="int"/>.
    /// </summary>
    /// <param name="instance">The instance to convert.</param>
    public static implicit operator int(Integer32 instance) => instance.Value;

    /// <summary>
    /// Explicitly converts a <see cref="int"/> to a <see cref="Integer32"/>.
    /// </summary>
    /// <param name="value">The int value to convert.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (-2147483648) 
    /// or greater than <see cref="MaxValue"/> (2147483647).
    /// </exception>
    public static explicit operator Integer32(int value) => new(value);

    /// <summary>
    /// Returns a string representation of this instance.
    /// </summary>
    /// <returns>A string of <see cref="Value"/>.</returns>
    public override string ToString() => Value.ToString();
}
