// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeleteObjectRequestCodec :
    IAsduElementCodec<T::DeleteObjectRequest>,
    IAsduConstructedCodec<T::DeleteObjectRequest>
{
    public static T::DeleteObjectRequest Decode(ref AsduReader reader)
    {
        return new T::DeleteObjectRequest
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader)
        };
    }

    public static T::DeleteObjectRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeleteObjectRequestCodec, T::DeleteObjectRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeleteObjectRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.ObjectIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeleteObjectRequest value)
        => AsduConstructed.Encode<DeleteObjectRequestCodec, T::DeleteObjectRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeleteObjectRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.ObjectIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::DeleteObjectRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeleteObjectRequestCodec, T::DeleteObjectRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
