// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingDoorStatusCodec :
    IAsduElementCodec<T::LandingDoorStatus>,
    IAsduConstructedCodec<T::LandingDoorStatus>
{
    public static T::LandingDoorStatus Decode(ref AsduReader reader)
    {
        return new T::LandingDoorStatus
        {
            LandingDoors = AsduElement.DecodeSequenceOf<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(ref reader, 0)
        };
    }

    public static T::LandingDoorStatus Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LandingDoorStatusCodec, T::LandingDoorStatus>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LandingDoorStatus value)
    {
        AsduElement.EncodeSequenceOf<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(ref writer, 0, value.LandingDoors);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LandingDoorStatus value)
        => AsduConstructed.Encode<LandingDoorStatusCodec, T::LandingDoorStatus>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LandingDoorStatus value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(0, value.LandingDoors);
        return length;
    }

    public static int GetEncodedLength(in T::LandingDoorStatus value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LandingDoorStatusCodec, T::LandingDoorStatus>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
