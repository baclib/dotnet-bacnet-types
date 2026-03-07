// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private Scale(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FloatScale)} hat das Template erstellt");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A floating-point scaling factor.
    /// </summary>
    public static Scale NewFloatScale(float value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IntegerScale)} hat das Template erstellt");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An integer scaling factor.
    /// </summary>
    public static Scale NewIntegerScale(int value)
    {
        return new Scale(Option.IntegerScale, value);
    }
}
