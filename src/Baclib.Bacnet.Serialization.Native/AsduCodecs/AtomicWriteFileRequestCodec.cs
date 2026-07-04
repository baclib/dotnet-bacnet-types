// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileRequestCodec :
    IAsduElementCodec<T::AtomicWriteFileRequest>,
    IAsduConstructedCodec<T::AtomicWriteFileRequest>
{
    public static T::AtomicWriteFileRequest Decode(ref AsduReader reader)
    {
        return new T::AtomicWriteFileRequest
        {
            FileIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            AccessMethod = AsduElement.Decode<AtomicWriteFileRequestTAccessMethodCodec, T::AtomicWriteFileRequest.TAccessMethod>(ref reader)
        };
    }

    public static T::AtomicWriteFileRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicWriteFileRequestCodec, T::AtomicWriteFileRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicWriteFileRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.FileIdentifier);
        AsduElement.Encode<AtomicWriteFileRequestTAccessMethodCodec, T::AtomicWriteFileRequest.TAccessMethod>(ref writer, value.AccessMethod);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicWriteFileRequest value)
        => AsduConstructed.Encode<AtomicWriteFileRequestCodec, T::AtomicWriteFileRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicWriteFileRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.FileIdentifier);
        length += AsduElement.GetEncodedLength<AtomicWriteFileRequestTAccessMethodCodec, T::AtomicWriteFileRequest.TAccessMethod>(value.AccessMethod);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicWriteFileRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicWriteFileRequestCodec, T::AtomicWriteFileRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
