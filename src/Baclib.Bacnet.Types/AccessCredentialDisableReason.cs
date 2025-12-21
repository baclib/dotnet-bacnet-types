// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessCredentialDisableReason as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessCredentialDisableReason : ushort
{
    /// <summary>
    /// Specifies that the credential is disabled.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// Specifies that the credential is disabled and needs provisioning.
    /// </summary>
    DisabledNeedsProvisioning = 1,

    /// <summary>
    /// Specifies that the credential is disabled and unassigned.
    /// </summary>
    DisabledUnassigned = 2,

    /// <summary>
    /// Specifies that the credential is disabled and not yet active.
    /// </summary>
    DisabledNotYetActive = 3,

    /// <summary>
    /// Specifies that the credential is disabled due to expiration.
    /// </summary>
    DisabledExpired = 4,

    /// <summary>
    /// Specifies that the credential is disabled due to lockout.
    /// </summary>
    DisabledLockout = 5,

    /// <summary>
    /// Specifies that the credential is disabled due to exceeding maximum days.
    /// </summary>
    DisabledMaxDays = 6,

    /// <summary>
    /// Specifies that the credential is disabled due to exceeding maximum uses.
    /// </summary>
    DisabledMaxUses = 7,

    /// <summary>
    /// Specifies that the credential is disabled due to inactivity.
    /// </summary>
    DisabledInactivity = 8,

    /// <summary>
    /// Specifies that the credential is disabled manually.
    /// </summary>
    DisabledManual = 9
}
