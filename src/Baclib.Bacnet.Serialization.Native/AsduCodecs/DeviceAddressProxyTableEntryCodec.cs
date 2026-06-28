// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceAddressProxyTableEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry Decode(ref NativeReader reader)
    {
        var _address = Asdu.DecodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 0);
        var _iAm = Asdu.DecodeConstructed<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(ref reader, 1);
        var _lastIAmTime = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry
        {
            Address = _address,
            IAm = _iAm,
            LastIAmTime = _lastIAmTime
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry value)
    {
        Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 0, value.Address);
        Asdu.EncodeElement<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(ref writer, 1, value.IAm);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.LastIAmTime);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry value)
    {
        return Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(0, value.Address) + Asdu.GetElementLength<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(1, value.IAm) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.LastIAmTime);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceAddressProxyTableEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
