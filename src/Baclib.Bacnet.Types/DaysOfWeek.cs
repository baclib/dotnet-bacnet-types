// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetDaysOfWeek bit string.
/// </summary>
public readonly record struct DaysOfWeek : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent days. Only bits 0..6 are used (bit 0 = Monday, bit 6 = Sunday).
    /// The constructor masks the supplied value so the highest bit (bit 7) is always zero.
    /// </summary>
    public byte Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DaysOfWeek"/>.
    /// </summary>
    /// <param name="flags">The raw flag byte. Only the low 7 bits are used; the value is masked with <c>0x7F</c>.</param>
    public DaysOfWeek(byte flags)
    {
        Flags = (byte)(flags & 0x7F);
    }

    /// <summary>
    /// Returns whether the bit at <paramref name="index"/> is set.
    /// </summary>
    /// <param name="index">Bit index, 0 = Monday ... 6 = Sunday.</param>
    /// <returns><c>true</c> when the bit is set; otherwise <c>false</c>.</returns>
    private bool GetFlag(int index) => (Flags & (1 << index)) != 0;

    /// <summary>
    /// True when Monday (bit 0) is set.
    /// </summary>
    public bool Monday => GetFlag(0);

    /// <summary>
    /// True when Tuesday (bit 1) is set.
    /// </summary>
    public bool Tuesday => GetFlag(1);

    /// <summary>
    /// True when Wednesday (bit 2) is set.
    /// </summary>
    public bool Wednesday => GetFlag(2);

    /// <summary>
    /// True when Thursday (bit 3) is set.
    /// </summary>
    public bool Thursday => GetFlag(3);

    /// <summary>
    /// True when Friday (bit 4) is set.
    /// </summary>
    public bool Friday => GetFlag(4);

    /// <summary>
    /// True when Saturday (bit 5) is set.
    /// </summary>
    public bool Saturday => GetFlag(5);

    /// <summary>
    /// True when Sunday (bit 6) is set.
    /// </summary>
    public bool Sunday => GetFlag(6);

    /// <summary>
    /// Gets the number of bits used by this bit string (always 7).
    /// </summary>
    public int Count => 7;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = Monday, 6 = Sunday.</param>
    /// <returns><c>true</c> if the bit is set; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than 6.</exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(index, 6);

            return GetFlag(index);
        }
    }

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
        private readonly DaysOfWeek _days;
        private int _index;

        internal Enumerator(DaysOfWeek days)
        {
            _days = days;
            _index = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next bit.
        /// </summary>
        /// <returns><c>true</c> if the enumerator advanced to a valid bit; otherwise <c>false</c>.</returns>
        public bool MoveNext()
        {
            _index++;
            return _index < 7;
        }

        /// <summary>
        /// Gets the current bit value.
        /// </summary>
        public readonly bool Current => _days.GetFlag(_index);
    }

    /// <summary>
    /// Interface implementation for <see cref="IEnumerable{Boolean}"/>.
    /// Enumerating via the interface will allocate (iterator state machine) and may box the struct.
    /// </summary>
    IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return GetFlag(i);
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<bool>)this).GetEnumerator();
}
