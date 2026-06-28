// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

/// <summary>
/// Top-level wrapper for a BACnet <c>SEQUENCE OF</c> GetAlarmSummary-ACK items.
/// </summary>
public sealed partial record class GetAlarmSummaryAck :
    ISequenceOf<GetAlarmSummaryAck.TItem>,
    IEquatable<GetAlarmSummaryAck>
{
    private readonly SequenceOf<TItem> _value;

    /// <summary>
    /// Initializes the wrapper from an existing <see cref="SequenceOf{T}"/> value.
    /// </summary>
    /// <param name="value">The sequence value to wrap.</param>
    public GetAlarmSummaryAck(SequenceOf<TItem> value)
    {
        _value = value;
    }

    /// <summary>
    /// Initializes the wrapper from enumerable GetAlarmSummary-ACK items.
    /// </summary>
    /// <param name="items">The items to copy into the wrapper sequence.</param>
    public GetAlarmSummaryAck(IEnumerable<TItem> items)
    {
        _value = new SequenceOf<TItem>(items);
    }

    /// <inheritdoc />
    public int Count => _value.Count;

    /// <inheritdoc />
    public bool IsEmpty => _value.IsEmpty;

    /// <inheritdoc />
    public TItem this[int index] => _value[index];

    /// <inheritdoc />
    public ImmutableArray<TItem> Items => _value.Items;

    /// <summary>
    /// Returns a value-type enumerator for <c>foreach</c> iteration.
    /// </summary>
    /// <returns>An enumerator over the sequence items.</returns>
    public ImmutableArray<TItem>.Enumerator GetEnumerator() => _value.GetEnumerator();

    IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() => ((IEnumerable<TItem>)Items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Items).GetEnumerator();

    /// <summary>
    /// Compares two wrappers for sequence-value equality.
    /// </summary>
    /// <param name="other">The other wrapper instance to compare.</param>
    /// <returns><see langword="true"/> when both wrappers contain equal items in the same order.</returns>
    public bool Equals(GetAlarmSummaryAck? other) => other is not null && _value.Equals(other._value);

    // public override bool Equals(object? obj) => obj is GetAlarmSummaryAck other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => _value.GetHashCode();

    /// <summary>
    /// Converts a sequence value to the wrapper type.
    /// </summary>
    /// <param name="value">The sequence value to wrap.</param>
    public static implicit operator GetAlarmSummaryAck(SequenceOf<TItem> value) => new(value);

    /// <summary>
    /// Converts the wrapper back to the underlying sequence value.
    /// </summary>
    /// <param name="value">The wrapper value.</param>
    public static implicit operator SequenceOf<TItem>(GetAlarmSummaryAck value) => value._value;
}

