// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
    
        private readonly object _choiceValue;
    
        private TPeriod(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CalendarEntry)}.");
                }
                return (CalendarEntry)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.CalendarEntry"/>.
        /// </summary>
        public bool TryGetCalendarEntry(out CalendarEntry value)
        {
            if (Choice == Option.CalendarEntry)
            {
                value = (CalendarEntry)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.CalendarEntry"/> option.
        /// </summary>
        public static TPeriod FromCalendarEntry(CalendarEntry value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CalendarReference)}.");
                }
                return (ObjectIdentifier)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.CalendarReference"/>.
        /// </summary>
        public bool TryGetCalendarReference(out ObjectIdentifier value)
        {
            if (Choice == Option.CalendarReference)
            {
                value = (ObjectIdentifier)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.CalendarReference"/> option.
        /// </summary>
        public static TPeriod FromCalendarReference(ObjectIdentifier value)
        {
            return new TPeriod(Option.CalendarReference, value);
        }
    }
}
