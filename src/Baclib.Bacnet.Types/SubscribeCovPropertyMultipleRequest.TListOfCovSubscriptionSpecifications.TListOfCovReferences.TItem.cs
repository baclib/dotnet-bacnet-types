// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class SubscribeCovPropertyMultipleRequest
{
    public partial record class TListOfCovSubscriptionSpecifications
    {
        public partial record class TListOfCovReferences
        {
            /// <summary>
            /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
            /// </summary>
            public partial record class TItem
            {
                /// <summary>
                /// The property to be monitored for changes.
                /// </summary>
                public required PropertyReference MonitoredProperty { get; init; }
                
                /// <summary>
                /// The minimum change in value required to trigger a notification. Optional.
                /// </summary>
                public Optional<float> CovIncrement { get; init; }
            
                /// <summary>
                /// Indicates if the notification should be timestamped.
                /// </summary>
                public required Boolean Timestamped { get; init; }
                }
        }
    }
}
