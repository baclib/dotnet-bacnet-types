// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class GetEventInformationAck
{
    /// <summary>
    /// Represents the sequence list-of-event-summaries as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TListOfEventSummariesItem
    {
        /// <summary>
        /// The object identifier of the event-generating object.
        /// </summary>
        public required ObjectIdentifier ObjectIdentifier { get; init; }
    
        /// <summary>
        /// The current event state of the object.
        /// </summary>
        public required EventState EventState { get; init; }
    
        /// <summary>
        /// Bit flags indicating which event transitions have been acknowledged.
        /// </summary>
        public required EventTransitionBits AcknowledgedTransitions { get; init; }
    
        /// <summary>
        /// An array of three timestamps for TO-OFFNORMAL, TO-FAULT, and TO-NORMAL transitions.
        /// </summary>
        public required SequenceOf<TimeStamp> EventTimestamps { get; init; }
    
        /// <summary>
        /// The notification type (alarm or event) for this object.
        /// </summary>
        public required NotifyType NotifyType { get; init; }
    
        /// <summary>
        /// Bit flags indicating which event transitions are enabled.
        /// </summary>
        public required EventTransitionBits EventEnable { get; init; }
    
        /// <summary>
        /// An array of three priority values for TO-OFFNORMAL, TO-FAULT, and TO-NORMAL transitions.
        /// </summary>
        public required SequenceOf<Unsigned> EventPriorities { get; init; }
    }
}
