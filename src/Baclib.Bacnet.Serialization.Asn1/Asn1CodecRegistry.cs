// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Registry for runtime lookup of ASN.1 codecs by .NET type.
/// Generated code can extend registration via partial method implementation.
/// </summary>
public static partial class Asn1CodecRegistry
{
    private static readonly Dictionary<Type, IAsn1CodecUntyped> s_codecs = CreateRegistry();

    private static Dictionary<Type, IAsn1CodecUntyped> CreateRegistry()
    {
        var codecs = new Dictionary<Type, IAsn1CodecUntyped>();
        RegisterGenerated(codecs);
        return codecs;
    }

    static partial void RegisterGenerated(IDictionary<Type, IAsn1CodecUntyped> codecs);

    public static bool TryGet(Type targetType, out IAsn1CodecUntyped codec)
    {
        ArgumentNullException.ThrowIfNull(targetType);
        return s_codecs.TryGetValue(targetType, out codec!);
    }

    public static IAsn1CodecUntyped Get(Type targetType)
    {
        ArgumentNullException.ThrowIfNull(targetType);

        if (TryGet(targetType, out IAsn1CodecUntyped codec))
        {
            return codec;
        }

        throw new NotSupportedException($"No ASN.1 codec registered for type {targetType.FullName}.");
    }

    public static IAsn1Codec<T> Get<T>()
    {
        var codec = Get(typeof(T));
        if (codec is IAsn1Codec<T> typed)
        {
            return typed;
        }

        throw new NotSupportedException($"Registered codec for type {typeof(T).FullName} is not compatible with IAsn1Codec<{typeof(T).Name}>.");
    }
}
