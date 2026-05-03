// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Exception thrown when a binary read or write operation fails.
/// </summary>
public class BinaryException : Exception
{
    public BinaryException()
    {
    }

    public BinaryException(string message) : base(message)
    {
    }

    public BinaryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Throws a <see cref="BinaryException"/> if the value is negative.
    /// </summary>
    public static void ThrowIfNegative(int value, string paramName)
    {
        if (value < 0)
        {
            throw new BinaryException($"{paramName} must be non-negative.");
        }
    }

    /// <summary>
    /// Throws a <see cref="BinaryException"/> if insufficient data is available.
    /// </summary>
    /// <param name="position">The current position in the buffer.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="available">The total size/length of the buffer.</param>
    public static void ThrowIfInsufficientData(int position, int count, int available)
    {
        if (position + count > available)
        {
            int remaining = available - position;
            throw new BinaryException($"Attempted to read {count} byte(s) but only {remaining} byte(s) remaining.");
        }
    }

    internal static void ThrowIfGreaterThan(byte unusedBits, int v1, string v2)
    {
        throw new NotImplementedException();
    }
}
