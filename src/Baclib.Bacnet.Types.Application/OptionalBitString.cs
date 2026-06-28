// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalBitString as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalBitString
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a bit string value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet bit string value when present.
        /// </summary>
        Bitstring
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalBitString(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a bit string value.
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
    public static OptionalBitString FromNull(Null value)
    {
        return new OptionalBitString(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet bit string value when present.
    /// </summary>
    public BitString Bitstring
    {
        get
        {
            if (Choice != Option.Bitstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Bitstring)}.");
            }
            return (BitString)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Bitstring"/>.
    /// </summary>
    public bool TryGetBitstring(out BitString value)
    {
        if (Choice == Option.Bitstring)
        {
            value = (BitString)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Bitstring"/> option.
    /// </summary>
    public static OptionalBitString FromBitstring(BitString value)
    {
        return new OptionalBitString(Option.Bitstring, value);
    }
}
