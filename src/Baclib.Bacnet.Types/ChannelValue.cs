// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetChannelValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ChannelValue
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No value.
        /// </summary>
        Null,

        /// <summary>
        /// A real (floating-point) value.
        /// </summary>
        Real,

        /// <summary>
        /// An enumerated value.
        /// </summary>
        Enumerated,

        /// <summary>
        /// An unsigned integer value.
        /// </summary>
        Unsigned,

        /// <summary>
        /// A boolean value.
        /// </summary>
        Boolean,

        /// <summary>
        /// A signed integer value.
        /// </summary>
        Integer,

        /// <summary>
        /// A double-precision floating-point value.
        /// </summary>
        Double,

        /// <summary>
        /// A time value.
        /// </summary>
        Time,

        /// <summary>
        /// A character string value.
        /// </summary>
        Characterstring,

        /// <summary>
        /// An octet string value.
        /// </summary>
        Octetstring,

        /// <summary>
        /// A bit string value.
        /// </summary>
        Bitstring,

        /// <summary>
        /// A date value.
        /// </summary>
        Date,

        /// <summary>
        /// An object identifier value.
        /// </summary>
        Objectidentifier,

        /// <summary>
        /// A lighting command value.
        /// </summary>
        LightingCommand,

        /// <summary>
        /// An XY color space value.
        /// </summary>
        Xycolor,

        /// <summary>
        /// A color command value.
        /// </summary>
        ColorCommand
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private ChannelValue(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No value.
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
    /// Create function for No value.
    /// </summary>
    public static ChannelValue NewNull(Null value)
    {
        return new ChannelValue(Option.Null, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)} hat das Template erstellt");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A real (floating-point) value.
    /// </summary>
    public static ChannelValue NewReal(float value)
    {
        return new ChannelValue(Option.Real, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Enumerated)} hat das Template erstellt");
            }
            return (Enumerated)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An enumerated value.
    /// </summary>
    public static ChannelValue NewEnumerated(Enumerated value)
    {
        return new ChannelValue(Option.Enumerated, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)} hat das Template erstellt");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An unsigned integer value.
    /// </summary>
    public static ChannelValue NewUnsigned(Unsigned value)
    {
        return new ChannelValue(Option.Unsigned, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Boolean)} hat das Template erstellt");
            }
            return (Boolean)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A boolean value.
    /// </summary>
    public static ChannelValue NewBoolean(Boolean value)
    {
        return new ChannelValue(Option.Boolean, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)} hat das Template erstellt");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A signed integer value.
    /// </summary>
    public static ChannelValue NewInteger(int value)
    {
        return new ChannelValue(Option.Integer, value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)} hat das Template erstellt");
            }
            return (double)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A double-precision floating-point value.
    /// </summary>
    public static ChannelValue NewDouble(double value)
    {
        return new ChannelValue(Option.Double, value);
    }

    /// <summary>
    /// A time value.
    /// </summary>
    public Time Time
    {
        get
        {
            if (Choice != Option.Time)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Time)} hat das Template erstellt");
            }
            return (Time)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A time value.
    /// </summary>
    public static ChannelValue NewTime(Time value)
    {
        return new ChannelValue(Option.Time, value);
    }

    /// <summary>
    /// A character string value.
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
    /// Create function for A character string value.
    /// </summary>
    public static ChannelValue NewCharacterstring(CharacterString value)
    {
        return new ChannelValue(Option.Characterstring, value);
    }

    /// <summary>
    /// An octet string value.
    /// </summary>
    public OctetString Octetstring
    {
        get
        {
            if (Choice != Option.Octetstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Octetstring)} hat das Template erstellt");
            }
            return (OctetString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An octet string value.
    /// </summary>
    public static ChannelValue NewOctetstring(OctetString value)
    {
        return new ChannelValue(Option.Octetstring, value);
    }

    /// <summary>
    /// A bit string value.
    /// </summary>
    public BitString Bitstring
    {
        get
        {
            if (Choice != Option.Bitstring)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Bitstring)} hat das Template erstellt");
            }
            return (BitString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A bit string value.
    /// </summary>
    public static ChannelValue NewBitstring(BitString value)
    {
        return new ChannelValue(Option.Bitstring, value);
    }

    /// <summary>
    /// A date value.
    /// </summary>
    public Date Date
    {
        get
        {
            if (Choice != Option.Date)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)} hat das Template erstellt");
            }
            return (Date)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date value.
    /// </summary>
    public static ChannelValue NewDate(Date value)
    {
        return new ChannelValue(Option.Date, value);
    }

    /// <summary>
    /// An object identifier value.
    /// </summary>
    public ObjectIdentifier Objectidentifier
    {
        get
        {
            if (Choice != Option.Objectidentifier)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Objectidentifier)} hat das Template erstellt");
            }
            return (ObjectIdentifier)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An object identifier value.
    /// </summary>
    public static ChannelValue NewObjectidentifier(ObjectIdentifier value)
    {
        return new ChannelValue(Option.Objectidentifier, value);
    }

    /// <summary>
    /// A lighting command value.
    /// </summary>
    public LightingCommand LightingCommand
    {
        get
        {
            if (Choice != Option.LightingCommand)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LightingCommand)} hat das Template erstellt");
            }
            return (LightingCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A lighting command value.
    /// </summary>
    public static ChannelValue NewLightingCommand(LightingCommand value)
    {
        return new ChannelValue(Option.LightingCommand, value);
    }

    /// <summary>
    /// An XY color space value.
    /// </summary>
    public XyColor Xycolor
    {
        get
        {
            if (Choice != Option.Xycolor)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Xycolor)} hat das Template erstellt");
            }
            return (XyColor)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An XY color space value.
    /// </summary>
    public static ChannelValue NewXycolor(XyColor value)
    {
        return new ChannelValue(Option.Xycolor, value);
    }

    /// <summary>
    /// A color command value.
    /// </summary>
    public ColorCommand ColorCommand
    {
        get
        {
            if (Choice != Option.ColorCommand)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ColorCommand)} hat das Template erstellt");
            }
            return (ColorCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A color command value.
    /// </summary>
    public static ChannelValue NewColorCommand(ColorCommand value)
    {
        return new ChannelValue(Option.ColorCommand, value);
    }
}
