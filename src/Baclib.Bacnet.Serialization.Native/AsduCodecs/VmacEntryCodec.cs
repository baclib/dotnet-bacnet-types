// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VmacEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VmacEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VmacEntry>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.VmacEntry Decode(ref NativeReader reader)
    {
        var _virtualMacAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 0);
        var _nativeMacAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.VmacEntry
        {
            VirtualMacAddress = _virtualMacAddress,
            NativeMacAddress = _nativeMacAddress
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VmacEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VmacEntry value)
    {
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 0, value.VirtualMacAddress);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 1, value.NativeMacAddress);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VmacEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VmacEntry value)
    {
        return Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(0, value.VirtualMacAddress) + Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(1, value.NativeMacAddress);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VmacEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
