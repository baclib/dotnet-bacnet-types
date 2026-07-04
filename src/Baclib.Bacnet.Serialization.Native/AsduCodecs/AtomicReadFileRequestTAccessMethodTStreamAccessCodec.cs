// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileRequestTAccessMethodTStreamAccessCodec :
    IAsduElementCodec<T::AtomicReadFileRequest.TAccessMethod.TStreamAccess>,
    IAsduConstructedCodec<T::AtomicReadFileRequest.TAccessMethod.TStreamAccess>
{
    public static T::AtomicReadFileRequest.TAccessMethod.TStreamAccess Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileRequest.TAccessMethod.TStreamAccess
        {
            FileStartPosition = AsduElement.Decode<IntegerCodec, int>(ref reader),
            RequestedOctetCount = AsduElement.Decode<UnsignedCodec, uint>(ref reader)
        };
    }

    public static T::AtomicReadFileRequest.TAccessMethod.TStreamAccess Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileRequestTAccessMethodTStreamAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TStreamAccess>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
    {
        AsduElement.Encode<IntegerCodec, int>(ref writer, value.FileStartPosition);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.RequestedOctetCount);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
        => AsduConstructed.Encode<AtomicReadFileRequestTAccessMethodTStreamAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TStreamAccess>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(value.FileStartPosition);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.RequestedOctetCount);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileRequest.TAccessMethod.TStreamAccess value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileRequestTAccessMethodTStreamAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TStreamAccess>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return IntegerCodec.Matches(ref reader);
    }
}
