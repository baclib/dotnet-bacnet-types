// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ComplexAckPdu
{
    /// <summary>
    /// Represents the BACnet primitive data type proposed-window-size with a range restriction from 1 to 127.
    /// </summary>
    public readonly record struct TProposedWindowSize : IComparable<TProposedWindowSize>, IComparable
    {
        /// <summary>
        /// The minimum allowed value for an instance of <see cref="TProposedWindowSize"/>.
        /// </summary>
        public const byte MinValue = 1;
    
        /// <summary>
        /// The maximum allowed value for an instance of <see cref="TProposedWindowSize"/>.
        /// </summary>
        public const byte MaxValue = 127;
    
        /// <summary>
        /// Gets the instance value.
        /// </summary>
        public byte Value { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TProposedWindowSize"/> struct.
        /// </summary>
        /// <param name="value">The instance value, must be in the range from 1 to 127.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (1) 
        /// or greater than <see cref="MaxValue"/> (127).
        /// </exception>
        public TProposedWindowSize(byte value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
            Value = value;
        }
    
        /// <summary>
        /// Compares this instance to another <see cref="TProposedWindowSize"/>.
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TProposedWindowSize other) => Value.CompareTo(other.Value);
    
        /// <summary>
        /// Compares this instance to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="obj"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="TProposedWindowSize"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }
    
            if (obj is TProposedWindowSize other)
            {
                return CompareTo(other);
            }
    
            throw new ArgumentException($"Object must be of type {nameof(TProposedWindowSize)}.", nameof(obj));
        }
    
        /// <summary>
        /// Implicitly converts a <see cref="TProposedWindowSize"/> instance to a <see cref="byte"/>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        public static implicit operator byte(TProposedWindowSize instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="byte"/> to a <see cref="TProposedWindowSize"/>.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (1) 
        /// or greater than <see cref="MaxValue"/> (127).
        /// </exception>
        public static explicit operator TProposedWindowSize(byte value) => new(value);
    
        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();
    }
}
