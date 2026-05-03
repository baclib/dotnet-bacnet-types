// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class UnconfirmedCovNotificationMultipleRequest
{
    public partial record class TListOfCovNotifications
    {
        public partial record class TListOfValues
        {
            /// <summary>
            /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
            /// </summary>
            public partial record class TItem
            {
                /// <summary>
                /// The identifier of the property whose value changed.
                /// </summary>
                public required PropertyIdentifier PropertyIdentifier { get; init; }
                
                /// <summary>
                /// The index within an array property, if applicable. Optional.
                /// </summary>
                public Optional<Unsigned> PropertyArrayIndex { get; init; }
            
                /// <summary>
                /// The new value of the property.
                /// </summary>
                public required Any PropertyValue { get; init; }
                
                /// <summary>
                /// The time when the value changed. Optional.
                /// </summary>
                public Optional<Time> TimeOfChange { get; init; }
            }
        }
    }
}
