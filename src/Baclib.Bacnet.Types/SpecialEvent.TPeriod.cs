// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class SpecialEvent
{
    /// <summary>
    /// Represents the choice period as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TPeriod
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// A specific calendar entry defining the event period.
            /// </summary>
            CalendarEntry,
    
            /// <summary>
            /// A reference to a calendar object defining the event period.
            /// </summary>
            CalendarReference
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TPeriod(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// A specific calendar entry defining the event period.
        /// </summary>
        public CalendarEntry CalendarEntry
        {
            get
            {
                if (Choice != Option.CalendarEntry)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CalendarEntry)} hat das Template erstellt");
                }
                return (CalendarEntry)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A specific calendar entry defining the event period.
        /// </summary>
        public static TPeriod NewCalendarEntry(CalendarEntry value)
        {
            return new TPeriod(Option.CalendarEntry, value);
        }
    
        /// <summary>
        /// A reference to a calendar object defining the event period.
        /// </summary>
        public ObjectIdentifier CalendarReference
        {
            get
            {
                if (Choice != Option.CalendarReference)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CalendarReference)} hat das Template erstellt");
                }
                return (ObjectIdentifier)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A reference to a calendar object defining the event period.
        /// </summary>
        public static TPeriod NewCalendarReference(ObjectIdentifier value)
        {
            return new TPeriod(Option.CalendarReference, value);
        }
    }
}
