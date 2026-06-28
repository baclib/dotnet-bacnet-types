// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class UnconfirmedCovNotificationMultipleRequest
{
    /// <summary>
    /// Represents the sequence list-of-cov-notifications as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TListOfCovNotificationsItem
    {
        /// <summary>
        /// The identifier of the monitored object.
        /// </summary>
        public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
    
        /// <summary>
        /// A list of property values that have changed for the monitored object.
        /// </summary>
        public required SequenceOf<TListOfValuesItem> ListOfValues { get; init; }
    }
}
