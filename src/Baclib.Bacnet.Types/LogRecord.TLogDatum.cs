// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LogStatus)} hat das Template erstellt");
                }
                return (LogStatus)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A log status bit string indicating the state of the log.
        /// </summary>
        public static TLogDatum NewLogStatus(LogStatus value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BooleanValue)} hat das Template erstellt");
                }
                return (Boolean)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged boolean value.
        /// </summary>
        public static TLogDatum NewBooleanValue(Boolean value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RealValue)} hat das Template erstellt");
                }
                return (float)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged real (floating-point) value.
        /// </summary>
        public static TLogDatum NewRealValue(float value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EnumeratedValue)} hat das Template erstellt");
                }
                return (Enumerated)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged enumerated value.
        /// </summary>
        public static TLogDatum NewEnumeratedValue(Enumerated value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedValue)} hat das Template erstellt");
                }
                return (Unsigned)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged unsigned integer value.
        /// </summary>
        public static TLogDatum NewUnsignedValue(Unsigned value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IntegerValue)} hat das Template erstellt");
                }
                return (int)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged signed integer value.
        /// </summary>
        public static TLogDatum NewIntegerValue(int value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BitstringValue)} hat das Template erstellt");
                }
                return (BitString)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged bit string value.
        /// </summary>
        public static TLogDatum NewBitstringValue(BitString value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NullValue)} hat das Template erstellt");
                }
                return (Null)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Indicates no value was logged at this timestamp.
        /// </summary>
        public static TLogDatum NewNullValue(Null value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Failure)} hat das Template erstellt");
                }
                return (Error)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for An error that occurred during logging.
        /// </summary>
        public static TLogDatum NewFailure(Error value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeChange)} hat das Template erstellt");
                }
                return (float)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Indicates a time change event, with the value representing the time adjustment in seconds.
        /// </summary>
        public static TLogDatum NewTimeChange(float value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AnyValue)} hat das Template erstellt");
                }
                return (Any)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A logged value of any BACnet data type.
        /// </summary>
        public static TLogDatum NewAnyValue(Any value)
        {
            return new TLogDatum(Option.AnyValue, value);
        }
    }
}
