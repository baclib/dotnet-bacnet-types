// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetDaysOfWeek as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public readonly record struct DaysOfWeek
{
    /// <summary>
    /// Gets the underlying -bit unsigned integer containing the bits in system-native format.
    /// </summary>
    public long Flags { get; }

    /// <summary>
    /// Fixed number of bits for this type
    /// </summary>
    public const int FixCount = 7;

/*
    /// <summary>
    /// Initializes a new instance of <see cref=""/>.
    /// </summary>
    /// <param name="flags">
    /// The underlying -bit unsigned integer containing the bits in system-native format.
    /// Only the lower bits up to <see cref="FixCount"/> are used. The remaining bits are always set to zero.
    /// </param>
    public (long flags)
    {
        Flags = (long)(flags & );
    }

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The zero-based bit index.</param>
    /// <returns><see langword="true"/> if the bit is set; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than <see cref="FixCount"/>.</exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, FixCount);

            return Flags.GetBit(index);
        }
    }

    /// <summary>
    /// Gets the number of bits used by this instance, which is always equal to <see cref="FixCount"/>.
    /// </summary>
    public int Count => FixCount;
    */
}
