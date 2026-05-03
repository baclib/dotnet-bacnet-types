// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Represents the BACnet ASDU tag type, indicating whether the tag is an opening or closing tag.
/// Used for BACnet constructed data structures that require explicit start (opening) and end (closing) tags.
/// </summary>
public enum AsduTagType
{
    None = 0x0,

    /// <summary>
    /// Indicates an opening tag in a BACnet ASDU.
    /// </summary>
    Opening = 0xE,

    /// <summary>
    /// Indicates a closing tag in a BACnet ASDU.
    /// </summary>
    Closing = 0xF
}
