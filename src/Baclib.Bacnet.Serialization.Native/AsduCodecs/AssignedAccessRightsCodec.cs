// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AssignedAccessRightsCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AssignedAccessRights>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AssignedAccessRights>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AssignedAccessRights Decode(ref NativeReader reader)
    {
        var _reference = Asdu.DecodeConstructed<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref reader, 0);
        var _enable = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.AssignedAccessRights
        {
            Reference = _reference,
            Enable = _enable
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AssignedAccessRights Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AssignedAccessRights value)
    {
        Asdu.EncodeElement<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref writer, 0, value.Reference);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.Enable);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AssignedAccessRights value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AssignedAccessRights value)
    {
        return Asdu.GetElementLength<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(0, value.Reference) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.Enable);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AssignedAccessRights value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
