// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AddressBindingCodec :
    IAsduElementCodec<T::AddressBinding>,
    IAsduConstructedCodec<T::AddressBinding>
{
    public static T::AddressBinding Decode(ref AsduReader reader)
    {
        return new T::AddressBinding
        {
            DeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            DeviceAddress = AsduElement.Decode<AddressCodec, T::Address>(ref reader)
        };
    }

    public static T::AddressBinding Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AddressBindingCodec, T::AddressBinding>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AddressBinding value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.DeviceIdentifier);
        AsduElement.Encode<AddressCodec, T::Address>(ref writer, value.DeviceAddress);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AddressBinding value)
        => AsduConstructed.Encode<AddressBindingCodec, T::AddressBinding>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AddressBinding value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<AddressCodec, T::Address>(value.DeviceAddress);
        return length;
    }

    public static int GetEncodedLength(in T::AddressBinding value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AddressBindingCodec, T::AddressBinding>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
