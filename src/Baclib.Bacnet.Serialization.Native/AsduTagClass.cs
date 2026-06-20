// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Specifies the BACnet ASDU tag class for an ASN.1-encoded BACnet value.
/// </summary>
public enum AsduTagClass : byte
{
    /// <summary>
    /// Indicates an application tag class, used for standard BACnet data types.
    /// </summary>
    Application = 0,

    /// <summary>
    /// Indicates a context-specific tag class, used for context-dependent encoding.
    /// </summary>
    Context = 8
}

