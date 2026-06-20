// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
                        }
                        return (Null)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for No parameter value.
                /// </summary>
                public static TItem FromNull(Null value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Real)}.");
                        }
                        return (float)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A real number parameter.
                /// </summary>
                public static TItem FromReal(float value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Unsigned)}.");
                        }
                        return (Unsigned)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for An unsigned integer parameter.
                /// </summary>
                public static TItem FromUnsigned(Unsigned value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Boolean)}.");
                        }
                        return (Boolean)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A boolean parameter.
                /// </summary>
                public static TItem FromBoolean(Boolean value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Integer)}.");
                        }
                        return (int)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A signed integer parameter.
                /// </summary>
                public static TItem FromInteger(int value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Double)}.");
                        }
                        return (double)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A double-precision floating-point parameter.
                /// </summary>
                public static TItem FromDouble(double value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Octetstring)}.");
                        }
                        return (OctetString)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for An octet string parameter.
                /// </summary>
                public static TItem FromOctetstring(OctetString value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Characterstring)}.");
                        }
                        return (CharacterString)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A character string parameter.
                /// </summary>
                public static TItem FromCharacterstring(CharacterString value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Bitstring)}.");
                        }
                        return (BitString)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A bit string parameter.
                /// </summary>
                public static TItem FromBitstring(BitString value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Enumerated)}.");
                        }
                        return (Enumerated)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for An enumerated value parameter.
                /// </summary>
                public static TItem FromEnumerated(Enumerated value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Date)}.");
                        }
                        return (Date)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A date parameter.
                /// </summary>
                public static TItem FromDate(Date value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Time)}.");
                        }
                        return (Time)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A time parameter.
                /// </summary>
                public static TItem FromTime(Time value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Objectidentifier)}.");
                        }
                        return (ObjectIdentifier)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A BACnet object identifier parameter.
                /// </summary>
                public static TItem FromObjectidentifier(ObjectIdentifier value)
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
                            throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Reference)}.");
                        }
                        return (DeviceObjectPropertyReference)_choiceValue;
                    }
                }
                
                /// <summary>
                /// Create function for A device object property reference parameter.
                /// </summary>
                public static TItem FromReference(DeviceObjectPropertyReference value)
                {
                    return new TItem(Option.Reference, value);
                }
            }
        }
    }
}
