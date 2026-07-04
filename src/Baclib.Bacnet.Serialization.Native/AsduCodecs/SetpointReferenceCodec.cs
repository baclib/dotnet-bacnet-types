// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SetpointReferenceCodec :
    IAsduElementCodec<T::SetpointReference>,
    IAsduConstructedCodec<T::SetpointReference>
{
    public static T::SetpointReference Decode(ref AsduReader reader)
    {
        return new T::SetpointReference
        {
            Reference = AsduElement.DecodeOptional<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref reader, 0)
        };
    }

    public static T::SetpointReference Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SetpointReferenceCodec, T::SetpointReference>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SetpointReference value)
    {
        AsduElement.EncodeOptional<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref writer, 0, value.Reference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SetpointReference value)
        => AsduConstructed.Encode<SetpointReferenceCodec, T::SetpointReference>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SetpointReference value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(0, value.Reference);
        return length;
    }

    public static int GetEncodedLength(in T::SetpointReference value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SetpointReferenceCodec, T::SetpointReference>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
