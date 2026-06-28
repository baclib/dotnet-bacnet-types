// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetScale as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Scale
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A floating-point scaling factor.
        /// </summary>
        FloatScale,

        /// <summary>
        /// An integer scaling factor.
        /// </summary>
        IntegerScale
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private Scale(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A floating-point scaling factor.
    /// </summary>
    public float FloatScale
    {
        get
        {
            if (Choice != Option.FloatScale)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FloatScale)}.");
            }
            return (float)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FloatScale"/>.
    /// </summary>
    public bool TryGetFloatScale(out float value)
    {
        if (Choice == Option.FloatScale)
        {
            value = (float)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FloatScale"/> option.
    /// </summary>
    public static Scale FromFloatScale(float value)
    {
        return new Scale(Option.FloatScale, value);
    }

    /// <summary>
    /// An integer scaling factor.
    /// </summary>
    public int IntegerScale
    {
        get
        {
            if (Choice != Option.IntegerScale)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IntegerScale)}.");
            }
            return (int)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.IntegerScale"/>.
    /// </summary>
    public bool TryGetIntegerScale(out int value)
    {
        if (Choice == Option.IntegerScale)
        {
            value = (int)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.IntegerScale"/> option.
    /// </summary>
    public static Scale FromIntegerScale(int value)
    {
        return new Scale(Option.IntegerScale, value);
    }
}
