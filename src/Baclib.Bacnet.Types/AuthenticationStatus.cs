// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthenticationStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthenticationStatus : byte
{
    /// <summary>
    /// Authentication is not ready.
    /// </summary>
    NotReady = 0,

    /// <summary>
    /// Authentication is ready.
    /// </summary>
    Ready = 1,

    /// <summary>
    /// Authentication is disabled.
    /// </summary>
    Disabled = 2,

    /// <summary>
    /// Waiting for authentication factor.
    /// </summary>
    WaitingForAuthenticationFactor = 3,

    /// <summary>
    /// Waiting for accompaniment.
    /// </summary>
    WaitingForAccompaniment = 4,

    /// <summary>
    /// Waiting for verification.
    /// </summary>
    WaitingForVerification = 5,

    /// <summary>
    /// Authentication is in progress.
    /// </summary>
    InProgress = 6
}
