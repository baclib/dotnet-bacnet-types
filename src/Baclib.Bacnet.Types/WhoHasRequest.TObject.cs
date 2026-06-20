// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class WhoHasRequest
{
    /// <summary>
    /// Represents the choice object as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TObject
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// The object identifier to search for.
            /// </summary>
            ObjectIdentifier,
    
            /// <summary>
            /// The object name to search for.
            /// </summary>
            ObjectName
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TObject(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// The object identifier to search for.
        /// </summary>
        public ObjectIdentifier ObjectIdentifier
        {
            get
            {
                if (Choice != Option.ObjectIdentifier)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectIdentifier)}.");
                }
                return (ObjectIdentifier)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for The object identifier to search for.
        /// </summary>
        public static TObject FromObjectIdentifier(ObjectIdentifier value)
        {
            return new TObject(Option.ObjectIdentifier, value);
        }
    
        /// <summary>
        /// The object name to search for.
        /// </summary>
        public CharacterString ObjectName
        {
            get
            {
                if (Choice != Option.ObjectName)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectName)}.");
                }
                return (CharacterString)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for The object name to search for.
        /// </summary>
        public static TObject FromObjectName(CharacterString value)
        {
            return new TObject(Option.ObjectName, value);
        }
    }
}
