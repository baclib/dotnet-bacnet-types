// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class FaultParameter
{
    public partial record class TFaultExtended
    {
        public partial record class TParameters
        {
            /// <summary>
            /// Represents the choice ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
            /// </summary>
            public partial record class TItem
            {
                /// <summary>
                /// Represents the tag choice of this choice type.
                /// </summary>
                public enum Option : byte
                {
                    /// <summary>
                    /// No parameter value.
                    /// </summary>
                    Null,
            
                    /// <summary>
                    /// A real number parameter.
                    /// </summary>
                    Real,
            
                    /// <summary>
                    /// An unsigned integer parameter.
                    /// </summary>
                    Unsigned,
            
                    /// <summary>
                    /// A boolean parameter.
                    /// </summary>
                    Boolean,
            
                    /// <summary>
                    /// A signed integer parameter.
                    /// </summary>
                    Integer,
            
                    /// <summary>
                    /// A double-precision floating-point parameter.
                    /// </summary>
                    Double,
            
                    /// <summary>
                    /// An octet string parameter.
                    /// </summary>
                    Octetstring,
            
                    /// <summary>
                    /// A character string parameter.
                    /// </summary>
                    Characterstring,
            
                    /// <summary>
                    /// A bit string parameter.
                    /// </summary>
                    Bitstring,
            
                    /// <summary>
                    /// An enumerated value parameter.
                    /// </summary>
                    Enumerated,
            
                    /// <summary>
                    /// A date parameter.
                    /// </summary>
                    Date,
            
                    /// <summary>
                    /// A time parameter.
                    /// </summary>
                    Time,
            
                    /// <summary>
                    /// A BACnet object identifier parameter.
                    /// </summary>
                    Objectidentifier,
            
                    /// <summary>
                    /// A device object property reference parameter.
                    /// </summary>
                    Reference
                }
            
                /// <summary>
                /// The active choice of this instance.
                /// </summary>
                public Option Choice { get; }
            
                private object _choiceValue
                {
                    get;
                }
            
                private TItem(Option choice, object value)
                {
                    Choice = choice;
                    _choiceValue = value;
                }
            
                /// <summary>
                /// No parameter value.
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
                /// Create function for No parameter value.
                /// </summary>
                public static TItem NewNull(Null value)
                {
                    return new TItem(Option.Null, value);
                }
            
                /// <summary>
                /// A real number parameter.
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
                /// Create function for A real number parameter.
                /// </summary>
                public static TItem NewReal(float value)
                {
                    return new TItem(Option.Real, value);
                }
            
                /// <summary>
                /// An unsigned integer parameter.
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
                /// Create function for An unsigned integer parameter.
                /// </summary>
                public static TItem NewUnsigned(Unsigned value)
                {
                    return new TItem(Option.Unsigned, value);
                }
            
                /// <summary>
                /// A boolean parameter.
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
                /// Create function for A boolean parameter.
                /// </summary>
                public static TItem NewBoolean(Boolean value)
                {
                    return new TItem(Option.Boolean, value);
                }
            
                /// <summary>
                /// A signed integer parameter.
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
                /// Create function for A signed integer parameter.
                /// </summary>
                public static TItem NewInteger(int value)
                {
                    return new TItem(Option.Integer, value);
                }
            
                /// <summary>
                /// A double-precision floating-point parameter.
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
                /// Create function for A double-precision floating-point parameter.
                /// </summary>
                public static TItem NewDouble(double value)
                {
                    return new TItem(Option.Double, value);
                }
            
                /// <summary>
                /// An octet string parameter.
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
                /// Create function for An octet string parameter.
                /// </summary>
                public static TItem NewOctetstring(OctetString value)
                {
                    return new TItem(Option.Octetstring, value);
                }
            
                /// <summary>
                /// A character string parameter.
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
                /// Create function for A character string parameter.
                /// </summary>
                public static TItem NewCharacterstring(CharacterString value)
                {
                    return new TItem(Option.Characterstring, value);
                }
            
                /// <summary>
                /// A bit string parameter.
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
                /// Create function for A bit string parameter.
                /// </summary>
                public static TItem NewBitstring(BitString value)
                {
                    return new TItem(Option.Bitstring, value);
                }
            
                /// <summary>
                /// An enumerated value parameter.
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
                /// Create function for An enumerated value parameter.
                /// </summary>
                public static TItem NewEnumerated(Enumerated value)
                {
                    return new TItem(Option.Enumerated, value);
                }
            
                /// <summary>
                /// A date parameter.
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
                /// Create function for A date parameter.
                /// </summary>
                public static TItem NewDate(Date value)
                {
                    return new TItem(Option.Date, value);
                }
            
                /// <summary>
                /// A time parameter.
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
                /// Create function for A time parameter.
                /// </summary>
                public static TItem NewTime(Time value)
                {
                    return new TItem(Option.Time, value);
                }
            
                /// <summary>
                /// A BACnet object identifier parameter.
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
                /// Create function for A BACnet object identifier parameter.
                /// </summary>
                public static TItem NewObjectidentifier(ObjectIdentifier value)
                {
                    return new TItem(Option.Objectidentifier, value);
                }
            
                /// <summary>
                /// A device object property reference parameter.
                /// </summary>
                public DeviceObjectPropertyReference Reference
                {
                    get
                    {
                        if (Choice != Option.Reference)
                        {
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Reference)} hat das Template erstellt");
                        }
                        return (DeviceObjectPropertyReference)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A device object property reference parameter.
                /// </summary>
                public static TItem NewReference(DeviceObjectPropertyReference value)
                {
                    return new TItem(Option.Reference, value);
                }
            }
        }
    }
}
