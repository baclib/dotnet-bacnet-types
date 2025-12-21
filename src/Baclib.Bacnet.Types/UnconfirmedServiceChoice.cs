// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetUnconfirmedServiceChoice as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum UnconfirmedServiceChoice : byte
{
    /// <summary>
    /// I-Am service - used to respond to Who-Is requests with device identification information.
    /// </summary>
    IAm = 0,

    /// <summary>
    /// I-Have service - used to respond to Who-Has requests indicating possession of a specific object.
    /// </summary>
    IHave = 1,

    /// <summary>
    /// Unconfirmed COV (Change of Value) Notification service - used to report property value changes.
    /// </summary>
    UnconfirmedCovNotification = 2,

    /// <summary>
    /// Unconfirmed Event Notification service - used to report alarm and event information.
    /// </summary>
    UnconfirmedEventNotification = 3,

    /// <summary>
    /// Unconfirmed Private Transfer service - used for proprietary or vendor-specific services.
    /// </summary>
    UnconfirmedPrivateTransfer = 4,

    /// <summary>
    /// Unconfirmed Text Message service - used to send text messages to operator displays.
    /// </summary>
    UnconfirmedTextMessage = 5,

    /// <summary>
    /// Time Synchronization service - used to synchronize time across BACnet devices.
    /// </summary>
    TimeSynchronization = 6,

    /// <summary>
    /// Who-Has service - used to discover which device has a specific object.
    /// </summary>
    WhoHas = 7,

    /// <summary>
    /// Who-Is service - used to discover BACnet devices on the network.
    /// </summary>
    WhoIs = 8,

    /// <summary>
    /// UTC Time Synchronization service - used to synchronize UTC time across BACnet devices.
    /// </summary>
    UtcTimeSynchronization = 9,

    /// <summary>
    /// Write Group service - used to write to multiple properties in a single operation.
    /// </summary>
    WriteGroup = 10,

    /// <summary>
    /// Unconfirmed COV Notification Multiple service - used to report multiple property value changes.
    /// </summary>
    UnconfirmedCovNotificationMultiple = 11,

    /// <summary>
    /// Unconfirmed Audit Notification service - used to report audit log entries.
    /// </summary>
    UnconfirmedAuditNotification = 12,

    /// <summary>
    /// Who-Am-I service - used to request identification of the local device.
    /// </summary>
    WhoAmI = 13,

    /// <summary>
    /// You-Are service - used to respond to Who-Am-I requests with device identification.
    /// </summary>
    YouAre = 14
}
