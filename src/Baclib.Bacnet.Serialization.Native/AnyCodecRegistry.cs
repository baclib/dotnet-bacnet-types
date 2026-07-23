// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Read-optimized registry for runtime-selected codecs used with <c>Any</c>.
/// </summary>
public sealed class AnyCodecRegistry
{
    private readonly Dictionary<Type, IAnyRuntimeCodec> _byType;
    private readonly IAnyRuntimeCodec[] _probeOrder;

    private AnyCodecRegistry(Dictionary<Type, IAnyRuntimeCodec> byType, IAnyRuntimeCodec[] probeOrder)
    {
        _byType = byType;
        _probeOrder = probeOrder;
    }

    /// <summary>
    /// Gets an empty registry.
    /// </summary>
    public static AnyCodecRegistry Empty { get; } = new([], []);

    /// <summary>
    /// Tries to resolve a runtime codec by CLR value type.
    /// </summary>
    public bool TryGetByType(Type valueType, out IAnyRuntimeCodec codec)
        => _byType.TryGetValue(valueType, out codec!);

    /// <summary>
    /// Tries to resolve the first codec that matches the reader's next element.
    /// </summary>
    public bool TryGetByTag(ref AsduReader reader, out IAnyRuntimeCodec codec)
    {
        for (var i = 0; i < _probeOrder.Length; i++)
        {
            var candidate = _probeOrder[i];
            if (candidate.Matches(ref reader))
            {
                codec = candidate;
                return true;
            }
        }

        codec = default!;
        return false;
    }

    /// <summary>
    /// Creates a mutable builder used to register codecs and build an immutable registry snapshot.
    /// </summary>
    public static Builder CreateBuilder() => new();

    /// <summary>
    /// Builds a registry from a registration callback.
    /// </summary>
    public static AnyCodecRegistry Build(Action<Builder> configure)
    {
        var builder = new Builder();
        configure(builder);
        return builder.Build();
    }

    /// <summary>
    /// Builder for <see cref="AnyCodecRegistry"/>.
    /// </summary>
    public sealed class Builder
    {
        private readonly Dictionary<Type, IAnyRuntimeCodec> _byType = [];
        private readonly List<IAnyRuntimeCodec> _probeOrder = [];

        /// <summary>
        /// Registers a runtime codec.
        /// </summary>
        public Builder Register(IAnyRuntimeCodec codec, bool includeInProbeOrder = true)
        {
            ArgumentNullException.ThrowIfNull(codec);

            if (_byType.ContainsKey(codec.ValueType))
            {
                throw new InvalidOperationException(
                    $"A codec is already registered for type '{codec.ValueType}'.");
            }

            _byType.Add(codec.ValueType, codec);
            if (includeInProbeOrder)
            {
                _probeOrder.Add(codec);
            }

            return this;
        }

        /// <summary>
        /// Registers a static codec.
        /// </summary>
        public Builder RegisterStatic<T, TCodec>(bool includeInProbeOrder = true)
            where TCodec : IAsduElementCodec<T>
            => Register(AnyRuntimeCodecs.FromStatic<T, TCodec>(), includeInProbeOrder);

        /// <summary>
        /// Registers a dynamic codec instance.
        /// </summary>
        public Builder RegisterDynamic<T>(IAsduElementDynamicCodec<T> codec, bool includeInProbeOrder = true)
            => Register(AnyRuntimeCodecs.FromDynamic(codec), includeInProbeOrder);

        /// <summary>
        /// Builds an immutable registry snapshot.
        /// </summary>
        public AnyCodecRegistry Build()
            => new(new(_byType), [.. _probeOrder]);
    }
}
