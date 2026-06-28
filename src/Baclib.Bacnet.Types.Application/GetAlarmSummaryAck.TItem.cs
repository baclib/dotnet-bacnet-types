// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class GetAlarmSummaryAck
{
    /// <summary>
    /// Represents the sequence item as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TItem
    {
        /// <summary>
        /// The object identifier of the object in alarm.
        /// </summary>
        public required ObjectIdentifier ObjectIdentifier { get; init; }
    
        /// <summary>
        /// The current alarm state of the object.
        /// </summary>
        public required EventState AlarmState { get; init; }
    
        /// <summary>
        /// Bit flags indicating which alarm transitions have been acknowledged.
        /// </summary>
        public required EventTransitionBits AcknowledgedTransitions { get; init; }
    }
}
