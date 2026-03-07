// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class LightingCommand
{
    /// <summary>
    /// Represents the BACnet primitive data type ramp-rate with a range restriction from 0.1f to 100f.
    /// </summary>
    public readonly record struct TRampRate : IComparable<TRampRate>, IComparable
    {
        /// <summary>
        /// The minimum allowed value for an instance of <see cref="TRampRate"/>.
        /// </summary>
        public const float MinValue = 0.1f;
    
        /// <summary>
        /// The maximum allowed value for an instance of <see cref="TRampRate"/>.
        /// </summary>
        public const float MaxValue = 100f;
    
        /// <summary>
        /// Gets the instance value.
        /// </summary>
        public float Value { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TRampRate"/> struct.
        /// </summary>
        /// <param name="value">The instance value, must be in the range from 0.1f to 100f.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0.1f) 
        /// or greater than <see cref="MaxValue"/> (100f).
        /// </exception>
        public TRampRate(float value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
            Value = value;
        }
    
        /// <summary>
        /// Compares this instance to another <see cref="TRampRate"/>.
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TRampRate other) => Value.CompareTo(other.Value);
    
        /// <summary>
        /// Compares this instance to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="obj"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="TRampRate"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }
    
            if (obj is TRampRate other)
            {
                return CompareTo(other);
            }
    
            throw new ArgumentException($"Object must be of type {nameof(TRampRate)}.", nameof(obj));
        }
    
        /// <summary>
        /// Implicitly converts a <see cref="TRampRate"/> instance to a <see cref="float"/>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        public static implicit operator float(TRampRate instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="float"/> to a <see cref="TRampRate"/>.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (0.1f) 
        /// or greater than <see cref="MaxValue"/> (100f).
        /// </exception>
        public static explicit operator TRampRate(float value) => new(value);
    
        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();
    }
}
