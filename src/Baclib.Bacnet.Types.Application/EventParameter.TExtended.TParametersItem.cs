// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    public partial record class TExtended
    {
        /// <summary>
        /// Represents the choice parameters as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TParametersItem
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
                /// A real (floating-point) parameter value.
                /// </summary>
                Real,
        
                /// <summary>
                /// An unsigned integer parameter value.
                /// </summary>
                Unsigned,
        
                /// <summary>
                /// A boolean parameter value.
                /// </summary>
                Boolean,
        
                /// <summary>
                /// A signed integer parameter value.
                /// </summary>
                Integer,
        
                /// <summary>
                /// A double-precision floating-point parameter value.
                /// </summary>
                Double,
        
                /// <summary>
                /// An octet string parameter value.
                /// </summary>
                Octetstring,
        
                /// <summary>
                /// A character string parameter value.
                /// </summary>
                Characterstring,
        
                /// <summary>
                /// A bit string parameter value.
                /// </summary>
                Bitstring,
        
                /// <summary>
                /// An enumerated parameter value.
                /// </summary>
                Enumerated,
        
                /// <summary>
                /// A date pattern parameter value.
                /// </summary>
                Date,
        
                /// <summary>
                /// A time pattern parameter value.
                /// </summary>
                Time,
        
                /// <summary>
                /// An object identifier parameter value.
                /// </summary>
                Objectidentifier,
        
                /// <summary>
                /// A device object property reference parameter value.
                /// </summary>
                Reference
            }
        
            /// <summary>
            /// The active choice of this instance.
            /// </summary>
            public Option Choice { get; }
        
            private readonly object _choiceValue;
        
            private TParametersItem(Option choice, object value)
            {
                ArgumentNullException.ThrowIfNull(value);
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
            public static TParametersItem FromNull(Null value)
            {
                return new TParametersItem(Option.Null, value);
            }
        
            /// <summary>
            /// A real (floating-point) parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Real"/>.
            /// </summary>
            public bool TryGetReal(out float value)
            {
                if (Choice == Option.Real)
                {
                    value = (float)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Real"/> option.
            /// </summary>
            public static TParametersItem FromReal(float value)
            {
                return new TParametersItem(Option.Real, value);
            }
        
            /// <summary>
            /// An unsigned integer parameter value.
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
            public static TParametersItem FromUnsigned(Unsigned value)
            {
                return new TParametersItem(Option.Unsigned, value);
            }
        
            /// <summary>
            /// A boolean parameter value.
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
            public static TParametersItem FromBoolean(Boolean value)
            {
                return new TParametersItem(Option.Boolean, value);
            }
        
            /// <summary>
            /// A signed integer parameter value.
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
            public static TParametersItem FromInteger(int value)
            {
                return new TParametersItem(Option.Integer, value);
            }
        
            /// <summary>
            /// A double-precision floating-point parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Double"/>.
            /// </summary>
            public bool TryGetDouble(out double value)
            {
                if (Choice == Option.Double)
                {
                    value = (double)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Double"/> option.
            /// </summary>
            public static TParametersItem FromDouble(double value)
            {
                return new TParametersItem(Option.Double, value);
            }
        
            /// <summary>
            /// An octet string parameter value.
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
            public static TParametersItem FromOctetstring(OctetString value)
            {
                return new TParametersItem(Option.Octetstring, value);
            }
        
            /// <summary>
            /// A character string parameter value.
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
            public static TParametersItem FromCharacterstring(CharacterString value)
            {
                return new TParametersItem(Option.Characterstring, value);
            }
        
            /// <summary>
            /// A bit string parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Bitstring"/>.
            /// </summary>
            public bool TryGetBitstring(out BitString value)
            {
                if (Choice == Option.Bitstring)
                {
                    value = (BitString)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Bitstring"/> option.
            /// </summary>
            public static TParametersItem FromBitstring(BitString value)
            {
                return new TParametersItem(Option.Bitstring, value);
            }
        
            /// <summary>
            /// An enumerated parameter value.
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
            public static TParametersItem FromEnumerated(Enumerated value)
            {
                return new TParametersItem(Option.Enumerated, value);
            }
        
            /// <summary>
            /// A date pattern parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Date"/>.
            /// </summary>
            public bool TryGetDate(out DatePattern value)
            {
                if (Choice == Option.Date)
                {
                    value = (DatePattern)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Date"/> option.
            /// </summary>
            public static TParametersItem FromDate(DatePattern value)
            {
                return new TParametersItem(Option.Date, value);
            }
        
            /// <summary>
            /// A time pattern parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Time"/>.
            /// </summary>
            public bool TryGetTime(out TimePattern value)
            {
                if (Choice == Option.Time)
                {
                    value = (TimePattern)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Time"/> option.
            /// </summary>
            public static TParametersItem FromTime(TimePattern value)
            {
                return new TParametersItem(Option.Time, value);
            }
        
            /// <summary>
            /// An object identifier parameter value.
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
            public static TParametersItem FromObjectidentifier(ObjectIdentifier value)
            {
                return new TParametersItem(Option.Objectidentifier, value);
            }
        
            /// <summary>
            /// A device object property reference parameter value.
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
            /// Tries to get the value when the active choice is <see cref="Option.Reference"/>.
            /// </summary>
            public bool TryGetReference(out DeviceObjectPropertyReference value)
            {
                if (Choice == Option.Reference)
                {
                    value = (DeviceObjectPropertyReference)_choiceValue;
                    return true;
                }
        
                value = default!;
                return false;
            }
            
            /// <summary>
            /// Creates a choice with the <see cref="Option.Reference"/> option.
            /// </summary>
            public static TParametersItem FromReference(DeviceObjectPropertyReference value)
            {
                return new TParametersItem(Option.Reference, value);
            }
        }
    }
}
