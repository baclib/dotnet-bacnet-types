// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAssignedLandingCalls as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AssignedLandingCalls
{
    /// <summary>
    /// A list of landing calls with floor and direction.
    /// </summary>
    public required TLandingCalls LandingCalls { get; init; }
    }
