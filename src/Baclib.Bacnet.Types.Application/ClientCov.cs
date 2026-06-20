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

    private object _choiceValue
    {
        get;
    }

    private ClientCov(Option choice, object value)
    {
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
    /// Create function for A specific real value increment for COV detection.
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
    /// Create function for Use the default increment value.
    /// </summary>
    public static ClientCov FromDefaultIncrement(Null value)
    {
        return new ClientCov(Option.DefaultIncrement, value);
    }
}
