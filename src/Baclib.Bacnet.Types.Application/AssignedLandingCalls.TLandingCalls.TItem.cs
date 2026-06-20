// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AssignedLandingCalls
{
    public partial record class TLandingCalls
    {
        /// <summary>
        /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
        {
            /// <summary>
            /// The floor number of the landing call.
            /// </summary>
            public required Unsigned8 FloorNumber { get; init; }
            
            /// <summary>
            /// The direction of travel for the landing call.
            /// </summary>
            public required LiftCarDirection Direction { get; init; }
            }
    }
}
