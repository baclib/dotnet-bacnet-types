namespace Baclib.Bacnet.Types.Application;

public readonly partial record struct BitString
{
    /// <summary>
    /// Initializes a new instance from BACnet-encoded bit string payload bytes.
    /// The payload format is: [unusedBits, data0, data1, ...].
    /// </summary>
    /// <param name="encodedValue">Encoded bit string payload bytes.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when payload is malformed.</exception>
    public BitString(ReadOnlySpan<byte> encodedValue)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(encodedValue.Length, 1, nameof(encodedValue));

        byte unusedBits = encodedValue[0];
        int dataLength = encodedValue.Length - 1;
        if (dataLength == 0)
        {
            if (unusedBits != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(encodedValue), "Unused bits must be zero when payload has no data bytes.");
            }

            _count = 0;
            Flags = [];
            return;
        }

        ArgumentOutOfRangeException.ThrowIfGreaterThan((int)unusedBits, 7, nameof(encodedValue));

        int bitCount = checked(dataLength * 8 - unusedBits);
        ArgumentOutOfRangeException.ThrowIfNegative(bitCount, nameof(encodedValue));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, ushort.MaxValue, nameof(encodedValue));

        var flags = new byte[dataLength];
        for (int i = 0; i < dataLength; i++)
        {
            flags[i] = ReverseBits(encodedValue[i + 1]);
        }

        int remainder = bitCount & 7;
        if (remainder != 0)
        {
            byte mask = (byte)((1 << remainder) - 1);
            flags[^1] = (byte)(flags[^1] & mask);
        }

        _count = (ushort)bitCount;
        Flags = flags;
    }

    /// <summary>
    /// Writes this value as BACnet bit string payload bytes to destination.
    /// The payload format is: [unusedBits, data0, data1, ...].
    /// </summary>
    /// <param name="destination">Destination span with enough capacity.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when destination is too small.</exception>
    public void CopyTo(Span<byte> destination)
    {
        int requiredBytes = GetRequiredByteCount(_count);
        int payloadLength = requiredBytes + 1;
        ArgumentOutOfRangeException.ThrowIfLessThan(destination.Length, payloadLength, nameof(destination));

        byte unusedBits = (byte)((8 - (_count & 7)) & 7);
        destination[0] = unusedBits;

        for (int i = 0; i < requiredBytes; i++)
        {
            destination[i + 1] = ReverseBits(Flags[i]);
        }
    }

    private static byte ReverseBits(byte value)
    {
        value = (byte)(((value & 0xF0) >> 4) | ((value & 0x0F) << 4));
        value = (byte)(((value & 0xCC) >> 2) | ((value & 0x33) << 2));
        value = (byte)(((value & 0xAA) >> 1) | ((value & 0x55) << 1));
        return value;
    }
}
