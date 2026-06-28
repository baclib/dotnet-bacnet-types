// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface IAsduElementCodec<T>
{
    static abstract T Decode(ref NativeReader reader);

    static abstract T Decode(ref NativeReader reader, byte tagNumber);

    static abstract void Encode(ref NativeWriter writer, in T value);

    static abstract void Encode(ref NativeWriter writer, byte tagNumber, in T value);

    static abstract int GetLength(in T value);

    static abstract int GetLength(in T value, byte tagNumber);

    static abstract bool Matches(ref NativeReader reader);

    static abstract bool Matches(ref NativeReader reader, byte tagNumber);
}
