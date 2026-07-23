// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents BACnet bit string BACnetPriorityFilter.
/// </summary>
public readonly partial record struct PriorityFilter : IBitString
{
    /// <summary>
    /// Fixed number of bits for this type.
    /// </summary>
    public const int FixedLength = 16;

    /// <inheritdoc/>
    int IReadOnlyCollection<bool>.Count => FixedLength;

    /// <inheritdoc/>
    public int Length => FixedLength;

    /// <inheritdoc/>
    public int MinCount => FixedLength;

    /// <inheritdoc/>
    public int MaxCount => FixedLength;

    /// <summary>
    /// Gets the underlying bit container.
    /// </summary>
    public ushort Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="PriorityFilter"/> with a fixed bit length.
    /// </summary>
    /// <param name="flags">Underlying ushort bit container in LSB-first bit order.</param>
    public PriorityFilter(ushort flags)
    {
        Flags = MaskToCount(flags, FixedLength);
    }

    /// <summary>
    /// Manual life safety priority.
    /// </summary>
    public bool ManualLifeSafety => this[0];

    /// <summary>
    /// Automatic life safety priority.
    /// </summary>
    public bool AutomaticLifeSafety => this[1];

    /// <summary>
    /// Priority 3.
    /// </summary>
    public bool Priority3 => this[2];

    /// <summary>
    /// Priority 4.
    /// </summary>
    public bool Priority4 => this[3];

    /// <summary>
    /// Critical equipment controls priority.
    /// </summary>
    public bool CriticalEquipmentControls => this[4];

    /// <summary>
    /// Minimum on/off priority.
    /// </summary>
    public bool MinimumOnOff => this[5];

    /// <summary>
    /// Priority 7.
    /// </summary>
    public bool Priority7 => this[6];

    /// <summary>
    /// Manual operator priority.
    /// </summary>
    public bool ManualOperator => this[7];

    /// <summary>
    /// Priority 9.
    /// </summary>
    public bool Priority9 => this[8];

    /// <summary>
    /// Priority 10.
    /// </summary>
    public bool Priority10 => this[9];

    /// <summary>
    /// Priority 11.
    /// </summary>
    public bool Priority11 => this[10];

    /// <summary>
    /// Priority 12.
    /// </summary>
    public bool Priority12 => this[11];

    /// <summary>
    /// Priority 13.
    /// </summary>
    public bool Priority13 => this[12];

    /// <summary>
    /// Priority 14.
    /// </summary>
    public bool Priority14 => this[13];

    /// <summary>
    /// Priority 15.
    /// </summary>
    public bool Priority15 => this[14];

    /// <summary>
    /// Priority 16.
    /// </summary>
    public bool Priority16 => this[15];

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
            return (Flags & (1 << index)) != 0;
        }
    }

    /// <summary>
    /// Clears all bits above the provided bit count and returns the normalized value.
    /// </summary>
    /// <param name="flags">Input bit container.</param>
    /// <param name="count">Number of valid low-order bits to preserve.</param>
    /// <returns>Masked flag value containing only the valid bits.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is outside the supported bit range for this storage type.</exception>
    private static ushort MaskToCount(ushort flags, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count, nameof(count));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(count, 16, nameof(count));

        if (count == 0) return 0;
        if (count >= 16) return flags;
        ushort mask = (ushort)((1u << count) - 1u);
        return (ushort)(flags & mask);
    }
}

