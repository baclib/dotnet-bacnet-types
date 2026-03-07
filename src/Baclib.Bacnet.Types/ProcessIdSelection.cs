// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetProcessIdSelection as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ProcessIdSelection
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A specific process identifier.
        /// </summary>
        ProcessIdentifier,

        /// <summary>
        /// Indicates no process identifier is selected.
        /// </summary>
        NullValue
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private ProcessIdSelection(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A specific process identifier.
    /// </summary>
    public Unsigned32 ProcessIdentifier
    {
        get
        {
            if (Choice != Option.ProcessIdentifier)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ProcessIdentifier)} hat das Template erstellt");
            }
            return (Unsigned32)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A specific process identifier.
    /// </summary>
    public static ProcessIdSelection NewProcessIdentifier(Unsigned32 value)
    {
        return new ProcessIdSelection(Option.ProcessIdentifier, value);
    }

    /// <summary>
    /// Indicates no process identifier is selected.
    /// </summary>
    public Null NullValue
    {
        get
        {
            if (Choice != Option.NullValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NullValue)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates no process identifier is selected.
    /// </summary>
    public static ProcessIdSelection NewNullValue(Null value)
    {
        return new ProcessIdSelection(Option.NullValue, value);
    }
}
