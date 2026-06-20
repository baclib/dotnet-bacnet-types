// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetNotificationParameters as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Notification parameters for a change-of-bitstring event, triggered when a bit string value changes.
        /// </summary>
        ChangeOfBitstring,

        /// <summary>
        /// Notification parameters for a change-of-state event, triggered when an object transitions to a new state.
        /// </summary>
        ChangeOfState,

        /// <summary>
        /// Notification parameters for a change-of-value event, triggered when a monitored value changes significantly.
        /// </summary>
        ChangeOfValue,

        /// <summary>
        /// Notification parameters for a command-failure event, triggered when a command does not achieve the expected result.
        /// </summary>
        CommandFailure,

        /// <summary>
        /// Notification parameters for a floating-limit event, triggered when a value deviates from a setpoint by more than a specified error limit.
        /// </summary>
        FloatingLimit,

        /// <summary>
        /// Notification parameters for an out-of-range event, triggered when a real value exceeds a defined limit.
        /// </summary>
        OutOfRange,

        /// <summary>
        /// Notification parameters for a complex event type, containing a series of property-value pairs for vendor-specific or advanced event scenarios.
        /// </summary>
        ComplexEventType,

        /// <summary>
        /// Notification parameters for a change-of-life-safety event, triggered when a life safety system changes state or mode.
        /// </summary>
        ChangeOfLifeSafety,

        /// <summary>
        /// Notification parameters for vendor-specific extended events, allowing custom event types beyond the standard BACnet event definitions.
        /// </summary>
        Extended,

        /// <summary>
        /// Notification parameters for a buffer-ready event, triggered when a data buffer reaches a threshold and is ready for retrieval.
        /// </summary>
        BufferReady,

        /// <summary>
        /// Notification parameters for an unsigned-range event, triggered when an unsigned integer value exceeds a defined limit.
        /// </summary>
        UnsignedRange,

        /// <summary>
        /// Notification parameters for an access-event, triggered by physical access control events such as door access attempts.
        /// </summary>
        AccessEvent,

        /// <summary>
        /// Notification parameters for a double-out-of-range event, triggered when a double-precision value exceeds a defined limit.
        /// </summary>
        DoubleOutOfRange,

        /// <summary>
        /// Notification parameters for a signed-out-of-range event, triggered when a signed integer value exceeds a defined limit.
        /// </summary>
        SignedOutOfRange,

        /// <summary>
        /// Notification parameters for an unsigned-out-of-range event, triggered when an unsigned integer value exceeds a defined limit.
        /// </summary>
        UnsignedOutOfRange,

        /// <summary>
        /// Notification parameters for a change-of-characterstring event, triggered when a character string value changes to a specified alarm value.
        /// </summary>
        ChangeOfCharacterstring,

        /// <summary>
        /// Notification parameters for a change-of-status-flags event, triggered when object status flags change.
        /// </summary>
        ChangeOfStatusFlags,

        /// <summary>
        /// Notification parameters for a change-of-reliability event, triggered when an object&#x27;s reliability status changes.
        /// </summary>
        ChangeOfReliability,

        /// <summary>
        /// Notification parameters for a change-of-discrete-value event, triggered when a discrete value changes to a new state.
        /// </summary>
        ChangeOfDiscreteValue,

        /// <summary>
        /// Notification parameters for a change-of-timer event, triggered when a timer object transitions to a new state.
        /// </summary>
        ChangeOfTimer
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private NotificationParameters(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Notification parameters for a change-of-bitstring event, triggered when a bit string value changes.
    /// </summary>
    public TChangeOfBitstring ChangeOfBitstring
    {
        get
        {
            if (Choice != Option.ChangeOfBitstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfBitstring)}.");
            }
            return (TChangeOfBitstring)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-bitstring event, triggered when a bit string value changes.
    /// </summary>
    public static NotificationParameters FromChangeOfBitstring(TChangeOfBitstring value)
    {
        return new NotificationParameters(Option.ChangeOfBitstring, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-state event, triggered when an object transitions to a new state.
    /// </summary>
    public TChangeOfState ChangeOfState
    {
        get
        {
            if (Choice != Option.ChangeOfState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfState)}.");
            }
            return (TChangeOfState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-state event, triggered when an object transitions to a new state.
    /// </summary>
    public static NotificationParameters FromChangeOfState(TChangeOfState value)
    {
        return new NotificationParameters(Option.ChangeOfState, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-value event, triggered when a monitored value changes significantly.
    /// </summary>
    public TChangeOfValue ChangeOfValue
    {
        get
        {
            if (Choice != Option.ChangeOfValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfValue)}.");
            }
            return (TChangeOfValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-value event, triggered when a monitored value changes significantly.
    /// </summary>
    public static NotificationParameters FromChangeOfValue(TChangeOfValue value)
    {
        return new NotificationParameters(Option.ChangeOfValue, value);
    }

    /// <summary>
    /// Notification parameters for a command-failure event, triggered when a command does not achieve the expected result.
    /// </summary>
    public TCommandFailure CommandFailure
    {
        get
        {
            if (Choice != Option.CommandFailure)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CommandFailure)}.");
            }
            return (TCommandFailure)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a command-failure event, triggered when a command does not achieve the expected result.
    /// </summary>
    public static NotificationParameters FromCommandFailure(TCommandFailure value)
    {
        return new NotificationParameters(Option.CommandFailure, value);
    }

    /// <summary>
    /// Notification parameters for a floating-limit event, triggered when a value deviates from a setpoint by more than a specified error limit.
    /// </summary>
    public TFloatingLimit FloatingLimit
    {
        get
        {
            if (Choice != Option.FloatingLimit)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FloatingLimit)}.");
            }
            return (TFloatingLimit)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a floating-limit event, triggered when a value deviates from a setpoint by more than a specified error limit.
    /// </summary>
    public static NotificationParameters FromFloatingLimit(TFloatingLimit value)
    {
        return new NotificationParameters(Option.FloatingLimit, value);
    }

    /// <summary>
    /// Notification parameters for an out-of-range event, triggered when a real value exceeds a defined limit.
    /// </summary>
    public TOutOfRange OutOfRange
    {
        get
        {
            if (Choice != Option.OutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.OutOfRange)}.");
            }
            return (TOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for an out-of-range event, triggered when a real value exceeds a defined limit.
    /// </summary>
    public static NotificationParameters FromOutOfRange(TOutOfRange value)
    {
        return new NotificationParameters(Option.OutOfRange, value);
    }

    /// <summary>
    /// Notification parameters for a complex event type, containing a series of property-value pairs for vendor-specific or advanced event scenarios.
    /// </summary>
    public TComplexEventType ComplexEventType
    {
        get
        {
            if (Choice != Option.ComplexEventType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ComplexEventType)}.");
            }
            return (TComplexEventType)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a complex event type, containing a series of property-value pairs for vendor-specific or advanced event scenarios.
    /// </summary>
    public static NotificationParameters FromComplexEventType(TComplexEventType value)
    {
        return new NotificationParameters(Option.ComplexEventType, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-life-safety event, triggered when a life safety system changes state or mode.
    /// </summary>
    public TChangeOfLifeSafety ChangeOfLifeSafety
    {
        get
        {
            if (Choice != Option.ChangeOfLifeSafety)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfLifeSafety)}.");
            }
            return (TChangeOfLifeSafety)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-life-safety event, triggered when a life safety system changes state or mode.
    /// </summary>
    public static NotificationParameters FromChangeOfLifeSafety(TChangeOfLifeSafety value)
    {
        return new NotificationParameters(Option.ChangeOfLifeSafety, value);
    }

    /// <summary>
    /// Notification parameters for vendor-specific extended events, allowing custom event types beyond the standard BACnet event definitions.
    /// </summary>
    public TExtended Extended
    {
        get
        {
            if (Choice != Option.Extended)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Extended)}.");
            }
            return (TExtended)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for vendor-specific extended events, allowing custom event types beyond the standard BACnet event definitions.
    /// </summary>
    public static NotificationParameters FromExtended(TExtended value)
    {
        return new NotificationParameters(Option.Extended, value);
    }

    /// <summary>
    /// Notification parameters for a buffer-ready event, triggered when a data buffer reaches a threshold and is ready for retrieval.
    /// </summary>
    public TBufferReady BufferReady
    {
        get
        {
            if (Choice != Option.BufferReady)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BufferReady)}.");
            }
            return (TBufferReady)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a buffer-ready event, triggered when a data buffer reaches a threshold and is ready for retrieval.
    /// </summary>
    public static NotificationParameters FromBufferReady(TBufferReady value)
    {
        return new NotificationParameters(Option.BufferReady, value);
    }

    /// <summary>
    /// Notification parameters for an unsigned-range event, triggered when an unsigned integer value exceeds a defined limit.
    /// </summary>
    public TUnsignedRange UnsignedRange
    {
        get
        {
            if (Choice != Option.UnsignedRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedRange)}.");
            }
            return (TUnsignedRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for an unsigned-range event, triggered when an unsigned integer value exceeds a defined limit.
    /// </summary>
    public static NotificationParameters FromUnsignedRange(TUnsignedRange value)
    {
        return new NotificationParameters(Option.UnsignedRange, value);
    }

    /// <summary>
    /// Notification parameters for an access-event, triggered by physical access control events such as door access attempts.
    /// </summary>
    public TAccessEvent AccessEvent
    {
        get
        {
            if (Choice != Option.AccessEvent)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessEvent)}.");
            }
            return (TAccessEvent)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for an access-event, triggered by physical access control events such as door access attempts.
    /// </summary>
    public static NotificationParameters FromAccessEvent(TAccessEvent value)
    {
        return new NotificationParameters(Option.AccessEvent, value);
    }

    /// <summary>
    /// Notification parameters for a double-out-of-range event, triggered when a double-precision value exceeds a defined limit.
    /// </summary>
    public TDoubleOutOfRange DoubleOutOfRange
    {
        get
        {
            if (Choice != Option.DoubleOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoubleOutOfRange)}.");
            }
            return (TDoubleOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a double-out-of-range event, triggered when a double-precision value exceeds a defined limit.
    /// </summary>
    public static NotificationParameters FromDoubleOutOfRange(TDoubleOutOfRange value)
    {
        return new NotificationParameters(Option.DoubleOutOfRange, value);
    }

    /// <summary>
    /// Notification parameters for a signed-out-of-range event, triggered when a signed integer value exceeds a defined limit.
    /// </summary>
    public TSignedOutOfRange SignedOutOfRange
    {
        get
        {
            if (Choice != Option.SignedOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SignedOutOfRange)}.");
            }
            return (TSignedOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a signed-out-of-range event, triggered when a signed integer value exceeds a defined limit.
    /// </summary>
    public static NotificationParameters FromSignedOutOfRange(TSignedOutOfRange value)
    {
        return new NotificationParameters(Option.SignedOutOfRange, value);
    }

    /// <summary>
    /// Notification parameters for an unsigned-out-of-range event, triggered when an unsigned integer value exceeds a defined limit.
    /// </summary>
    public TUnsignedOutOfRange UnsignedOutOfRange
    {
        get
        {
            if (Choice != Option.UnsignedOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedOutOfRange)}.");
            }
            return (TUnsignedOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for an unsigned-out-of-range event, triggered when an unsigned integer value exceeds a defined limit.
    /// </summary>
    public static NotificationParameters FromUnsignedOutOfRange(TUnsignedOutOfRange value)
    {
        return new NotificationParameters(Option.UnsignedOutOfRange, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-characterstring event, triggered when a character string value changes to a specified alarm value.
    /// </summary>
    public TChangeOfCharacterstring ChangeOfCharacterstring
    {
        get
        {
            if (Choice != Option.ChangeOfCharacterstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfCharacterstring)}.");
            }
            return (TChangeOfCharacterstring)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-characterstring event, triggered when a character string value changes to a specified alarm value.
    /// </summary>
    public static NotificationParameters FromChangeOfCharacterstring(TChangeOfCharacterstring value)
    {
        return new NotificationParameters(Option.ChangeOfCharacterstring, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-status-flags event, triggered when object status flags change.
    /// </summary>
    public TChangeOfStatusFlags ChangeOfStatusFlags
    {
        get
        {
            if (Choice != Option.ChangeOfStatusFlags)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfStatusFlags)}.");
            }
            return (TChangeOfStatusFlags)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-status-flags event, triggered when object status flags change.
    /// </summary>
    public static NotificationParameters FromChangeOfStatusFlags(TChangeOfStatusFlags value)
    {
        return new NotificationParameters(Option.ChangeOfStatusFlags, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-reliability event, triggered when an object&#x27;s reliability status changes.
    /// </summary>
    public TChangeOfReliability ChangeOfReliability
    {
        get
        {
            if (Choice != Option.ChangeOfReliability)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfReliability)}.");
            }
            return (TChangeOfReliability)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-reliability event, triggered when an object&#x27;s reliability status changes.
    /// </summary>
    public static NotificationParameters FromChangeOfReliability(TChangeOfReliability value)
    {
        return new NotificationParameters(Option.ChangeOfReliability, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-discrete-value event, triggered when a discrete value changes to a new state.
    /// </summary>
    public TChangeOfDiscreteValue ChangeOfDiscreteValue
    {
        get
        {
            if (Choice != Option.ChangeOfDiscreteValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfDiscreteValue)}.");
            }
            return (TChangeOfDiscreteValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-discrete-value event, triggered when a discrete value changes to a new state.
    /// </summary>
    public static NotificationParameters FromChangeOfDiscreteValue(TChangeOfDiscreteValue value)
    {
        return new NotificationParameters(Option.ChangeOfDiscreteValue, value);
    }

    /// <summary>
    /// Notification parameters for a change-of-timer event, triggered when a timer object transitions to a new state.
    /// </summary>
    public TChangeOfTimer ChangeOfTimer
    {
        get
        {
            if (Choice != Option.ChangeOfTimer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfTimer)}.");
            }
            return (TChangeOfTimer)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Notification parameters for a change-of-timer event, triggered when a timer object transitions to a new state.
    /// </summary>
    public static NotificationParameters FromChangeOfTimer(TChangeOfTimer value)
    {
        return new NotificationParameters(Option.ChangeOfTimer, value);
    }
}
