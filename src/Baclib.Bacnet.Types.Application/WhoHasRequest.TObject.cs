// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
    
        private readonly object _choiceValue;
    
        private TObject(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
        /// Tries to get the value when the active choice is <see cref="Option.ObjectIdentifier"/>.
        /// </summary>
        public bool TryGetObjectIdentifier(out ObjectIdentifier value)
        {
            if (Choice == Option.ObjectIdentifier)
            {
                value = (ObjectIdentifier)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.ObjectIdentifier"/> option.
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
        /// Tries to get the value when the active choice is <see cref="Option.ObjectName"/>.
        /// </summary>
        public bool TryGetObjectName(out CharacterString value)
        {
            if (Choice == Option.ObjectName)
            {
                value = (CharacterString)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.ObjectName"/> option.
        /// </summary>
        public static TObject FromObjectName(CharacterString value)
        {
            return new TObject(Option.ObjectName, value);
        }
    }
}
