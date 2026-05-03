// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Represents errors that occur during BACnet ASDU encoding or decoding operations.
/// </summary>
public class AsduException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AsduException"/> class.
    /// </summary>
    public AsduException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AsduException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public AsduException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AsduException"/> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception.</param>
    public AsduException(string message, Exception inner)
        : base(message, inner)
    {
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the specified length does not match the expected size.
    /// </summary>
    /// <param name="length">The actual length.</param>
    /// <param name="size">The expected size.</param>
    /// <exception cref="ArgumentException">Thrown when length does not equal size.</exception>
    public static void ThrowIfLengthIsNotEqual(int length, int size)
    {
        if (length != size)
        {
            throw new ArgumentException($"The specified length of {length} does not match the expected size of {size}.", nameof(length));
        }
    }

    /*
    public static void ThrowIfNotEqual(uint length, uint size)
    {
        if (length != size)
        {
            throw new ArgumentException($"The specified length of {length} does not match the expected size of {size}.", nameof(length));
        }
    }

    public static void ThrowIfGreaterThan(uint length, uint maximum)
    {
        if (length > maximum)
        {
            throw new ArgumentException($"The specified length of {length} is greater than the expected maximum of {maximum}.", nameof(length));
        }
    }
    */
}