// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetStatusFlags as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct StatusFlags : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Gets the underlying 8-bit unsigned integer containing the bits in system-native format.
    /// </summary>
    public byte Flags { get; }

    /// <summary>
    /// Fixed number of bits for this type
    /// </summary>
    public const int FixCount = 4;

    /// <summary>
    /// Initializes a new instance of <see cref="StatusFlags"/>.
    /// </summary>
    /// <param name="flags">
    /// The underlying 8-bit unsigned integer containing the bits in system-native format.
    /// Only the lower bits up to <see cref="FixCount"/> are used. The remaining bits are always set to zero.
    /// </param>
    public StatusFlags(byte flags)
    {
        Flags = (byte)(flags & 0xF);
    }

    /// <summary>
    /// Object is in alarm.
    /// </summary>
    public bool InAlarm => this[0];

    /// <summary>
    /// Object is in fault condition.
    /// </summary>
    public bool Fault => this[1];

    /// <summary>
    /// Object is overridden.
    /// </summary>
    public bool Overridden => this[2];

    /// <summary>
    /// Object is out of service.
    /// </summary>
    public bool OutOfService => this[3];

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
    /// As is standard .NET practice, no range checks are performed in <see cref="Current"/>. The consumer must
    /// call <see cref="MoveNext"/> and only access <see cref="Current"/> when it is valid.
    /// </remarks>
    public struct Enumerator
    {
        /// <summary>
        /// Copy of the parent <see cref="StatusFlags"/> instance being enumerated.
        /// </summary>
        private readonly StatusFlags _bits;

        /// <summary>
        /// Current enumerator index. Starts at -1 before the first element; incremented by <see cref="MoveNext"/>.
        /// Valid indices are 0..(<see cref="StatusFlags.FixCount"/> - 1).
        /// </summary>
        private int _index;

        /// <summary>
        /// Initializes a new <see cref="Enumerator"/> for the specified <paramref name="bits"/>.
        /// </summary>
        /// <param name="bits">The parent <see cref="StatusFlags"/> instance to enumerate.</param>
        /// <remarks>
        /// The constructor sets the internal index to -1 so enumeration starts before the first element.
        /// </remarks>
        internal Enumerator(StatusFlags bits)
        {
            _bits = bits;
            _index = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next bit.
        /// </summary>
        /// <returns><see langword="true"/> if the enumerator advanced to a valid bit; otherwise <see langword="false"/>.</returns>
        public bool MoveNext()
        {
            _index++;
            return _index < FixCount;
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
        for (int i = 0; i < FixCount; i++)
        {
            yield return Flags.GetBit(i);
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<bool>)this).GetEnumerator();
}
