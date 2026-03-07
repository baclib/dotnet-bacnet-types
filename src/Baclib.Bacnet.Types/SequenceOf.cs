// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections;

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a generic Sequence-Of value as defined in ANSI/ASHRAE 135-2024 Clause 20.2.17.
/// </summary>
/// <typeparam name="TItem">The type of elements in the series.</typeparam>
public readonly record struct SequenceOf<TItem> : IReadOnlyCollection<TItem>
{
    private readonly TItem[] _items;

    /// <summary>
    /// Gets an empty <see cref="SequenceOf{TItem}"/> instance.
    /// </summary>
    public static SequenceOf<TItem> Default => new([]);

    /// <summary>
    /// Initializes a new instance of the <see cref="SequenceOf{TItem}"/> struct with the specified array.
    /// </summary>
    /// <param name="items">The array to wrap. If null, an empty array is used.</param>
    public SequenceOf(TItem[] items)
    {
        _items = items ?? [];
    }

    /// <summary>
    /// Gets the item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to get.</param>
    /// <returns>The item at the specified index.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when the index is outside the bounds of the series.</exception>
    public TItem this[int index] => _items[index];

    /// <summary>
    /// Gets the number of items in the series.
    /// </summary>
    public int Count => _items.Length;

    /// <summary>
    /// Returns a read-only span over the items for zero-copy access.
    /// </summary>
    /// <returns>A <see cref="ReadOnlySpan{T}"/> that provides zero-copy access to the underlying array.</returns>
    public ReadOnlySpan<TItem> ToSpan() => _items;

    /// <summary>
    /// Returns an enumerator that iterates through the series.
    /// </summary>
    /// <returns>An enumerator for the series.</returns>
    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var item in _items)
        {
            yield return item;
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Determines whether the series contains a specific item.
    /// </summary>
    /// <param name="item">The item to locate in the series.</param>
    /// <returns><see langword="true"/> if the item is found; otherwise, <see langword="false"/>.</returns>
    public bool Contains(TItem item) => Array.IndexOf(_items, item) >= 0;

    /// <summary>
    /// Copies the items of the series to an array, starting at a particular array index.
    /// </summary>
    /// <param name="array">The destination array.</param>
    /// <param name="arrayIndex">The zero-based index in the destination array at which copying begins.</param>
    public void CopyTo(TItem[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    /// <summary>
    /// Searches for the specified item and returns the zero-based index of the first occurrence.
    /// </summary>
    /// <param name="item">The item to locate.</param>
    /// <returns>The zero-based index of the first occurrence of the item, or -1 if not found.</returns>
    public int IndexOf(TItem item) => Array.IndexOf(_items, item);

    /// <summary>
    /// Searches for the specified item and returns the zero-based index of the last occurrence.
    /// </summary>
    /// <param name="item">The item to locate.</param>
    /// <returns>The zero-based index of the last occurrence of the item, or -1 if not found.</returns>
    public int LastIndexOf(TItem item) => Array.LastIndexOf(_items, item);
}
