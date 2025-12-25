// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetAuditOperationFlags as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct AuditOperationFlags : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Gets the underlying 64-bit unsigned integer containing the bits in system-native format.
    /// </summary>
    public ulong Flags { get; }

    /// <summary>
    /// Minimum allowed bit count for this type.
    /// </summary>
    public const int MinCount = 16;

    /// <summary>
    /// Maximum allowed bit count for this type.
    /// </summary>
    public const int MaxCount = 64;

    /// <summary>
    /// Initializes a new instance of <see cref="AuditOperationFlags"/>.
    /// </summary>
    /// <param name="flags">
    /// The underlying 64-bit unsigned integer containing the bits in system-native format.
    /// Only the lower bits up to <see cref="Count"/> are used. The remaining bits are always set to zero.
    /// </param>
    /// <param name="count">Number of bits used by this instance (range <see cref="MinCount"/>.. <see cref="MaxCount"/>).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is outside the allowed range.</exception>
    public AuditOperationFlags(ulong flags, int count = MinCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(count, MinCount, nameof(count));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(count, MaxCount, nameof(count));

        Count = count;
        if (count < MaxCount)
        {
            ulong mask = (1UL << count) - 1;
            flags &= mask;
        }
        Flags = flags;
    }

    /// <summary>
    /// Read operation.
    /// </summary>
    public bool Read => this[0];

    /// <summary>
    /// Write operation.
    /// </summary>
    public bool Write => this[1];

    /// <summary>
    /// Create operation.
    /// </summary>
    public bool Create => this[2];

    /// <summary>
    /// Delete operation.
    /// </summary>
    public bool Delete => this[3];

    /// <summary>
    /// Life safety operation.
    /// </summary>
    public bool LifeSafety => this[4];

    /// <summary>
    /// Acknowledge alarm operation.
    /// </summary>
    public bool AcknowledgeAlarm => this[5];

    /// <summary>
    /// Device disable communication operation.
    /// </summary>
    public bool DeviceDisableComm => this[6];

    /// <summary>
    /// Device enable communication operation.
    /// </summary>
    public bool DeviceEnableComm => this[7];

    /// <summary>
    /// Device reset operation.
    /// </summary>
    public bool DeviceReset => this[8];

    /// <summary>
    /// Device backup operation.
    /// </summary>
    public bool DeviceBackup => this[9];

    /// <summary>
    /// Device restore operation.
    /// </summary>
    public bool DeviceRestore => this[10];

    /// <summary>
    /// Subscription operation.
    /// </summary>
    public bool Subscription => this[11];

    /// <summary>
    /// Notification operation.
    /// </summary>
    public bool Notification => this[12];

    /// <summary>
    /// Auditing failure operation.
    /// </summary>
    public bool AuditingFailure => this[13];

    /// <summary>
    /// Network changes operation.
    /// </summary>
    public bool NetworkChanges => this[14];

    /// <summary>
    /// General operation.
    /// </summary>
    public bool General => this[15];

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
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Count);

            return Flags.GetBit(index);
        }
    }

    /// <summary>
    /// Gets the number of bits used by this bit string.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Returns a value-type enumerator suitable for pattern-based foreach iteration.
    /// Use this when iterating the struct directly to avoid allocations/boxing.
    /// </summary>
    public Enumerator GetEnumerator() => new(this);

    /// <summary>
    /// Value-type enumerator used by the public pattern-based <see cref="GetEnumerator"/> method.
    /// </summary>
    /// <remarks>
    /// The enumerator is a struct so direct iteration over a <see cref="AuditOperationFlags"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly AuditOperationFlags _bits;
        private int _index;

        internal Enumerator(AuditOperationFlags flags)
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
        for (int i = 0; i < Count; i++)
        {
            yield return Flags.GetBit(i);
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<bool>)this).GetEnumerator();
}
