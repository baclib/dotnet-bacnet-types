// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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
        /// A log status indicator.
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
        /// Create function for A log status indicator.
        /// </summary>
        public static TLogDatum NewLogStatus(LogStatus value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Notification)} hat das Template erstellt");
                }
                return (ConfirmedEventNotificationRequest)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A confirmed event notification.
        /// </summary>
        public static TLogDatum NewNotification(ConfirmedEventNotificationRequest value)
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
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeChange)} hat das Template erstellt");
                }
                return (float)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for A time change value in seconds.
        /// </summary>
        public static TLogDatum NewTimeChange(float value)
        {
            return new TLogDatum(Option.TimeChange, value);
        }
    }
}
