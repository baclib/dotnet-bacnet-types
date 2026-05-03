// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Enumerates BACnet application tag numbers as defined in the BACnet standard (see ANSI/ASHRAE 135-2020, Clause 21.2.2).
/// These tag numbers are used to identify the type of application data in BACnet ASN.1 encoding.
/// </summary>
public enum ApplicationTagNumber : byte
{
    /// <summary>
    /// Null value (tag number 0).
    /// </summary>
    Null = 0,

    /// <summary>
    /// Boolean value (tag number 1).
    /// </summary>
    Boolean = 1,

    /// <summary>
    /// Unsigned integer value (tag number 2).
    /// </summary>
    Unsigned = 2,

    /// <summary>
    /// Signed integer value (tag number 3).
    /// </summary>
    Signed = 3,

    /// <summary>
    /// Real (single-precision floating point) value (tag number 4).
    /// </summary>
    Real = 4,

    /// <summary>
    /// Double (double-precision floating point) value (tag number 5).
    /// </summary>
    Double = 5,

    /// <summary>
    /// Octet string value (tag number 6).
    /// </summary>
    OctetString = 6,

    /// <summary>
    /// Character string value (tag number 7).
    /// </summary>
    CharacterString = 7,

    /// <summary>
    /// Bit string value (tag number 8).
    /// </summary>
    BitString = 8,

    /// <summary>
    /// Enumerated value (tag number 9).
    /// </summary>
    Enumerated = 9,

    /// <summary>
    /// Date value (tag number 10).
    /// </summary>
    Date = 10,

    /// <summary>
    /// Time value (tag number 11).
    /// </summary>
    Time = 11,

    /// <summary>
    /// Object identifier value (tag number 12).
    /// </summary>
    ObjectIdentifier = 12
}
