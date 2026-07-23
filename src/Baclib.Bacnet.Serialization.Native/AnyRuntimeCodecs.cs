// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Helpers and adapters that expose static or dynamic codecs as runtime-erased codecs.
/// </summary>
public static class AnyRuntimeCodecs
{
    /// <summary>
    /// Creates a runtime codec wrapper for a static codec.
    /// </summary>
    public static IAnyRuntimeCodec FromStatic<T, TCodec>()
        where TCodec : IAsduElementCodec<T>
        => new StaticRuntimeCodec<T, TCodec>();

    /// <summary>
    /// Creates a runtime codec wrapper for an instance-based dynamic codec.
    /// </summary>
    public static IAnyRuntimeCodec FromDynamic<T>(IAsduElementDynamicCodec<T> codec)
        => new DynamicRuntimeCodec<T>(codec);

    private sealed class StaticRuntimeCodec<T, TCodec> : IAnyRuntimeCodec
        where TCodec : IAsduElementCodec<T>
    {
        public Type ValueType => typeof(T);

        public bool Matches(ref AsduReader reader)
            => TCodec.Matches(ref reader);

        public object Decode(ref AsduReader reader)
            => TCodec.Decode(ref reader)!;

        public void Encode(ref AsduWriter writer, object value)
            => TCodec.Encode(ref writer, (T)value);

        public int GetEncodedLength(object value)
            => TCodec.GetEncodedLength((T)value);
    }

    private sealed class DynamicRuntimeCodec<T>(IAsduElementDynamicCodec<T> codec) : IAnyRuntimeCodec
    {
        public Type ValueType => typeof(T);

        public bool Matches(ref AsduReader reader)
            => codec.Matches(ref reader);

        public object Decode(ref AsduReader reader)
            => codec.Decode(ref reader)!;

        public void Encode(ref AsduWriter writer, object value)
            => codec.Encode(ref writer, (T)value);

        public int GetEncodedLength(object value)
            => codec.GetLength((T)value);
    }
}
