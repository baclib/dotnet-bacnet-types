// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private OptionalCharacterString(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)} hat das Template erstellt");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a character string value.
    /// </summary>
    public static OptionalCharacterString NewNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Characterstring)} hat das Template erstellt");
            }
            return (CharacterString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet character string value when present.
    /// </summary>
    public static OptionalCharacterString NewCharacterstring(CharacterString value)
    {
        return new OptionalCharacterString(Option.Characterstring, value);
    }
}
