// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetReliability as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum Reliability : ushort
{
    /// <summary>
    /// No fault detected.
    /// </summary>
    NoFaultDetected = 0,

    /// <summary>
    /// No sensor present.
    /// </summary>
    NoSensor = 1,

    /// <summary>
    /// Value is over range.
    /// </summary>
    OverRange = 2,

    /// <summary>
    /// Value is under range.
    /// </summary>
    UnderRange = 3,

    /// <summary>
    /// Open loop detected.
    /// </summary>
    OpenLoop = 4,

    /// <summary>
    /// Shorted loop detected.
    /// </summary>
    ShortedLoop = 5,

    /// <summary>
    /// No output detected.
    /// </summary>
    NoOutput = 6,

    /// <summary>
    /// Other unreliable condition.
    /// </summary>
    UnreliableOther = 7,

    /// <summary>
    /// Process error detected.
    /// </summary>
    ProcessError = 8,

    /// <summary>
    /// Multi-state fault detected.
    /// </summary>
    MultiStateFault = 9,

    /// <summary>
    /// Configuration error detected.
    /// </summary>
    ConfigurationError = 10,

    /// <summary>
    /// Communication failure detected.
    /// </summary>
    CommunicationFailure = 12,

    /// <summary>
    /// Member fault detected.
    /// </summary>
    MemberFault = 13,

    /// <summary>
    /// Monitored object fault detected.
    /// </summary>
    MonitoredObjectFault = 14,

    /// <summary>
    /// Tripped condition detected.
    /// </summary>
    Tripped = 15,

    /// <summary>
    /// Lamp failure detected.
    /// </summary>
    LampFailure = 16,

    /// <summary>
    /// Activation failure detected.
    /// </summary>
    ActivationFailure = 17,

    /// <summary>
    /// Renew DHCP failure detected.
    /// </summary>
    RenewDhcpFailure = 18,

    /// <summary>
    /// Renew FD registration failure detected.
    /// </summary>
    RenewFdRegistrationFailure = 19,

    /// <summary>
    /// Restart auto-negotiation failure detected.
    /// </summary>
    RestartAutoNegotiationFailure = 20,

    /// <summary>
    /// Restart failure detected.
    /// </summary>
    RestartFailure = 21,

    /// <summary>
    /// Proprietary command failure detected.
    /// </summary>
    ProprietaryCommandFailure = 22,

    /// <summary>
    /// Faults listed.
    /// </summary>
    FaultsListed = 23,

    /// <summary>
    /// Referenced object fault detected.
    /// </summary>
    ReferencedObjectFault = 24,

    /// <summary>
    /// Multi-state out of range.
    /// </summary>
    MultiStateOutOfRange = 25
}
