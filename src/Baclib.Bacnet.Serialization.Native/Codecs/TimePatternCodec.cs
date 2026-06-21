// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class TimePatternCodec : NativeCodecBase<TimePattern>
{
    private TimePatternCodec() : base(ApplicationTagNumber.Time)
    {
    }

    public static readonly TimePatternCodec Instance = new();

    protected override int CalculateValueSize(in TimePattern value) => AsduLength.Time;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in TimePattern value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Time);
        // NativePrimitives.WriteTime(bytes, value);
    }

    protected override TimePattern DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber, AsduLength.Time);
        return NativePrimitives.ReadTimePattern(bytes);
    }

    protected override Optional<TimePattern> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.Time);
        if (!bytes.IsEmpty)
            return NativePrimitives.ReadTimePattern(bytes);
        return default;
    }
}

