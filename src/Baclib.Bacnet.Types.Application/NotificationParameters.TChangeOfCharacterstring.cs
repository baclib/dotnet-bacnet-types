// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence change-of-characterstring as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfCharacterstring
    {
        /// <summary>
        /// The new character string value that triggered the notification.
        /// </summary>
        public required CharacterString ChangedValue { get; init; }
    
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
    
        /// <summary>
        /// The alarm value that the changed value matched or triggered.
        /// </summary>
        public required CharacterString AlarmValue { get; init; }
    }
}
