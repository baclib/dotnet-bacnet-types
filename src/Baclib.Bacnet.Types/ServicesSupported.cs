// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetServicesSupported as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct ServicesSupported : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Backing storage for the configured bits.
    /// </summary>
    private readonly byte[] _bytes = BitString.EmptyData;

    /// <summary>
    /// Minimum allowed bit count for this type.
    /// </summary>
    public const int MinBitCount = 35;

    /// <summary>
    /// Maximum allowed bit count for this type.
    /// </summary>
    public const int MaxBitCount = 512;

    /// <summary>
    /// Initializes a new instance of <see cref="ServicesSupported"/> from a span of bytes.
    /// </summary>
    /// <param name="bitBytes">
    /// Source bytes containing bit data. The span must be at least <c>(bitCount + 7) / 8</c> bytes long.
    /// Only the first <c>minimumLength</c> bytes are copied; excess bytes in the span are ignored.
    /// </param>
    /// <param name="bitCount">Number of bits used by this instance (range <see cref="MinBitCount"/>.. <see cref="MaxBitCount"/>).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="bitCount"/> is outside the allowed range.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="bitBytes"/> is shorter than required for <paramref name="bitCount"/>.</exception>
    public ServicesSupported(ReadOnlySpan<byte> bitBytes, int bitCount = MinBitCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, MinBitCount, nameof(bitCount));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, MaxBitCount, nameof(bitCount));

        int minimumLength = (bitCount + 7) / 8;
        if (bitBytes.Length < minimumLength)
        {
            throw new ArgumentException($"Too short for {bitCount} bits.", nameof(bitBytes));
        }

        _bytes = bitBytes[..minimumLength].ToArray();
        Count = bitCount;
    }

    /// <summary>
    /// Acknowledge alarm service.
    /// </summary>
    public bool AcknowledgeAlarm => this[0];

    /// <summary>
    /// Confirmed COV notification service.
    /// </summary>
    public bool ConfirmedCovNotification => this[1];

    /// <summary>
    /// Confirmed event notification service.
    /// </summary>
    public bool ConfirmedEventNotification => this[2];

    /// <summary>
    /// Get alarm summary service.
    /// </summary>
    public bool GetAlarmSummary => this[3];

    /// <summary>
    /// Get enrollment summary service.
    /// </summary>
    public bool GetEnrollmentSummary => this[4];

    /// <summary>
    /// Subscribe COV service.
    /// </summary>
    public bool SubscribeCov => this[5];

    /// <summary>
    /// Atomic read file service.
    /// </summary>
    public bool AtomicReadFile => this[6];

    /// <summary>
    /// Atomic write file service.
    /// </summary>
    public bool AtomicWriteFile => this[7];

    /// <summary>
    /// Add list element service.
    /// </summary>
    public bool AddListElement => this[8];

    /// <summary>
    /// Remove list element service.
    /// </summary>
    public bool RemoveListElement => this[9];

    /// <summary>
    /// Create object service.
    /// </summary>
    public bool CreateObject => this[10];

    /// <summary>
    /// Delete object service.
    /// </summary>
    public bool DeleteObject => this[11];

    /// <summary>
    /// Read property service.
    /// </summary>
    public bool ReadProperty => this[12];

    /// <summary>
    /// Read property multiple service.
    /// </summary>
    public bool ReadPropertyMultiple => this[14];

    /// <summary>
    /// Write property service.
    /// </summary>
    public bool WriteProperty => this[15];

    /// <summary>
    /// Write property multiple service.
    /// </summary>
    public bool WritePropertyMultiple => this[16];

    /// <summary>
    /// Device communication control service.
    /// </summary>
    public bool DeviceCommunicationControl => this[17];

    /// <summary>
    /// Confirmed private transfer service.
    /// </summary>
    public bool ConfirmedPrivateTransfer => this[18];

    /// <summary>
    /// Confirmed text message service.
    /// </summary>
    public bool ConfirmedTextMessage => this[19];

    /// <summary>
    /// Reinitialize device service.
    /// </summary>
    public bool ReinitializeDevice => this[20];

    /// <summary>
    /// VT open service.
    /// </summary>
    public bool VtOpen => this[21];

    /// <summary>
    /// VT close service.
    /// </summary>
    public bool VtClose => this[22];

    /// <summary>
    /// VT data service.
    /// </summary>
    public bool VtData => this[23];

    /// <summary>
    /// I-Am service.
    /// </summary>
    public bool IAm => this[26];

    /// <summary>
    /// I-Have service.
    /// </summary>
    public bool IHave => this[27];

    /// <summary>
    /// Unconfirmed COV notification service.
    /// </summary>
    public bool UnconfirmedCovNotification => this[28];

    /// <summary>
    /// Unconfirmed event notification service.
    /// </summary>
    public bool UnconfirmedEventNotification => this[29];

    /// <summary>
    /// Unconfirmed private transfer service.
    /// </summary>
    public bool UnconfirmedPrivateTransfer => this[30];

    /// <summary>
    /// Unconfirmed text message service.
    /// </summary>
    public bool UnconfirmedTextMessage => this[31];

    /// <summary>
    /// Time synchronization service.
    /// </summary>
    public bool TimeSynchronization => this[32];

    /// <summary>
    /// Who-Has service.
    /// </summary>
    public bool WhoHas => this[33];

    /// <summary>
    /// Who-Is service.
    /// </summary>
    public bool WhoIs => this[34];

    /// <summary>
    /// Read range service.
    /// </summary>
    public bool ReadRange => this[35];

    /// <summary>
    /// UTC time synchronization service.
    /// </summary>
    public bool UtcTimeSynchronization => this[36];

    /// <summary>
    /// Life safety operation service.
    /// </summary>
    public bool LifeSafetyOperation => this[37];

    /// <summary>
    /// Subscribe COV property service.
    /// </summary>
    public bool SubscribeCovProperty => this[38];

    /// <summary>
    /// Get event information service.
    /// </summary>
    public bool GetEventInformation => this[39];

    /// <summary>
    /// Write group service.
    /// </summary>
    public bool WriteGroup => this[40];

    /// <summary>
    /// Subscribe COV property multiple service.
    /// </summary>
    public bool SubscribeCovPropertyMultiple => this[41];

    /// <summary>
    /// Confirmed COV notification multiple service.
    /// </summary>
    public bool ConfirmedCovNotificationMultiple => this[42];

    /// <summary>
    /// Unconfirmed COV notification multiple service.
    /// </summary>
    public bool UnconfirmedCovNotificationMultiple => this[43];

    /// <summary>
    /// Confirmed audit notification service.
    /// </summary>
    public bool ConfirmedAuditNotification => this[44];

    /// <summary>
    /// Audit log query service.
    /// </summary>
    public bool AuditLogQuery => this[45];

    /// <summary>
    /// Unconfirmed audit notification service.
    /// </summary>
    public bool UnconfirmedAuditNotification => this[46];

    /// <summary>
    /// Who-Am-I service.
    /// </summary>
    public bool WhoAmI => this[47];

    /// <summary>
    /// You-Are service.
    /// </summary>
    public bool YouAre => this[48];

    /// <summary>
    /// Auth request service.
    /// </summary>
    public bool AuthRequest => this[49];

    /// <summary>
    /// Gets the number of bits used by this instance.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Gets the boolean value of the bit at the specified zero-based <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index.</param>
    /// <returns><see langword="true"/> if the bit is set; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="index"/> is less than 0 or greater than or equal to <see cref="Count"/>.
    /// </exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Count, nameof(index));

            return _bytes[index / 8].GetBit(index % 8);
        }
    }

    /// <summary>
    /// Returns a value-type enumerator suitable for pattern-based foreach iteration.
    /// The enumerator yields exactly <see cref="Count"/> boolean values.
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
        /// <summary>
        /// Reference to the parent <see cref="ServicesSupported"/> instance being enumerated.
        /// </summary>
        private readonly ServicesSupported _bits;

        /// <summary>
        /// Current enumerator index. Starts at -1 before the first element; incremented by <see cref="MoveNext"/>.
        /// Valid indices are 0..(<see cref="ServicesSupported.Count"/> - 1).
        /// </summary>
        private int _index;

        /// <summary>
        /// Initializes a new <see cref="Enumerator"/> for the specified <paramref name="bits"/>.
        /// </summary>
        /// <param name="bits">The parent <see cref="ServicesSupported"/> instance to enumerate.</param>
        /// <remarks>
        /// The constructor sets the internal index to -1 so enumeration starts before the first element.
        /// </remarks>
        internal Enumerator(ServicesSupported bits)
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
            return _index < _bits.Count;
        }

        /// <summary>
        /// Gets the current bit value.
        /// </summary>
        public readonly bool Current => _bits[_index];
    }

    /// <summary>
    /// Interface implementation for <see cref="IEnumerable{Boolean}"/>
    /// Enumerating via the interface will allocate (iterator state machine) and may box the struct.
    /// </summary>
    IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return this[i];
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<bool>)this).GetEnumerator();
}
