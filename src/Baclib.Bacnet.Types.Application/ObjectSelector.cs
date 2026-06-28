// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetObjectSelector as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ObjectSelector
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// No object is selected.
        /// </summary>
        None,

        /// <summary>
        /// Selects a specific object by its identifier.
        /// </summary>
        Object,

        /// <summary>
        /// Selects all objects of a given type.
        /// </summary>
        ObjectType
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private ObjectSelector(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// No object is selected.
    /// </summary>
    public Null None
    {
        get
        {
            if (Choice != Option.None)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.None)}.");
            }
            return (Null)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.None"/>.
    /// </summary>
    public bool TryGetNone(out Null value)
    {
        if (Choice == Option.None)
        {
            value = (Null)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.None"/> option.
    /// </summary>
    public static ObjectSelector FromNone(Null value)
    {
        return new ObjectSelector(Option.None, value);
    }

    /// <summary>
    /// Selects a specific object by its identifier.
    /// </summary>
    public ObjectIdentifier Object
    {
        get
        {
            if (Choice != Option.Object)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Object)}.");
            }
            return (ObjectIdentifier)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.Object"/>.
    /// </summary>
    public bool TryGetObject(out ObjectIdentifier value)
    {
        if (Choice == Option.Object)
        {
            value = (ObjectIdentifier)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.Object"/> option.
    /// </summary>
    public static ObjectSelector FromObject(ObjectIdentifier value)
    {
        return new ObjectSelector(Option.Object, value);
    }

    /// <summary>
    /// Selects all objects of a given type.
    /// </summary>
    public ObjectType ObjectType
    {
        get
        {
            if (Choice != Option.ObjectType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ObjectType)}.");
            }
            return (ObjectType)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ObjectType"/>.
    /// </summary>
    public bool TryGetObjectType(out ObjectType value)
    {
        if (Choice == Option.ObjectType)
        {
            value = (ObjectType)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ObjectType"/> option.
    /// </summary>
    public static ObjectSelector FromObjectType(ObjectType value)
    {
        return new ObjectSelector(Option.ObjectType, value);
    }
}
