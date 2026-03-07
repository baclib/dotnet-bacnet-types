// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetLandingDoorStatus as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LandingDoorStatus
{
    /// <summary>
    /// A series of landing door entries, each containing a floor number and the door status at that floor.
    /// </summary>
    public required TLandingDoors LandingDoors { get; init; }
    }
