// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    public partial record class TChangeOfDiscreteValue
    {
        /// <summary>
        /// Represents the choice new-value as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TNewValue
        {
            /// <summary>
            /// Represents the tag choice of this choice type.
            /// </summary>
            public enum Option : byte
            {
                /// <summary>
                /// A boolean discrete value.
                /// </summary>
                Boolean,
        
                /// <summary>
                /// An unsigned integer discrete value.
                /// </summary>
                Unsigned,
        
                /// <summary>
                /// A signed integer discrete value.
                /// </summary>
                Integer,
        
                /// <summary>
                /// An enumerated discrete value.
                /// </summary>
                Enumerated,
        
                /// <summary>
                /// A character string discrete value.
                /// </summary>
                Characterstring,
        
                /// <summary>
                /// An octet string discrete value.
                /// </summary>
                Octetstring,
        
                /// <summary>
                /// A date pattern discrete value.
                /// </summary>
                Datepattern,
        
                /// <summary>
                /// A time pattern discrete value.
                /// </summary>
                Timepattern,
        
                /// <summary>
                /// An object identifier discrete value.
                /// </summary>
                Objectidentifier,
        
                /// <summary>
                /// A date and time discrete value.
                /// </summary>
                Datetime
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private object _choiceValue
            {
                get;
            }
        
            private TNewValue(Option choice, object value)
            {
                Choice = choice;
                _choiceValue = value;
            }
        
            /// <summary>
            /// A boolean discrete value.
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
            /// Create function for A boolean discrete value.
            /// </summary>
            public static TNewValue FromBoolean(Boolean value)
            {
                return new TNewValue(Option.Boolean, value);
            }
        
            /// <summary>
            /// An unsigned integer discrete value.
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
            /// Create function for An unsigned integer discrete value.
            /// </summary>
            public static TNewValue FromUnsigned(Unsigned value)
            {
                return new TNewValue(Option.Unsigned, value);
            }
        
            /// <summary>
            /// A signed integer discrete value.
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
            /// Create function for A signed integer discrete value.
            /// </summary>
            public static TNewValue FromInteger(int value)
            {
                return new TNewValue(Option.Integer, value);
            }
        
            /// <summary>
            /// An enumerated discrete value.
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
            /// Create function for An enumerated discrete value.
            /// </summary>
            public static TNewValue FromEnumerated(Enumerated value)
            {
                return new TNewValue(Option.Enumerated, value);
            }
        
            /// <summary>
            /// A character string discrete value.
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
            /// Create function for A character string discrete value.
            /// </summary>
            public static TNewValue FromCharacterstring(CharacterString value)
            {
                return new TNewValue(Option.Characterstring, value);
            }
        
            /// <summary>
            /// An octet string discrete value.
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
            /// Create function for An octet string discrete value.
            /// </summary>
            public static TNewValue FromOctetstring(OctetString value)
            {
                return new TNewValue(Option.Octetstring, value);
            }
        
            /// <summary>
            /// A date pattern discrete value.
            /// </summary>
            public Date Datepattern
            {
                get
                {
                    if (Choice != Option.Datepattern)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Datepattern)}.");
                    }
                    return (Date)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A date pattern discrete value.
            /// </summary>
            public static TNewValue FromDatepattern(Date value)
            {
                return new TNewValue(Option.Datepattern, value);
            }
        
            /// <summary>
            /// A time pattern discrete value.
            /// </summary>
            public Time Timepattern
            {
                get
                {
                    if (Choice != Option.Timepattern)
                    {
                        throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Timepattern)}.");
                    }
                    return (Time)_choiceValue;
                }
            }
            
            /// <summary>
            /// Create function for A time pattern discrete value.
            /// </summary>
            public static TNewValue FromTimepattern(Time value)
            {
                return new TNewValue(Option.Timepattern, value);
            }
        
            /// <summary>
            /// An object identifier discrete value.
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
            /// Create function for An object identifier discrete value.
            /// </summary>
            public static TNewValue FromObjectidentifier(ObjectIdentifier value)
            {
                return new TNewValue(Option.Objectidentifier, value);
            }
        
            /// <summary>
            /// A date and time discrete value.
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
            /// Create function for A date and time discrete value.
            /// </summary>
            public static TNewValue FromDatetime(DateTime value)
            {
                return new TNewValue(Option.Datetime, value);
            }
        }
    }
}
