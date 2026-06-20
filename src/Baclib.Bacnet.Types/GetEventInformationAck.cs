// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence GetEventInformation-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class GetEventInformationAck
{
    /// <summary>
    /// A list of event summary entries, one for each active event.
    /// </summary>
    public required TListOfEventSummaries ListOfEventSummaries { get; init; }
    
    /// <summary>
    /// Indicates whether more event information is available (true) or if all events have been returned (false).
    /// </summary>
    public required Boolean MoreEvents { get; init; }
    }
