// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessCredentialDisable as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessCredentialDisable : ushort
{
    /// <summary>
    /// Specifies that the credential is not disabled.
    /// </summary>
    None = 0,

    /// <summary>
    /// Specifies that the credential is disabled.
    /// </summary>
    Disable = 1,

    /// <summary>
    /// Specifies that the credential is disabled manually.
    /// </summary>
    DisableManual = 2,

    /// <summary>
    /// Specifies that the credential is disabled due to lockout.
    /// </summary>
    DisableLockout = 3
}
