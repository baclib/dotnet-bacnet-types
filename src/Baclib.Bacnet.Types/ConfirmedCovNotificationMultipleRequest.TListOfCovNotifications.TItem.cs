// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ConfirmedCovNotificationMultipleRequest
{
    public partial record class TListOfCovNotifications
    {
        /// <summary>
        /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
        {
            /// <summary>
            /// The identifier of the object being monitored.
            /// </summary>
            public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
            
            /// <summary>
            /// A list of property values that have changed.
            /// </summary>
            public required TListOfValues ListOfValues { get; init; }
            }
    }
}
