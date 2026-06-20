// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AccumulatorRecord
{
    /// <summary>
    /// Represents the enumeration accumulator-status as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TAccumulatorStatus : byte
    {
        /// <summary>
        /// Accumulator is operating normally.
        /// </summary>
        Normal = 0,
    
        /// <summary>
        /// Accumulator is starting or initializing.
        /// </summary>
        Starting = 1,
    
        /// <summary>
        /// Accumulator has recovered from a previous issue.
        /// </summary>
        Recovered = 2,
    
        /// <summary>
        /// Accumulator is in an abnormal state.
        /// </summary>
        Abnormal = 3,
    
        /// <summary>
        /// Accumulator has failed.
        /// </summary>
        Failed = 4
    }
}
