// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetServicesSupported bit string.
/// </summary>
public readonly record struct ServicesSupported : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent services. Bits 0..(Count-1) are possible, with bits 0..49 named.
    /// The stored array is sized appropriately for the configured bit count.
    /// </summary>
    public readonly nuint[] _flags;

    private readonly int _count;

    /// <summary>
    /// Initializes a new instance of <see cref="ServicesSupported"/>.
    /// </summary>
    /// <param name="flags">The raw flag array. Will be copied and masked to the configured bit count.</param>
    /// <param name="bitCount">Number of bits used by this instance (allowed range 35..512). Defaults to 35.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="flags"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="bitCount"/> is outside the 35..512 range.</exception>
    public ServicesSupported(nuint[] flags, int bitCount = 35)
    {
        ArgumentNullException.ThrowIfNull(flags);
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 35, nameof(bitCount));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 512, nameof(bitCount));

        _count = bitCount;

        // Calculate the required array size.
        int arraySize = (bitCount + (nuint.Size * 8 - 1)) / (nuint.Size * 8);
        _flags = new nuint[arraySize];

        // Copy and mask the input flags.
        int copyLength = Math.Min(flags.Length, arraySize);
        Array.Copy(flags, _flags, copyLength);

        // Mask the last element to the configured bit count.
        int bitsInLastElement = bitCount % (nuint.Size * 8);
        if (bitsInLastElement > 0 && arraySize > 0)
        {
            nuint mask = (1U << bitsInLastElement) - 1U;
            _flags[arraySize - 1] &= mask;
        }
    }

    /// <summary>
    /// Returns whether the bit at <paramref name="index"/> is set.
    /// </summary>
    /// <param name="index">Bit index, 0..(Count-1).</param>
    /// <returns><c>true</c> when the bit is set; otherwise <c>false</c>.</returns>
    private readonly bool GetFlag(int index)
    {
        if (_flags == null || _flags.Length == 0) return false;

        int elementIndex = index / (nuint.Size * 8);
        int bitIndex = index % (nuint.Size * 8);

        if (elementIndex >= _flags.Length) return false;

        return (_flags[elementIndex] & ((nuint)1 << bitIndex)) != 0;
    }

    /// <summary>
    /// True when Acknowledge-Alarm (bit 0) is set.
    /// </summary>
    public bool AcknowledgeAlarm => GetFlag(0);

    /// <summary>
    /// True when Confirmed-Cov-Notification (bit 1) is set.
    /// </summary>
    public bool ConfirmedCovNotification => GetFlag(1);

    /// <summary>
    /// True when Confirmed-Event-Notification (bit 2) is set.
    /// </summary>
    public bool ConfirmedEventNotification => GetFlag(2);

    /// <summary>
    /// True when Get-Alarm-Summary (bit 3) is set.
    /// </summary>
    public bool GetAlarmSummary => GetFlag(3);

    /// <summary>
    /// True when Get-Enrollment-Summary (bit 4) is set.
    /// </summary>
    public bool GetEnrollmentSummary => GetFlag(4);

    /// <summary>
    /// True when Subscribe-Cov (bit 5) is set.
    /// </summary>
    public bool SubscribeCov => GetFlag(5);

    /// <summary>
    /// True when Atomic-Read-File (bit 6) is set.
    /// </summary>
    public bool AtomicReadFile => GetFlag(6);

    /// <summary>
    /// True when Atomic-Write-File (bit 7) is set.
    /// </summary>
    public bool AtomicWriteFile => GetFlag(7);

    /// <summary>
    /// True when Add-List-Element (bit 8) is set.
    /// </summary>
    public bool AddListElement => GetFlag(8);

    /// <summary>
    /// True when Remove-List-Element (bit 9) is set.
    /// </summary>
    public bool RemoveListElement => GetFlag(9);

    /// <summary>
    /// True when Create-Object (bit 10) is set.
    /// </summary>
    public bool CreateObject => GetFlag(10);

    /// <summary>
    /// True when Delete-Object (bit 11) is set.
    /// </summary>
    public bool DeleteObject => GetFlag(11);

    /// <summary>
    /// True when Read-Property (bit 12) is set.
    /// </summary>
    public bool ReadProperty => GetFlag(12);

    /// <summary>
    /// True when Read-Property-Multiple (bit 14) is set.
    /// </summary>
    public bool ReadPropertyMultiple => GetFlag(14);

    /// <summary>
    /// True when Write-Property (bit 15) is set.
    /// </summary>
    public bool WriteProperty => GetFlag(15);

    /// <summary>
    /// True when Write-Property-Multiple (bit 16) is set.
    /// </summary>
    public bool WritePropertyMultiple => GetFlag(16);

    /// <summary>
    /// True when Device-Communication-Control (bit 17) is set.
    /// </summary>
    public bool DeviceCommunicationControl => GetFlag(17);

    /// <summary>
    /// True when Confirmed-Private-Transfer (bit 18) is set.
    /// </summary>
    public bool ConfirmedPrivateTransfer => GetFlag(18);

    /// <summary>
    /// True when Confirmed-Text-Message (bit 19) is set.
    /// </summary>
    public bool ConfirmedTextMessage => GetFlag(19);

    /// <summary>
    /// True when Reinitialize-Device (bit 20) is set.
    /// </summary>
    public bool ReinitializeDevice => GetFlag(20);

    /// <summary>
    /// True when Vt-Open (bit 21) is set.
    /// </summary>
    public bool VtOpen => GetFlag(21);

    /// <summary>
    /// True when Vt-Close (bit 22) is set.
    /// </summary>
    public bool VtClose => GetFlag(22);

    /// <summary>
    /// True when Vt-Data (bit 23) is set.
    /// </summary>
    public bool VtData => GetFlag(23);

    /// <summary>
    /// True when I-Am (bit 26) is set.
    /// </summary>
    public bool IAm => GetFlag(26);

    /// <summary>
    /// True when I-Have (bit 27) is set.
    /// </summary>
    public bool IHave => GetFlag(27);

    /// <summary>
    /// True when Unconfirmed-Cov-Notification (bit 28) is set.
    /// </summary>
    public bool UnconfirmedCovNotification => GetFlag(28);

    /// <summary>
    /// True when Unconfirmed-Event-Notification (bit 29) is set.
    /// </summary>
    public bool UnconfirmedEventNotification => GetFlag(29);

    /// <summary>
    /// True when Unconfirmed-Private-Transfer (bit 30) is set.
    /// </summary>
    public bool UnconfirmedPrivateTransfer => GetFlag(30);

    /// <summary>
    /// True when Unconfirmed-Text-Message (bit 31) is set.
    /// </summary>
    public bool UnconfirmedTextMessage => GetFlag(31);

    /// <summary>
    /// True when Time-Synchronization (bit 32) is set.
    /// </summary>
    public bool TimeSynchronization => GetFlag(32);

    /// <summary>
    /// True when Who-Has (bit 33) is set.
    /// </summary>
    public bool WhoHas => GetFlag(33);

    /// <summary>
    /// True when Who-Is (bit 34) is set.
    /// </summary>
    public bool WhoIs => GetFlag(34);

    /// <summary>
    /// True when Read-Range (bit 35) is set.
    /// </summary>
    public bool ReadRange => GetFlag(35);

    /// <summary>
    /// True when Utc-Time-Synchronization (bit 36) is set.
    /// </summary>
    public bool UtcTimeSynchronization => GetFlag(36);

    /// <summary>
    /// True when Life-Safety-Operation (bit 37) is set.
    /// </summary>
    public bool LifeSafetyOperation => GetFlag(37);

    /// <summary>
    /// True when Subscribe-Cov-Property (bit 38) is set.
    /// </summary>
    public bool SubscribeCovProperty => GetFlag(38);

    /// <summary>
    /// True when Get-Event-Information (bit 39) is set.
    /// </summary>
    public bool GetEventInformation => GetFlag(39);

    /// <summary>
    /// True when Write-Group (bit 40) is set.
    /// </summary>
    public bool WriteGroup => GetFlag(40);

    /// <summary>
    /// True when Subscribe-Cov-Property-Multiple (bit 41) is set.
    /// </summary>
    public bool SubscribeCovPropertyMultiple => GetFlag(41);

    /// <summary>
    /// True when Confirmed-Cov-Notification-Multiple (bit 42) is set.
    /// </summary>
    public bool ConfirmedCovNotificationMultiple => GetFlag(42);

    /// <summary>
    /// True when Unconfirmed-Cov-Notification-Multiple (bit 43) is set.
    /// </summary>
    public bool UnconfirmedCovNotificationMultiple => GetFlag(43);

    /// <summary>
    /// True when Confirmed-Audit-Notification (bit 44) is set.
    /// </summary>
    public bool ConfirmedAuditNotification => GetFlag(44);

    /// <summary>
    /// True when Audit-Log-Query (bit 45) is set.
    /// </summary>
    public bool AuditLogQuery => GetFlag(45);

    /// <summary>
    /// True when Unconfirmed-Audit-Notification (bit 46) is set.
    /// </summary>
    public bool UnconfirmedAuditNotification => GetFlag(46);

    /// <summary>
    /// True when Who-Am-I (bit 47) is set.
    /// </summary>
    public bool WhoAmI => GetFlag(47);

    /// <summary>
    /// True when You-Are (bit 48) is set.
    /// </summary>
    public bool YouAre => GetFlag(48);

    /// <summary>
    /// True when Auth-Request (bit 49) is set.
    /// </summary>
    public bool AuthRequest => GetFlag(49);

    /// <summary>
    /// Gets the number of bits used by this bit string (configured via constructor, range 35..512).
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = Acknowledge-Alarm, (Count-1) = last bit.</param>
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
    /// The enumerator is a struct so direct iteration over a <see cref="ServicesSupported"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly ServicesSupported _flags;
        private int _index;

        internal Enumerator(ServicesSupported flags)
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
