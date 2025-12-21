// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessEvent as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessEvent : ushort
{
    /// <summary>
    /// No access event.
    /// </summary>
    None = 0,

    /// <summary>
    /// Access granted event.
    /// </summary>
    Granted = 1,

    /// <summary>
    /// Muster event.
    /// </summary>
    Muster = 2,

    /// <summary>
    /// Passback detected event.
    /// </summary>
    PassbackDetected = 3,

    /// <summary>
    /// Duress event.
    /// </summary>
    Duress = 4,

    /// <summary>
    /// Trace event.
    /// </summary>
    Trace = 5,

    /// <summary>
    /// Lockout due to maximum attempts event.
    /// </summary>
    LockoutMaxAttempts = 6,

    /// <summary>
    /// Lockout due to other reasons event.
    /// </summary>
    LockoutOther = 7,

    /// <summary>
    /// Lockout relinquished event.
    /// </summary>
    LockoutRelinquished = 8,

    /// <summary>
    /// Locked by higher priority event.
    /// </summary>
    LockedByHigherPriority = 9,

    /// <summary>
    /// Out of service event.
    /// </summary>
    OutOfService = 10,

    /// <summary>
    /// Out of service relinquished event.
    /// </summary>
    OutOfServiceRelinquished = 11,

    /// <summary>
    /// Accompaniment by event.
    /// </summary>
    AccompanimentBy = 12,

    /// <summary>
    /// Authentication factor read event.
    /// </summary>
    AuthenticationFactorRead = 13,

    /// <summary>
    /// Authorization delayed event.
    /// </summary>
    AuthorizationDelayed = 14,

    /// <summary>
    /// Verification required event.
    /// </summary>
    VerificationRequired = 15,

    /// <summary>
    /// No entry after granted event.
    /// </summary>
    NoEntryAfterGranted = 16,

    /// <summary>
    /// Access denied: deny all.
    /// </summary>
    DeniedDenyAll = 128,

    /// <summary>
    /// Access denied: unknown credential.
    /// </summary>
    DeniedUnknownCredential = 129,

    /// <summary>
    /// Access denied: authentication unavailable.
    /// </summary>
    DeniedAuthenticationUnavailable = 130,

    /// <summary>
    /// Access denied: authentication factor timeout.
    /// </summary>
    DeniedAuthenticationFactorTimeout = 131,

    /// <summary>
    /// Access denied: incorrect authentication factor.
    /// </summary>
    DeniedIncorrectAuthenticationFactor = 132,

    /// <summary>
    /// Access denied: zone no access rights.
    /// </summary>
    DeniedZoneNoAccessRights = 133,

    /// <summary>
    /// Access denied: point no access rights.
    /// </summary>
    DeniedPointNoAccessRights = 134,

    /// <summary>
    /// Access denied: no access rights.
    /// </summary>
    DeniedNoAccessRights = 135,

    /// <summary>
    /// Access denied: out of time range.
    /// </summary>
    DeniedOutOfTimeRange = 136,

    /// <summary>
    /// Access denied: threat level.
    /// </summary>
    DeniedThreatLevel = 137,

    /// <summary>
    /// Access denied: passback.
    /// </summary>
    DeniedPassback = 138,

    /// <summary>
    /// Access denied: unexpected location usage.
    /// </summary>
    DeniedUnexpectedLocationUsage = 139,

    /// <summary>
    /// Access denied: maximum attempts.
    /// </summary>
    DeniedMaxAttempts = 140,

    /// <summary>
    /// Access denied: lower occupancy limit.
    /// </summary>
    DeniedLowerOccupancyLimit = 141,

    /// <summary>
    /// Access denied: upper occupancy limit.
    /// </summary>
    DeniedUpperOccupancyLimit = 142,

    /// <summary>
    /// Access denied: authentication factor lost.
    /// </summary>
    DeniedAuthenticationFactorLost = 143,

    /// <summary>
    /// Access denied: authentication factor stolen.
    /// </summary>
    DeniedAuthenticationFactorStolen = 144,

    /// <summary>
    /// Access denied: authentication factor damaged.
    /// </summary>
    DeniedAuthenticationFactorDamaged = 145,

    /// <summary>
    /// Access denied: authentication factor destroyed.
    /// </summary>
    DeniedAuthenticationFactorDestroyed = 146,

    /// <summary>
    /// Access denied: authentication factor disabled.
    /// </summary>
    DeniedAuthenticationFactorDisabled = 147,

    /// <summary>
    /// Access denied: authentication factor error.
    /// </summary>
    DeniedAuthenticationFactorError = 148,

    /// <summary>
    /// Access denied: credential unassigned.
    /// </summary>
    DeniedCredentialUnassigned = 149,

    /// <summary>
    /// Access denied: credential not provisioned.
    /// </summary>
    DeniedCredentialNotProvisioned = 150,

    /// <summary>
    /// Access denied: credential not yet active.
    /// </summary>
    DeniedCredentialNotYetActive = 151,

    /// <summary>
    /// Access denied: credential expired.
    /// </summary>
    DeniedCredentialExpired = 152,

    /// <summary>
    /// Access denied: credential manually disabled.
    /// </summary>
    DeniedCredentialManualDisable = 153,

    /// <summary>
    /// Access denied: credential lockout.
    /// </summary>
    DeniedCredentialLockout = 154,

    /// <summary>
    /// Access denied: credential max days exceeded.
    /// </summary>
    DeniedCredentialMaxDays = 155,

    /// <summary>
    /// Access denied: credential max uses exceeded.
    /// </summary>
    DeniedCredentialMaxUses = 156,

    /// <summary>
    /// Access denied: credential inactivity.
    /// </summary>
    DeniedCredentialInactivity = 157,

    /// <summary>
    /// Access denied: credential disabled.
    /// </summary>
    DeniedCredentialDisabled = 158,

    /// <summary>
    /// Access denied: no accompaniment.
    /// </summary>
    DeniedNoAccompaniment = 159,

    /// <summary>
    /// Access denied: incorrect accompaniment.
    /// </summary>
    DeniedIncorrectAccompaniment = 160,

    /// <summary>
    /// Access denied: lockout.
    /// </summary>
    DeniedLockout = 161,

    /// <summary>
    /// Access denied: verification failed.
    /// </summary>
    DeniedVerificationFailed = 162,

    /// <summary>
    /// Access denied: verification timeout.
    /// </summary>
    DeniedVerificationTimeout = 163,

    /// <summary>
    /// Access denied: other reason.
    /// </summary>
    DeniedOther = 164
}
