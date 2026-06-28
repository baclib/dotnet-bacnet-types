// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class IAmRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.IAmRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.IAmRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(ObjectIdentifierCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.IAmRequest Decode(ref NativeReader reader)
    {
        var _iAmDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _maxApduLengthAccepted = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader);
        var _segmentationSupported = Asdu.DecodePrimitive<SegmentationCodec, global::Baclib.Bacnet.Types.Application.Segmentation>(ref reader);
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.IAmRequest
        {
            IAmDeviceIdentifier = _iAmDeviceIdentifier,
            MaxApduLengthAccepted = _maxApduLengthAccepted,
            SegmentationSupported = _segmentationSupported,
            VendorId = _vendorId
        };
    }

    public static global::Baclib.Bacnet.Types.Application.IAmRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.IAmRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.IAmDeviceIdentifier);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, value.MaxApduLengthAccepted);
        Asdu.EncodePrimitive<SegmentationCodec, global::Baclib.Bacnet.Types.Application.Segmentation>(ref writer, value.SegmentationSupported);
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, value.VendorId);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.IAmRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.IAmRequest value)
    {
        return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.IAmDeviceIdentifier) + Asdu.GetEncodedLength<UnsignedCodec, uint>(value.MaxApduLengthAccepted) + Asdu.GetEncodedLength<SegmentationCodec, global::Baclib.Bacnet.Types.Application.Segmentation>(value.SegmentationSupported) + Asdu.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.IAmRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
