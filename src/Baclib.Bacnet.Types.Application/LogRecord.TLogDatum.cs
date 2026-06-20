// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class LogRecord
{
    /// <summary>
    /// Represents the choice log-datum as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TLogDatum
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// A log status bit string indicating the state of the log.
            /// </summary>
            LogStatus,
    
            /// <summary>
            /// A logged boolean value.
            /// </summary>
            BooleanValue,
    
            /// <summary>
            /// A logged real (floating-point) value.
            /// </summary>
            RealValue,
    
            /// <summary>
            /// A logged enumerated value.
            /// </summary>
            EnumeratedValue,
    
            /// <summary>
            /// A logged unsigned integer value.
            /// </summary>
            UnsignedValue,
    
            /// <summary>
            /// A logged signed integer value.
            /// </summary>
            IntegerValue,
    
            /// <summary>
            /// A logged bit string value.
            /// </summary>
            BitstringValue,
    
            /// <summary>
            /// Indicates no value was logged at this timestamp.
            /// </summary>
            NullValue,
    
            /// <summary>
            /// An error that occurred during logging.
            /// </summary>
            Failure,
    
            /// <summary>
            /// Indicates a time change event, with the value representing the time adjustment in seconds.
            /// </summary>
            TimeChange,
    
            /// <summary>
            /// A logged value of any BACnet data type.
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
    
        private TLogDatum(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// A log status bit string indicating the state of the log.
        /// </summary>
        public LogStatus LogStatus
        {
            get
            {
                if (Choice != Option.LogStatus)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LogStatus)}.");
                }
                return (LogStatus)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A log status bit string indicating the state of the log.
        /// </summary>
        public static TLogDatum FromLogStatus(LogStatus value)
        {
            return new TLogDatum(Option.LogStatus, value);
        }
    
        /// <summary>
        /// A logged boolean value.
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
        /// Create function for A logged boolean value.
        /// </summary>
        public static TLogDatum FromBooleanValue(Boolean value)
        {
            return new TLogDatum(Option.BooleanValue, value);
        }
    
        /// <summary>
        /// A logged real (floating-point) value.
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
        /// Create function for A logged real (floating-point) value.
        /// </summary>
        public static TLogDatum FromRealValue(float value)
        {
            return new TLogDatum(Option.RealValue, value);
        }
    
        /// <summary>
        /// A logged enumerated value.
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
        /// Create function for A logged enumerated value.
        /// </summary>
        public static TLogDatum FromEnumeratedValue(Enumerated value)
        {
            return new TLogDatum(Option.EnumeratedValue, value);
        }
    
        /// <summary>
        /// A logged unsigned integer value.
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
        /// Create function for A logged unsigned integer value.
        /// </summary>
        public static TLogDatum FromUnsignedValue(Unsigned value)
        {
            return new TLogDatum(Option.UnsignedValue, value);
        }
    
        /// <summary>
        /// A logged signed integer value.
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
        /// Create function for A logged signed integer value.
        /// </summary>
        public static TLogDatum FromIntegerValue(int value)
        {
            return new TLogDatum(Option.IntegerValue, value);
        }
    
        /// <summary>
        /// A logged bit string value.
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
        /// Create function for A logged bit string value.
        /// </summary>
        public static TLogDatum FromBitstringValue(BitString value)
        {
            return new TLogDatum(Option.BitstringValue, value);
        }
    
        /// <summary>
        /// Indicates no value was logged at this timestamp.
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
        /// Create function for Indicates no value was logged at this timestamp.
        /// </summary>
        public static TLogDatum FromNullValue(Null value)
        {
            return new TLogDatum(Option.NullValue, value);
        }
    
        /// <summary>
        /// An error that occurred during logging.
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
        /// Create function for An error that occurred during logging.
        /// </summary>
        public static TLogDatum FromFailure(Error value)
        {
            return new TLogDatum(Option.Failure, value);
        }
    
        /// <summary>
        /// Indicates a time change event, with the value representing the time adjustment in seconds.
        /// </summary>
        public float TimeChange
        {
            get
            {
                if (Choice != Option.TimeChange)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeChange)}.");
                }
                return (float)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Indicates a time change event, with the value representing the time adjustment in seconds.
        /// </summary>
        public static TLogDatum FromTimeChange(float value)
        {
            return new TLogDatum(Option.TimeChange, value);
        }
    
        /// <summary>
        /// A logged value of any BACnet data type.
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
        /// Create function for A logged value of any BACnet data type.
        /// </summary>
        public static TLogDatum FromAnyValue(Any value)
        {
            return new TLogDatum(Option.AnyValue, value);
        }
    }
}
