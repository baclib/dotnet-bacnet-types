// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    public partial record class TChangeOfState
    {
        /// <summary>
        /// Represents the sequence-of list-of-values as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TListOfValues
        {
            /// <summary>
            /// TODO: Implement IEnumerable if needed
            /// </summary>
            public int DummyProperty => 42;
        }
    }
}
