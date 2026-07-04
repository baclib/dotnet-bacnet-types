// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VmacEntryCodec :
    IAsduElementCodec<T::VmacEntry>,
    IAsduConstructedCodec<T::VmacEntry>
{
    public static T::VmacEntry Decode(ref AsduReader reader)
    {
        return new T::VmacEntry
        {
            VirtualMacAddress = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 0),
            NativeMacAddress = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 1)
        };
    }

    public static T::VmacEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VmacEntryCodec, T::VmacEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VmacEntry value)
    {
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 0, value.VirtualMacAddress);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 1, value.NativeMacAddress);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VmacEntry value)
        => AsduConstructed.Encode<VmacEntryCodec, T::VmacEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VmacEntry value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(0, value.VirtualMacAddress);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(1, value.NativeMacAddress);
        return length;
    }

    public static int GetEncodedLength(in T::VmacEntry value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VmacEntryCodec, T::VmacEntry>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
