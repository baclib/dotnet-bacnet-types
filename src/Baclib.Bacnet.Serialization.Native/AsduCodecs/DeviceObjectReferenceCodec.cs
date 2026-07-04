// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceObjectReferenceCodec :
    IAsduElementCodec<T::DeviceObjectReference>,
    IAsduConstructedCodec<T::DeviceObjectReference>
{
    public static T::DeviceObjectReference Decode(ref AsduReader reader)
    {
        return new T::DeviceObjectReference
        {
            DeviceIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1)
        };
    }

    public static T::DeviceObjectReference Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeviceObjectReference value)
    {
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeviceObjectReference value)
        => AsduConstructed.Encode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeviceObjectReference value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.ObjectIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::DeviceObjectReference value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeviceObjectReferenceCodec, T::DeviceObjectReference>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        return reader.PeekContextTag(1);
    }
}
