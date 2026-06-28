// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
    
        private readonly object _choiceValue;
    
        private TRange(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByPosition)}.");
                }
                return (TByPosition)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.ByPosition"/>.
        /// </summary>
        public bool TryGetByPosition(out TByPosition value)
        {
            if (Choice == Option.ByPosition)
            {
                value = (TByPosition)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.ByPosition"/> option.
        /// </summary>
        public static TRange FromByPosition(TByPosition value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BySequenceNumber)}.");
                }
                return (TBySequenceNumber)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.BySequenceNumber"/>.
        /// </summary>
        public bool TryGetBySequenceNumber(out TBySequenceNumber value)
        {
            if (Choice == Option.BySequenceNumber)
            {
                value = (TBySequenceNumber)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.BySequenceNumber"/> option.
        /// </summary>
        public static TRange FromBySequenceNumber(TBySequenceNumber value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByTime)}.");
                }
                return (TByTime)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.ByTime"/>.
        /// </summary>
        public bool TryGetByTime(out TByTime value)
        {
            if (Choice == Option.ByTime)
            {
                value = (TByTime)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.ByTime"/> option.
        /// </summary>
        public static TRange FromByTime(TByTime value)
        {
            return new TRange(Option.ByTime, value);
        }
    }
}
