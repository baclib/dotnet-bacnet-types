// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetAuditOperationFlags bit string.
/// </summary>
public readonly record struct AuditOperationFlags : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent audit operations. Bits 0..63 are possible, with bits 0..15 named.
    /// The stored value is masked to the configured bit count.
    /// </summary>
    public ulong Flags { get; }

    private readonly int _count;

    /// <summary>
    /// Initializes a new instance of <see cref="AuditOperationFlags"/>.
    /// </summary>
    /// <param name="flags">The raw flag value.</param>
    /// <param name="bitCount">Number of bits used by this instance (allowed range 16..64). Defaults to 16.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="bitCount"/> is outside the 16..64 range.</exception>
    public AuditOperationFlags(ulong flags, int bitCount = 16)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 16, nameof(bitCount));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 64, nameof(bitCount));

        _count = bitCount;

        // Mask the provided flags to the configured bit count.
        var mask = bitCount == 64 ? ulong.MaxValue : ((1UL << bitCount) - 1UL);
        Flags = flags & mask;
    }

    /// <summary>
    /// Returns whether the bit at <paramref name="index"/> is set.
    /// </summary>
    /// <param name="index">Bit index, 0..(Count-1).</param>
    /// <returns><c>true</c> when the bit is set; otherwise <c>false</c>.</returns>
    private readonly bool GetFlag(int index) => (Flags & (1UL << index)) != 0;

    /// <summary>
    /// True when Read (bit 0) is set.
    /// </summary>
    public bool Read => GetFlag(0);

    /// <summary>
    /// True when Write (bit 1) is set.
    /// </summary>
    public bool Write => GetFlag(1);

    /// <summary>
    /// True when Create (bit 2) is set.
    /// </summary>
    public bool Create => GetFlag(2);

    /// <summary>
    /// True when Delete (bit 3) is set.
    /// </summary>
    public bool Delete => GetFlag(3);

    /// <summary>
    /// True when Life-Safety (bit 4) is set.
    /// </summary>
    public bool LifeSafety => GetFlag(4);

    /// <summary>
    /// True when Acknowledge-Alarm (bit 5) is set.
    /// </summary>
    public bool AcknowledgeAlarm => GetFlag(5);

    /// <summary>
    /// True when Device-Disable-Comm (bit 6) is set.
    /// </summary>
    public bool DeviceDisableComm => GetFlag(6);

    /// <summary>
    /// True when Device-Enable-Comm (bit 7) is set.
    /// </summary>
    public bool DeviceEnableComm => GetFlag(7);

    /// <summary>
    /// True when Device-Reset (bit 8) is set.
    /// </summary>
    public bool DeviceReset => GetFlag(8);

    /// <summary>
    /// True when Device-Backup (bit 9) is set.
    /// </summary>
    public bool DeviceBackup => GetFlag(9);

    /// <summary>
    /// True when Device-Restore (bit 10) is set.
    /// </summary>
    public bool DeviceRestore => GetFlag(10);

    /// <summary>
    /// True when Subscription (bit 11) is set.
    /// </summary>
    public bool Subscription => GetFlag(11);

    /// <summary>
    /// True when Notification (bit 12) is set.
    /// </summary>
    public bool Notification => GetFlag(12);

    /// <summary>
    /// True when Auditing-Failure (bit 13) is set.
    /// </summary>
    public bool AuditingFailure => GetFlag(13);

    /// <summary>
    /// True when Network-Changes (bit 14) is set.
    /// </summary>
    public bool NetworkChanges => GetFlag(14);

    /// <summary>
    /// True when General (bit 15) is set.
    /// </summary>
    public bool General => GetFlag(15);

    /// <summary>
    /// Gets the number of bits used by this bit string (configured via constructor, range 16..64).
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = Read, (Count-1) = last bit.</param>
    /// <returns><c>true</c> if the bit is set; otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than 0 or greater than or equal to <see cref="Count"/>.</exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Count);

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
    /// The enumerator is a struct so direct iteration over a <see cref="AuditOperationFlags"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly AuditOperationFlags _flags;
        private int _index;

        internal Enumerator(AuditOperationFlags flags)
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
            return _index < _flags.Count;
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
