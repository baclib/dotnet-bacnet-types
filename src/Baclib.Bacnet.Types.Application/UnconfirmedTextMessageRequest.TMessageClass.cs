// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
    
        private readonly object _choiceValue;
    
        private TMessageClass(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
        /// Tries to get the value when the active choice is <see cref="Option.Numeric"/>.
        /// </summary>
        public bool TryGetNumeric(out Unsigned value)
        {
            if (Choice == Option.Numeric)
            {
                value = (Unsigned)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Numeric"/> option.
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
        /// Tries to get the value when the active choice is <see cref="Option.Character"/>.
        /// </summary>
        public bool TryGetCharacter(out CharacterString value)
        {
            if (Choice == Option.Character)
            {
                value = (CharacterString)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Character"/> option.
        /// </summary>
        public static TMessageClass FromCharacter(CharacterString value)
        {
            return new TMessageClass(Option.Character, value);
        }
    }
}
