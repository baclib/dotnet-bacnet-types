// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Decodes BACnet values from a <see cref="NativeReader"/> by dispatching to the codec
/// registered for the requested .NET type in the provided <see cref="NativeCodecRegistry"/>.
/// </summary>
public sealed class NativeDecoder
{
    private readonly NativeCodecRegistry _registry;

    /// <param name="registry">Registry that maps .NET types to their ASN.1 codecs.</param>
    public NativeDecoder(NativeCodecRegistry registry)
    {
        ArgumentNullException.ThrowIfNull(registry);
        _registry = registry;
    }

    /// <summary>
    /// Decodes a value of type <typeparamref name="T"/> from the current position of <paramref name="reader"/>.
    /// </summary>
    /// <typeparam name="T">The BACnet value type to decode.</typeparam>
    /// <param name="reader">The reader positioned at the start of the encoded value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="NotSupportedException">Thrown when no codec is registered for <typeparamref name="T"/>.</exception>
    public T Decode<T>(ref NativeReader reader)
    {
        if (!_registry.TryGet<T>(out var codec))
        {
            throw new NotSupportedException($"No native codec registered for type '{typeof(T).FullName}'.");
        }
        return codec.Decode(ref reader);
    }
}
