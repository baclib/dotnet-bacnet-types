// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetSpecialEvent as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SpecialEvent
{
    /// <summary>
    /// The period during which the special event is active, specified as a calendar entry or reference.
    /// </summary>
    public required TPeriod Period { get; init; }
    
    /// <summary>
    /// A list of time values associated with the special event.
    /// </summary>
    public required TListOfTimeValues ListOfTimeValues { get; init; }
    
    /// <summary>
    /// The priority of the special event, from 1 (highest) to 16 (lowest).
    /// </summary>
    public required TEventPriority EventPriority { get; init; }
    }
