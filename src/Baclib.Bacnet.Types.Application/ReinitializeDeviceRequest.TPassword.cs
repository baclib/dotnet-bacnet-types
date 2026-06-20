// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class ReinitializeDeviceRequest
{
    /// <summary>
    /// Represents the length constrained CharacterString password as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public readonly record struct TPassword
    {
        /// <summary>
        /// The minimum allowed length for an instance of <see cref="TPassword"/>.
        /// </summary>
        public const int MinValue = 1;
    
        /// <summary>
        /// The maximum allowed length for an instance of <see cref="TPassword"/>.
        /// </summary>
        public const int MaxValue = 20;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TPassword"/> struct with the specified length constrained value.
        /// </summary>
        ///<param name="value">The length constrained value to be assigned to this instance.</param>
        public TPassword(CharacterString value)
        {
            if (value.Length < MinValue || value.Length > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The length of the value must be between {MinValue} and {MaxValue} characters.");
            }
    
            Value = value;
        }
    
        /// <summary>
        /// The length constrained value of this <see cref="TPassword"/> instance.
        /// </summary>
        public CharacterString Value { get; }
    
        /// <summary>
        /// Implicitly converts an instance of <see cref="TPassword"/> to a <see cref="CharacterString"/> by returning the underlying value.
        /// </summary>
        /// <param name="instance">The instance of <see cref="TPassword"/> to be converted.</param>
        public static implicit operator CharacterString(TPassword instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="CharacterString"/> to an instance of <see cref="TPassword"/> by invoking the constructor to enforce length constraints.
        /// </summary>
        /// <param name="value">The length constrained value to be assigned to the new instance.</param>
        public static explicit operator TPassword(CharacterString value) => new(value);
    }
}
