// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class DatePatternCodec : NativeCodecBase<DatePattern>
{
    private DatePatternCodec() : base(ApplicationTagNumber.Date)
    {
    }

    public static readonly DatePatternCodec Instance = new();

    protected override int CalculateValueSize(in DatePattern value) => AsduLength.Date;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in DatePattern value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Date);
        // NativePrimitives.WriteDate(bytes, value);
    }

    protected override DatePattern DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber, AsduLength.Date);
        return NativePrimitives.ReadDatePattern(bytes);
    }

    protected override Optional<DatePattern> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.Date);
        if (!bytes.IsEmpty)
            return NativePrimitives.ReadDatePattern(bytes);
        return default;
    }
}

