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

    private object _choiceValue
    {
        get;
    }

    private FaultParameter(Option choice, object value)
    {
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
    /// Create function for No fault parameter specified.
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
    /// Create function for Fault parameters for character string value monitoring, triggered when a string matches one of the specified fault values.
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
    /// Create function for Fault parameters for vendor-specific extended fault detection, allowing custom fault algorithms beyond standard BACnet fault types.
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
    /// Create function for Fault parameters for life safety state monitoring, triggered when a life safety object enters one of the specified fault states.
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
    /// Create function for Fault parameters for property state monitoring, triggered when a state property matches one of the specified fault states.
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
    /// Create function for Fault parameters for status flags monitoring, triggered when specific status flags are set in a referenced property.
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
    /// Create function for Fault parameters for out-of-range monitoring, triggered when a numeric value falls outside the specified normal range.
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
    /// Create function for Fault parameters for list monitoring, triggered when a monitored value appears in a referenced fault list.
    /// </summary>
    public static FaultParameter FromFaultListed(TFaultListed value)
    {
        return new FaultParameter(Option.FaultListed, value);
    }
}
