// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckTAccessMethodTStreamAccessCodec :
    IAsduElementCodec<T::AtomicReadFileAck.TAccessMethod.TStreamAccess>,
    IAsduConstructedCodec<T::AtomicReadFileAck.TAccessMethod.TStreamAccess>
{
    public static T::AtomicReadFileAck.TAccessMethod.TStreamAccess Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileAck.TAccessMethod.TStreamAccess
        {
            FileStartPosition = AsduElement.Decode<IntegerCodec, int>(ref reader),
            FileData = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader)
        };
    }

    public static T::AtomicReadFileAck.TAccessMethod.TStreamAccess Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileAckTAccessMethodTStreamAccessCodec, T::AtomicReadFileAck.TAccessMethod.TStreamAccess>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileAck.TAccessMethod.TStreamAccess value)
    {
        AsduElement.Encode<IntegerCodec, int>(ref writer, value.FileStartPosition);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, value.FileData);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileAck.TAccessMethod.TStreamAccess value)
        => AsduConstructed.Encode<AtomicReadFileAckTAccessMethodTStreamAccessCodec, T::AtomicReadFileAck.TAccessMethod.TStreamAccess>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileAck.TAccessMethod.TStreamAccess value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(value.FileStartPosition);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(value.FileData);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileAck.TAccessMethod.TStreamAccess value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileAckTAccessMethodTStreamAccessCodec, T::AtomicReadFileAck.TAccessMethod.TStreamAccess>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return IntegerCodec.Matches(ref reader);
    }
}
