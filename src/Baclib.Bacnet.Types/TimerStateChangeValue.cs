// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetTimerStateChangeValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class TimerStateChangeValue
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No value specified.
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
        Octetstring,

        /// <summary>
        /// A character string value.
        /// </summary>
        Characterstring,

        /// <summary>
        /// A bit string value.
        /// </summary>
        Bitstring,

        /// <summary>
        /// An enumerated value.
        /// </summary>
        Enumerated,

        /// <summary>
        /// A date pattern value.
        /// </summary>
        Date,

        /// <summary>
        /// A time pattern value.
        /// </summary>
        Time,

        /// <summary>
        /// An object identifier value.
        /// </summary>
        Objectidentifier,

        /// <summary>
        /// No value present (context-specific).
        /// </summary>
        NoValue,

        /// <summary>
        /// A constructed value (context-specific).
        /// </summary>
        ConstructedValue,

        /// <summary>
        /// A date and time value (context-specific).
        /// </summary>
        Datetime,

        /// <summary>
        /// A lighting command value (context-specific).
        /// </summary>
        LightingCommand
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private TimerStateChangeValue(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No value specified.
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
    /// Create function for No value specified.
    /// </summary>
    public static TimerStateChangeValue FromNull(Null value)
    {
        return new TimerStateChangeValue(Option.Null, value);
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
    public static TimerStateChangeValue FromBoolean(Boolean value)
    {
        return new TimerStateChangeValue(Option.Boolean, value);
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
    public static TimerStateChangeValue FromUnsigned(Unsigned value)
    {
        return new TimerStateChangeValue(Option.Unsigned, value);
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
    public static TimerStateChangeValue FromInteger(int value)
    {
        return new TimerStateChangeValue(Option.Integer, value);
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
    public static TimerStateChangeValue FromReal(float value)
    {
        return new TimerStateChangeValue(Option.Real, value);
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
    public static TimerStateChangeValue FromDouble(double value)
    {
        return new TimerStateChangeValue(Option.Double, value);
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
    public static TimerStateChangeValue FromOctetstring(OctetString value)
    {
        return new TimerStateChangeValue(Option.Octetstring, value);
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
    public static TimerStateChangeValue FromCharacterstring(CharacterString value)
    {
        return new TimerStateChangeValue(Option.Characterstring, value);
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
    public static TimerStateChangeValue FromBitstring(BitString value)
    {
        return new TimerStateChangeValue(Option.Bitstring, value);
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
    public static TimerStateChangeValue FromEnumerated(Enumerated value)
    {
        return new TimerStateChangeValue(Option.Enumerated, value);
    }

    /// <summary>
    /// A date pattern value.
    /// </summary>
    public DatePattern Date
    {
        get
        {
            if (Choice != Option.Date)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)}.");
            }
            return (DatePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date pattern value.
    /// </summary>
    public static TimerStateChangeValue FromDate(DatePattern value)
    {
        return new TimerStateChangeValue(Option.Date, value);
    }

    /// <summary>
    /// A time pattern value.
    /// </summary>
    public TimePattern Time
    {
        get
        {
            if (Choice != Option.Time)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Time)}.");
            }
            return (TimePattern)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A time pattern value.
    /// </summary>
    public static TimerStateChangeValue FromTime(TimePattern value)
    {
        return new TimerStateChangeValue(Option.Time, value);
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
    public static TimerStateChangeValue FromObjectidentifier(ObjectIdentifier value)
    {
        return new TimerStateChangeValue(Option.Objectidentifier, value);
    }

    /// <summary>
    /// No value present (context-specific).
    /// </summary>
    public Null NoValue
    {
        get
        {
            if (Choice != Option.NoValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NoValue)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for No value present (context-specific).
    /// </summary>
    public static TimerStateChangeValue FromNoValue(Null value)
    {
        return new TimerStateChangeValue(Option.NoValue, value);
    }

    /// <summary>
    /// A constructed value (context-specific).
    /// </summary>
    public Any ConstructedValue
    {
        get
        {
            if (Choice != Option.ConstructedValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConstructedValue)}.");
            }
            return (Any)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A constructed value (context-specific).
    /// </summary>
    public static TimerStateChangeValue FromConstructedValue(Any value)
    {
        return new TimerStateChangeValue(Option.ConstructedValue, value);
    }

    /// <summary>
    /// A date and time value (context-specific).
    /// </summary>
    public DateTime Datetime
    {
        get
        {
            if (Choice != Option.Datetime)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datetime)}.");
            }
            return (DateTime)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A date and time value (context-specific).
    /// </summary>
    public static TimerStateChangeValue FromDatetime(DateTime value)
    {
        return new TimerStateChangeValue(Option.Datetime, value);
    }

    /// <summary>
    /// A lighting command value (context-specific).
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
    /// Create function for A lighting command value (context-specific).
    /// </summary>
    public static TimerStateChangeValue FromLightingCommand(LightingCommand value)
    {
        return new TimerStateChangeValue(Option.LightingCommand, value);
    }
}
