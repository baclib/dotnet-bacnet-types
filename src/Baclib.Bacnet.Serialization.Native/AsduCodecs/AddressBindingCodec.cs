// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AddressBindingCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AddressBinding>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AddressBinding>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(ObjectIdentifierCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AddressBinding Decode(ref NativeReader reader)
    {
        var _deviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _deviceAddress = Asdu.DecodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AddressBinding
        {
            DeviceIdentifier = _deviceIdentifier,
            DeviceAddress = _deviceAddress
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AddressBinding Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AddressBinding value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.DeviceIdentifier);
        Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, value.DeviceAddress);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AddressBinding value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AddressBinding value)
    {
        return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.DeviceIdentifier) + Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(value.DeviceAddress);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AddressBinding value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
