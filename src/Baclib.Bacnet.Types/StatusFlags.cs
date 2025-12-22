// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetStatusFlags bit string (4 bits).
/// </summary>
public readonly record struct StatusFlags : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent status. Only bits 0..3 are used.
    /// The constructor masks the supplied value so bits 4-7 are always zero.
    /// </summary>
    public byte Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="StatusFlags"/>.
    /// </summary>
    /// <param name="flags">The raw flag byte. Only the low 4 bits are used; the value is masked with <c>0x0F</c>.</param>
    public StatusFlags(byte flags)
    {
        Flags = (byte)(flags & 0x0F);
    }

    /// <summary>
    /// Returns whether the bit at <paramref name="index"/> is set.
    /// </summary>
    /// <param name="index">Bit index, 0 = in-alarm, 1 = fault, 2 = overridden, 3 = out-of-service.</param>
    /// <returns><c>true</c> when the bit is set; otherwise <c>false</c>.</returns>
    private bool GetFlag(int index) => (Flags & (1 << index)) != 0;

    /// <summary>
    /// True when in-alarm (bit 0) is set.
    /// </summary>
    public bool InAlarm => GetFlag(0);

    /// <summary>
    /// True when fault (bit 1) is set.
    /// </summary>
    public bool Fault => GetFlag(1);

    /// <summary>
    /// True when overridden (bit 2) is set.
    /// </summary>
    public bool Overridden => GetFlag(2);

    /// <summary>
    /// True when out-of-service (bit 3) is set.
    /// </summary>
    public bool OutOfService => GetFlag(3);

    /// <summary>
    /// Gets the number of bits used by this bit string (always 4).
    /// </summary>
    public int Count => 4;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = in-alarm, 1 = fault, 2 = overridden, 3 = out-of-service.</param>
    /// <returns><c>true</c> if the bit is set; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than 3.</exception>
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
    /// The enumerator is a struct so direct iteration over a <see cref="StatusFlags"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly StatusFlags _flags;
        private int _index;

        internal Enumerator(StatusFlags flags)
        {
            _flags = flags;
            _index = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next bit.
        /// </summary>
        /// <returns><c>true</c> if the enumerator advanced to a valid bit; otherwise <c>false</c>.</returns>
        public bool MoveNext()
        {
            _index++;
            return _index < 4;
        }

        /// <summary>
        /// Gets the current bit value.
        /// </summary>
        public readonly bool Current => _flags.GetFlag(_index);
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