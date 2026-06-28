// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
    
        private readonly object _choiceValue;
    
        private TAccessResult(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
        /// Tries to get the value when the active choice is <see cref="Option.PropertyValue"/>.
        /// </summary>
        public bool TryGetPropertyValue(out Any value)
        {
            if (Choice == Option.PropertyValue)
            {
                value = (Any)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.PropertyValue"/> option.
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
        /// Tries to get the value when the active choice is <see cref="Option.PropertyAccessError"/>.
        /// </summary>
        public bool TryGetPropertyAccessError(out Error value)
        {
            if (Choice == Option.PropertyAccessError)
            {
                value = (Error)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.PropertyAccessError"/> option.
        /// </summary>
        public static TAccessResult FromPropertyAccessError(Error value)
        {
            return new TAccessResult(Option.PropertyAccessError, value);
        }
    }
}
