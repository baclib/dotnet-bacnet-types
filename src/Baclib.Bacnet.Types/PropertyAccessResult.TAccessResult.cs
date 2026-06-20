// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class PropertyAccessResult
{
    /// <summary>
    /// Represents the choice access-result as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TAccessResult
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// The value of the property accessed.
            /// </summary>
            PropertyValue,
    
            /// <summary>
            /// Error encountered while accessing the property.
            /// </summary>
            PropertyAccessError
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TAccessResult(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// The value of the property accessed.
        /// </summary>
        public Any PropertyValue
        {
            get
            {
                if (Choice != Option.PropertyValue)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.PropertyValue)}.");
                }
                return (Any)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for The value of the property accessed.
        /// </summary>
        public static TAccessResult FromPropertyValue(Any value)
        {
            return new TAccessResult(Option.PropertyValue, value);
        }
    
        /// <summary>
        /// Error encountered while accessing the property.
        /// </summary>
        public Error PropertyAccessError
        {
            get
            {
                if (Choice != Option.PropertyAccessError)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.PropertyAccessError)}.");
                }
                return (Error)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Error encountered while accessing the property.
        /// </summary>
        public static TAccessResult FromPropertyAccessError(Error value)
        {
            return new TAccessResult(Option.PropertyAccessError, value);
        }
    }
}
