// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationFactorFormatCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat Decode(ref NativeReader reader)
    {
        var _formatType = Asdu.DecodePrimitive<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(ref reader, 0);
        var _vendorId = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 1);
        var _vendorFormat = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat
        {
            FormatType = _formatType,
            VendorId = _vendorId,
            VendorFormat = _vendorFormat
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat value)
    {
        Asdu.EncodePrimitive<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(ref writer, 0, value.FormatType);
        if (value.VendorId.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 1, value.VendorId.Value);
        }
        if (value.VendorFormat.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 2, value.VendorFormat.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat value)
    {
        return Asdu.GetPrimitiveLength<AuthenticationFactorTypeCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactorType>(0, value.FormatType) + (value.VendorId.HasValue ? Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(1, value.VendorId.Value) : 0) + (value.VendorFormat.HasValue ? Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(2, value.VendorFormat.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationFactorFormat value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
