// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface ICodec<T>
{
    static abstract T DecodeBasicValue(ref NativeReader reader);

    static abstract T DecodeContextValue(ref NativeReader reader);

    static abstract void EncodeBasicValue(ref NativeWriter writer, in T value);

    static abstract void EncodeContextValue(ref NativeWriter writer, in T value);

    static abstract int GetBasicValueSize(in T value);

    static abstract int GetContextValueSize(in T value);
}

public interface ICodec<TSelf, T> : ICodec<T> where TSelf : ICodec<TSelf, T>
{
    static T ICodec<T>.DecodeContextValue(ref NativeReader reader) => TSelf.DecodeBasicValue(ref reader);

    static void ICodec<T>.EncodeContextValue(ref NativeWriter writer, in T value) => TSelf.EncodeBasicValue(ref writer, in value);

    static int ICodec<T>.GetContextValueSize(in T value) => TSelf.GetBasicValueSize(in value);
}
