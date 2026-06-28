// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetFaultParameter as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class FaultParameter
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No fault parameter specified.
        /// </summary>
        None,

        /// <summary>
        /// Fault parameters for character string value monitoring, triggered when a string matches one of the specified fault values.
        /// </summary>
        FaultCharacterstring,

        /// <summary>
        /// Fault parameters for vendor-specific extended fault detection, allowing custom fault algorithms beyond standard BACnet fault types.
        /// </summary>
        FaultExtended,

        /// <summary>
        /// Fault parameters for life safety state monitoring, triggered when a life safety object enters one of the specified fault states.
        /// </summary>
        FaultLifeSafety,

        /// <summary>
        /// Fault parameters for property state monitoring, triggered when a state property matches one of the specified fault states.
        /// </summary>
        FaultState,

        /// <summary>
        /// Fault parameters for status flags monitoring, triggered when specific status flags are set in a referenced property.
        /// </summary>
        FaultStatusFlags,

        /// <summary>
        /// Fault parameters for out-of-range monitoring, triggered when a numeric value falls outside the specified normal range.
        /// </summary>
        FaultOutOfRange,

        /// <summary>
        /// Fault parameters for list monitoring, triggered when a monitored value appears in a referenced fault list.
        /// </summary>
        FaultListed
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private FaultParameter(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No fault parameter specified.
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
    public static FaultParameter FromNone(Null value)
    {
        return new FaultParameter(Option.None, value);
    }

    /// <summary>
    /// Fault parameters for character string value monitoring, triggered when a string matches one of the specified fault values.
    /// </summary>
    public TFaultCharacterstring FaultCharacterstring
    {
        get
        {
            if (Choice != Option.FaultCharacterstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultCharacterstring)}.");
            }
            return (TFaultCharacterstring)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultCharacterstring"/>.
    /// </summary>
    public bool TryGetFaultCharacterstring(out TFaultCharacterstring value)
    {
        if (Choice == Option.FaultCharacterstring)
        {
            value = (TFaultCharacterstring)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultCharacterstring"/> option.
    /// </summary>
    public static FaultParameter FromFaultCharacterstring(TFaultCharacterstring value)
    {
        return new FaultParameter(Option.FaultCharacterstring, value);
    }

    /// <summary>
    /// Fault parameters for vendor-specific extended fault detection, allowing custom fault algorithms beyond standard BACnet fault types.
    /// </summary>
    public TFaultExtended FaultExtended
    {
        get
        {
            if (Choice != Option.FaultExtended)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultExtended)}.");
            }
            return (TFaultExtended)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultExtended"/>.
    /// </summary>
    public bool TryGetFaultExtended(out TFaultExtended value)
    {
        if (Choice == Option.FaultExtended)
        {
            value = (TFaultExtended)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultExtended"/> option.
    /// </summary>
    public static FaultParameter FromFaultExtended(TFaultExtended value)
    {
        return new FaultParameter(Option.FaultExtended, value);
    }

    /// <summary>
    /// Fault parameters for life safety state monitoring, triggered when a life safety object enters one of the specified fault states.
    /// </summary>
    public TFaultLifeSafety FaultLifeSafety
    {
        get
        {
            if (Choice != Option.FaultLifeSafety)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultLifeSafety)}.");
            }
            return (TFaultLifeSafety)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultLifeSafety"/>.
    /// </summary>
    public bool TryGetFaultLifeSafety(out TFaultLifeSafety value)
    {
        if (Choice == Option.FaultLifeSafety)
        {
            value = (TFaultLifeSafety)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultLifeSafety"/> option.
    /// </summary>
    public static FaultParameter FromFaultLifeSafety(TFaultLifeSafety value)
    {
        return new FaultParameter(Option.FaultLifeSafety, value);
    }

    /// <summary>
    /// Fault parameters for property state monitoring, triggered when a state property matches one of the specified fault states.
    /// </summary>
    public TFaultState FaultState
    {
        get
        {
            if (Choice != Option.FaultState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultState)}.");
            }
            return (TFaultState)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultState"/>.
    /// </summary>
    public bool TryGetFaultState(out TFaultState value)
    {
        if (Choice == Option.FaultState)
        {
            value = (TFaultState)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultState"/> option.
    /// </summary>
    public static FaultParameter FromFaultState(TFaultState value)
    {
        return new FaultParameter(Option.FaultState, value);
    }

    /// <summary>
    /// Fault parameters for status flags monitoring, triggered when specific status flags are set in a referenced property.
    /// </summary>
    public TFaultStatusFlags FaultStatusFlags
    {
        get
        {
            if (Choice != Option.FaultStatusFlags)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultStatusFlags)}.");
            }
            return (TFaultStatusFlags)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultStatusFlags"/>.
    /// </summary>
    public bool TryGetFaultStatusFlags(out TFaultStatusFlags value)
    {
        if (Choice == Option.FaultStatusFlags)
        {
            value = (TFaultStatusFlags)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultStatusFlags"/> option.
    /// </summary>
    public static FaultParameter FromFaultStatusFlags(TFaultStatusFlags value)
    {
        return new FaultParameter(Option.FaultStatusFlags, value);
    }

    /// <summary>
    /// Fault parameters for out-of-range monitoring, triggered when a numeric value falls outside the specified normal range.
    /// </summary>
    public TFaultOutOfRange FaultOutOfRange
    {
        get
        {
            if (Choice != Option.FaultOutOfRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultOutOfRange)}.");
            }
            return (TFaultOutOfRange)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultOutOfRange"/>.
    /// </summary>
    public bool TryGetFaultOutOfRange(out TFaultOutOfRange value)
    {
        if (Choice == Option.FaultOutOfRange)
        {
            value = (TFaultOutOfRange)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultOutOfRange"/> option.
    /// </summary>
    public static FaultParameter FromFaultOutOfRange(TFaultOutOfRange value)
    {
        return new FaultParameter(Option.FaultOutOfRange, value);
    }

    /// <summary>
    /// Fault parameters for list monitoring, triggered when a monitored value appears in a referenced fault list.
    /// </summary>
    public TFaultListed FaultListed
    {
        get
        {
            if (Choice != Option.FaultListed)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FaultListed)}.");
            }
            return (TFaultListed)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FaultListed"/>.
    /// </summary>
    public bool TryGetFaultListed(out TFaultListed value)
    {
        if (Choice == Option.FaultListed)
        {
            value = (TFaultListed)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FaultListed"/> option.
    /// </summary>
    public static FaultParameter FromFaultListed(TFaultListed value)
    {
        return new FaultParameter(Option.FaultListed, value);
    }
}
