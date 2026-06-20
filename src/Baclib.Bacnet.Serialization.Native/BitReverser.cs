// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides static methods for reversing the bit order of 8, 16, 32, and 64-bit unsigned integers.
/// Uses a lookup table for efficient bit reversal of bytes.
/// </summary>
public static class BitReverser
{
    /// <summary>
    /// Lookup table for bit-reversed values of all 256 possible bytes.
    /// </summary>
    private static readonly byte[] _reverseLookup = BuildReverseLookup();

    /// <summary>
    /// Builds the lookup table for bit-reversed bytes.
    /// </summary>
    /// <returns>A byte array where each index contains the bit-reversed value of that index.</returns>
    private static byte[] BuildReverseLookup()
    {
        var table = new byte[256];
        for (int outerIndex = 0; outerIndex < 256; outerIndex++)
        {
            byte originalByte = (byte)outerIndex;
            byte reversedByte = 0;
            for (int innerIndex = 0; innerIndex < 8; innerIndex++)
            {
                reversedByte = (byte)((reversedByte << 1) | (originalByte & 1));
                originalByte >>= 1;
            }
            table[outerIndex] = reversedByte;
        }
        return table;
    }

    /// <summary>
    /// Reverses the bit order of an 8-bit unsigned integer.
    /// </summary>
    /// <param name="value">The byte value to reverse.</param>
    /// <returns>The bit-reversed byte.</returns>
    public static byte Reverse8Bits(byte value)
    {
        return _reverseLookup[value];
    }

    /// <summary>
    /// Reverses the bit order of a 16-bit unsigned integer.
    /// </summary>
    /// <param name="value">The ushort value to reverse.</param>
    /// <returns>The bit-reversed ushort.</returns>
    public static ushort Reverse16Bits(ushort value)
    {
        byte originalByte0 = (byte)(value & 0xFF);
        byte originalByte1 = (byte)((value >> 8) & 0xFF);

        ushort reversedByte0 = _reverseLookup[originalByte0];
        ushort reversedByte1 = _reverseLookup[originalByte1];

        return (ushort)((reversedByte0 << 8) | reversedByte1);
    }

    /// <summary>
    /// Reverses the bit order of a 32-bit unsigned integer.
    /// </summary>
    /// <param name="value">The uint value to reverse.</param>
    /// <returns>The bit-reversed uint.</returns>
    public static uint Reverse32Bits(uint value)
    {
        byte originalByte0 = (byte)(value & 0xFF);
        byte originalByte1 = (byte)((value >> 8) & 0xFF);
        byte originalByte2 = (byte)((value >> 16) & 0xFF);
        byte originalByte3 = (byte)((value >> 24) & 0xFF);

        uint reversedByte0 = _reverseLookup[originalByte0];
        uint reversedByte1 = _reverseLookup[originalByte1];
        uint reversedByte2 = _reverseLookup[originalByte2];
        uint reversedByte3 = _reverseLookup[originalByte3];

        return (reversedByte0 << 24) | (reversedByte1 << 16) | (reversedByte2 << 8) | (reversedByte3 << 0);
    }

    /// <summary>
    /// Reverses the bit order of a 64-bit unsigned integer.
    /// </summary>
    /// <param name="value">The ulong value to reverse.</param>
    /// <returns>The bit-reversed ulong.</returns>
    public static ulong Reverse64Bits(ulong value)
    {
        byte originalByte0 = (byte)(value & 0xFF);
        byte originalByte1 = (byte)((value >> 8) & 0xFF);
        byte originalByte2 = (byte)((value >> 16) & 0xFF);
        byte originalByte3 = (byte)((value >> 24) & 0xFF);
        byte originalByte4 = (byte)((value >> 32) & 0xFF);
        byte originalByte5 = (byte)((value >> 40) & 0xFF);
        byte originalByte6 = (byte)((value >> 48) & 0xFF);
        byte originalByte7 = (byte)((value >> 56) & 0xFF);

        ulong reversedByte0 = _reverseLookup[originalByte0];
        ulong reversedByte1 = _reverseLookup[originalByte1];
        ulong reversedByte2 = _reverseLookup[originalByte2];
        ulong reversedByte3 = _reverseLookup[originalByte3];
        ulong reversedByte4 = _reverseLookup[originalByte4];
        ulong reversedByte5 = _reverseLookup[originalByte5];
        ulong reversedByte6 = _reverseLookup[originalByte6];
        ulong reversedByte7 = _reverseLookup[originalByte7];

        return (reversedByte0 << 56) | (reversedByte1 << 48) | (reversedByte2 << 40) | (reversedByte3 << 32) |
               (reversedByte4 << 24) | (reversedByte5 << 16) | (reversedByte6 << 8) | (reversedByte7 << 0);
    }
}
