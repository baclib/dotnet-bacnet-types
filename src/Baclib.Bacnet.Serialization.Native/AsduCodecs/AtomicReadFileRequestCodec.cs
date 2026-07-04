// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileRequestCodec :
    IAsduElementCodec<T::AtomicReadFileRequest>,
    IAsduConstructedCodec<T::AtomicReadFileRequest>
{
    public static T::AtomicReadFileRequest Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileRequest
        {
            FileIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            AccessMethod = AsduElement.Decode<AtomicReadFileRequestTAccessMethodCodec, T::AtomicReadFileRequest.TAccessMethod>(ref reader)
        };
    }

    public static T::AtomicReadFileRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileRequestCodec, T::AtomicReadFileRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.FileIdentifier);
        AsduElement.Encode<AtomicReadFileRequestTAccessMethodCodec, T::AtomicReadFileRequest.TAccessMethod>(ref writer, value.AccessMethod);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileRequest value)
        => AsduConstructed.Encode<AtomicReadFileRequestCodec, T::AtomicReadFileRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.FileIdentifier);
        length += AsduElement.GetEncodedLength<AtomicReadFileRequestTAccessMethodCodec, T::AtomicReadFileRequest.TAccessMethod>(value.AccessMethod);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileRequestCodec, T::AtomicReadFileRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
