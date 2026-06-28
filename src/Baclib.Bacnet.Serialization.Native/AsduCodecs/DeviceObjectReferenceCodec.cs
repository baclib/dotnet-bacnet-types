// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceObjectReferenceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DeviceObjectReference>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DeviceObjectReference>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)1);
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceObjectReference Decode(ref NativeReader reader)
    {
        var _deviceIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.DeviceObjectReference
        {
            DeviceIdentifier = _deviceIdentifier,
            ObjectIdentifier = _objectIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceObjectReference Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DeviceObjectReference value)
    {
        if (value.DeviceIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier.Value);
        }
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DeviceObjectReference value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceObjectReference value)
    {
        return (value.DeviceIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.DeviceIdentifier.Value) : 0) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.ObjectIdentifier);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceObjectReference value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
