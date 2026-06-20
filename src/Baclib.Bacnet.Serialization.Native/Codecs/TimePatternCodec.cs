// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class TimePatternCodec : INativeCodec<TimePattern>
{
    private TimePatternCodec()
    {
    }

    public static readonly TimePatternCodec Instance = new();

    public int GetEncodedSize(in TimePattern value) => AsduLength.Sum(ApplicationTagNumber.Time, AsduLength.Time);

    public int GetEncodedSize(byte tagNumber, in TimePattern value) => AsduLength.Sum(tagNumber, AsduLength.Time);

    public void Encode(ref AsduEncoder encoder, in TimePattern value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.Time, AsduLength.Time);
        //NativePrimitives.WriteTime(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in TimePattern value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Time);
        //NativePrimitives.WriteTime(bytes, value);
    }

    public TimePattern Decode(ref NativeReader decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.Time, AsduLength.Time);
        return NativePrimitives.ReadTimePattern(bytes);
    }

    public TimePattern Decode(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Time);
        return NativePrimitives.ReadTimePattern(bytes);
    }

    public Optional<TimePattern> DecodeOptional(ref NativeReader decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.Time, AsduLength.Time);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadTimePattern(bytes);
        }
        return default;
    }

    public Optional<TimePattern> DecodeOptional(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Time);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadTimePattern(bytes);
        }
        return default;
    }
}

