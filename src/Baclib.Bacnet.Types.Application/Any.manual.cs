// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents a BACnet <c>ABSTRACT-SYNTAX.&amp;Type</c> ("Any") value as defined in
/// ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
/// <remarks>
/// An <see cref="Any"/> holds exactly one of two representations:
/// <list type="bullet">
/// <item>
/// raw ASDU bytes (the encoded form of a single element; may be empty), used when the
/// concrete type is unknown, proprietary, or simply not (yet) materialized; or
/// </item>
/// <item>
/// an arbitrary materialized .NET value stored as <see cref="object"/>, used when the
/// concrete value is known at construction time (for example a <c>Real</c> present-value).
/// </item>
/// </list>
/// There is no separate "none" state: an <see cref="Any"/> that carries no materialized
/// value is treated as raw data (possibly of zero length). The materialized value can be
/// inspected via <see cref="Value"/> / <see cref="ValueType"/> regardless of whether it is
/// encodable by the serialization layer.
/// </remarks>
public readonly partial record struct Any
{
    private readonly byte[]? _encoded;
    private readonly object? _value;

    private Any(byte[]? encoded, object? value)
    {
        _encoded = encoded;
        _value = value;
    }

    /// <summary>
    /// Gets an empty <see cref="Any"/> holding zero raw bytes.
    /// </summary>
    public static Any Empty => default;

    /// <summary>
    /// Creates an <see cref="Any"/> from the raw encoded bytes of a single ASDU element.
    /// </summary>
    /// <param name="encoded">The encoded bytes to copy. May be empty.</param>
    public static Any FromEncoded(ReadOnlySpan<byte> encoded)
        => new([.. encoded], null);

    /// <summary>
    /// Creates an <see cref="Any"/> from an arbitrary materialized .NET value.
    /// </summary>
    /// <param name="value">The value to wrap. Must not be <see langword="null"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
    public static Any FromValue(object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new(null, value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance holds a materialized .NET value.
    /// </summary>
    public bool HasValue => _value is not null;

    /// <summary>
    /// Gets a value indicating whether this instance holds raw encoded bytes.
    /// </summary>
    public bool IsEncoded => _value is null;

    /// <summary>
    /// Gets a value indicating whether this instance holds raw bytes of zero length.
    /// </summary>
    public bool IsEmpty => _value is null && (_encoded is null || _encoded.Length == 0);

    /// <summary>
    /// Gets the raw encoded bytes. Returns an empty span when a materialized value is held.
    /// </summary>
    public ReadOnlySpan<byte> RawData => _encoded ?? [];

    /// <summary>
    /// Gets the materialized value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when this instance holds raw encoded bytes instead of a materialized value.
    /// Check <see cref="HasValue"/> or use <see cref="TryGetValue{T}"/> first.
    /// </exception>
    public object Value => _value
        ?? throw new InvalidOperationException(
            "Any holds raw encoded data, not a materialized value.");

    /// <summary>
    /// Gets the runtime type of the materialized value, or <see langword="null"/> when raw
    /// bytes are held.
    /// </summary>
    public Type? ValueType => _value?.GetType();

    /// <summary>
    /// Tries to get the materialized value as <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The expected value type.</typeparam>
    /// <param name="value">The materialized value when it is of type <typeparamref name="T"/>.</param>
    /// <returns><see langword="true"/> if a materialized value of type <typeparamref name="T"/> is present.</returns>
    public bool TryGetValue<T>(out T value)
    {
        if (_value is T typed)
        {
            value = typed;
            return true;
        }

        value = default!;
        return false;
    }

    /// <inheritdoc/>
    public bool Equals(Any other)
    {
        if (_value is not null || other._value is not null)
        {
            return Equals(_value, other._value);
        }

        return RawData.SequenceEqual(other.RawData);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        if (_value is not null)
        {
            return _value.GetHashCode();
        }

        var hash = new HashCode();
        hash.AddBytes(RawData);
        return hash.ToHashCode();
    }
}