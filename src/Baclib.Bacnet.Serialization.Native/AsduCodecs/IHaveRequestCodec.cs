// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class IHaveRequestCodec :
    IAsduElementCodec<T::IHaveRequest>,
    IAsduConstructedCodec<T::IHaveRequest>
{
    public static T::IHaveRequest Decode(ref AsduReader reader)
    {
        return new T::IHaveRequest
        {
            DeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            ObjectName = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader)
        };
    }

    public static T::IHaveRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<IHaveRequestCodec, T::IHaveRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::IHaveRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.DeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.ObjectIdentifier);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.ObjectName);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::IHaveRequest value)
        => AsduConstructed.Encode<IHaveRequestCodec, T::IHaveRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::IHaveRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.ObjectName);
        return length;
    }

    public static int GetEncodedLength(in T::IHaveRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<IHaveRequestCodec, T::IHaveRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
