// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Optional typed materialization helpers for <see cref="T.Any"/>.
/// </summary>
public static class AnyMaterializer
{
    /// <summary>
    /// Tries to materialize an <see cref="T.Any"/> as a specific value type.
    /// </summary>
    public static bool TryDecodeAs<TValue>(
        in T.Any any,
        out TValue value,
        AnyCodecRegistry? registry = null)
    {
        if (TryDecodeAs(any, typeof(TValue), out var boxed, registry) && boxed is TValue typed)
        {
            value = typed;
            return true;
        }

        value = default!;
        return false;
    }

    /// <summary>
    /// Tries to materialize an <see cref="T.Any"/> as a runtime-selected value type.
    /// </summary>
    public static bool TryDecodeAs(
        in T.Any any,
        Type valueType,
        out object? value,
        AnyCodecRegistry? registry = null)
    {
        ArgumentNullException.ThrowIfNull(valueType);

        if (!any.IsEncoded)
        {
            var materialized = any.Value;
            if (valueType.IsInstanceOfType(materialized))
            {
                value = materialized;
                return true;
            }

            value = null;
            return false;
        }

        if (TryDecodeStatic(any.EncodedData.Span, valueType, out value))
        {
            return true;
        }

        if (registry is not null && registry.TryGetByType(valueType, out var codec))
        {
            try
            {
                var reader = new AsduReader(any.EncodedData.Span);
                var decoded = codec.Decode(ref reader);
                if (!reader.End)
                {
                    value = null;
                    return false;
                }

                if (!valueType.IsInstanceOfType(decoded))
                {
                    value = null;
                    return false;
                }

                value = decoded;
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        value = null;
        return false;
    }

    private static bool TryDecodeStatic(ReadOnlySpan<byte> encoded, Type valueType, out object? value)
    {
        try
        {
            var reader = new AsduReader(encoded);
            if (!AnyStaticDispatch.TryDecode(ref reader, valueType, out var decoded) || !reader.End)
            {
                value = null;
                return false;
            }

            value = decoded;
            return true;
        }
        catch
        {
            value = null;
            return false;
        }
    }
}
