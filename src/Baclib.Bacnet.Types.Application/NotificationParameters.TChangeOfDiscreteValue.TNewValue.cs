// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
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
                /// A date discrete value.
                /// </summary>
                Date,
        
                /// <summary>
                /// A time discrete value.
                /// </summary>
                Time,
        
                /// <summary>
                /// An object identifier discrete value.
                /// </summary>
                Objectidentifier,
        
                /// <summary>
                /// A date-time discrete value.
                /// </summary>
                Datetime
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private readonly object _choiceValue;
        
            private TNewValue(Option choice, object value)
            {
                ArgumentNullException.ThrowIfNull(value);
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
            /// Tries to get the value when the active choice is <see cref="Option.Boolean"/>.
            /// </summary>
            public bool TryGetBoolean(out Boolean value)
            {
                if (Choice == Option.Boolean)
                {
                    value = (Boolean)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Boolean"/> option.
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
            /// Tries to get the value when the active choice is <see cref="Option.Unsigned"/>.
            /// </summary>
            public bool TryGetUnsigned(out Unsigned value)
            {
                if (Choice == Option.Unsigned)
                {
                    value = (Unsigned)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Unsigned"/> option.
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
            /// Tries to get the value when the active choice is <see cref="Option.Integer"/>.
            /// </summary>
            public bool TryGetInteger(out int value)
            {
                if (Choice == Option.Integer)
                {
                    value = (int)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Integer"/> option.
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
            /// Tries to get the value when the active choice is <see cref="Option.Enumerated"/>.
            /// </summary>
            public bool TryGetEnumerated(out Enumerated value)
            {
                if (Choice == Option.Enumerated)
                {
                    value = (Enumerated)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Enumerated"/> option.
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
            public static TNewValue FromOctetstring(OctetString value)
            {
                return new TNewValue(Option.Octetstring, value);
            }
        
            /// <summary>
            /// A date discrete value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Date"/>.
            /// </summary>
            public bool TryGetDate(out Date value)
            {
                if (Choice == Option.Date)
                {
                    value = (Date)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Date"/> option.
            /// </summary>
            public static TNewValue FromDate(Date value)
            {
                return new TNewValue(Option.Date, value);
            }
        
            /// <summary>
            /// A time discrete value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Time"/>.
            /// </summary>
            public bool TryGetTime(out Time value)
            {
                if (Choice == Option.Time)
                {
                    value = (Time)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Time"/> option.
            /// </summary>
            public static TNewValue FromTime(Time value)
            {
                return new TNewValue(Option.Time, value);
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
            /// Tries to get the value when the active choice is <see cref="Option.Objectidentifier"/>.
            /// </summary>
            public bool TryGetObjectidentifier(out ObjectIdentifier value)
            {
                if (Choice == Option.Objectidentifier)
                {
                    value = (ObjectIdentifier)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Objectidentifier"/> option.
            /// </summary>
            public static TNewValue FromObjectidentifier(ObjectIdentifier value)
            {
                return new TNewValue(Option.Objectidentifier, value);
            }
        
            /// <summary>
            /// A date-time discrete value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Datetime"/>.
            /// </summary>
            public bool TryGetDatetime(out DateTime value)
            {
                if (Choice == Option.Datetime)
                {
                    value = (DateTime)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Datetime"/> option.
            /// </summary>
            public static TNewValue FromDatetime(DateTime value)
            {
                return new TNewValue(Option.Datetime, value);
            }
        }
    }
}
