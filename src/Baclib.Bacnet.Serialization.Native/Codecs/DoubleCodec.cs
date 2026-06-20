// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class DoubleCodec : INativeCodec<double>
{
    private DoubleCodec()
    {
    }

    public static readonly DoubleCodec Instance = new();

    public int GetEncodedSize(in double value) => AsduLength.Sum(ApplicationTagNumber.Double, AsduLength.Double);

    public int GetEncodedSize(byte tagNumber, in double value) => AsduLength.Sum(tagNumber, AsduLength.Double);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in double value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Double);
        AsduEncoder.WriteDouble(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in double value) => Encode(ref encoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in double value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static double Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Double)
        {
            throw new AsduException();
        }

        return NativePrimitives.ReadDouble(bytes);
    }

    public double Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application);

    public double Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<double> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Double)
            {
                throw new AsduException();
            }

            return NativePrimitives.ReadDouble(bytes);
        }

        return default;
    }

    public Optional<double> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application);

    public Optional<double> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

