// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BooleanCodec : NativeCodecBase<bool>
{
    private BooleanCodec() : base(ApplicationTagNumber.Boolean)
    {
    }

    public static readonly BooleanCodec Instance = new();

    protected override int CalculateValueSize(in bool value) => AsduLength.Boolean;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in bool value)
    {
        if (tagClass == AsduTagClass.Application)
        {
            encoder.Encode(ApplicationTagNumber.Boolean, value ? 1 : 0);
        }
        else
        {
            var bytes = encoder.Encode(tagNumber, AsduLength.Boolean);
            NativeWriter.WriteBoolean(bytes, value);
        }
    }

    protected override bool DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (tagClass == AsduTagClass.Application)
        {
            var value = decoder.DecodeTag(ApplicationTagNumber.Boolean);
            return value switch
            {
                0 => false,
                1 => true,
                _ => throw new AsduException($"Invalid boolean value: {value}")
            };
        }
        else
        {
            var bytes = decoder.Decode(tagNumber, AsduLength.Boolean);
            if (bytes.Length != 1)
                throw new AsduException($"Invalid boolean length: {bytes.Length}");
            return bytes[0] switch
            {
                0 => false,
                1 => true,
                _ => throw new AsduException($"Invalid boolean value: {bytes[0]}")
            };
        }
    }

    protected override Optional<bool> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (tagClass == AsduTagClass.Application)
        {
            if (decoder.DecodeOptionalTag(ApplicationTagNumber.Boolean, out var value))
            {
                return value switch
                {
                    0 => false,
                    1 => true,
                    _ => throw new AsduException($"Invalid boolean value: {value}")
                };
            }
        }
        else
        {
            var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Boolean);
            if (!bytes.IsEmpty)
            {
                if (bytes.Length != 1)
                    throw new AsduException($"Invalid boolean length: {bytes.Length}");
                return bytes[0] switch
                {
                    0 => false,
                    1 => true,
                    _ => throw new AsduException($"Invalid boolean value: {bytes[0]}")
                };
            }
        }
        return default;
    }
}

