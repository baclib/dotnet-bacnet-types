// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileRequestTAccessMethodTRecordAccessCodec :
    IAsduElementCodec<T::AtomicReadFileRequest.TAccessMethod.TRecordAccess>,
    IAsduConstructedCodec<T::AtomicReadFileRequest.TAccessMethod.TRecordAccess>
{
    public static T::AtomicReadFileRequest.TAccessMethod.TRecordAccess Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileRequest.TAccessMethod.TRecordAccess
        {
            FileStartRecord = AsduElement.Decode<IntegerCodec, int>(ref reader),
            RequestedRecordCount = AsduElement.Decode<UnsignedCodec, uint>(ref reader)
        };
    }

    public static T::AtomicReadFileRequest.TAccessMethod.TRecordAccess Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileRequestTAccessMethodTRecordAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TRecordAccess>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileRequest.TAccessMethod.TRecordAccess value)
    {
        AsduElement.Encode<IntegerCodec, int>(ref writer, value.FileStartRecord);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.RequestedRecordCount);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileRequest.TAccessMethod.TRecordAccess value)
        => AsduConstructed.Encode<AtomicReadFileRequestTAccessMethodTRecordAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TRecordAccess>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileRequest.TAccessMethod.TRecordAccess value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(value.FileStartRecord);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.RequestedRecordCount);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileRequest.TAccessMethod.TRecordAccess value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileRequestTAccessMethodTRecordAccessCodec, T::AtomicReadFileRequest.TAccessMethod.TRecordAccess>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return IntegerCodec.Matches(ref reader);
    }
}
