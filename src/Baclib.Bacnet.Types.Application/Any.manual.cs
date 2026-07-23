// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents a BACnet <c>ABSTRACT-SYNTAX.&amp;Type</c> (Any) value.
/// </summary>
/// <remarks>
/// This type can hold either:
/// <list type="bullet">
/// <item>
/// <description>Raw ASDU-encoded bytes wrapped in <see cref="AsduEncodedData"/>.</description>
/// </item>
/// <item>
/// <description>A materialized .NET value.</description>
/// </item>
/// </list>
///
/// A default-initialized instance is normalized to <see cref="AsduEncodedData.Empty"/> when
/// accessed via <see cref="Value"/>.
/// </remarks>
public readonly partial record struct Any
{
    private readonly object? _value;

    /// <summary>
    /// Represents raw ASDU-encoded bytes used by <see cref="Any"/>.
    /// </summary>
    /// <param name="source">The source bytes to copy.</param>
    /// <remarks>
    /// The input is defensively copied, and only read-only views are exposed.
    /// </remarks>
    public readonly struct AsduEncodedData(ReadOnlySpan<byte> source)
    {
        /// <summary>
        /// Gets an empty encoded data value.
        /// </summary>
        public static readonly AsduEncodedData Empty = new([]);

        private readonly byte[] _data = source.ToArray();

        /// <summary>
        /// Gets the number of encoded bytes.
        /// </summary>
        public int Length => _data.Length;

        /// <summary>
        /// Gets a read-only span over the encoded bytes.
        /// </summary>
        public ReadOnlySpan<byte> Span => _data;

        /// <summary>
        /// Gets a read-only memory view over the encoded bytes.
        /// </summary>
        public ReadOnlyMemory<byte> Memory => _data;

        /// <summary>
        /// Converts encoded data to a read-only span.
        /// </summary>
        /// <param name="value">The encoded data value.</param>
        public static implicit operator ReadOnlySpan<byte>(AsduEncodedData value) => value.Span;

        /// <summary>
        /// Converts encoded data to read-only memory.
        /// </summary>
        /// <param name="value">The encoded data value.</param>
        public static implicit operator ReadOnlyMemory<byte>(AsduEncodedData value) => value.Memory;
    }

    private Any(object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    /// <summary>
    /// Gets an empty <see cref="Any"/> that carries empty ASDU-encoded bytes.
    /// </summary>
    public static Any Empty => new(AsduEncodedData.Empty);

    /// <summary>
    /// Creates an <see cref="Any"/> from ASDU-encoded bytes.
    /// </summary>
    /// <param name="encoded">The encoded bytes to copy.</param>
    /// <returns>An <see cref="Any"/> containing encoded data.</returns>
    public static Any FromEncoded(ReadOnlySpan<byte> encoded)
        => new(new AsduEncodedData(encoded));

    /// <summary>
    /// Creates an <see cref="Any"/> from a materialized value.
    /// </summary>
    /// <param name="value">The value to store.</param>
    /// <returns>An <see cref="Any"/> containing the provided value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public static Any FromValue(object value)
        => new(value ?? throw new ArgumentNullException(nameof(value)));

    /// <summary>
    /// Gets a value indicating whether this instance currently holds ASDU-encoded bytes.
    /// </summary>
    public bool IsEncoded => Value is AsduEncodedData;

    /// <summary>
    /// Gets the underlying stored value.
    /// </summary>
    /// <remarks>
    /// If this instance is default-initialized, this property returns <see cref="AsduEncodedData.Empty"/>.
    /// </remarks>
    public object Value => _value ?? AsduEncodedData.Empty;

    /// <summary>
    /// Tries to get the stored value as the specified type.
    /// </summary>
    /// <typeparam name="TValue">The requested value type.</typeparam>
    /// <param name="value">When this method returns, contains the typed value if successful; otherwise the default value of <typeparamref name="TValue"/>.</param>
    /// <returns><see langword="true"/> if the stored value is of type <typeparamref name="TValue"/>; otherwise <see langword="false"/>.</returns>
    public bool TryGetValue<TValue>(out TValue value)
    {
        if (Value is TValue typed)
        {
            value = typed;
            return true;
        }

        value = default!;
        return false;
    }

    /// <summary>
    /// Gets the runtime type of the underlying stored value.
    /// </summary>
    public Type ValueType => Value.GetType();

    /// <summary>
    /// Gets the encoded representation when this instance holds ASDU bytes.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when this instance does not carry ASDU-encoded data.</exception>
    public AsduEncodedData EncodedData
        => Value is AsduEncodedData encoded
            ? encoded
            : throw new InvalidOperationException("This instance does not carry ASDU encoded data.");
}
