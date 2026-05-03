// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Specifies the kind of BACnet ASN.1 tag used in APDU encoding.
/// </summary>
public enum AsduTagKind
{
    /// <summary>
    /// Primitive tag: used for simple, non-constructed values.
    /// </summary>
    Primitive = 0,

    /// <summary>
    /// Context tag: used for context-specific encoding.
    /// </summary>
    Context = 0x800,

    /// <summary>
    /// Opening tag: marks the start of a constructed value.
    /// </summary>
    Opening = 0xE00,

    /// <summary>
    /// Closing tag: marks the end of a constructed value.
    /// </summary>
    Closing = 0xF00
}



public enum AsduTagTrait
{
    Application = 0x00,
    ContextSpecific = 0x08,
    False = 0x10,
    True = 0x11,
    Opening = 0xE0,
    Closing = 0xF0
}