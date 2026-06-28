// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class SubscribeCovPropertyMultipleRequest
{
    /// <summary>
    /// Represents the sequence list-of-cov-subscription-specifications as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TListOfCovSubscriptionSpecificationsItem
    {
        /// <summary>
        /// The identifier of the object to be monitored.
        /// </summary>
        public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
    
        /// <summary>
        /// A list of COV references for the monitored object.
        /// </summary>
        public required SequenceOf<TListOfCovReferencesItem> ListOfCovReferences { get; init; }
    }
}
