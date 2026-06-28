// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalCharacterString as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalCharacterString
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a character string value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet character string value when present.
        /// </summary>
        Characterstring
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalCharacterString(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a character string value.
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
    public static OptionalCharacterString FromNull(Null value)
    {
        return new OptionalCharacterString(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet character string value when present.
    /// </summary>
    public CharacterString Characterstring
    {
        get
        {
            if (Choice != Option.Characterstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Characterstring)}.");
            }
            return (CharacterString)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Characterstring"/>.
    /// </summary>
    public bool TryGetCharacterstring(out CharacterString value)
    {
        if (Choice == Option.Characterstring)
        {
            value = (CharacterString)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Characterstring"/> option.
    /// </summary>
    public static OptionalCharacterString FromCharacterstring(CharacterString value)
    {
        return new OptionalCharacterString(Option.Characterstring, value);
    }
}
