// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface IAsduPrimitiveDynamicCodec<T>
{
    T DecodeContents(ReadOnlySpan<byte> source);

    void EncodeContents(Span<byte> destination, in T value);

    int GetEncodedLength(in T value);

    ApplicationTagNumber GetApplicationTagNumber();
}
