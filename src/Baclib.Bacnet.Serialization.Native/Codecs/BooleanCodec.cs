// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BooleanCodec : INativeCodec<bool>
{
    private BooleanCodec()
    {
    }

    public static readonly BooleanCodec Instance = new();

    public int GetEncodedSize(in bool value) => AsduLength.Boolean;

    public int GetEncodedSize(byte tagNumber, in bool value) => AsduLength.Sum(tagNumber, AsduLength.Boolean);

    public void Encode(ref AsduEncoder encoder, in bool value)
    {
        encoder.Encode(ApplicationTagNumber.Boolean, value ? 1 : 0);
    }

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in bool value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Boolean);
        AsduEncoder.WriteBoolean(bytes, value);
    }

    private static bool Convert(int value)
    {
        return value switch
        {
            0 => false,
            1 => true,
            _ => throw new AsduException($"Invalid boolean value: {value}")
        };
    }

    public bool Decode(ref NativeReader decoder)
    {
        var value = decoder.DecodeTag(ApplicationTagNumber.Boolean);
        return Convert(value);
    }

    public bool Decode(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Boolean);
        if (bytes.Length != 1)
        {
            throw new AsduException($"Invalid boolean length: {bytes.Length}");
        }
        return Convert(bytes[0]);
    }

    public Optional<bool> DecodeOptional(ref NativeReader decoder)
    {
        if (decoder.DecodeOptionalTag(ApplicationTagNumber.Boolean, out var value))
        {
            return Convert(value);
        }
        return default;
    }

    public Optional<bool> DecodeOptional(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Boolean);
        if (!bytes.IsEmpty)
        {
            if (bytes.Length != 1)
            {
                throw new AsduException($"Invalid boolean length: {bytes.Length}");
            }
            return Convert(bytes[0]);
        }
        return default;
    }
}

