// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Serialization.Native;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Represents a BACnet ASN.1 tag number, as used in BACnet protocol encoding.
/// This struct provides type safety and convenient constants for all standard BACnet application tag numbers
/// (see ANSI/ASHRAE 135-2020, Clause 21.2.2).
/// </summary>
public readonly record struct AsduTagNumber(byte Value)
{
    /// <summary>
    /// Initializes a new <see cref="AsduTagNumber"/> from an <see cref="ApplicationTagNumber"/> value.
    /// </summary>
    /// <param name="value">The BACnet application tag number.</param>
    public AsduTagNumber(ApplicationTagNumber value):
        this((byte)value)
    {
    }

    /// <summary>Tag number for BACnet Null (0).</summary>
    public static readonly AsduTagNumber ApplicationNull = new(ApplicationTagNumber.Null);

    /// <summary>Tag number for BACnet Boolean (1).</summary>
    public static readonly AsduTagNumber ApplicationBoolean = new(ApplicationTagNumber.Boolean);

    /// <summary>Tag number for BACnet Unsigned Integer (2).</summary>
    public static readonly AsduTagNumber ApplicationUnsigned = new(ApplicationTagNumber.Unsigned);

    /// <summary>Tag number for BACnet Signed Integer (3).</summary>
    public static readonly AsduTagNumber ApplicationSigned = new(ApplicationTagNumber.Signed);

    /// <summary>Tag number for BACnet Real (4).</summary>
    public static readonly AsduTagNumber ApplicationReal = new(ApplicationTagNumber.Real);

    /// <summary>Tag number for BACnet Double (5).</summary>
    public static readonly AsduTagNumber ApplicationDouble = new(ApplicationTagNumber.Double);

    /// <summary>Tag number for BACnet Octet String (6).</summary>
    public static readonly AsduTagNumber ApplicationOctetString = new(ApplicationTagNumber.OctetString);

    /// <summary>Tag number for BACnet Character String (7).</summary>
    public static readonly AsduTagNumber ApplicationCharacterString = new(ApplicationTagNumber.CharacterString);

    /// <summary>Tag number for BACnet Bit String (8).</summary>
    public static readonly AsduTagNumber ApplicationBitString = new(ApplicationTagNumber.BitString);

    /// <summary>Tag number for BACnet Enumerated (9).</summary>
    public static readonly AsduTagNumber ApplicationEnumerated = new(ApplicationTagNumber.Enumerated);

    /// <summary>Tag number for BACnet Date (10).</summary>
    public static readonly AsduTagNumber ApplicationDate = new(ApplicationTagNumber.DatePattern);

    /// <summary>Tag number for BACnet Time (11).</summary>
    public static readonly AsduTagNumber ApplicationTime = new(ApplicationTagNumber.TimePattern);

    /// <summary>Tag number for BACnet Object Identifier (12).</summary>
    public static readonly AsduTagNumber ApplicationObjectIdentifier = new(ApplicationTagNumber.ObjectIdentifier);

    /// <summary>
    /// Reserved tag number for proprietary or undefined use (255).
    /// </summary>
    public static readonly AsduTagNumber AshraeReserved = new(byte.MaxValue);

    /// <summary>
    /// Implicit conversion from <see cref="AsduTagNumber"/> to <see cref="byte"/>.
    /// </summary>
    public static implicit operator byte(AsduTagNumber tagNumber) => tagNumber.Value;

    /// <summary>
    /// Implicit conversion from <see cref="byte"/> to <see cref="AsduTagNumber"/>.
    /// </summary>
    public static implicit operator AsduTagNumber(byte value) => new(value);

    /// <summary>
    /// Returns the string representation of the tag number value.
    /// </summary>
    public override string ToString() => Value.ToString();
}

