// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetLiftCarCallList as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LiftCarCallList
{
    /// <summary>
    /// A series of floor numbers where the lift car has active calls.
    /// </summary>
    public required TFloorNumbers FloorNumbers { get; init; }
    }
