// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationFactorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationFactor>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationFactor>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationFactor Decode(ref NativeReader reader)
    {
        var _formatType = Asdu.DecodePrimitive<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(ref reader, 0);
        var _formatClass = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _value = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationFactor
        {
            FormatType = _formatType,
            FormatClass = _formatClass,
            Value = _value
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationFactor Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationFactor value)
    {
        Asdu.EncodePrimitive<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(ref writer, 0, value.FormatType);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.FormatClass);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 2, value.Value);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationFactor value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationFactor value)
    {
        return Asdu.GetPrimitiveLength<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(0, value.FormatType) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.FormatClass) + Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(2, value.Value);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationFactor value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
