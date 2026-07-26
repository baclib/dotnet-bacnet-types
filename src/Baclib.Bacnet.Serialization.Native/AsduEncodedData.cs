// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public readonly struct AsduEncodedData
{
    private readonly ReadOnlyMemory<byte> _data;

    public AsduEncodedData(ReadOnlySpan<byte> source)
    {
        _data = source.ToArray();
    }

    public ReadOnlySpan<byte> Span => _data.Span;
}
