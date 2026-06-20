// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class RealCodec : INativeCodec, INativeCodec<float>
{
    private RealCodec()
    {
    }

    public static readonly RealCodec Instance = new();

    public int GetEncodedSize(in float value) => AsduLength.Sum(ApplicationTagNumber.Real, AsduLength.Real);

    public int GetEncodedSize(byte tagNumber, in float value) => AsduLength.Sum(tagNumber, AsduLength.Real);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in float value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Real);
        AsduEncoder.WriteReal(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in float value) => Encode(ref encoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in float value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static float Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Real)
        {
            throw new AsduException();
        }

        return NativePrimitives.ReadReal(bytes);
    }

    public float Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application);

    public float Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<float> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Real)
            {
                throw new AsduException();
            }

            return NativePrimitives.ReadReal(bytes);
        }

        return default;
    }

    public Optional<float> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application);

    public Optional<float> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);

    /*
    object INativeCodec.Decode(ref NativeReader decoder)
    {
        return Decode(ref decoder);
    }

    object INativeCodec.Decode(ref NativeReader decoder, byte tagNumber)
    {
        return Decode(ref decoder, tagNumber);
    }
    */
}
