// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private ProcessIdSelection(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ProcessIdentifier)}.");
            }
            return (Unsigned32)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ProcessIdentifier"/>.
    /// </summary>
    public bool TryGetProcessIdentifier(out Unsigned32 value)
    {
        if (Choice == Option.ProcessIdentifier)
        {
            value = (Unsigned32)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ProcessIdentifier"/> option.
    /// </summary>
    public static ProcessIdSelection FromProcessIdentifier(Unsigned32 value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NullValue)}.");
            }
            return (Null)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.NullValue"/>.
    /// </summary>
    public bool TryGetNullValue(out Null value)
    {
        if (Choice == Option.NullValue)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.NullValue"/> option.
    /// </summary>
    public static ProcessIdSelection FromNullValue(Null value)
    {
        return new ProcessIdSelection(Option.NullValue, value);
    }
}
