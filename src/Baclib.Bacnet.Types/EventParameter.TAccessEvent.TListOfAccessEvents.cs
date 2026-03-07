// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class EventParameter
{
    public partial record class TAccessEvent
    {
        /// <summary>
        /// Represents the sequence-of list-of-access-events as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TListOfAccessEvents
        {
            /// <summary>
            /// TODO: Implement IEnumerable if needed
            /// </summary>
            public int DummyProperty => 42;
        }
    }
}
