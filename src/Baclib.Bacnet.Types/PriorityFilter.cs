// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetPriorityFilter as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct PriorityFilter : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Gets the underlying 16-bit unsigned integer containing the bits in system-native format.
    /// </summary>
    public ushort Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="PriorityFilter"/>.
    /// </summary>
    /// <param name="flags">
    /// The underlying 16-bit unsigned integer containing the bits in system-native format.
    /// Only the lower bits up to <see cref="Count"/> (always 16) are used. The remaining bits are always set to zero.
    /// </param>
    public PriorityFilter(ushort flags)
    {
        Flags = (ushort)(flags & 0xFFFF);
    }

    /// <summary>
    /// Manual life safety priority.
    /// </summary>
    public bool ManualLifeSafety => Flags.GetBit(0);

    /// <summary>
    /// Automatic life safety priority.
    /// </summary>
    public bool AutomaticLifeSafety => Flags.GetBit(1);

    /// <summary>
    /// Priority 3.
    /// </summary>
    public bool Priority3 => Flags.GetBit(2);

    /// <summary>
    /// Priority 4.
    /// </summary>
    public bool Priority4 => Flags.GetBit(3);

    /// <summary>
    /// Critical equipment controls priority.
    /// </summary>
    public bool CriticalEquipmentControls => Flags.GetBit(4);

    /// <summary>
    /// Minimum on/off priority.
    /// </summary>
    public bool MinimumOnOff => Flags.GetBit(5);

    /// <summary>
    /// Priority 7.
    /// </summary>
    public bool Priority7 => Flags.GetBit(6);

    /// <summary>
    /// Manual operator priority.
    /// </summary>
    public bool ManualOperator => Flags.GetBit(7);

    /// <summary>
    /// Priority 9.
    /// </summary>
    public bool Priority9 => Flags.GetBit(8);

    /// <summary>
    /// Priority 10.
    /// </summary>
    public bool Priority10 => Flags.GetBit(9);

    /// <summary>
    /// Priority 11.
    /// </summary>
    public bool Priority11 => Flags.GetBit(10);

    /// <summary>
    /// Priority 12.
    /// </summary>
    public bool Priority12 => Flags.GetBit(11);

    /// <summary>
    /// Priority 13.
    /// </summary>
    public bool Priority13 => Flags.GetBit(12);

    /// <summary>
    /// Priority 14.
    /// </summary>
    public bool Priority14 => Flags.GetBit(13);

    /// <summary>
    /// Priority 15.
    /// </summary>
    public bool Priority15 => Flags.GetBit(14);

    /// <summary>
    /// Priority 16.
    /// </summary>
    public bool Priority16 => Flags.GetBit(15);

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
    private const int _count = 16;

    /// <summary>
    /// Gets the number of bits used by this bit string (always 16).
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
    /// The enumerator is a struct so direct iteration over a <see cref="PriorityFilter"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly PriorityFilter _bits;
        private int _index;

        internal Enumerator(PriorityFilter flags)
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
