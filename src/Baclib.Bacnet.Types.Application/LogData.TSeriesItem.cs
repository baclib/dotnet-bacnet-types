// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class LogData
{
    /// <summary>
    /// Represents the choice log-data as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TSeriesItem
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
    
        private readonly object _choiceValue;
    
        private TSeriesItem(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
        /// Tries to get the value when the active choice is <see cref="Option.BooleanValue"/>.
        /// </summary>
        public bool TryGetBooleanValue(out Boolean value)
        {
            if (Choice == Option.BooleanValue)
            {
                value = (Boolean)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.BooleanValue"/> option.
        /// </summary>
        public static TSeriesItem FromBooleanValue(Boolean value)
        {
            return new TSeriesItem(Option.BooleanValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.RealValue"/>.
        /// </summary>
        public bool TryGetRealValue(out float value)
        {
            if (Choice == Option.RealValue)
            {
                value = (float)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.RealValue"/> option.
        /// </summary>
        public static TSeriesItem FromRealValue(float value)
        {
            return new TSeriesItem(Option.RealValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.EnumeratedValue"/>.
        /// </summary>
        public bool TryGetEnumeratedValue(out Enumerated value)
        {
            if (Choice == Option.EnumeratedValue)
            {
                value = (Enumerated)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.EnumeratedValue"/> option.
        /// </summary>
        public static TSeriesItem FromEnumeratedValue(Enumerated value)
        {
            return new TSeriesItem(Option.EnumeratedValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.UnsignedValue"/>.
        /// </summary>
        public bool TryGetUnsignedValue(out Unsigned value)
        {
            if (Choice == Option.UnsignedValue)
            {
                value = (Unsigned)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.UnsignedValue"/> option.
        /// </summary>
        public static TSeriesItem FromUnsignedValue(Unsigned value)
        {
            return new TSeriesItem(Option.UnsignedValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.IntegerValue"/>.
        /// </summary>
        public bool TryGetIntegerValue(out int value)
        {
            if (Choice == Option.IntegerValue)
            {
                value = (int)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.IntegerValue"/> option.
        /// </summary>
        public static TSeriesItem FromIntegerValue(int value)
        {
            return new TSeriesItem(Option.IntegerValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.BitstringValue"/>.
        /// </summary>
        public bool TryGetBitstringValue(out BitString value)
        {
            if (Choice == Option.BitstringValue)
            {
                value = (BitString)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.BitstringValue"/> option.
        /// </summary>
        public static TSeriesItem FromBitstringValue(BitString value)
        {
            return new TSeriesItem(Option.BitstringValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.NullValue"/>.
        /// </summary>
        public bool TryGetNullValue(out Null value)
        {
            if (Choice == Option.NullValue)
            {
                value = (Null)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.NullValue"/> option.
        /// </summary>
        public static TSeriesItem FromNullValue(Null value)
        {
            return new TSeriesItem(Option.NullValue, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.Failure"/>.
        /// </summary>
        public bool TryGetFailure(out Error value)
        {
            if (Choice == Option.Failure)
            {
                value = (Error)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Failure"/> option.
        /// </summary>
        public static TSeriesItem FromFailure(Error value)
        {
            return new TSeriesItem(Option.Failure, value);
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
        /// Tries to get the value when the active choice is <see cref="Option.AnyValue"/>.
        /// </summary>
        public bool TryGetAnyValue(out Any value)
        {
            if (Choice == Option.AnyValue)
            {
                value = (Any)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.AnyValue"/> option.
        /// </summary>
        public static TSeriesItem FromAnyValue(Any value)
        {
            return new TSeriesItem(Option.AnyValue, value);
        }
    }
}
