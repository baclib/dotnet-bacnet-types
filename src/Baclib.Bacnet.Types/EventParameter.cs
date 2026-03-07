// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetEventParameter as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class EventParameter
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Event parameters for change-of-bitstring detection, triggered when a bit string value changes according to the specified criteria.
        /// </summary>
        ChangeOfBitstring,

        /// <summary>
        /// Event parameters for change-of-state detection, triggered when a state property changes to one of the specified values.
        /// </summary>
        ChangeOfState,

        /// <summary>
        /// Event parameters for change-of-value detection, triggered when a value changes significantly based on the specified criteria.
        /// </summary>
        ChangeOfValue,

        /// <summary>
        /// Event parameters for command-failure detection, triggered when a command does not achieve the expected result.
        /// </summary>
        CommandFailure,

        /// <summary>
        /// Event parameters for floating-limit detection, triggered when a value deviates from a setpoint by more than the specified limits.
        /// </summary>
        FloatingLimit,

        /// <summary>
        /// Event parameters for out-of-range detection, triggered when a real value exceeds the specified low or high limits.
        /// </summary>
        OutOfRange,

        /// <summary>
        /// Event parameters for change-of-life-safety detection, triggered when a life safety value changes to one of the specified alarm values or modes.
        /// </summary>
        ChangeOfLifeSafety,

        /// <summary>
        /// Event parameters for vendor-specific extended event types, allowing proprietary event detection using vendor-defined parameters.
        /// </summary>
        Extended,

        /// <summary>
        /// Event parameters for buffer-ready detection, triggered when buffer storage reaches the specified notification thresholds or when a previous notification has not been confirmed.
        /// </summary>
        BufferReady,

        /// <summary>
        /// Event parameters for unsigned-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
        /// </summary>
        UnsignedRange,

        /// <summary>
        /// Event parameters for access-event detection, triggered when physical access events occur that match the specified criteria.
        /// </summary>
        AccessEvent,

        /// <summary>
        /// Event parameters for double-out-of-range detection, triggered when a double-precision floating-point value exceeds the specified low or high limits.
        /// </summary>
        DoubleOutOfRange,

        /// <summary>
        /// Event parameters for signed-out-of-range detection, triggered when a signed integer value exceeds the specified low or high limits.
        /// </summary>
        SignedOutOfRange,

        /// <summary>
        /// Event parameters for unsigned-out-of-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
        /// </summary>
        UnsignedOutOfRange,

        /// <summary>
        /// Event parameters for change-of-characterstring detection, triggered when a character string value changes to one of the specified alarm values.
        /// </summary>
        ChangeOfCharacterstring,

        /// <summary>
        /// Event parameters for change-of-status-flags detection, triggered when the specified status flags change state.
        /// </summary>
        ChangeOfStatusFlags,

        /// <summary>
        /// Indicates no event parameters are defined.
        /// </summary>
        None,

        /// <summary>
        /// Event parameters for change-of-discrete-value detection, triggered when a discrete-valued property changes to a new value.
        /// </summary>
        ChangeOfDiscreteValue,

        /// <summary>
        /// Event parameters for change-of-timer detection, triggered when a timer state changes to one of the specified alarm values.
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

    private EventParameter(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Event parameters for change-of-bitstring detection, triggered when a bit string value changes according to the specified criteria.
    /// </summary>
    public TChangeOfBitstring ChangeOfBitstring
    {
        get
        {
            if (Choice != Option.ChangeOfBitstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfBitstring)} hat das Template erstellt");
            }
            return (TChangeOfBitstring)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-bitstring detection, triggered when a bit string value changes according to the specified criteria.
    /// </summary>
    public static EventParameter NewChangeOfBitstring(TChangeOfBitstring value)
    {
        return new EventParameter(Option.ChangeOfBitstring, value);
    }

    /// <summary>
    /// Event parameters for change-of-state detection, triggered when a state property changes to one of the specified values.
    /// </summary>
    public TChangeOfState ChangeOfState
    {
        get
        {
            if (Choice != Option.ChangeOfState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfState)} hat das Template erstellt");
            }
            return (TChangeOfState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-state detection, triggered when a state property changes to one of the specified values.
    /// </summary>
    public static EventParameter NewChangeOfState(TChangeOfState value)
    {
        return new EventParameter(Option.ChangeOfState, value);
    }

    /// <summary>
    /// Event parameters for change-of-value detection, triggered when a value changes significantly based on the specified criteria.
    /// </summary>
    public TChangeOfValue ChangeOfValue
    {
        get
        {
            if (Choice != Option.ChangeOfValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfValue)} hat das Template erstellt");
            }
            return (TChangeOfValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-value detection, triggered when a value changes significantly based on the specified criteria.
    /// </summary>
    public static EventParameter NewChangeOfValue(TChangeOfValue value)
    {
        return new EventParameter(Option.ChangeOfValue, value);
    }

    /// <summary>
    /// Event parameters for command-failure detection, triggered when a command does not achieve the expected result.
    /// </summary>
    public TCommandFailure CommandFailure
    {
        get
        {
            if (Choice != Option.CommandFailure)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CommandFailure)} hat das Template erstellt");
            }
            return (TCommandFailure)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for command-failure detection, triggered when a command does not achieve the expected result.
    /// </summary>
    public static EventParameter NewCommandFailure(TCommandFailure value)
    {
        return new EventParameter(Option.CommandFailure, value);
    }

    /// <summary>
    /// Event parameters for floating-limit detection, triggered when a value deviates from a setpoint by more than the specified limits.
    /// </summary>
    public TFloatingLimit FloatingLimit
    {
        get
        {
            if (Choice != Option.FloatingLimit)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FloatingLimit)} hat das Template erstellt");
            }
            return (TFloatingLimit)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for floating-limit detection, triggered when a value deviates from a setpoint by more than the specified limits.
    /// </summary>
    public static EventParameter NewFloatingLimit(TFloatingLimit value)
    {
        return new EventParameter(Option.FloatingLimit, value);
    }

    /// <summary>
    /// Event parameters for out-of-range detection, triggered when a real value exceeds the specified low or high limits.
    /// </summary>
    public TOutOfRange OutOfRange
    {
        get
        {
            if (Choice != Option.OutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.OutOfRange)} hat das Template erstellt");
            }
            return (TOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for out-of-range detection, triggered when a real value exceeds the specified low or high limits.
    /// </summary>
    public static EventParameter NewOutOfRange(TOutOfRange value)
    {
        return new EventParameter(Option.OutOfRange, value);
    }

    /// <summary>
    /// Event parameters for change-of-life-safety detection, triggered when a life safety value changes to one of the specified alarm values or modes.
    /// </summary>
    public TChangeOfLifeSafety ChangeOfLifeSafety
    {
        get
        {
            if (Choice != Option.ChangeOfLifeSafety)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfLifeSafety)} hat das Template erstellt");
            }
            return (TChangeOfLifeSafety)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-life-safety detection, triggered when a life safety value changes to one of the specified alarm values or modes.
    /// </summary>
    public static EventParameter NewChangeOfLifeSafety(TChangeOfLifeSafety value)
    {
        return new EventParameter(Option.ChangeOfLifeSafety, value);
    }

    /// <summary>
    /// Event parameters for vendor-specific extended event types, allowing proprietary event detection using vendor-defined parameters.
    /// </summary>
    public TExtended Extended
    {
        get
        {
            if (Choice != Option.Extended)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Extended)} hat das Template erstellt");
            }
            return (TExtended)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for vendor-specific extended event types, allowing proprietary event detection using vendor-defined parameters.
    /// </summary>
    public static EventParameter NewExtended(TExtended value)
    {
        return new EventParameter(Option.Extended, value);
    }

    /// <summary>
    /// Event parameters for buffer-ready detection, triggered when buffer storage reaches the specified notification thresholds or when a previous notification has not been confirmed.
    /// </summary>
    public TBufferReady BufferReady
    {
        get
        {
            if (Choice != Option.BufferReady)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BufferReady)} hat das Template erstellt");
            }
            return (TBufferReady)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for buffer-ready detection, triggered when buffer storage reaches the specified notification thresholds or when a previous notification has not been confirmed.
    /// </summary>
    public static EventParameter NewBufferReady(TBufferReady value)
    {
        return new EventParameter(Option.BufferReady, value);
    }

    /// <summary>
    /// Event parameters for unsigned-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
    /// </summary>
    public TUnsignedRange UnsignedRange
    {
        get
        {
            if (Choice != Option.UnsignedRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedRange)} hat das Template erstellt");
            }
            return (TUnsignedRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for unsigned-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
    /// </summary>
    public static EventParameter NewUnsignedRange(TUnsignedRange value)
    {
        return new EventParameter(Option.UnsignedRange, value);
    }

    /// <summary>
    /// Event parameters for access-event detection, triggered when physical access events occur that match the specified criteria.
    /// </summary>
    public TAccessEvent AccessEvent
    {
        get
        {
            if (Choice != Option.AccessEvent)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessEvent)} hat das Template erstellt");
            }
            return (TAccessEvent)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for access-event detection, triggered when physical access events occur that match the specified criteria.
    /// </summary>
    public static EventParameter NewAccessEvent(TAccessEvent value)
    {
        return new EventParameter(Option.AccessEvent, value);
    }

    /// <summary>
    /// Event parameters for double-out-of-range detection, triggered when a double-precision floating-point value exceeds the specified low or high limits.
    /// </summary>
    public TDoubleOutOfRange DoubleOutOfRange
    {
        get
        {
            if (Choice != Option.DoubleOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoubleOutOfRange)} hat das Template erstellt");
            }
            return (TDoubleOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for double-out-of-range detection, triggered when a double-precision floating-point value exceeds the specified low or high limits.
    /// </summary>
    public static EventParameter NewDoubleOutOfRange(TDoubleOutOfRange value)
    {
        return new EventParameter(Option.DoubleOutOfRange, value);
    }

    /// <summary>
    /// Event parameters for signed-out-of-range detection, triggered when a signed integer value exceeds the specified low or high limits.
    /// </summary>
    public TSignedOutOfRange SignedOutOfRange
    {
        get
        {
            if (Choice != Option.SignedOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SignedOutOfRange)} hat das Template erstellt");
            }
            return (TSignedOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for signed-out-of-range detection, triggered when a signed integer value exceeds the specified low or high limits.
    /// </summary>
    public static EventParameter NewSignedOutOfRange(TSignedOutOfRange value)
    {
        return new EventParameter(Option.SignedOutOfRange, value);
    }

    /// <summary>
    /// Event parameters for unsigned-out-of-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
    /// </summary>
    public TUnsignedOutOfRange UnsignedOutOfRange
    {
        get
        {
            if (Choice != Option.UnsignedOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedOutOfRange)} hat das Template erstellt");
            }
            return (TUnsignedOutOfRange)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for unsigned-out-of-range detection, triggered when an unsigned integer value exceeds the specified low or high limits.
    /// </summary>
    public static EventParameter NewUnsignedOutOfRange(TUnsignedOutOfRange value)
    {
        return new EventParameter(Option.UnsignedOutOfRange, value);
    }

    /// <summary>
    /// Event parameters for change-of-characterstring detection, triggered when a character string value changes to one of the specified alarm values.
    /// </summary>
    public TChangeOfCharacterstring ChangeOfCharacterstring
    {
        get
        {
            if (Choice != Option.ChangeOfCharacterstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfCharacterstring)} hat das Template erstellt");
            }
            return (TChangeOfCharacterstring)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-characterstring detection, triggered when a character string value changes to one of the specified alarm values.
    /// </summary>
    public static EventParameter NewChangeOfCharacterstring(TChangeOfCharacterstring value)
    {
        return new EventParameter(Option.ChangeOfCharacterstring, value);
    }

    /// <summary>
    /// Event parameters for change-of-status-flags detection, triggered when the specified status flags change state.
    /// </summary>
    public TChangeOfStatusFlags ChangeOfStatusFlags
    {
        get
        {
            if (Choice != Option.ChangeOfStatusFlags)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfStatusFlags)} hat das Template erstellt");
            }
            return (TChangeOfStatusFlags)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-status-flags detection, triggered when the specified status flags change state.
    /// </summary>
    public static EventParameter NewChangeOfStatusFlags(TChangeOfStatusFlags value)
    {
        return new EventParameter(Option.ChangeOfStatusFlags, value);
    }

    /// <summary>
    /// Indicates no event parameters are defined.
    /// </summary>
    public Null None
    {
        get
        {
            if (Choice != Option.None)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.None)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates no event parameters are defined.
    /// </summary>
    public static EventParameter NewNone(Null value)
    {
        return new EventParameter(Option.None, value);
    }

    /// <summary>
    /// Event parameters for change-of-discrete-value detection, triggered when a discrete-valued property changes to a new value.
    /// </summary>
    public TChangeOfDiscreteValue ChangeOfDiscreteValue
    {
        get
        {
            if (Choice != Option.ChangeOfDiscreteValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfDiscreteValue)} hat das Template erstellt");
            }
            return (TChangeOfDiscreteValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-discrete-value detection, triggered when a discrete-valued property changes to a new value.
    /// </summary>
    public static EventParameter NewChangeOfDiscreteValue(TChangeOfDiscreteValue value)
    {
        return new EventParameter(Option.ChangeOfDiscreteValue, value);
    }

    /// <summary>
    /// Event parameters for change-of-timer detection, triggered when a timer state changes to one of the specified alarm values.
    /// </summary>
    public TChangeOfTimer ChangeOfTimer
    {
        get
        {
            if (Choice != Option.ChangeOfTimer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfTimer)} hat das Template erstellt");
            }
            return (TChangeOfTimer)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Event parameters for change-of-timer detection, triggered when a timer state changes to one of the specified alarm values.
    /// </summary>
    public static EventParameter NewChangeOfTimer(TChangeOfTimer value)
    {
        return new EventParameter(Option.ChangeOfTimer, value);
    }
}
