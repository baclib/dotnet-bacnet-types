// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class YouAreRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.YouAreRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.YouAreRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned16Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.YouAreRequest Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader);
        var _modelName = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
        var _serialNumber = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
        var _deviceIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _deviceMacAddress = Asdu.DecodeOptional<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.YouAreRequest
        {
            VendorId = _vendorId,
            ModelName = _modelName,
            SerialNumber = _serialNumber,
            DeviceIdentifier = _deviceIdentifier,
            DeviceMacAddress = _deviceMacAddress
        };
    }

    public static global::Baclib.Bacnet.Types.Application.YouAreRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.YouAreRequest value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, value.VendorId);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.ModelName);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.SerialNumber);
        if (value.DeviceIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.DeviceIdentifier.Value);
        }
        if (value.DeviceMacAddress.HasValue)
        {
            Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.DeviceMacAddress.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.YouAreRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.YouAreRequest value)
    {
        return Asdu.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.ModelName) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.SerialNumber) + (value.DeviceIdentifier.HasValue ? Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.DeviceIdentifier.Value) : 0) + (value.DeviceMacAddress.HasValue ? Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.DeviceMacAddress.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.YouAreRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
