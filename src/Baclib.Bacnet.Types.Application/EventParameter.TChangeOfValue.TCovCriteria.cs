// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
        
            private readonly object _choiceValue;
        
            private TCovCriteria(Option choice, object value)
            {
                ArgumentNullException.ThrowIfNull(value);
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
            /// Tries to get the value when the active choice is <see cref="Option.Bitmask"/>.
            /// </summary>
            public bool TryGetBitmask(out BitString value)
            {
                if (Choice == Option.Bitmask)
                {
                    value = (BitString)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Bitmask"/> option.
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
            /// Tries to get the value when the active choice is <see cref="Option.ReferencedPropertyIncrement"/>.
            /// </summary>
            public bool TryGetReferencedPropertyIncrement(out float value)
            {
                if (Choice == Option.ReferencedPropertyIncrement)
                {
                    value = (float)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.ReferencedPropertyIncrement"/> option.
            /// </summary>
            public static TCovCriteria FromReferencedPropertyIncrement(float value)
            {
                return new TCovCriteria(Option.ReferencedPropertyIncrement, value);
            }
        }
    }
}
