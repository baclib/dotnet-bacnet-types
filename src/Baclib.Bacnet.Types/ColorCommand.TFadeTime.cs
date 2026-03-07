// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ColorCommand
{
    /// <summary>
    /// Represents the BACnet primitive data type fade-time with a range restriction from 100 to 86400000.
    /// </summary>
    public readonly record struct TFadeTime : IComparable<TFadeTime>, IComparable
    {
        /// <summary>
        /// The minimum allowed value for an instance of <see cref="TFadeTime"/>.
        /// </summary>
        public const uint MinValue = 100;
    
        /// <summary>
        /// The maximum allowed value for an instance of <see cref="TFadeTime"/>.
        /// </summary>
        public const uint MaxValue = 86400000;
    
        /// <summary>
        /// Gets the instance value.
        /// </summary>
        public uint Value { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TFadeTime"/> struct.
        /// </summary>
        /// <param name="value">The instance value, must be in the range from 100 to 86400000.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (100) 
        /// or greater than <see cref="MaxValue"/> (86400000).
        /// </exception>
        public TFadeTime(uint value)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue, nameof(value));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
            Value = value;
        }
    
        /// <summary>
        /// Compares this instance to another <see cref="TFadeTime"/>.
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(TFadeTime other) => Value.CompareTo(other.Value);
    
        /// <summary>
        /// Compares this instance to another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="obj"/>, 
        /// zero if equal, or a positive value if this instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not a <see cref="TFadeTime"/>.</exception>
        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                return 1;
            }
    
            if (obj is TFadeTime other)
            {
                return CompareTo(other);
            }
    
            throw new ArgumentException($"Object must be of type {nameof(TFadeTime)}.", nameof(obj));
        }
    
        /// <summary>
        /// Implicitly converts a <see cref="TFadeTime"/> instance to a <see cref="uint"/>.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        public static implicit operator uint(TFadeTime instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="uint"/> to a <see cref="TFadeTime"/>.
        /// </summary>
        /// <param name="value">The uint value to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <see cref="MinValue"/> (100) 
        /// or greater than <see cref="MaxValue"/> (86400000).
        /// </exception>
        public static explicit operator TFadeTime(uint value) => new(value);
    
        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();
    }
}
