// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceAddressProxyTableEntryCodec :
    IAsduElementCodec<T::DeviceAddressProxyTableEntry>,
    IAsduConstructedCodec<T::DeviceAddressProxyTableEntry>
{
    public static T::DeviceAddressProxyTableEntry Decode(ref AsduReader reader)
    {
        return new T::DeviceAddressProxyTableEntry
        {
            Address = AsduElement.Decode<AddressCodec, T::Address>(ref reader, 0),
            IAm = AsduElement.Decode<IAmRequestCodec, T::IAmRequest>(ref reader, 1),
            LastIAmTime = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 2)
        };
    }

    public static T::DeviceAddressProxyTableEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeviceAddressProxyTableEntryCodec, T::DeviceAddressProxyTableEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeviceAddressProxyTableEntry value)
    {
        AsduElement.Encode<AddressCodec, T::Address>(ref writer, 0, value.Address);
        AsduElement.Encode<IAmRequestCodec, T::IAmRequest>(ref writer, 1, value.IAm);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 2, value.LastIAmTime);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeviceAddressProxyTableEntry value)
        => AsduConstructed.Encode<DeviceAddressProxyTableEntryCodec, T::DeviceAddressProxyTableEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeviceAddressProxyTableEntry value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AddressCodec, T::Address>(0, value.Address);
        length += AsduElement.GetEncodedLength<IAmRequestCodec, T::IAmRequest>(1, value.IAm);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(2, value.LastIAmTime);
        return length;
    }

    public static int GetEncodedLength(in T::DeviceAddressProxyTableEntry value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeviceAddressProxyTableEntryCodec, T::DeviceAddressProxyTableEntry>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
