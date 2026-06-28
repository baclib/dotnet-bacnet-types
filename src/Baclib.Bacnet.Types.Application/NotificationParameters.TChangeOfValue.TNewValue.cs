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
        
            private readonly object _choiceValue;
        
            private TNewValue(Option choice, object value)
            {
                ArgumentNullException.ThrowIfNull(value);
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
            /// Tries to get the value when the active choice is <see cref="Option.ChangedBits"/>.
            /// </summary>
            public bool TryGetChangedBits(out BitString value)
            {
                if (Choice == Option.ChangedBits)
                {
                    value = (BitString)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.ChangedBits"/> option.
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
            /// Tries to get the value when the active choice is <see cref="Option.ChangedValue"/>.
            /// </summary>
            public bool TryGetChangedValue(out float value)
            {
                if (Choice == Option.ChangedValue)
                {
                    value = (float)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.ChangedValue"/> option.
            /// </summary>
            public static TNewValue FromChangedValue(float value)
            {
                return new TNewValue(Option.ChangedValue, value);
            }
        }
    }
}
