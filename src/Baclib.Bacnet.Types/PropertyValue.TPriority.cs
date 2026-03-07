// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class PropertyValue
{
    /// <summary>
    /// Represents the BACnet primitive data type priority with a range restriction from 1 to 16.
    /// </summary>
    public readonly record struct TPriority : IComparable<TPriority>, IComparable
    {
        /// <summary>
        /// The minimum allowed value for an instance of <see cref="TPriority"/>.
        /// </summary>
        public const byte MinValue = 1;
    
        /// <summary>
        /// The maximum allowed value for an instance of <see cref="TPriority"/>.
        /// </summary>
        public const byte MaxValue = 16;
    
        /// <summary>
        /// Gets the instance value.
        /// </summary>
        public byte Value { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TPriority"/> struct.
        /// </summary>
        /// <param name="value">The instance value, must be in the range from 1 to 16.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (1) 
        /// or greater than <see cref="MaxValue"/> (16).
        /// </exception>
        public TPriority(byte value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
            Value = value;
        }
    
        /// <summary>
        /// Compares this instance to another <see cref="TPriority"/>.
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TPriority other) => Value.CompareTo(other.Value);
    
        /// <summary>
        /// Compares this instance to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="obj"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="TPriority"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }
    
            if (obj is TPriority other)
            {
                return CompareTo(other);
            }
    
            throw new ArgumentException($"Object must be of type {nameof(TPriority)}.", nameof(obj));
        }
    
        /// <summary>
        /// Implicitly converts a <see cref="TPriority"/> instance to a <see cref="byte"/>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        public static implicit operator byte(TPriority instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="byte"/> to a <see cref="TPriority"/>.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (1) 
        /// or greater than <see cref="MaxValue"/> (16).
        /// </exception>
        public static explicit operator TPriority(byte value) => new(value);
    
        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();
    }
}
