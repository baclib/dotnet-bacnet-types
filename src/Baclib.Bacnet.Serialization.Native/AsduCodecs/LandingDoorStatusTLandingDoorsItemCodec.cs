// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingDoorStatusTLandingDoorsItemCodec :
    IAsduElementCodec<T::LandingDoorStatus.TLandingDoorsItem>,
    IAsduConstructedCodec<T::LandingDoorStatus.TLandingDoorsItem>
{
    public static T::LandingDoorStatus.TLandingDoorsItem Decode(ref AsduReader reader)
    {
        return new T::LandingDoorStatus.TLandingDoorsItem
        {
            FloorNumber = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 0),
            DoorStatus = AsduElement.Decode<DoorStatusCodec, T::DoorStatus>(ref reader, 1)
        };
    }

    public static T::LandingDoorStatus.TLandingDoorsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LandingDoorStatus.TLandingDoorsItem value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 0, value.FloorNumber);
        AsduElement.Encode<DoorStatusCodec, T::DoorStatus>(ref writer, 1, value.DoorStatus);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LandingDoorStatus.TLandingDoorsItem value)
        => AsduConstructed.Encode<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LandingDoorStatus.TLandingDoorsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(0, value.FloorNumber);
        length += AsduElement.GetEncodedLength<DoorStatusCodec, T::DoorStatus>(1, value.DoorStatus);
        return length;
    }

    public static int GetEncodedLength(in T::LandingDoorStatus.TLandingDoorsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LandingDoorStatusTLandingDoorsItemCodec, T::LandingDoorStatus.TLandingDoorsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
