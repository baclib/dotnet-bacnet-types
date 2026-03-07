// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class LandingDoorStatus
{
    public partial record class TLandingDoors
    {
        /// <summary>
        /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
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
}
