// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class XyColorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.XyColor>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.XyColor>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(RealCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.XyColor Decode(ref NativeReader reader)
    {
        var _xCoordinate = Asdu.DecodePrimitive<RealCodec, float>(ref reader);
        var _yCoordinate = Asdu.DecodePrimitive<RealCodec, float>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.XyColor
        {
            XCoordinate = _xCoordinate,
            YCoordinate = _yCoordinate
        };
    }

    public static global::Baclib.Bacnet.Types.Application.XyColor Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.XyColor value)
    {
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, value.XCoordinate);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, value.YCoordinate);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.XyColor value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.XyColor value)
    {
        return Asdu.GetEncodedLength<RealCodec, float>(value.XCoordinate) + Asdu.GetEncodedLength<RealCodec, float>(value.YCoordinate);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.XyColor value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
