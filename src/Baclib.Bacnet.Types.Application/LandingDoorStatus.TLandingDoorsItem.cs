// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class LandingDoorStatus
{
    /// <summary>
    /// Represents the sequence landing-doors as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TLandingDoorsItem
    {
        /// <summary>
        /// The floor number where the landing door is located.
        /// </summary>
        public required Unsigned8 FloorNumber { get; init; }
    
        /// <summary>
        /// The status of the landing door at this floor.
        /// </summary>
        public required DoorStatus DoorStatus { get; init; }
    }
}
