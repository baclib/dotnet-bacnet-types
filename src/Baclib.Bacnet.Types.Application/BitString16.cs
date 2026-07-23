// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents BACnet bit string BitString16.
/// </summary>
public readonly partial record struct BitString16 : IBitString
{
    /// <summary>
    /// Minimum permitted number of bits.
    /// </summary>
    public const int MinLength = 0;

    /// <summary>
    /// Maximum permitted number of bits.
    /// </summary>
    public const int MaxLength = 16;

    private readonly byte _count;

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
    public ushort Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="BitString16"/> with a variable number of bits.
    /// </summary>
    /// <param name="flags">Underlying ushort bit container in LSB-first bit order.</param>
    /// <param name="count">Number of valid bits in <paramref name="flags"/>. Valid range is <see cref="MinLength"/> to <see cref="MaxLength"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is out of range.</exception>
    public BitString16(ushort flags, byte count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan((int)count, MinLength, nameof(count));
        if (MaxLength != int.MaxValue)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan((int)count, MaxLength, nameof(count));
        }

        _count = count;
        Flags = MaskToCount(flags, (int)count);
    }

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

