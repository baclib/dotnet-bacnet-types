// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class NullCodec : NativeCodecBase<Null>
{
    private NullCodec() : base(ApplicationTagNumber.Null)
    {
    }

    public static NullCodec Instance { get; } = new();

    protected override int CalculateValueSize(in Null value) => AsduLength.Null;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in Null value)
    {
        encoder.Encode(tagClass, tagNumber, AsduLength.Null);
    }

    protected override Null DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        decoder.Read(tagClass, tagNumber);
        return Null.Value;
    }

    protected override Optional<Null> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out _))
            return Null.Value;
        return default;
    }
}

