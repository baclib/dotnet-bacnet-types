// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Represents a BACnet ASDU tag with its associated data length.
/// </summary>
/// <remarks>
/// An ASDU tag consists of a tag number (identifying the data type or context)
/// and a length (indicating the size of the associated data in bytes).
/// </remarks>
public readonly struct AsduTagOld(AsduTagNumberOld number, int length)
{
    /// <summary>
    /// Gets the tag number identifying the data type or context.
    /// </summary>
    public AsduTagNumberOld Number => number;

    /// <summary>
    /// Gets the length of the associated data in bytes.
    /// </summary>
    public int Length => length;

    /// <summary>
    /// Gets the total size of the tag including tag header and data length.
    /// </summary>
    public int Size => length + number.Size;
}