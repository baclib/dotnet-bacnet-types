// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

// Bit Number:   7     6     5     4     3     2     1     0
//            |-----|-----|-----|-----|-----|-----|-----|-----|
//            |       Tag Number      |Class|Length/Value/Type|
//            |-----|-----|-----|-----|-----|-----|-----|-----|

/// <summary>
/// Represents a BACnet ASDU tag number with its associated kind (primitive, context, opening, or closing).
/// </summary>
/// <remarks>
/// An ASDU tag number encodes both the tag value (0-254) and the tag kind/class.
/// Application (primitive) tags identify standard BACnet data types.
/// Context tags provide application-specific meaning within constructed types.
/// Opening and closing tags delimit constructed values.
/// </remarks>
public readonly struct AsduTagNumberOld
{
    private readonly int _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsduTagNumberOld"/> struct.
    /// </summary>
    /// <param name="number">The tag number (0-254).</param>
    /// <param name="kind">The tag kind (Primitive, Context, Opening, or Closing).</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when number is not between 0 and 254, or when kind is invalid.
    /// </exception>
    public AsduTagNumberOld(int number, AsduTagKind kind = AsduTagKind.Context)
    {
        if (number < 0 || number > 254)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 0 and 254.");
        }

        if (kind is not AsduTagKind.Primitive and not AsduTagKind.Context and not AsduTagKind.Opening and not AsduTagKind.Closing)
        {
            throw new ArgumentOutOfRangeException(nameof(kind), "Invalid tag kind.");
        }

        _value = (int)kind | number;
    }

    /// <summary>
    /// Gets the kind of this tag (Primitive, Context, Opening, or Closing).
    /// </summary>
    public AsduTagKind Kind => (AsduTagKind)(_value & 0xF00);

    /// <summary>
    /// Gets the size in bytes required to encode this tag number.
    /// </summary>
    /// <value>1 byte if tag number is less than 15, otherwise 2 bytes.</value>
    public int Size => Value < 15 ? 1 : 2;

    /// <summary>
    /// Gets the numeric value of this tag (0-254).
    /// </summary>
    public int Value => _value & 0xFF;

    /// <summary>
    /// Gets a value indicating whether this is a primitive (application) tag.
    /// </summary>
    public bool IsPrimitive => Kind == AsduTagKind.Primitive;

    /// <summary>
    /// Gets a value indicating whether this is a context tag.
    /// </summary>
    public bool IsContext => Kind == AsduTagKind.Context;

    /// <summary>
    /// Gets a value indicating whether this is a context-class tag (context, opening, or closing).
    /// </summary>
    public bool IsContextClass => Kind != AsduTagKind.Primitive;

    /// <summary>
    /// Gets a value indicating whether this is an opening tag.
    /// </summary>
    public bool IsOpening => Kind == AsduTagKind.Opening;

    /// <summary>
    /// Gets a value indicating whether this is a closing tag.
    /// </summary>
    public bool IsClosing => Kind == AsduTagKind.Closing;

    /// <summary>
    /// Gets the application tag for Null (tag 0).
    /// </summary>
    public static AsduTagNumberOld Null => new(0, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Boolean (tag 1).
    /// </summary>
    public static AsduTagNumberOld Boolean => new(1, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Unsigned Integer (tag 2).
    /// </summary>
    public static AsduTagNumberOld Unsigned => new(2, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Signed Integer (tag 3).
    /// </summary>
    public static AsduTagNumberOld Signed => new(3, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Real (32-bit float) (tag 4).
    /// </summary>
    public static AsduTagNumberOld Real => new(4, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Double (64-bit float) (tag 5).
    /// </summary>
    public static AsduTagNumberOld Double => new(5, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Enumerated (tag 9).
    /// </summary>
    public static AsduTagNumberOld Enumerated => new(9, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Octet String (tag 6).
    /// </summary>
    public static AsduTagNumberOld OctetString => new(6, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Character String (tag 7).
    /// </summary>
    public static AsduTagNumberOld CharacterString => new(7, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Bit String (tag 8).
    /// </summary>
    public static AsduTagNumberOld BitString => new(8, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Date (tag 10).
    /// </summary>
    public static AsduTagNumberOld Date => new(10, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Time (tag 11).
    /// </summary>
    public static AsduTagNumberOld Time => new(11, AsduTagKind.Primitive);

    /// <summary>
    /// Gets the application tag for Object Identifier (tag 12).
    /// </summary>
    public static AsduTagNumberOld ObjectIdentifier => new(12, AsduTagKind.Primitive);

    /// <summary>
    /// Determines whether two <see cref="AsduTagNumberOld"/> instances are equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if the instances are equal; otherwise, false.</returns>
    public static bool operator ==(AsduTagNumberOld left, AsduTagNumberOld right) => left._value == right._value;

    /// <summary>
    /// Determines whether two <see cref="AsduTagNumberOld"/> instances are not equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>true if the instances are not equal; otherwise, false.</returns>
    public static bool operator !=(AsduTagNumberOld left, AsduTagNumberOld right) => left._value != right._value;

    /// <summary>
    /// Implicitly converts an integer to a context tag with the specified number.
    /// </summary>
    /// <param name="number">The tag number.</param>
    public static implicit operator AsduTagNumberOld(int number) => new(number);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => throw new NotImplementedException();

    /// <inheritdoc/>
    public override int GetHashCode() => _value;

    /// <inheritdoc/>
    public override string ToString() => IsContextClass ? $"[{Value}]" : $"{{Number}}";
}