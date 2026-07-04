// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class IAmRequestCodec :
    IAsduElementCodec<T::IAmRequest>,
    IAsduConstructedCodec<T::IAmRequest>
{
    public static T::IAmRequest Decode(ref AsduReader reader)
    {
        return new T::IAmRequest
        {
            IAmDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            MaxApduLengthAccepted = AsduElement.Decode<UnsignedCodec, uint>(ref reader),
            SegmentationSupported = AsduElement.Decode<SegmentationCodec, T::Segmentation>(ref reader),
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader)
        };
    }

    public static T::IAmRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<IAmRequestCodec, T::IAmRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::IAmRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.IAmDeviceIdentifier);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.MaxApduLengthAccepted);
        AsduElement.Encode<SegmentationCodec, T::Segmentation>(ref writer, value.SegmentationSupported);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, value.VendorId);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::IAmRequest value)
        => AsduConstructed.Encode<IAmRequestCodec, T::IAmRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::IAmRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.IAmDeviceIdentifier);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.MaxApduLengthAccepted);
        length += AsduElement.GetEncodedLength<SegmentationCodec, T::Segmentation>(value.SegmentationSupported);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId);
        return length;
    }

    public static int GetEncodedLength(in T::IAmRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<IAmRequestCodec, T::IAmRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
