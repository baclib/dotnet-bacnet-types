// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private EventParameter(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfBitstring)}.");
            }
            return (TChangeOfBitstring)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfBitstring"/>.
    /// </summary>
    public bool TryGetChangeOfBitstring(out TChangeOfBitstring value)
    {
        if (Choice == Option.ChangeOfBitstring)
        {
            value = (TChangeOfBitstring)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfBitstring"/> option.
    /// </summary>
    public static EventParameter FromChangeOfBitstring(TChangeOfBitstring value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfState)}.");
            }
            return (TChangeOfState)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfState"/>.
    /// </summary>
    public bool TryGetChangeOfState(out TChangeOfState value)
    {
        if (Choice == Option.ChangeOfState)
        {
            value = (TChangeOfState)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfState"/> option.
    /// </summary>
    public static EventParameter FromChangeOfState(TChangeOfState value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfValue)}.");
            }
            return (TChangeOfValue)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfValue"/>.
    /// </summary>
    public bool TryGetChangeOfValue(out TChangeOfValue value)
    {
        if (Choice == Option.ChangeOfValue)
        {
            value = (TChangeOfValue)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfValue"/> option.
    /// </summary>
    public static EventParameter FromChangeOfValue(TChangeOfValue value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CommandFailure)}.");
            }
            return (TCommandFailure)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.CommandFailure"/>.
    /// </summary>
    public bool TryGetCommandFailure(out TCommandFailure value)
    {
        if (Choice == Option.CommandFailure)
        {
            value = (TCommandFailure)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.CommandFailure"/> option.
    /// </summary>
    public static EventParameter FromCommandFailure(TCommandFailure value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FloatingLimit)}.");
            }
            return (TFloatingLimit)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FloatingLimit"/>.
    /// </summary>
    public bool TryGetFloatingLimit(out TFloatingLimit value)
    {
        if (Choice == Option.FloatingLimit)
        {
            value = (TFloatingLimit)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FloatingLimit"/> option.
    /// </summary>
    public static EventParameter FromFloatingLimit(TFloatingLimit value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.OutOfRange)}.");
            }
            return (TOutOfRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.OutOfRange"/>.
    /// </summary>
    public bool TryGetOutOfRange(out TOutOfRange value)
    {
        if (Choice == Option.OutOfRange)
        {
            value = (TOutOfRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.OutOfRange"/> option.
    /// </summary>
    public static EventParameter FromOutOfRange(TOutOfRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfLifeSafety)}.");
            }
            return (TChangeOfLifeSafety)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfLifeSafety"/>.
    /// </summary>
    public bool TryGetChangeOfLifeSafety(out TChangeOfLifeSafety value)
    {
        if (Choice == Option.ChangeOfLifeSafety)
        {
            value = (TChangeOfLifeSafety)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfLifeSafety"/> option.
    /// </summary>
    public static EventParameter FromChangeOfLifeSafety(TChangeOfLifeSafety value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Extended)}.");
            }
            return (TExtended)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Extended"/>.
    /// </summary>
    public bool TryGetExtended(out TExtended value)
    {
        if (Choice == Option.Extended)
        {
            value = (TExtended)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Extended"/> option.
    /// </summary>
    public static EventParameter FromExtended(TExtended value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BufferReady)}.");
            }
            return (TBufferReady)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.BufferReady"/>.
    /// </summary>
    public bool TryGetBufferReady(out TBufferReady value)
    {
        if (Choice == Option.BufferReady)
        {
            value = (TBufferReady)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.BufferReady"/> option.
    /// </summary>
    public static EventParameter FromBufferReady(TBufferReady value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedRange)}.");
            }
            return (TUnsignedRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnsignedRange"/>.
    /// </summary>
    public bool TryGetUnsignedRange(out TUnsignedRange value)
    {
        if (Choice == Option.UnsignedRange)
        {
            value = (TUnsignedRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnsignedRange"/> option.
    /// </summary>
    public static EventParameter FromUnsignedRange(TUnsignedRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessEvent)}.");
            }
            return (TAccessEvent)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AccessEvent"/>.
    /// </summary>
    public bool TryGetAccessEvent(out TAccessEvent value)
    {
        if (Choice == Option.AccessEvent)
        {
            value = (TAccessEvent)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AccessEvent"/> option.
    /// </summary>
    public static EventParameter FromAccessEvent(TAccessEvent value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoubleOutOfRange)}.");
            }
            return (TDoubleOutOfRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.DoubleOutOfRange"/>.
    /// </summary>
    public bool TryGetDoubleOutOfRange(out TDoubleOutOfRange value)
    {
        if (Choice == Option.DoubleOutOfRange)
        {
            value = (TDoubleOutOfRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.DoubleOutOfRange"/> option.
    /// </summary>
    public static EventParameter FromDoubleOutOfRange(TDoubleOutOfRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SignedOutOfRange)}.");
            }
            return (TSignedOutOfRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.SignedOutOfRange"/>.
    /// </summary>
    public bool TryGetSignedOutOfRange(out TSignedOutOfRange value)
    {
        if (Choice == Option.SignedOutOfRange)
        {
            value = (TSignedOutOfRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.SignedOutOfRange"/> option.
    /// </summary>
    public static EventParameter FromSignedOutOfRange(TSignedOutOfRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedOutOfRange)}.");
            }
            return (TUnsignedOutOfRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnsignedOutOfRange"/>.
    /// </summary>
    public bool TryGetUnsignedOutOfRange(out TUnsignedOutOfRange value)
    {
        if (Choice == Option.UnsignedOutOfRange)
        {
            value = (TUnsignedOutOfRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnsignedOutOfRange"/> option.
    /// </summary>
    public static EventParameter FromUnsignedOutOfRange(TUnsignedOutOfRange value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfCharacterstring)}.");
            }
            return (TChangeOfCharacterstring)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfCharacterstring"/>.
    /// </summary>
    public bool TryGetChangeOfCharacterstring(out TChangeOfCharacterstring value)
    {
        if (Choice == Option.ChangeOfCharacterstring)
        {
            value = (TChangeOfCharacterstring)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfCharacterstring"/> option.
    /// </summary>
    public static EventParameter FromChangeOfCharacterstring(TChangeOfCharacterstring value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfStatusFlags)}.");
            }
            return (TChangeOfStatusFlags)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfStatusFlags"/>.
    /// </summary>
    public bool TryGetChangeOfStatusFlags(out TChangeOfStatusFlags value)
    {
        if (Choice == Option.ChangeOfStatusFlags)
        {
            value = (TChangeOfStatusFlags)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfStatusFlags"/> option.
    /// </summary>
    public static EventParameter FromChangeOfStatusFlags(TChangeOfStatusFlags value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.None)}.");
            }
            return (Null)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.None"/>.
    /// </summary>
    public bool TryGetNone(out Null value)
    {
        if (Choice == Option.None)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.None"/> option.
    /// </summary>
    public static EventParameter FromNone(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfDiscreteValue)}.");
            }
            return (TChangeOfDiscreteValue)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfDiscreteValue"/>.
    /// </summary>
    public bool TryGetChangeOfDiscreteValue(out TChangeOfDiscreteValue value)
    {
        if (Choice == Option.ChangeOfDiscreteValue)
        {
            value = (TChangeOfDiscreteValue)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfDiscreteValue"/> option.
    /// </summary>
    public static EventParameter FromChangeOfDiscreteValue(TChangeOfDiscreteValue value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ChangeOfTimer)}.");
            }
            return (TChangeOfTimer)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ChangeOfTimer"/>.
    /// </summary>
    public bool TryGetChangeOfTimer(out TChangeOfTimer value)
    {
        if (Choice == Option.ChangeOfTimer)
        {
            value = (TChangeOfTimer)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ChangeOfTimer"/> option.
    /// </summary>
    public static EventParameter FromChangeOfTimer(TChangeOfTimer value)
    {
        return new EventParameter(Option.ChangeOfTimer, value);
    }
}
