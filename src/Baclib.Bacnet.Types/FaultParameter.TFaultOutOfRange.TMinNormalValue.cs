// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    public partial record class TFaultOutOfRange
    {
        /// <summary>
        /// Represents the choice min-normal-value as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TMinNormalValue
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// Minimum normal value as a real number.
                /// </summary>
                Real,
        
                /// <summary>
                /// Minimum normal value as an unsigned integer.
                /// </summary>
                Unsigned,
        
                /// <summary>
                /// Minimum normal value as a double-precision number.
                /// </summary>
                Double,
        
                /// <summary>
                /// Minimum normal value as a signed integer.
                /// </summary>
                Integer
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private object _choiceValue
            {
                get;
            }
        
            private TMinNormalValue(Option choice, object value)
            {
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// Minimum normal value as a real number.
            /// </summary>
            public float Real
            {
                get
                {
                    if (Choice != Option.Real)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)}.");
                    }
                    return (float)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for Minimum normal value as a real number.
            /// </summary>
            public static TMinNormalValue FromReal(float value)
            {
                return new TMinNormalValue(Option.Real, value);
            }
        
            /// <summary>
            /// Minimum normal value as an unsigned integer.
            /// </summary>
            public Unsigned Unsigned
            {
                get
                {
                    if (Choice != Option.Unsigned)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)}.");
                    }
                    return (Unsigned)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for Minimum normal value as an unsigned integer.
            /// </summary>
            public static TMinNormalValue FromUnsigned(Unsigned value)
            {
                return new TMinNormalValue(Option.Unsigned, value);
            }
        
            /// <summary>
            /// Minimum normal value as a double-precision number.
            /// </summary>
            public double Double
            {
                get
                {
                    if (Choice != Option.Double)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)}.");
                    }
                    return (double)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for Minimum normal value as a double-precision number.
            /// </summary>
            public static TMinNormalValue FromDouble(double value)
            {
                return new TMinNormalValue(Option.Double, value);
            }
        
            /// <summary>
            /// Minimum normal value as a signed integer.
            /// </summary>
            public int Integer
            {
                get
                {
                    if (Choice != Option.Integer)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)}.");
                    }
                    return (int)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for Minimum normal value as a signed integer.
            /// </summary>
            public static TMinNormalValue FromInteger(int value)
            {
                return new TMinNormalValue(Option.Integer, value);
            }
        }
    }
}
