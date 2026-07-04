// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AssignedAccessRightsCodec :
    IAsduElementCodec<T::AssignedAccessRights>,
    IAsduConstructedCodec<T::AssignedAccessRights>
{
    public static T::AssignedAccessRights Decode(ref AsduReader reader)
    {
        return new T::AssignedAccessRights
        {
            Reference = AsduElement.Decode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref reader, 0),
            Enable = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1)
        };
    }

    public static T::AssignedAccessRights Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AssignedAccessRightsCodec, T::AssignedAccessRights>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AssignedAccessRights value)
    {
        AsduElement.Encode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref writer, 0, value.Reference);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.Enable);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AssignedAccessRights value)
        => AsduConstructed.Encode<AssignedAccessRightsCodec, T::AssignedAccessRights>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AssignedAccessRights value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DeviceObjectReferenceCodec, T::DeviceObjectReference>(0, value.Reference);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.Enable);
        return length;
    }

    public static int GetEncodedLength(in T::AssignedAccessRights value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AssignedAccessRightsCodec, T::AssignedAccessRights>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
