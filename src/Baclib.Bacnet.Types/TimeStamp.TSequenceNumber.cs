// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class TimeStamp
{
    /// <summary>
    /// Represents the BACnet primitive data type sequence-number with a range restriction from 0 to 65535.
    /// </summary>
    public readonly record struct TSequenceNumber : IComparable<TSequenceNumber>, IComparable
    {
        /// <summary>
        /// The minimum allowed value for an instance of <see cref="TSequenceNumber"/>.
        /// </summary>
        public const ushort MinValue = 0;
    
        /// <summary>
        /// The maximum allowed value for an instance of <see cref="TSequenceNumber"/>.
        /// </summary>
        public const ushort MaxValue = 65535;
    
        /// <summary>
        /// Gets the instance value.
        /// </summary>
        public ushort Value { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TSequenceNumber"/> struct.
        /// </summary>
        /// <param name="value">The instance value, must be in the range from 0 to 65535.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0) 
        /// or greater than <see cref="MaxValue"/> (65535).
        /// </exception>
        public TSequenceNumber(ushort value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
            Value = value;
        }
    
        /// <summary>
        /// Compares this instance to another <see cref="TSequenceNumber"/>.
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TSequenceNumber other) => Value.CompareTo(other.Value);
    
        /// <summary>
        /// Compares this instance to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="obj"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="TSequenceNumber"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }
    
            if (obj is TSequenceNumber other)
            {
                return CompareTo(other);
            }
    
            throw new ArgumentException($"Object must be of type {nameof(TSequenceNumber)}.", nameof(obj));
        }
    
        /// <summary>
        /// Implicitly converts a <see cref="TSequenceNumber"/> instance to a <see cref="ushort"/>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        public static implicit operator ushort(TSequenceNumber instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="ushort"/> to a <see cref="TSequenceNumber"/>.
        /// </summary>
        /// <param name="value">The ushort value to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0) 
        /// or greater than <see cref="MaxValue"/> (65535).
        /// </exception>
        public static explicit operator TSequenceNumber(ushort value) => new(value);
    
        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();
    }
}
