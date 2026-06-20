// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public sealed class NativeCodecRegistry
{
    private readonly Dictionary<Type, INativeCodec> _codecs = [];

    public void Register<T>(INativeCodec<T> codec)
    {
        ArgumentNullException.ThrowIfNull(codec);
        _codecs[typeof(T)] = codec;
    }

    public bool TryGet<T>(out INativeCodec<T> codec)
    {
        if (_codecs.TryGetValue(typeof(T), out var foundCodec) && foundCodec is INativeCodec<T> typedCodec)
        {
            codec = typedCodec;
            return true;
        }
        codec = default!;
        return false;
    }

    public INativeCodec<T> Get<T>()
    {
        if (!_codecs.TryGetValue(typeof(T), out var codec))
        {
            throw new NotSupportedException($"No native codec registered for type '{typeof(T).FullName}'.");
        }
        return (INativeCodec<T>)codec;
    }
}
