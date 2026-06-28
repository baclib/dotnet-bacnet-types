// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingDoorStatusCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LandingDoorStatus>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LandingDoorStatus>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.LandingDoorStatus Decode(ref NativeReader reader)
    {
        var _landingDoors = Asdu.DecodeSequenceOf<LandingDoorStatusTLandingDoorsTLandingDoorsItemCodec, global::Baclib.Bacnet.Types.Application.LandingDoorStatus.TLandingDoors.TLandingDoorsItem>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.LandingDoorStatus
        {
            LandingDoors = _landingDoors
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LandingDoorStatus Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LandingDoorStatus value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.LandingDoors)
        {
            Asdu.EncodeElement<LandingDoorStatusTLandingDoorsTLandingDoorsItemCodec, global::Baclib.Bacnet.Types.Application.LandingDoorStatus.TLandingDoors.TLandingDoorsItem>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LandingDoorStatus value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingDoorStatus value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.LandingDoors.Items.Sum(static item => Asdu.GetElementLength<LandingDoorStatusTLandingDoorsTLandingDoorsItemCodec, global::Baclib.Bacnet.Types.Application.LandingDoorStatus.TLandingDoors.TLandingDoorsItem>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LandingDoorStatus value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
