// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for No value.
    /// </summary>
    public static ChannelValue FromNull(Null value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)}.");
            }
            return (float)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A real (floating-point) value.
    /// </summary>
    public static ChannelValue FromReal(float value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Enumerated)}.");
            }
            return (Enumerated)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An enumerated value.
    /// </summary>
    public static ChannelValue FromEnumerated(Enumerated value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An unsigned integer value.
    /// </summary>
    public static ChannelValue FromUnsigned(Unsigned value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Boolean)}.");
            }
            return (Boolean)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A boolean value.
    /// </summary>
    public static ChannelValue FromBoolean(Boolean value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)}.");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A signed integer value.
    /// </summary>
    public static ChannelValue FromInteger(int value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)}.");
            }
            return (double)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A double-precision floating-point value.
    /// </summary>
    public static ChannelValue FromDouble(double value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Time)}.");
            }
            return (Time)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A time value.
    /// </summary>
    public static ChannelValue FromTime(Time value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Characterstring)}.");
            }
            return (CharacterString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A character string value.
    /// </summary>
    public static ChannelValue FromCharacterstring(CharacterString value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Octetstring)}.");
            }
            return (OctetString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An octet string value.
    /// </summary>
    public static ChannelValue FromOctetstring(OctetString value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Bitstring)}.");
            }
            return (BitString)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A bit string value.
    /// </summary>
    public static ChannelValue FromBitstring(BitString value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)}.");
            }
            return (Date)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date value.
    /// </summary>
    public static ChannelValue FromDate(Date value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Objectidentifier)}.");
            }
            return (ObjectIdentifier)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An object identifier value.
    /// </summary>
    public static ChannelValue FromObjectidentifier(ObjectIdentifier value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LightingCommand)}.");
            }
            return (LightingCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A lighting command value.
    /// </summary>
    public static ChannelValue FromLightingCommand(LightingCommand value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Xycolor)}.");
            }
            return (XyColor)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An XY color space value.
    /// </summary>
    public static ChannelValue FromXycolor(XyColor value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ColorCommand)}.");
            }
            return (ColorCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A color command value.
    /// </summary>
    public static ChannelValue FromColorCommand(ColorCommand value)
    {
        return new ChannelValue(Option.ColorCommand, value);
    }
}
