// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class SubscribeCovPropertyMultipleError
{
    /// <summary>
    /// Represents the sequence first-failed-subscription as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFirstFailedSubscription
    {
        /// <summary>
        /// The identifier of the object for the failed subscription.
        /// </summary>
        public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
    
        /// <summary>
        /// The property reference for the failed subscription.
        /// </summary>
        public required PropertyReference MonitoredPropertyReference { get; init; }
    
        /// <summary>
        /// The error type for the failed subscription.
        /// </summary>
        public required Error ErrorType { get; init; }
    }
}
