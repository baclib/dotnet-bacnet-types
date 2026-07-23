// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents BACnet bit string BitString.
/// </summary>
public readonly partial record struct BitString : IBitString
{
    /// <summary>
    /// Minimum permitted number of bits.
    /// </summary>
    public const int MinLength = 0;

    /// <summary>
    /// Maximum permitted number of bits.
    /// </summary>
    public const int MaxLength = int.MaxValue;

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
    /// Initializes a new instance of <see cref="BitString"/> with a variable number of bits.
    /// </summary>
    /// <param name="flags">Bit payload bytes in LSB-first bit order.</param>
    /// <param name="count">Number of valid bits in <paramref name="flags"/>. Valid range is <see cref="MinLength"/> to <see cref="MaxLength"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="flags"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is out of range, or when <paramref name="flags"/> is shorter than required for <paramref name="count"/>.</exception>
    public BitString(byte[] flags, ushort count)
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

