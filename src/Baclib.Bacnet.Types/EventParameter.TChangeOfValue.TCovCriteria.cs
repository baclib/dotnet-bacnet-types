// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class EventParameter
{
    public partial record class TChangeOfValue
    {
        /// <summary>
        /// Represents the choice cov-criteria as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TCovCriteria
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// A bit mask for detecting changes in specific bits.
                /// </summary>
                Bitmask,
        
                /// <summary>
                /// The minimum change in value required to trigger the event.
                /// </summary>
                ReferencedPropertyIncrement
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private object _choiceValue
            {
                get;
            }
        
            private TCovCriteria(Option choice, object value)
            {
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// A bit mask for detecting changes in specific bits.
            /// </summary>
            public BitString Bitmask
            {
                get
                {
                    if (Choice != Option.Bitmask)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Bitmask)}.");
                    }
                    return (BitString)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A bit mask for detecting changes in specific bits.
            /// </summary>
            public static TCovCriteria FromBitmask(BitString value)
            {
                return new TCovCriteria(Option.Bitmask, value);
            }
        
            /// <summary>
            /// The minimum change in value required to trigger the event.
            /// </summary>
            public float ReferencedPropertyIncrement
            {
                get
                {
                    if (Choice != Option.ReferencedPropertyIncrement)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReferencedPropertyIncrement)}.");
                    }
                    return (float)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for The minimum change in value required to trigger the event.
            /// </summary>
            public static TCovCriteria FromReferencedPropertyIncrement(float value)
            {
                return new TCovCriteria(Option.ReferencedPropertyIncrement, value);
            }
        }
    }
}
