// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLifeSafetyState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LifeSafetyState : ushort
{
    /// <summary>
    /// Quiet state.
    /// </summary>
    Quiet = 0,

    /// <summary>
    /// Pre-alarm state.
    /// </summary>
    PreAlarm = 1,

    /// <summary>
    /// Alarm state.
    /// </summary>
    Alarm = 2,

    /// <summary>
    /// Fault state.
    /// </summary>
    Fault = 3,

    /// <summary>
    /// Fault pre-alarm state.
    /// </summary>
    FaultPreAlarm = 4,

    /// <summary>
    /// Fault alarm state.
    /// </summary>
    FaultAlarm = 5,

    /// <summary>
    /// Not ready state.
    /// </summary>
    NotReady = 6,

    /// <summary>
    /// Active state.
    /// </summary>
    Active = 7,

    /// <summary>
    /// Tamper state.
    /// </summary>
    Tamper = 8,

    /// <summary>
    /// Test alarm state.
    /// </summary>
    TestAlarm = 9,

    /// <summary>
    /// Test active state.
    /// </summary>
    TestActive = 10,

    /// <summary>
    /// Test fault state.
    /// </summary>
    TestFault = 11,

    /// <summary>
    /// Test fault alarm state.
    /// </summary>
    TestFaultAlarm = 12,

    /// <summary>
    /// Holdup state.
    /// </summary>
    Holdup = 13,

    /// <summary>
    /// Duress state.
    /// </summary>
    Duress = 14,

    /// <summary>
    /// Tamper alarm state.
    /// </summary>
    TamperAlarm = 15,

    /// <summary>
    /// Abnormal state.
    /// </summary>
    Abnormal = 16,

    /// <summary>
    /// Emergency power state.
    /// </summary>
    EmergencyPower = 17,

    /// <summary>
    /// Delayed state.
    /// </summary>
    Delayed = 18,

    /// <summary>
    /// Blocked state.
    /// </summary>
    Blocked = 19,

    /// <summary>
    /// Local alarm state.
    /// </summary>
    LocalAlarm = 20,

    /// <summary>
    /// General alarm state.
    /// </summary>
    GeneralAlarm = 21,

    /// <summary>
    /// Supervisory state.
    /// </summary>
    Supervisory = 22,

    /// <summary>
    /// Test supervisory state.
    /// </summary>
    TestSupervisory = 23,

    /// <summary>
    /// Non-default mode state.
    /// </summary>
    NonDefaultMode = 24,

    /// <summary>
    /// OEO unavailable state.
    /// </summary>
    OeoUnavailable = 25,

    /// <summary>
    /// OEO alarm state.
    /// </summary>
    OeoAlarm = 26,

    /// <summary>
    /// OEO phase 1 recall state.
    /// </summary>
    OeoPhase1Recall = 27,

    /// <summary>
    /// OEO evacuate state.
    /// </summary>
    OeoEvacuate = 28,

    /// <summary>
    /// OEO unaffected state.
    /// </summary>
    OeoUnaffected = 29,

    /// <summary>
    /// Test OEO unavailable state.
    /// </summary>
    TestOeoUnavailable = 30,

    /// <summary>
    /// Test OEO alarm state.
    /// </summary>
    TestOeoAlarm = 31,

    /// <summary>
    /// Test OEO phase 1 recall state.
    /// </summary>
    TestOeoPhase1Recall = 32,

    /// <summary>
    /// Test OEO evacuate state.
    /// </summary>
    TestOeoEvacuate = 33,

    /// <summary>
    /// Test OEO unaffected state.
    /// </summary>
    TestOeoUnaffected = 34
}
