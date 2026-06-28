// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventLogRecord
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
            /// A log status indicator.
            /// </summary>
            LogStatus,
    
            /// <summary>
            /// A confirmed event notification.
            /// </summary>
            Notification,
    
            /// <summary>
            /// A time change value in seconds.
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
        /// A log status indicator.
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
        /// A confirmed event notification.
        /// </summary>
        public ConfirmedEventNotificationRequest Notification
        {
            get
            {
                if (Choice != Option.Notification)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Notification)}.");
                }
                return (ConfirmedEventNotificationRequest)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.Notification"/>.
        /// </summary>
        public bool TryGetNotification(out ConfirmedEventNotificationRequest value)
        {
            if (Choice == Option.Notification)
            {
                value = (ConfirmedEventNotificationRequest)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Notification"/> option.
        /// </summary>
        public static TLogDatum FromNotification(ConfirmedEventNotificationRequest value)
        {
            return new TLogDatum(Option.Notification, value);
        }
    
        /// <summary>
        /// A time change value in seconds.
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
