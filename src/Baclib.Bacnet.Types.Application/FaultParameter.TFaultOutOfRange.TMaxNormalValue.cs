// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    public partial record class TFaultOutOfRange
    {
        /// <summary>
        /// Represents the choice max-normal-value as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TMaxNormalValue
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// Maximum normal value as a real number.
                /// </summary>
                Real,
        
                /// <summary>
                /// Maximum normal value as an unsigned integer.
                /// </summary>
                Unsigned,
        
                /// <summary>
                /// Maximum normal value as a double-precision number.
                /// </summary>
                Double,
        
                /// <summary>
                /// Maximum normal value as a signed integer.
                /// </summary>
                Integer
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private readonly object _choiceValue;
        
            private TMaxNormalValue(Option choice, object value)
            {
                ArgumentNullException.ThrowIfNull(value);
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// Maximum normal value as a real number.
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
            /// Tries to get the value when the active choice is <see cref="Option.Real"/>.
            /// </summary>
            public bool TryGetReal(out float value)
            {
                if (Choice == Option.Real)
                {
                    value = (float)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Real"/> option.
            /// </summary>
            public static TMaxNormalValue FromReal(float value)
            {
                return new TMaxNormalValue(Option.Real, value);
            }
        
            /// <summary>
            /// Maximum normal value as an unsigned integer.
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
            /// Tries to get the value when the active choice is <see cref="Option.Unsigned"/>.
            /// </summary>
            public bool TryGetUnsigned(out Unsigned value)
            {
                if (Choice == Option.Unsigned)
                {
                    value = (Unsigned)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Unsigned"/> option.
            /// </summary>
            public static TMaxNormalValue FromUnsigned(Unsigned value)
            {
                return new TMaxNormalValue(Option.Unsigned, value);
            }
        
            /// <summary>
            /// Maximum normal value as a double-precision number.
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
            /// Tries to get the value when the active choice is <see cref="Option.Double"/>.
            /// </summary>
            public bool TryGetDouble(out double value)
            {
                if (Choice == Option.Double)
                {
                    value = (double)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Double"/> option.
            /// </summary>
            public static TMaxNormalValue FromDouble(double value)
            {
                return new TMaxNormalValue(Option.Double, value);
            }
        
            /// <summary>
            /// Maximum normal value as a signed integer.
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
            /// Tries to get the value when the active choice is <see cref="Option.Integer"/>.
            /// </summary>
            public bool TryGetInteger(out int value)
            {
                if (Choice == Option.Integer)
                {
                    value = (int)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Integer"/> option.
            /// </summary>
            public static TMaxNormalValue FromInteger(int value)
            {
                return new TMaxNormalValue(Option.Integer, value);
            }
        }
    }
}
