// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalBinaryPV as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalBinaryPv
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a binary PV value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet binary PV value when present.
        /// </summary>
        BinaryPv
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalBinaryPv(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a binary PV value.
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
    public static OptionalBinaryPv FromNull(Null value)
    {
        return new OptionalBinaryPv(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet binary PV value when present.
    /// </summary>
    public BinaryPv BinaryPv
    {
        get
        {
            if (Choice != Option.BinaryPv)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BinaryPv)}.");
            }
            return (BinaryPv)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.BinaryPv"/>.
    /// </summary>
    public bool TryGetBinaryPv(out BinaryPv value)
    {
        if (Choice == Option.BinaryPv)
        {
            value = (BinaryPv)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.BinaryPv"/> option.
    /// </summary>
    public static OptionalBinaryPv FromBinaryPv(BinaryPv value)
    {
        return new OptionalBinaryPv(Option.BinaryPv, value);
    }
}
