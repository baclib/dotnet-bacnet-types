// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class XyColorCodec :
    IAsduElementCodec<T::XyColor>,
    IAsduConstructedCodec<T::XyColor>
{
    public static T::XyColor Decode(ref AsduReader reader)
    {
        return new T::XyColor
        {
            XCoordinate = AsduElement.Decode<RealCodec, float>(ref reader),
            YCoordinate = AsduElement.Decode<RealCodec, float>(ref reader)
        };
    }

    public static T::XyColor Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<XyColorCodec, T::XyColor>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::XyColor value)
    {
        AsduElement.Encode<RealCodec, float>(ref writer, value.XCoordinate);
        AsduElement.Encode<RealCodec, float>(ref writer, value.YCoordinate);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::XyColor value)
        => AsduConstructed.Encode<XyColorCodec, T::XyColor>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::XyColor value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RealCodec, float>(value.XCoordinate);
        length += AsduElement.GetEncodedLength<RealCodec, float>(value.YCoordinate);
        return length;
    }

    public static int GetEncodedLength(in T::XyColor value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<XyColorCodec, T::XyColor>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return RealCodec.Matches(ref reader);
    }
}
