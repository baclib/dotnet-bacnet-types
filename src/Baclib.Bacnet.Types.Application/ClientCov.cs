// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetClientCOV as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ClientCov
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A specific real value increment for COV detection.
        /// </summary>
        RealIncrement,

        /// <summary>
        /// Use the default increment value.
        /// </summary>
        DefaultIncrement
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private ClientCov(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A specific real value increment for COV detection.
    /// </summary>
    public float RealIncrement
    {
        get
        {
            if (Choice != Option.RealIncrement)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RealIncrement)}.");
            }
            return (float)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.RealIncrement"/>.
    /// </summary>
    public bool TryGetRealIncrement(out float value)
    {
        if (Choice == Option.RealIncrement)
        {
            value = (float)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.RealIncrement"/> option.
    /// </summary>
    public static ClientCov FromRealIncrement(float value)
    {
        return new ClientCov(Option.RealIncrement, value);
    }

    /// <summary>
    /// Use the default increment value.
    /// </summary>
    public Null DefaultIncrement
    {
        get
        {
            if (Choice != Option.DefaultIncrement)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DefaultIncrement)}.");
            }
            return (Null)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.DefaultIncrement"/>.
    /// </summary>
    public bool TryGetDefaultIncrement(out Null value)
    {
        if (Choice == Option.DefaultIncrement)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.DefaultIncrement"/> option.
    /// </summary>
    public static ClientCov FromDefaultIncrement(Null value)
    {
        return new ClientCov(Option.DefaultIncrement, value);
    }
}
