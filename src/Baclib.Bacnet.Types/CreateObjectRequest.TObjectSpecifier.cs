// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class CreateObjectRequest
{
    /// <summary>
    /// Represents the choice object-specifier as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TObjectSpecifier
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// Specifies the type of object to create, letting the device assign the instance number.
            /// </summary>
            ObjectType,
    
            /// <summary>
            /// Specifies the complete object identifier including both type and instance number.
            /// </summary>
            ObjectIdentifier
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TObjectSpecifier(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// Specifies the type of object to create, letting the device assign the instance number.
        /// </summary>
        public ObjectType ObjectType
        {
            get
            {
                if (Choice != Option.ObjectType)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectType)} hat das Template erstellt");
                }
                return (ObjectType)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Specifies the type of object to create, letting the device assign the instance number.
        /// </summary>
        public static TObjectSpecifier NewObjectType(ObjectType value)
        {
            return new TObjectSpecifier(Option.ObjectType, value);
        }
    
        /// <summary>
        /// Specifies the complete object identifier including both type and instance number.
        /// </summary>
        public ObjectIdentifier ObjectIdentifier
        {
            get
            {
                if (Choice != Option.ObjectIdentifier)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectIdentifier)} hat das Template erstellt");
                }
                return (ObjectIdentifier)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Specifies the complete object identifier including both type and instance number.
        /// </summary>
        public static TObjectSpecifier NewObjectIdentifier(ObjectIdentifier value)
        {
            return new TObjectSpecifier(Option.ObjectIdentifier, value);
        }
    }
}
