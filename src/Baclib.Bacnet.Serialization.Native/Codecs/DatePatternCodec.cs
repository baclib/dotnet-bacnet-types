// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class DatePatternCodec : INativeCodec<DatePattern>
{
    private DatePatternCodec()
    {
    }

    public static readonly DatePatternCodec Instance = new();

    public int GetEncodedSize(in DatePattern value) => AsduLength.Sum(ApplicationTagNumber.Date, AsduLength.Date);

    public int GetEncodedSize(byte tagNumber, in DatePattern value) => AsduLength.Sum(tagNumber, AsduLength.Date);

    public void Encode(ref AsduEncoder encoder, in DatePattern value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.Date, AsduLength.Date);
        //NativePrimitives.WriteDate(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in DatePattern value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Date);
        //NativePrimitives.WriteDate(bytes, value);
    }

    public DatePattern Decode(ref NativeReader decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.Date, AsduLength.Date);
        return NativePrimitives.ReadDatePattern(bytes);
    }

    public DatePattern Decode(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Date);
        return NativePrimitives.ReadDatePattern(bytes);
    }

    public Optional<DatePattern> DecodeOptional(ref NativeReader decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.Date, AsduLength.Date);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadDatePattern(bytes);
        }
        return default;
    }

    public Optional<DatePattern> DecodeOptional(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Date);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadDatePattern(bytes);
        }
        return default;
    }
}

