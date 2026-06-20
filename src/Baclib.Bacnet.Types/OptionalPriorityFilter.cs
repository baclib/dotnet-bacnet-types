// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalPriorityFilter as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalPriorityFilter
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a priority filter value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet priority filter value when present.
        /// </summary>
        Filter
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalPriorityFilter(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a priority filter value.
    /// </summary>
    public Null Null
    {
        get
        {
            if (Choice != Option.Null)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a priority filter value.
    /// </summary>
    public static OptionalPriorityFilter FromNull(Null value)
    {
        return new OptionalPriorityFilter(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet priority filter value when present.
    /// </summary>
    public PriorityFilter Filter
    {
        get
        {
            if (Choice != Option.Filter)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Filter)}.");
            }
            return (PriorityFilter)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet priority filter value when present.
    /// </summary>
    public static OptionalPriorityFilter FromFilter(PriorityFilter value)
    {
        return new OptionalPriorityFilter(Option.Filter, value);
    }
}
