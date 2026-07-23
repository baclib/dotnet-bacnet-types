// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents BACnet bit string BACnetLogStatus.
/// </summary>
public readonly partial record struct LogStatus : IBitString
{
    /// <summary>
    /// Fixed number of bits for this type.
    /// </summary>
    public const int FixedLength = 3;

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
    public byte Flags { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="LogStatus"/> with a fixed bit length.
    /// </summary>
    /// <param name="flags">Underlying byte bit container in LSB-first bit order.</param>
    public LogStatus(byte flags)
    {
        Flags = MaskToCount(flags, FixedLength);
    }

    /// <summary>
    /// Log is disabled.
    /// </summary>
    public bool LogDisabled => this[0];

    /// <summary>
    /// Log buffer has been purged.
    /// </summary>
    public bool BufferPurged => this[1];

    /// <summary>
    /// Log was interrupted.
    /// </summary>
    public bool LogInterrupted => this[2];

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
    private static byte MaskToCount(byte flags, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count, nameof(count));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(count, 8, nameof(count));

        if (count == 0) return 0;
        if (count >= 8) return flags;
        byte mask = (byte)((1 << count) - 1);
        return (byte)(flags & mask);
    }
}

