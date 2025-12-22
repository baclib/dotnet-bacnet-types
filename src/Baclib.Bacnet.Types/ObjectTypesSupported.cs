// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnetObjectTypesSupported bit string.
/// </summary>
public readonly record struct ObjectTypesSupported : IReadOnlyCollection<bool>
{
    /// <summary>
    /// Raw flags used to represent object types. Bits 0..(Count-1) are possible, with bits 0..64 named.
    /// The stored array is sized appropriately for the configured bit count.
    /// </summary>
    public readonly nuint[] _flags;

    private readonly int _count;

    /// <summary>
    /// Initializes a new instance of <see cref="ObjectTypesSupported"/>.
    /// </summary>
    /// <param name="flags">The raw flag array. Will be copied and masked to the configured bit count.</param>
    /// <param name="bitCount">Number of bits used by this instance (allowed range 17..1024). Defaults to 17.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="flags"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="bitCount"/> is outside the 17..1024 range.</exception>
    public ObjectTypesSupported(nuint[] flags, int bitCount = 17)
    {
        ArgumentNullException.ThrowIfNull(flags);
        ArgumentOutOfRangeException.ThrowIfLessThan(bitCount, 17, nameof(bitCount));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, 1024, nameof(bitCount));

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
    /// True when Analog-Input (bit 0) is set.
    /// </summary>
    public bool AnalogInput => GetFlag(0);

    /// <summary>
    /// True when Analog-Output (bit 1) is set.
    /// </summary>
    public bool AnalogOutput => GetFlag(1);

    /// <summary>
    /// True when Analog-Value (bit 2) is set.
    /// </summary>
    public bool AnalogValue => GetFlag(2);

    /// <summary>
    /// True when Binary-Input (bit 3) is set.
    /// </summary>
    public bool BinaryInput => GetFlag(3);

    /// <summary>
    /// True when Binary-Output (bit 4) is set.
    /// </summary>
    public bool BinaryOutput => GetFlag(4);

    /// <summary>
    /// True when Binary-Value (bit 5) is set.
    /// </summary>
    public bool BinaryValue => GetFlag(5);

    /// <summary>
    /// True when Calendar (bit 6) is set.
    /// </summary>
    public bool Calendar => GetFlag(6);

    /// <summary>
    /// True when Command (bit 7) is set.
    /// </summary>
    public bool Command => GetFlag(7);

    /// <summary>
    /// True when Device (bit 8) is set.
    /// </summary>
    public bool Device => GetFlag(8);

    /// <summary>
    /// True when Event-Enrollment (bit 9) is set.
    /// </summary>
    public bool EventEnrollment => GetFlag(9);

    /// <summary>
    /// True when File (bit 10) is set.
    /// </summary>
    public bool File => GetFlag(10);

    /// <summary>
    /// True when Group (bit 11) is set.
    /// </summary>
    public bool Group => GetFlag(11);

    /// <summary>
    /// True when Loop (bit 12) is set.
    /// </summary>
    public bool Loop => GetFlag(12);

    /// <summary>
    /// True when Multi-State-Input (bit 13) is set.
    /// </summary>
    public bool MultiStateInput => GetFlag(13);

    /// <summary>
    /// True when Multi-State-Output (bit 14) is set.
    /// </summary>
    public bool MultiStateOutput => GetFlag(14);

    /// <summary>
    /// True when Notification-Class (bit 15) is set.
    /// </summary>
    public bool NotificationClass => GetFlag(15);

    /// <summary>
    /// True when Program (bit 16) is set.
    /// </summary>
    public bool Program => GetFlag(16);

    /// <summary>
    /// True when Schedule (bit 17) is set.
    /// </summary>
    public bool Schedule => GetFlag(17);

    /// <summary>
    /// True when Averaging (bit 18) is set.
    /// </summary>
    public bool Averaging => GetFlag(18);

    /// <summary>
    /// True when Multi-State-Value (bit 19) is set.
    /// </summary>
    public bool MultiStateValue => GetFlag(19);

    /// <summary>
    /// True when Trend-Log (bit 20) is set.
    /// </summary>
    public bool TrendLog => GetFlag(20);

    /// <summary>
    /// True when Life-Safety-Point (bit 21) is set.
    /// </summary>
    public bool LifeSafetyPoint => GetFlag(21);

    /// <summary>
    /// True when Life-Safety-Zone (bit 22) is set.
    /// </summary>
    public bool LifeSafetyZone => GetFlag(22);

    /// <summary>
    /// True when Accumulator (bit 23) is set.
    /// </summary>
    public bool Accumulator => GetFlag(23);

    /// <summary>
    /// True when Pulse-Converter (bit 24) is set.
    /// </summary>
    public bool PulseConverter => GetFlag(24);

    /// <summary>
    /// True when Event-Log (bit 25) is set.
    /// </summary>
    public bool EventLog => GetFlag(25);

    /// <summary>
    /// True when Global-Group (bit 26) is set.
    /// </summary>
    public bool GlobalGroup => GetFlag(26);

    /// <summary>
    /// True when Trend-Log-Multiple (bit 27) is set.
    /// </summary>
    public bool TrendLogMultiple => GetFlag(27);

    /// <summary>
    /// True when Load-Control (bit 28) is set.
    /// </summary>
    public bool LoadControl => GetFlag(28);

    /// <summary>
    /// True when Structured-View (bit 29) is set.
    /// </summary>
    public bool StructuredView => GetFlag(29);

    /// <summary>
    /// True when Access-Door (bit 30) is set.
    /// </summary>
    public bool AccessDoor => GetFlag(30);

    /// <summary>
    /// True when Timer (bit 31) is set.
    /// </summary>
    public bool Timer => GetFlag(31);

    /// <summary>
    /// True when Access-Credential (bit 32) is set.
    /// </summary>
    public bool AccessCredential => GetFlag(32);

    /// <summary>
    /// True when Access-Point (bit 33) is set.
    /// </summary>
    public bool AccessPoint => GetFlag(33);

    /// <summary>
    /// True when Access-Rights (bit 34) is set.
    /// </summary>
    public bool AccessRights => GetFlag(34);

    /// <summary>
    /// True when Access-User (bit 35) is set.
    /// </summary>
    public bool AccessUser => GetFlag(35);

    /// <summary>
    /// True when Access-Zone (bit 36) is set.
    /// </summary>
    public bool AccessZone => GetFlag(36);

    /// <summary>
    /// True when Credential-Data-Input (bit 37) is set.
    /// </summary>
    public bool CredentialDataInput => GetFlag(37);

    /// <summary>
    /// True when Bitstring-Value (bit 39) is set.
    /// </summary>
    public bool BitstringValue => GetFlag(39);

    /// <summary>
    /// True when Characterstring-Value (bit 40) is set.
    /// </summary>
    public bool CharacterstringValue => GetFlag(40);

    /// <summary>
    /// True when Datepattern-Value (bit 41) is set.
    /// </summary>
    public bool DatepatternValue => GetFlag(41);

    /// <summary>
    /// True when Date-Value (bit 42) is set.
    /// </summary>
    public bool DateValue => GetFlag(42);

    /// <summary>
    /// True when Datetimepattern-Value (bit 43) is set.
    /// </summary>
    public bool DatetimepatternValue => GetFlag(43);

    /// <summary>
    /// True when Datetime-Value (bit 44) is set.
    /// </summary>
    public bool DatetimeValue => GetFlag(44);

    /// <summary>
    /// True when Integer-Value (bit 45) is set.
    /// </summary>
    public bool IntegerValue => GetFlag(45);

    /// <summary>
    /// True when Large-Analog-Value (bit 46) is set.
    /// </summary>
    public bool LargeAnalogValue => GetFlag(46);

    /// <summary>
    /// True when Octetstring-Value (bit 47) is set.
    /// </summary>
    public bool OctetstringValue => GetFlag(47);

    /// <summary>
    /// True when Positive-Integer-Value (bit 48) is set.
    /// </summary>
    public bool PositiveIntegerValue => GetFlag(48);

    /// <summary>
    /// True when Timepattern-Value (bit 49) is set.
    /// </summary>
    public bool TimepatternValue => GetFlag(49);

    /// <summary>
    /// True when Time-Value (bit 50) is set.
    /// </summary>
    public bool TimeValue => GetFlag(50);

    /// <summary>
    /// True when Notification-Forwarder (bit 51) is set.
    /// </summary>
    public bool NotificationForwarder => GetFlag(51);

    /// <summary>
    /// True when Alert-Enrollment (bit 52) is set.
    /// </summary>
    public bool AlertEnrollment => GetFlag(52);

    /// <summary>
    /// True when Channel (bit 53) is set.
    /// </summary>
    public bool Channel => GetFlag(53);

    /// <summary>
    /// True when Lighting-Output (bit 54) is set.
    /// </summary>
    public bool LightingOutput => GetFlag(54);

    /// <summary>
    /// True when Binary-Lighting-Output (bit 55) is set.
    /// </summary>
    public bool BinaryLightingOutput => GetFlag(55);

    /// <summary>
    /// True when Network-Port (bit 56) is set.
    /// </summary>
    public bool NetworkPort => GetFlag(56);

    /// <summary>
    /// True when Elevator-Group (bit 57) is set.
    /// </summary>
    public bool ElevatorGroup => GetFlag(57);

    /// <summary>
    /// True when Escalator (bit 58) is set.
    /// </summary>
    public bool Escalator => GetFlag(58);

    /// <summary>
    /// True when Lift (bit 59) is set.
    /// </summary>
    public bool Lift => GetFlag(59);

    /// <summary>
    /// True when Staging (bit 60) is set.
    /// </summary>
    public bool Staging => GetFlag(60);

    /// <summary>
    /// True when Audit-Log (bit 61) is set.
    /// </summary>
    public bool AuditLog => GetFlag(61);

    /// <summary>
    /// True when Audit-Reporter (bit 62) is set.
    /// </summary>
    public bool AuditReporter => GetFlag(62);

    /// <summary>
    /// True when Color (bit 63) is set.
    /// </summary>
    public bool Color => GetFlag(63);

    /// <summary>
    /// True when Color-Temperature (bit 64) is set.
    /// </summary>
    public bool ColorTemperature => GetFlag(64);

    /// <summary>
    /// Gets the number of bits used by this bit string (configured via constructor, range 17..1024).
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Gets the boolean value of the bit at the specified <paramref name="index"/>.
    /// </summary>
    /// <param name="index">Zero-based bit index: 0 = Analog-Input, (Count-1) = last bit.</param>
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
    /// The enumerator is a struct so direct iteration over a <see cref="ObjectTypesSupported"/> value does not allocate.
    /// </remarks>
    public struct Enumerator
    {
        private readonly ObjectTypesSupported _flags;
        private int _index;

        internal Enumerator(ObjectTypesSupported flags)
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