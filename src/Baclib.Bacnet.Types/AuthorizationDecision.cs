// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthorizationDecision as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthorizationDecision : byte
{
    /// <summary>
    /// Authorization allowed by token.
    /// </summary>
    AllowByToken = 0,

    /// <summary>
    /// Authorization allowed by local policy.
    /// </summary>
    AllowByLocalPolicy = 1,

    /// <summary>
    /// Authorization denied: no token or policy.
    /// </summary>
    DenyNoTokenOrPolicy = 2,

    /// <summary>
    /// Authorization denied: not before time.
    /// </summary>
    DenyNotBefore = 3,

    /// <summary>
    /// Authorization denied: not after time.
    /// </summary>
    DenyNotAfter = 4,

    /// <summary>
    /// Authorization denied: target device.
    /// </summary>
    DenyTargetDevice = 5,

    /// <summary>
    /// Authorization denied: target group.
    /// </summary>
    DenyTargetGroup = 6,

    /// <summary>
    /// Authorization denied: client device.
    /// </summary>
    DenyClientDevice = 7,

    /// <summary>
    /// Authorization denied: client method.
    /// </summary>
    DenyClientMethod = 8,

    /// <summary>
    /// Authorization denied: scope.
    /// </summary>
    DenyScope = 9,

    /// <summary>
    /// Authorization denied: issuer.
    /// </summary>
    DenyIssuer = 10,

    /// <summary>
    /// Authorization denied: revoked.
    /// </summary>
    DenyRevoked = 11,

    /// <summary>
    /// Authorization denied: signature.
    /// </summary>
    DenySignature = 12,

    /// <summary>
    /// Authorization denied: other reason.
    /// </summary>
    DenyOther = 13
}
