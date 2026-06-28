// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class IHaveRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.IHaveRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.IHaveRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(ObjectIdentifierCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.IHaveRequest Decode(ref NativeReader reader)
    {
        var _deviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _objectName = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.IHaveRequest
        {
            DeviceIdentifier = _deviceIdentifier,
            ObjectIdentifier = _objectIdentifier,
            ObjectName = _objectName
        };
    }

    public static global::Baclib.Bacnet.Types.Application.IHaveRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.IHaveRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.DeviceIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.ObjectIdentifier);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.ObjectName);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.IHaveRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.IHaveRequest value)
    {
        return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.DeviceIdentifier) + Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.ObjectIdentifier) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.ObjectName);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.IHaveRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
