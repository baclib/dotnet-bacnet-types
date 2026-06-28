// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PortPermissionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.PortPermission>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.PortPermission>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.PortPermission Decode(ref NativeReader reader)
    {
        var _portId = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 0);
        var _enabled = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.PortPermission
        {
            PortId = _portId,
            Enabled = _enabled
        };
    }

    public static global::Baclib.Bacnet.Types.Application.PortPermission Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.PortPermission value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 0, value.PortId);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.Enabled);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.PortPermission value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PortPermission value)
    {
        return Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(0, value.PortId) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.Enabled);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PortPermission value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
