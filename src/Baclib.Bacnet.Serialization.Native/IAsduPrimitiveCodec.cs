// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface IAsduPrimitiveCodec<T>
{
    static abstract T DecodeValue(ReadOnlySpan<byte> source);

    static abstract void EncodeValue(Span<byte> destination, in T value);

    static abstract int GetEncodedValueLength(in T value);

    static abstract ApplicationTagNumber TagNumber { get; }
}
