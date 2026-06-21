// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class RealCodec : NativeCodecBase<float>
{
    private RealCodec() : base(ApplicationTagNumber.Real)
    {
    }

    public static readonly RealCodec Instance = new();

    protected override int CalculateValueSize(in float value) => AsduLength.Real;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in float value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Real);
        NativeWriter.WriteReal(bytes, value);
    }

    protected override float DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Real)
            throw new AsduException();
        return NativePrimitives.ReadReal(bytes);
    }

    protected override Optional<float> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Real)
                throw new AsduException();
            return NativePrimitives.ReadReal(bytes);
        }
        return default;
    }
}
