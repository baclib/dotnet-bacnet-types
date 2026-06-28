// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuditLogRecord
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
            /// A log status change event.
            /// </summary>
            LogStatus,
    
            /// <summary>
            /// An audit notification event.
            /// </summary>
            AuditNotification,
    
            /// <summary>
            /// A time change event indicating the magnitude of the time adjustment.
            /// </summary>
            TimeChange
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private readonly object _choiceValue;
    
        private TLogDatum(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// A log status change event.
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
        /// Tries to get the value when the active choice is <see cref="Option.LogStatus"/>.
        /// </summary>
        public bool TryGetLogStatus(out LogStatus value)
        {
            if (Choice == Option.LogStatus)
            {
                value = (LogStatus)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.LogStatus"/> option.
        /// </summary>
        public static TLogDatum FromLogStatus(LogStatus value)
        {
            return new TLogDatum(Option.LogStatus, value);
        }
    
        /// <summary>
        /// An audit notification event.
        /// </summary>
        public AuditNotification AuditNotification
        {
            get
            {
                if (Choice != Option.AuditNotification)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuditNotification)}.");
                }
                return (AuditNotification)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.AuditNotification"/>.
        /// </summary>
        public bool TryGetAuditNotification(out AuditNotification value)
        {
            if (Choice == Option.AuditNotification)
            {
                value = (AuditNotification)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.AuditNotification"/> option.
        /// </summary>
        public static TLogDatum FromAuditNotification(AuditNotification value)
        {
            return new TLogDatum(Option.AuditNotification, value);
        }
    
        /// <summary>
        /// A time change event indicating the magnitude of the time adjustment.
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
        /// Tries to get the value when the active choice is <see cref="Option.TimeChange"/>.
        /// </summary>
        public bool TryGetTimeChange(out float value)
        {
            if (Choice == Option.TimeChange)
            {
                value = (float)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.TimeChange"/> option.
        /// </summary>
        public static TLogDatum FromTimeChange(float value)
        {
            return new TLogDatum(Option.TimeChange, value);
        }
    }
}
