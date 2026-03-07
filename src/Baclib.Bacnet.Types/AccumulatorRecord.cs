// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAccumulatorRecord as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AccumulatorRecord
{
    /// <summary>
    /// The date and time of the accumulator record.
    /// </summary>
    public required DateTime Timestamp { get; init; }
    
    /// <summary>
    /// The present value at the time of the record.
    /// </summary>
    public required Unsigned PresentValue { get; init; }
    
    /// <summary>
    /// The accumulated total value at the time of the record.
    /// </summary>
    public required Unsigned AccumulatedValue { get; init; }
    
    /// <summary>
    /// The operational status of the accumulator.
    /// </summary>
    public required TAccumulatorStatus AccumulatorStatus { get; init; }
    }
