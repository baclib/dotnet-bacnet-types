// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private OptionalPriorityFilter(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
    /// Tries to get the value when the active choice is <see cref="Option.Null"/>.
    /// </summary>
    public bool TryGetNull(out Null value)
    {
        if (Choice == Option.Null)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Null"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.Filter"/>.
    /// </summary>
    public bool TryGetFilter(out PriorityFilter value)
    {
        if (Choice == Option.Filter)
        {
            value = (PriorityFilter)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Filter"/> option.
    /// </summary>
    public static OptionalPriorityFilter FromFilter(PriorityFilter value)
    {
        return new OptionalPriorityFilter(Option.Filter, value);
    }
}
