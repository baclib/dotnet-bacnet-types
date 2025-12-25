// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the bit string BACnetObjectTypesSupported as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public readonly record struct ObjectTypesSupported : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Backing storage for the configured bits.
    /// </summary>
    private readonly byte[] _bytes = BitString.EmptyData;

    /// <summary>
    /// Minimum allowed bit count for this type.
    /// </summary>
    public const int MinBitCount = 18;

    /// <summary>
    /// Maximum allowed bit count for this type.
    /// </summary>
    public const int MaxBitCount = 1024;

    /// <summary>
    /// Initializes a new instance of <see cref="ObjectTypesSupported"/> from a span of bytes.
    /// </summary>
    /// <param name="bitBytes">
    /// Source bytes containing bit data. The span must be at least <c>(bitCount + 7) / 8</c> bytes long.
    /// Only the first <c>minimumLength</c> bytes are copied; excess bytes in the span are ignored.
    /// </param>
    /// <param name="bitCount">Number of bits used by this instance (range <see cref="MinBitCount"/>.. <see cref="MaxBitCount"/>).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="bitCount"/> is outside the allowed range.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="bitBytes"/> is shorter than required for <paramref name="bitCount"/>.</exception>
    public ObjectTypesSupported(ReadOnlySpan<byte> bitBytes, int bitCount = MinBitCount)
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
    /// Analog input object.
    /// </summary>
    public bool AnalogInput => this[0];

    /// <summary>
    /// Analog output object.
    /// </summary>
    public bool AnalogOutput => this[1];

    /// <summary>
    /// Analog value object.
    /// </summary>
    public bool AnalogValue => this[2];

    /// <summary>
    /// Binary input object.
    /// </summary>
    public bool BinaryInput => this[3];

    /// <summary>
    /// Binary output object.
    /// </summary>
    public bool BinaryOutput => this[4];

    /// <summary>
    /// Binary value object.
    /// </summary>
    public bool BinaryValue => this[5];

    /// <summary>
    /// Calendar object.
    /// </summary>
    public bool Calendar => this[6];

    /// <summary>
    /// Command object.
    /// </summary>
    public bool Command => this[7];

    /// <summary>
    /// Device object.
    /// </summary>
    public bool Device => this[8];

    /// <summary>
    /// Event enrollment object.
    /// </summary>
    public bool EventEnrollment => this[9];

    /// <summary>
    /// File object.
    /// </summary>
    public bool File => this[10];

    /// <summary>
    /// Group object.
    /// </summary>
    public bool Group => this[11];

    /// <summary>
    /// Loop object.
    /// </summary>
    public bool Loop => this[12];

    /// <summary>
    /// Multi-state input object.
    /// </summary>
    public bool MultiStateInput => this[13];

    /// <summary>
    /// Multi-state output object.
    /// </summary>
    public bool MultiStateOutput => this[14];

    /// <summary>
    /// Notification class object.
    /// </summary>
    public bool NotificationClass => this[15];

    /// <summary>
    /// Program object.
    /// </summary>
    public bool Program => this[16];

    /// <summary>
    /// Schedule object.
    /// </summary>
    public bool Schedule => this[17];

    /// <summary>
    /// Averaging object.
    /// </summary>
    public bool Averaging => this[18];

    /// <summary>
    /// Multi-state value object.
    /// </summary>
    public bool MultiStateValue => this[19];

    /// <summary>
    /// Trend log object.
    /// </summary>
    public bool TrendLog => this[20];

    /// <summary>
    /// Life safety point object.
    /// </summary>
    public bool LifeSafetyPoint => this[21];

    /// <summary>
    /// Life safety zone object.
    /// </summary>
    public bool LifeSafetyZone => this[22];

    /// <summary>
    /// Accumulator object.
    /// </summary>
    public bool Accumulator => this[23];

    /// <summary>
    /// Pulse converter object.
    /// </summary>
    public bool PulseConverter => this[24];

    /// <summary>
    /// Event log object.
    /// </summary>
    public bool EventLog => this[25];

    /// <summary>
    /// Global group object.
    /// </summary>
    public bool GlobalGroup => this[26];

    /// <summary>
    /// Trend log multiple object.
    /// </summary>
    public bool TrendLogMultiple => this[27];

    /// <summary>
    /// Load control object.
    /// </summary>
    public bool LoadControl => this[28];

    /// <summary>
    /// Structured view object.
    /// </summary>
    public bool StructuredView => this[29];

    /// <summary>
    /// Access door object.
    /// </summary>
    public bool AccessDoor => this[30];

    /// <summary>
    /// Timer object.
    /// </summary>
    public bool Timer => this[31];

    /// <summary>
    /// Access credential object.
    /// </summary>
    public bool AccessCredential => this[32];

    /// <summary>
    /// Access point object.
    /// </summary>
    public bool AccessPoint => this[33];

    /// <summary>
    /// Access rights object.
    /// </summary>
    public bool AccessRights => this[34];

    /// <summary>
    /// Access user object.
    /// </summary>
    public bool AccessUser => this[35];

    /// <summary>
    /// Access zone object.
    /// </summary>
    public bool AccessZone => this[36];

    /// <summary>
    /// Credential data input object.
    /// </summary>
    public bool CredentialDataInput => this[37];

    /// <summary>
    /// Bitstring value object.
    /// </summary>
    public bool BitstringValue => this[39];

    /// <summary>
    /// Characterstring value object.
    /// </summary>
    public bool CharacterstringValue => this[40];

    /// <summary>
    /// Datepattern value object.
    /// </summary>
    public bool DatepatternValue => this[41];

    /// <summary>
    /// Date value object.
    /// </summary>
    public bool DateValue => this[42];

    /// <summary>
    /// Datetimepattern value object.
    /// </summary>
    public bool DatetimepatternValue => this[43];

    /// <summary>
    /// Datetime value object.
    /// </summary>
    public bool DatetimeValue => this[44];

    /// <summary>
    /// Integer value object.
    /// </summary>
    public bool IntegerValue => this[45];

    /// <summary>
    /// Large analog value object.
    /// </summary>
    public bool LargeAnalogValue => this[46];

    /// <summary>
    /// Octetstring value object.
    /// </summary>
    public bool OctetstringValue => this[47];

    /// <summary>
    /// Positive integer value object.
    /// </summary>
    public bool PositiveIntegerValue => this[48];

    /// <summary>
    /// Timepattern value object.
    /// </summary>
    public bool TimepatternValue => this[49];

    /// <summary>
    /// Time value object.
    /// </summary>
    public bool TimeValue => this[50];

    /// <summary>
    /// Notification forwarder object.
    /// </summary>
    public bool NotificationForwarder => this[51];

    /// <summary>
    /// Alert enrollment object.
    /// </summary>
    public bool AlertEnrollment => this[52];

    /// <summary>
    /// Channel object.
    /// </summary>
    public bool Channel => this[53];

    /// <summary>
    /// Lighting output object.
    /// </summary>
    public bool LightingOutput => this[54];

    /// <summary>
    /// Binary lighting output object.
    /// </summary>
    public bool BinaryLightingOutput => this[55];

    /// <summary>
    /// Network port object.
    /// </summary>
    public bool NetworkPort => this[56];

    /// <summary>
    /// Elevator group object.
    /// </summary>
    public bool ElevatorGroup => this[57];

    /// <summary>
    /// Escalator object.
    /// </summary>
    public bool Escalator => this[58];

    /// <summary>
    /// Lift object.
    /// </summary>
    public bool Lift => this[59];

    /// <summary>
    /// Staging object.
    /// </summary>
    public bool Staging => this[60];

    /// <summary>
    /// Audit log object.
    /// </summary>
    public bool AuditLog => this[61];

    /// <summary>
    /// Audit reporter object.
    /// </summary>
    public bool AuditReporter => this[62];

    /// <summary>
    /// Color object.
    /// </summary>
    public bool Color => this[63];

    /// <summary>
    /// Color temperature object.
    /// </summary>
    public bool ColorTemperature => this[64];

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
    /// The enumerator is a struct so direct iteration over a <see cref="ObjectTypesSupported"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        /// <summary>
        /// Reference to the parent <see cref="ObjectTypesSupported"/> instance being enumerated.
        /// </summary>
        private readonly ObjectTypesSupported _bits;

        /// <summary>
        /// Current enumerator index. Starts at -1 before the first element; incremented by <see cref="MoveNext"/>.
        /// Valid indices are 0..(<see cref="ObjectTypesSupported.Count"/> - 1).
        /// </summary>
        private int _index;

        /// <summary>
        /// Initializes a new <see cref="Enumerator"/> for the specified <paramref name="bits"/>.
        /// </summary>
        /// <param name="bits">The parent <see cref="ObjectTypesSupported"/> instance to enumerate.</param>
        /// <remarks>
        /// The constructor sets the internal index to -1 so enumeration starts before the first element.
        /// </remarks>
        internal Enumerator(ObjectTypesSupported bits)
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
