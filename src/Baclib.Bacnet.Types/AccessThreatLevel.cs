// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetAccessThreatLevel type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// This type represents a threat level assessment for access control, ranging from 0 (no threat)
/// to 100 (maximum threat).
/// </remarks>
public readonly record struct AccessThreatLevel
{
    /// <summary>
    /// The minimum allowed threat level value.
    /// </summary>
    public const byte MinValue = 0;

    /// <summary>
    /// The maximum allowed threat level value.
    /// </summary>
    public const byte MaxValue = 100;

    /// <summary>
    /// Gets the threat level value.
    /// </summary>
    public byte Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccessThreatLevel"/> struct.
    /// </summary>
    /// <param name="value">The threat level value. Must be in the range 0-100.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is greater than 100.
    /// </exception>
    public AccessThreatLevel(byte value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue, nameof(value));
        Value = value;
    }

    /// <summary>
    /// Implicitly converts a <see cref="byte"/> to an <see cref="AccessThreatLevel"/>.
    /// </summary>
    /// <param name="value">The byte value to convert.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is greater than 100.
    /// </exception>
    public static implicit operator AccessThreatLevel(byte value) => new(value);

    /// <summary>
    /// Implicitly converts an <see cref="AccessThreatLevel"/> to a <see cref="byte"/>.
    /// </summary>
    /// <param name="level">The access threat level to convert.</param>
    public static implicit operator byte(AccessThreatLevel level) => level.Value;

    /// <summary>
    /// Returns a string representation of this <see cref="AccessThreatLevel"/>.
    /// </summary>
    /// <returns>A string representing the threat level value.</returns>
    public override string ToString() => Value.ToString();
}
