// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class DoubleCodec : NativeCodecBase<double>
{
    private DoubleCodec() : base(ApplicationTagNumber.Double)
    {
    }

    public static readonly DoubleCodec Instance = new();

    protected override int CalculateValueSize(in double value) => AsduLength.Double;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in double value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Double);
        NativeWriter.WriteDouble(bytes, value);
    }

    protected override double DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Double)
            throw new AsduException();
        return NativePrimitives.ReadDouble(bytes);
    }

    protected override Optional<double> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Double)
                throw new AsduException();
            return NativePrimitives.ReadDouble(bytes);
        }
        return default;
    }
}

