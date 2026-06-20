// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class LogData
{
    public partial record class TSeries
    {
        /// <summary>
        /// Represents the choice ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// A boolean data value.
                /// </summary>
                BooleanValue,
        
                /// <summary>
                /// A real (floating-point) data value.
                /// </summary>
                RealValue,
        
                /// <summary>
                /// An enumerated data value.
                /// </summary>
                EnumeratedValue,
        
                /// <summary>
                /// An unsigned integer data value.
                /// </summary>
                UnsignedValue,
        
                /// <summary>
                /// A signed integer data value.
                /// </summary>
                IntegerValue,
        
                /// <summary>
                /// A bit string data value.
                /// </summary>
                BitstringValue,
        
                /// <summary>
                /// Indicates no data value was recorded.
                /// </summary>
                NullValue,
        
                /// <summary>
                /// An error that occurred during data logging.
                /// </summary>
                Failure,
        
                /// <summary>
                /// A data value of any BACnet data type.
                /// </summary>
                AnyValue
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private object _choiceValue
            {
                get;
            }
        
            private TItem(Option choice, object value)
            {
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// A boolean data value.
            /// </summary>
            public Boolean BooleanValue
            {
                get
                {
                    if (Choice != Option.BooleanValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BooleanValue)}.");
                    }
                    return (Boolean)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A boolean data value.
            /// </summary>
            public static TItem FromBooleanValue(Boolean value)
            {
                return new TItem(Option.BooleanValue, value);
            }
        
            /// <summary>
            /// A real (floating-point) data value.
            /// </summary>
            public float RealValue
            {
                get
                {
                    if (Choice != Option.RealValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RealValue)}.");
                    }
                    return (float)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A real (floating-point) data value.
            /// </summary>
            public static TItem FromRealValue(float value)
            {
                return new TItem(Option.RealValue, value);
            }
        
            /// <summary>
            /// An enumerated data value.
            /// </summary>
            public Enumerated EnumeratedValue
            {
                get
                {
                    if (Choice != Option.EnumeratedValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EnumeratedValue)}.");
                    }
                    return (Enumerated)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for An enumerated data value.
            /// </summary>
            public static TItem FromEnumeratedValue(Enumerated value)
            {
                return new TItem(Option.EnumeratedValue, value);
            }
        
            /// <summary>
            /// An unsigned integer data value.
            /// </summary>
            public Unsigned UnsignedValue
            {
                get
                {
                    if (Choice != Option.UnsignedValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedValue)}.");
                    }
                    return (Unsigned)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for An unsigned integer data value.
            /// </summary>
            public static TItem FromUnsignedValue(Unsigned value)
            {
                return new TItem(Option.UnsignedValue, value);
            }
        
            /// <summary>
            /// A signed integer data value.
            /// </summary>
            public int IntegerValue
            {
                get
                {
                    if (Choice != Option.IntegerValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IntegerValue)}.");
                    }
                    return (int)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A signed integer data value.
            /// </summary>
            public static TItem FromIntegerValue(int value)
            {
                return new TItem(Option.IntegerValue, value);
            }
        
            /// <summary>
            /// A bit string data value.
            /// </summary>
            public BitString BitstringValue
            {
                get
                {
                    if (Choice != Option.BitstringValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BitstringValue)}.");
                    }
                    return (BitString)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A bit string data value.
            /// </summary>
            public static TItem FromBitstringValue(BitString value)
            {
                return new TItem(Option.BitstringValue, value);
            }
        
            /// <summary>
            /// Indicates no data value was recorded.
            /// </summary>
            public Null NullValue
            {
                get
                {
                    if (Choice != Option.NullValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NullValue)}.");
                    }
                    return (Null)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for Indicates no data value was recorded.
            /// </summary>
            public static TItem FromNullValue(Null value)
            {
                return new TItem(Option.NullValue, value);
            }
        
            /// <summary>
            /// An error that occurred during data logging.
            /// </summary>
            public Error Failure
            {
                get
                {
                    if (Choice != Option.Failure)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Failure)}.");
                    }
                    return (Error)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for An error that occurred during data logging.
            /// </summary>
            public static TItem FromFailure(Error value)
            {
                return new TItem(Option.Failure, value);
            }
        
            /// <summary>
            /// A data value of any BACnet data type.
            /// </summary>
            public Any AnyValue
            {
                get
                {
                    if (Choice != Option.AnyValue)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AnyValue)}.");
                    }
                    return (Any)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A data value of any BACnet data type.
            /// </summary>
            public static TItem FromAnyValue(Any value)
            {
                return new TItem(Option.AnyValue, value);
            }
        }
    }
}
