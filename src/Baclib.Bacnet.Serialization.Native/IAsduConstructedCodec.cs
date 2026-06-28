// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface IAsduConstructedCodec<T>
{
    static abstract T Decode(ref NativeReader reader);

    static abstract void Encode(ref NativeWriter writer, in T value);

    static abstract int GetLength(in T value);

    static abstract bool Matches(ref NativeReader reader);
}
