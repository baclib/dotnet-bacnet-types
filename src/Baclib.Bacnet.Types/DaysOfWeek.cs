// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetDaysOfWeek as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct DaysOfWeek : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Gets the underlying 8-bit unsigned integer containing the bits in system-native format.
    /// </summary>
    public byte Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DaysOfWeek"/>.
    /// </summary>
    /// <param name="flags">
    /// The underlying 8-bit unsigned integer containing the bits in system-native format.
    /// Only the lower bits up to <see cref="Count"/> (always 7) are used. The remaining bits are always set to zero.
    /// </param>
    public DaysOfWeek(byte flags)
    {
        Flags = (byte)(flags & 0x7F);
    }

    /// <summary>
    /// Monday.
    /// </summary>
    public bool Monday => Flags.GetBit(0);

    /// <summary>
    /// Tuesday.
    /// </summary>
    public bool Tuesday => Flags.GetBit(1);

    /// <summary>
    /// Wednesday.
    /// </summary>
    public bool Wednesday => Flags.GetBit(2);

    /// <summary>
    /// Thursday.
    /// </summary>
    public bool Thursday => Flags.GetBit(3);

    /// <summary>
    /// Friday.
    /// </summary>
    public bool Friday => Flags.GetBit(4);

    /// <summary>
    /// Saturday.
    /// </summary>
    public bool Saturday => Flags.GetBit(5);

    /// <summary>
    /// Sunday.
    /// </summary>
    public bool Sunday => Flags.GetBit(6);

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The zero-based bit index.</param>
    /// <returns><see langword="true"/> if the bit is set; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than <see cref="Count"/>.</exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _count);

            return Flags.GetBit(index);
        }
    }

    /// <summary>
    /// The number of bits used by this bit string.
    /// </summary>
    private const int _count = 7;

    /// <summary>
    /// Gets the number of bits used by this bit string (always 7).
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Returns a value-type enumerator suitable for pattern-based foreach iteration.
    /// Use this when iterating the struct directly to avoid allocations/boxing.
    /// </summary>
    public Enumerator GetEnumerator() => new(this);

    /// <summary>
    /// Value-type enumerator used by the public pattern-based <see cref="GetEnumerator"/> method.
    /// </summary>
    /// <remarks>
    /// The enumerator is a struct so direct iteration over a <see cref="DaysOfWeek"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly DaysOfWeek _bits;
        private int _index;

        internal Enumerator(DaysOfWeek flags)
        {
            _bits = flags;
            _index = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next bit.
        /// </summary>
        /// <returns><see langword="true"/> if the enumerator advanced to a valid bit; otherwise <see langword="false"/>.</returns>
        public bool MoveNext()
        {
            _index++;
            return _index < _bits.Count;
        }

        /// <summary>
        /// Gets the current bit value.
        /// </summary>
        public readonly bool Current => _bits.Flags.GetBit(_index);
    }

    /// <summary>
    /// Interface implementation for <see cref="IEnumerable{Boolean}"/>.
    /// Enumerating via the interface will allocate (iterator state machine) and may box the struct.
    /// </summary>
    IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return Flags.GetBit(i);
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<bool>)this).GetEnumerator();
}
