// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice AnyPrimitive as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AnyPrimitive
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A null value.
        /// </summary>
        Null,

        /// <summary>
        /// A boolean value.
        /// </summary>
        Boolean,

        /// <summary>
        /// An unsigned integer value.
        /// </summary>
        Unsigned,

        /// <summary>
        /// A signed integer value.
        /// </summary>
        Integer,

        /// <summary>
        /// A real (floating-point) value.
        /// </summary>
        Real,

        /// <summary>
        /// A double-precision floating-point value.
        /// </summary>
        Double,

        /// <summary>
        /// An octet string value.
        /// </summary>
        OctetString,

        /// <summary>
        /// A character string value.
        /// </summary>
        CharacterString,

        /// <summary>
        /// A bit string value.
        /// </summary>
        BitString,

        /// <summary>
        /// An enumerated value.
        /// </summary>
        Enumerated,

        /// <summary>
        /// A date pattern value for matching dates.
        /// </summary>
        DatePattern,

        /// <summary>
        /// A time pattern value for matching times.
        /// </summary>
        TimePattern,

        /// <summary>
        /// An object identifier value.
        /// </summary>
        ObjectIdentifier
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private AnyPrimitive(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A null value.
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
    /// Create function for A null value.
    /// </summary>
    public static AnyPrimitive FromNull(Null value)
    {
        return new AnyPrimitive(Option.Null, value);
    }

    /// <summary>
    /// A boolean value.
    /// </summary>
    public Boolean Boolean
    {
        get
        {
            if (Choice != Option.Boolean)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Boolean)}.");
            }
            return (Boolean)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A boolean value.
    /// </summary>
    public static AnyPrimitive FromBoolean(Boolean value)
    {
        return new AnyPrimitive(Option.Boolean, value);
    }

    /// <summary>
    /// An unsigned integer value.
    /// </summary>
    public Unsigned Unsigned
    {
        get
        {
            if (Choice != Option.Unsigned)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An unsigned integer value.
    /// </summary>
    public static AnyPrimitive FromUnsigned(Unsigned value)
    {
        return new AnyPrimitive(Option.Unsigned, value);
    }

    /// <summary>
    /// A signed integer value.
    /// </summary>
    public int Integer
    {
        get
        {
            if (Choice != Option.Integer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)}.");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A signed integer value.
    /// </summary>
    public static AnyPrimitive FromInteger(int value)
    {
        return new AnyPrimitive(Option.Integer, value);
    }

    /// <summary>
    /// A real (floating-point) value.
    /// </summary>
    public float Real
    {
        get
        {
            if (Choice != Option.Real)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)}.");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A real (floating-point) value.
    /// </summary>
    public static AnyPrimitive FromReal(float value)
    {
        return new AnyPrimitive(Option.Real, value);
    }

    /// <summary>
    /// A double-precision floating-point value.
    /// </summary>
    public double Double
    {
        get
        {
            if (Choice != Option.Double)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)}.");
            }
            return (double)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A double-precision floating-point value.
    /// </summary>
    public static AnyPrimitive FromDouble(double value)
    {
        return new AnyPrimitive(Option.Double, value);
    }

    /// <summary>
    /// An octet string value.
    /// </summary>
    public OctetString OctetString
    {
        get
        {
            if (Choice != Option.OctetString)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.OctetString)}.");
            }
            return (OctetString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An octet string value.
    /// </summary>
    public static AnyPrimitive FromOctetString(OctetString value)
    {
        return new AnyPrimitive(Option.OctetString, value);
    }

    /// <summary>
    /// A character string value.
    /// </summary>
    public CharacterString CharacterString
    {
        get
        {
            if (Choice != Option.CharacterString)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CharacterString)}.");
            }
            return (CharacterString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A character string value.
    /// </summary>
    public static AnyPrimitive FromCharacterString(CharacterString value)
    {
        return new AnyPrimitive(Option.CharacterString, value);
    }

    /// <summary>
    /// A bit string value.
    /// </summary>
    public BitString BitString
    {
        get
        {
            if (Choice != Option.BitString)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BitString)}.");
            }
            return (BitString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A bit string value.
    /// </summary>
    public static AnyPrimitive FromBitString(BitString value)
    {
        return new AnyPrimitive(Option.BitString, value);
    }

    /// <summary>
    /// An enumerated value.
    /// </summary>
    public Enumerated Enumerated
    {
        get
        {
            if (Choice != Option.Enumerated)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Enumerated)}.");
            }
            return (Enumerated)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An enumerated value.
    /// </summary>
    public static AnyPrimitive FromEnumerated(Enumerated value)
    {
        return new AnyPrimitive(Option.Enumerated, value);
    }

    /// <summary>
    /// A date pattern value for matching dates.
    /// </summary>
    public DatePattern DatePattern
    {
        get
        {
            if (Choice != Option.DatePattern)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DatePattern)}.");
            }
            return (DatePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date pattern value for matching dates.
    /// </summary>
    public static AnyPrimitive FromDatePattern(DatePattern value)
    {
        return new AnyPrimitive(Option.DatePattern, value);
    }

    /// <summary>
    /// A time pattern value for matching times.
    /// </summary>
    public TimePattern TimePattern
    {
        get
        {
            if (Choice != Option.TimePattern)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimePattern)}.");
            }
            return (TimePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A time pattern value for matching times.
    /// </summary>
    public static AnyPrimitive FromTimePattern(TimePattern value)
    {
        return new AnyPrimitive(Option.TimePattern, value);
    }

    /// <summary>
    /// An object identifier value.
    /// </summary>
    public ObjectIdentifier ObjectIdentifier
    {
        get
        {
            if (Choice != Option.ObjectIdentifier)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectIdentifier)}.");
            }
            return (ObjectIdentifier)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An object identifier value.
    /// </summary>
    public static AnyPrimitive FromObjectIdentifier(ObjectIdentifier value)
    {
        return new AnyPrimitive(Option.ObjectIdentifier, value);
    }
}
