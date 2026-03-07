// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ConfirmedCovNotificationMultipleRequest
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
                /// The identifier of the property that changed.
                /// </summary>
                public required PropertyIdentifier PropertyIdentifier { get; init; }
                
                /// <summary>
                /// The array index, if the property is an array. Optional.
                /// </summary>
                public Unsigned? PropertyArrayIndex { get; init; }
            
                /// <summary>
                /// The current value of the property.
                /// </summary>
                public required Any PropertyValue { get; init; }
                
                /// <summary>
                /// Optional time when the property changed.
                /// </summary>
                public Time? TimeOfChange { get; init; }
            }
        }
    }
}
