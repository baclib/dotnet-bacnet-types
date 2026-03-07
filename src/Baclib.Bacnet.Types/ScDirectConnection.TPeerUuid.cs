// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ScDirectConnection
{
    /// <summary>
    /// Represents the length constrained OctetString peer-uuid as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public readonly record struct TPeerUuid
    {
        /// <summary>
        /// The minimum allowed length for an instance of <see cref="TPeerUuid"/>.
        /// </summary>
        public const int MinValue = 0;
    
        /// <summary>
        /// The maximum allowed length for an instance of <see cref="TPeerUuid"/>.
        /// </summary>
        public const int MaxValue = 16;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TPeerUuid"/> struct with the specified length constrained value.
        /// </summary>
        ///<param name="value">The length constrained value to be assigned to this instance.</param>
        public TPeerUuid(OctetString value)
        {
            if (value.Length < MinValue || value.Length > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The length of the value must be between {MinValue} and {MaxValue} bytes.");
            }
    
            Value = value;
        }
    
        /// <summary>
        /// The length constrained value of this <see cref="TPeerUuid"/> instance.
        /// </summary>
        public OctetString Value { get; }
    
        /// <summary>
        /// Implicitly converts an instance of <see cref="TPeerUuid"/> to a <see cref="OctetString"/> by returning the underlying value.
        /// </summary>
        /// <param name="instance">The instance of <see cref="TPeerUuid"/> to be converted.</param>
        public static implicit operator OctetString(TPeerUuid instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="OctetString"/> to an instance of <see cref="TPeerUuid"/> by invoking the constructor to enforce length constraints.
        /// </summary>
        /// <param name="value">The length constrained value to be assigned to the new instance.</param>
        public static explicit operator TPeerUuid(OctetString value) => new(value);
    }
}
