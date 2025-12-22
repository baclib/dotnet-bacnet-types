// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetPriorityFilter bit string (16 bits).
/// </summary>
public readonly record struct PriorityFilter : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent priority filter bits. All 16 bits are used.
    /// </summary>
    public ushort Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="PriorityFilter"/>.
    /// </summary>
    /// <param name="flags">The raw flag value (16 bits).</param>
    public PriorityFilter(ushort flags)
    {
        Flags = flags;
    }

    /// <summary>
    /// Returns whether the bit at <paramref name="index"/> is set.
    /// </summary>
    /// <param name="index">Bit index, 0 = manual-life-safety, 15 = priority-16.</param>
    /// <returns><c>true</c> when the bit is set; otherwise <c>false</c>.</returns>
    private bool GetFlag(int index) => (Flags & (1 << index)) != 0;

    /// <summary>
    /// True when manual-life-safety (bit 0) is set.
    /// </summary>
    public bool ManualLifeSafety => GetFlag(0);

    /// <summary>
    /// True when automatic-life-safety (bit 1) is set.
    /// </summary>
    public bool AutomaticLifeSafety => GetFlag(1);

    /// <summary>
    /// True when priority-3 (bit 2) is set.
    /// </summary>
    public bool Priority3 => GetFlag(2);

    /// <summary>
    /// True when priority-4 (bit 3) is set.
    /// </summary>
    public bool Priority4 => GetFlag(3);

    /// <summary>
    /// True when critical-equipment-controls (bit 4) is set.
    /// </summary>
    public bool CriticalEquipmentControls => GetFlag(4);

    /// <summary>
    /// True when minimum-on-off (bit 5) is set.
    /// </summary>
    public bool MinimumOnOff => GetFlag(5);

    /// <summary>
    /// True when priority-7 (bit 6) is set.
    /// </summary>
    public bool Priority7 => GetFlag(6);

    /// <summary>
    /// True when manual-operator (bit 7) is set.
    /// </summary>
    public bool ManualOperator => GetFlag(7);

    /// <summary>
    /// True when priority-9 (bit 8) is set.
    /// </summary>
    public bool Priority9 => GetFlag(8);

    /// <summary>
    /// True when priority-10 (bit 9) is set.
    /// </summary>
    public bool Priority10 => GetFlag(9);

    /// <summary>
    /// True when priority-11 (bit 10) is set.
    /// </summary>
    public bool Priority11 => GetFlag(10);

    /// <summary>
    /// True when priority-12 (bit 11) is set.
    /// </summary>
    public bool Priority12 => GetFlag(11);

    /// <summary>
    /// True when priority-13 (bit 12) is set.
    /// </summary>
    public bool Priority13 => GetFlag(12);

    /// <summary>
    /// True when priority-14 (bit 13) is set.
    /// </summary>
    public bool Priority14 => GetFlag(13);

    /// <summary>
    /// True when priority-15 (bit 14) is set.
    /// </summary>
    public bool Priority15 => GetFlag(14);

    /// <summary>
    /// True when priority-16 (bit 15) is set.
    /// </summary>
    public bool Priority16 => GetFlag(15);

    /// <summary>
    /// Gets the number of bits used by this bit string (always 16).
    /// </summary>
    public int Count => 16;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = manual-life-safety, 15 = priority-16.</param>
    /// <returns><c>true</c> if the bit is set; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than 15.</exception>
    public bool this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

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
    /// The enumerator is a struct so direct iteration over a <see cref="PriorityFilter"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly PriorityFilter _filter;
        private int _index;

        internal Enumerator(PriorityFilter filter)
        {
            _filter = filter;
            _index = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next bit.
        /// </summary>
        /// <returns><c>true</c> if the enumerator advanced to a valid bit; otherwise <c>false</c>.</returns>
        public bool MoveNext()
        {
            _index++;
            return _index < 16;
        }

        /// <summary>
        /// Gets the current bit value.
        /// </summary>
        public readonly bool Current => _filter.GetFlag(_index);
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
