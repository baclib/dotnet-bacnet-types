// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ReadRangeRequest
{
    /// <summary>
    /// Represents the choice range as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TRange
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// Read range by position.
            /// </summary>
            ByPosition,
    
            /// <summary>
            /// Read range by sequence number.
            /// </summary>
            BySequenceNumber,
    
            /// <summary>
            /// Read range by time.
            /// </summary>
            ByTime
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TRange(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// Read range by position.
        /// </summary>
        public TByPosition ByPosition
        {
            get
            {
                if (Choice != Option.ByPosition)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByPosition)} hat das Template erstellt");
                }
                return (TByPosition)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Read range by position.
        /// </summary>
        public static TRange NewByPosition(TByPosition value)
        {
            return new TRange(Option.ByPosition, value);
        }
    
        /// <summary>
        /// Read range by sequence number.
        /// </summary>
        public TBySequenceNumber BySequenceNumber
        {
            get
            {
                if (Choice != Option.BySequenceNumber)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BySequenceNumber)} hat das Template erstellt");
                }
                return (TBySequenceNumber)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Read range by sequence number.
        /// </summary>
        public static TRange NewBySequenceNumber(TBySequenceNumber value)
        {
            return new TRange(Option.BySequenceNumber, value);
        }
    
        /// <summary>
        /// Read range by time.
        /// </summary>
        public TByTime ByTime
        {
            get
            {
                if (Choice != Option.ByTime)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByTime)} hat das Template erstellt");
                }
                return (TByTime)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Read range by time.
        /// </summary>
        public static TRange NewByTime(TByTime value)
        {
            return new TRange(Option.ByTime, value);
        }
    }
}
