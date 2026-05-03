// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1;

public ref struct AsduPrimitivesReader
{
    private readonly ReadOnlySpan<byte> _span;
    private int _position;

    public AsduPrimitivesReader(ReadOnlySpan<byte> span)
    {
        _span = span;
        _position = 0;
    }

    public int Remaining => _span.Length - _position;

    public ReadOnlySpan<byte> ReadBytes(int count)
    {
        BinaryException.ThrowIfNegative(count, nameof(count));

        ReadOnlySpan<byte> value = _span.Slice(_position, count);
        _position += count;
        return value;
    }

    public bool IsEndOfSpan => _position >= _span.Length;
}
