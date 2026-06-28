using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Baclib.Bacnet.Types.Application;


/// <summary>
/// Read-only shape for BACnet <c>SEQUENCE OF</c> values.
/// </summary>
/// <typeparam name="T">The item type in the sequence.</typeparam>
public interface ISequenceOf<T> : IReadOnlyList<T>
{
    /// <summary>
    /// Gets a value indicating whether this sequence has no items.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    /// Gets the immutable items backing this sequence.
    /// </summary>
    ImmutableArray<T> Items { get; }
}


/// <summary>
/// Immutable wrapper for BACnet <c>SEQUENCE OF</c> values.
/// </summary>
/// <typeparam name="T">The item type in the sequence.</typeparam>
public readonly struct SequenceOf<T> : IReadOnlyList<T>, IEquatable<SequenceOf<T>>
{
    private readonly ImmutableArray<T> _items;

    /// <inheritdoc />
    public int Count => Items.Length;

    /// <summary>
    /// Gets a value indicating whether this sequence has no items.
    /// </summary>
    public bool IsEmpty => Items.IsEmpty;

    /// <inheritdoc />
    public T this[int index] => Items[index];

    /// <summary>
    /// Gets the immutable items backing this sequence.
    /// </summary>
    public ImmutableArray<T> Items => _items.IsDefault ? ImmutableArray<T>.Empty : _items;

    /// <summary>
    /// Initializes a sequence from an immutable array.
    /// </summary>
    /// <param name="items">The items to wrap.</param>
    public SequenceOf(ImmutableArray<T> items)
    {
        _items = items.IsDefault ? ImmutableArray<T>.Empty : items;
    }

    /// <summary>
    /// Initializes a sequence from an enumerable source.
    /// </summary>
    /// <param name="items">The items to copy.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is <see langword="null"/>.</exception>
    public SequenceOf(IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        _items = [.. items];
    }

    private static readonly SequenceOf<T> _empty = new(ImmutableArray<T>.Empty);

    /// <summary>
    /// Gets an empty sequence.
    /// </summary>
    public static SequenceOf<T> Empty => _empty;

    /// <summary>
    /// Creates a sequence from an enumerable source.
    /// </summary>
    /// <param name="items">The items to copy.</param>
    /// <returns>A new sequence containing the supplied items.</returns>
    public static SequenceOf<T> From(IEnumerable<T> items) => new(items);

    /// <summary>
    /// Creates a sequence from the supplied items.
    /// </summary>
    /// <param name="items">The items to copy.</param>
    /// <returns>A new sequence containing the supplied items.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is <see langword="null"/>.</exception>
    public static SequenceOf<T> Create(params T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        return new([.. items]);
    }

    /// <summary>
    /// Determines whether the sequence contains the specified item.
    /// </summary>
    /// <param name="item">The item to locate.</param>
    /// <returns><see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
    public bool Contains(T item) => Items.Contains(item);

    /// <summary>
    /// Returns the index of the first occurrence of the specified item.
    /// </summary>
    /// <param name="item">The item to locate.</param>
    /// <returns>The zero-based index, or -1 when not found.</returns>
    public int IndexOf(T item) => Items.IndexOf(item);

    /// <summary>
    /// Copies items to a new array.
    /// </summary>
    /// <returns>An array with the sequence items.</returns>
    public T[] ToArray() => Items.ToArray();

    /// <summary>
    /// Returns a value-type enumerator for <c>foreach</c> iteration.
    /// </summary>
    /// <returns>An enumerator over the sequence.</returns>
    public ImmutableArray<T>.Enumerator GetEnumerator() => Items.GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)Items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Items).GetEnumerator();

    /// <summary>
    /// Compares two sequences for item-by-item equality.
    /// </summary>
    /// <param name="other">The other sequence to compare.</param>
    /// <returns><see langword="true"/> when both sequences contain equal items in the same order.</returns>
    public bool Equals(SequenceOf<T> other) => Items.AsSpan().SequenceEqual(other.Items.AsSpan());

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is SequenceOf<T> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode()
    {
        HashCode hash = default;
        foreach (T item in Items)
        {
            hash.Add(item);
        }

        return hash.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString() => $"Count = {Count}";

    /// <summary>
    /// Compares two sequences for equality.
    /// </summary>
    public static bool operator ==(SequenceOf<T> left, SequenceOf<T> right) => left.Equals(right);

    /// <summary>
    /// Compares two sequences for inequality.
    /// </summary>
    public static bool operator !=(SequenceOf<T> left, SequenceOf<T> right) => !left.Equals(right);

    /// <summary>
    /// Converts an immutable array to a sequence wrapper.
    /// </summary>
    public static implicit operator SequenceOf<T>(ImmutableArray<T> items) => new(items);

    /// <summary>
    /// Converts a sequence wrapper to its immutable array.
    /// </summary>
    public static implicit operator ImmutableArray<T>(SequenceOf<T> sequence) => sequence.Items;
}