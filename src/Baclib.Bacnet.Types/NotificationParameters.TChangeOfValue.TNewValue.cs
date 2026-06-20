// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    public partial record class TChangeOfValue
    {
        /// <summary>
        /// Represents the choice new-value as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TNewValue
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// The bits that have changed in a bit string value.
                /// </summary>
                ChangedBits,
        
                /// <summary>
                /// The new numeric value that triggered the notification.
                /// </summary>
                ChangedValue
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private object _choiceValue
            {
                get;
            }
        
            private TNewValue(Option choice, object value)
            {
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// The bits that have changed in a bit string value.
            /// </summary>
            public BitString ChangedBits
            {
                get
                {
                    if (Choice != Option.ChangedBits)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangedBits)}.");
                    }
                    return (BitString)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for The bits that have changed in a bit string value.
            /// </summary>
            public static TNewValue FromChangedBits(BitString value)
            {
                return new TNewValue(Option.ChangedBits, value);
            }
        
            /// <summary>
            /// The new numeric value that triggered the notification.
            /// </summary>
            public float ChangedValue
            {
                get
                {
                    if (Choice != Option.ChangedValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangedValue)}.");
                    }
                    return (float)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for The new numeric value that triggered the notification.
            /// </summary>
            public static TNewValue FromChangedValue(float value)
            {
                return new TNewValue(Option.ChangedValue, value);
            }
        }
    }
}
