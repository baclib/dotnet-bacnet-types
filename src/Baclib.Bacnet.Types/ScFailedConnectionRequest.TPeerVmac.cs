// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ScFailedConnectionRequest
{
    /// <summary>
    /// Represents the length constrained OctetString peer-vmac as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public readonly record struct TPeerVmac
    {
        /// <summary>
        /// The minimum allowed length for an instance of <see cref="TPeerVmac"/>.
        /// </summary>
        public const int MinValue = 0;
    
        /// <summary>
        /// The maximum allowed length for an instance of <see cref="TPeerVmac"/>.
        /// </summary>
        public const int MaxValue = 6;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TPeerVmac"/> struct with the specified length constrained value.
        /// </summary>
        ///<param name="value">The length constrained value to be assigned to this instance.</param>
        public TPeerVmac(OctetString value)
        {
            if (value.Length < MinValue || value.Length > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The length of the value must be between {MinValue} and {MaxValue} bytes.");
            }
    
            Value = value;
        }
    
        /// <summary>
        /// The length constrained value of this <see cref="TPeerVmac"/> instance.
        /// </summary>
        public OctetString Value { get; }
    
        /// <summary>
        /// Implicitly converts an instance of <see cref="TPeerVmac"/> to a <see cref="OctetString"/> by returning the underlying value.
        /// </summary>
        /// <param name="instance">The instance of <see cref="TPeerVmac"/> to be converted.</param>
        public static implicit operator OctetString(TPeerVmac instance) => instance.Value;
    
        /// <summary>
        /// Explicitly converts a <see cref="OctetString"/> to an instance of <see cref="TPeerVmac"/> by invoking the constructor to enforce length constraints.
        /// </summary>
        /// <param name="value">The length constrained value to be assigned to the new instance.</param>
        public static explicit operator TPeerVmac(OctetString value) => new(value);
    }
}
