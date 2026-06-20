// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class UnconfirmedTextMessageRequest
{
    /// <summary>
    /// Represents the choice message-class as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TMessageClass
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// A numeric message class identifier.
            /// </summary>
            Numeric,
    
            /// <summary>
            /// A character string message class identifier.
            /// </summary>
            Character
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TMessageClass(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// A numeric message class identifier.
        /// </summary>
        public Unsigned Numeric
        {
            get
            {
                if (Choice != Option.Numeric)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Numeric)}.");
                }
                return (Unsigned)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A numeric message class identifier.
        /// </summary>
        public static TMessageClass FromNumeric(Unsigned value)
        {
            return new TMessageClass(Option.Numeric, value);
        }
    
        /// <summary>
        /// A character string message class identifier.
        /// </summary>
        public CharacterString Character
        {
            get
            {
                if (Choice != Option.Character)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Character)}.");
                }
                return (CharacterString)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A character string message class identifier.
        /// </summary>
        public static TMessageClass FromCharacter(CharacterString value)
        {
            return new TMessageClass(Option.Character, value);
        }
    }
}
