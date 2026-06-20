// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System;
using System.Drawing;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Exception thrown when there is not enough data available to complete a binary read or write operation.
/// </summary>
public class InsufficientDataException : Exception
{
    public InsufficientDataException()
    {
    }

    public InsufficientDataException(string message)
        : base(message)
    {
    }

    public InsufficientDataException(string message, Exception innerException)
        : base(message, innerException)
    {
    }


    public static void ThrowIfGreaterThan(int requiredSize, int actualSize)
    {
        if (requiredSize > actualSize)
        {
            int missing = requiredSize - actualSize;
            throw new InsufficientDataException($"Insufficient data: {missing} byte(s) missing. Required: {requiredSize}, Available: {actualSize}.");
        }
    }


    public static void ThrowIfLessThan(int requiredSize, int actualSize)
    {
        if (actualSize < requiredSize)
        {
            int missing = requiredSize - actualSize;
            throw new InsufficientDataException($"Insufficient data: {missing} byte(s) missing. Required: {requiredSize}, Available: {actualSize}.");
        }
    }
}
