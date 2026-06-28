// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetOptionalOctetString as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalOctetString
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of an octet string value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet octet string value when present.
        /// </summary>
        Octetstring
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private OptionalOctetString(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of an octet string value.
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
    public static OptionalOctetString FromNull(Null value)
    {
        return new OptionalOctetString(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet octet string value when present.
    /// </summary>
    public OctetString Octetstring
    {
        get
        {
            if (Choice != Option.Octetstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Octetstring)}.");
            }
            return (OctetString)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Octetstring"/>.
    /// </summary>
    public bool TryGetOctetstring(out OctetString value)
    {
        if (Choice == Option.Octetstring)
        {
            value = (OctetString)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Octetstring"/> option.
    /// </summary>
    public static OptionalOctetString FromOctetstring(OctetString value)
    {
        return new OptionalOctetString(Option.Octetstring, value);
    }
}
