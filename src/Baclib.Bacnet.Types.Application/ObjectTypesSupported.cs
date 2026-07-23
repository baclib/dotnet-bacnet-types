// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents BACnet bit string BACnetObjectTypesSupported.
/// </summary>
public readonly partial record struct ObjectTypesSupported : IBitString
{
    /// <summary>
    /// Minimum permitted number of bits.
    /// </summary>
    public const int MinLength = 18;

    /// <summary>
    /// Maximum permitted number of bits.
    /// </summary>
    public const int MaxLength = 1024;

    private readonly ushort _count;

    /// <inheritdoc/>
    int IReadOnlyCollection<bool>.Count => _count;

    /// <inheritdoc/>
    public int Length => _count;

    /// <inheritdoc/>
    public int MinCount => MinLength;

    /// <inheritdoc/>
    public int MaxCount => MaxLength;

    /// <summary>
    /// Gets the underlying bit container.
    /// </summary>
    public byte[] Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ObjectTypesSupported"/> with a variable number of bits.
    /// </summary>
    /// <param name="flags">Bit payload bytes in LSB-first bit order.</param>
    /// <param name="count">Number of valid bits in <paramref name="flags"/>. Valid range is <see cref="MinLength"/> to <see cref="MaxLength"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="flags"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is out of range, or when <paramref name="flags"/> is shorter than required for <paramref name="count"/>.</exception>
    public ObjectTypesSupported(byte[] flags, ushort count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan((int)count, MinLength, nameof(count));
        if (MaxLength != int.MaxValue)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan((int)count, MaxLength, nameof(count));
        }

        int requiredBytes = GetRequiredByteCount((int)count);
        ArgumentNullException.ThrowIfNull(flags, nameof(flags));
        ArgumentOutOfRangeException.ThrowIfLessThan(flags.Length, requiredBytes, nameof(flags));

        _count = count;
        Flags = new byte[requiredBytes];
        Array.Copy(flags, Flags, requiredBytes);
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
    /// Gets whether the bit at the specified zero-based index is set.
    /// </summary>
    /// <param name="index">Zero-based bit index.</param>
    /// <returns><see langword="true"/> when the bit is set; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is outside the range <c>0..Count-1</c>.</exception>
    public bool this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length, nameof(index));

            int byteIndex = index / 8;
            int bitOffset = index % 8;
            return (Flags[byteIndex] & (1 << bitOffset)) != 0;
        }
    }

    /// <summary>
    /// Calculates the minimum number of bytes required to store the specified number of bits.
    /// </summary>
    /// <param name="bitCount">Bit count to convert to a byte count.</param>
    /// <returns>Required byte count.</returns>
    private static int GetRequiredByteCount(int bitCount)
    {
        if (bitCount <= 0)
        {
            return 0;
        }

        return (bitCount + 7) / 8;
    }
}

