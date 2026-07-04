// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckTAccessMethodTRecordAccessCodec :
    IAsduElementCodec<T::AtomicReadFileAck.TAccessMethod.TRecordAccess>,
    IAsduConstructedCodec<T::AtomicReadFileAck.TAccessMethod.TRecordAccess>
{
    public static T::AtomicReadFileAck.TAccessMethod.TRecordAccess Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileAck.TAccessMethod.TRecordAccess
        {
            FileStartRecord = AsduElement.Decode<IntegerCodec, int>(ref reader),
            ReturnedRecordCount = AsduElement.Decode<UnsignedCodec, uint>(ref reader),
            FileRecordData = AsduElement.DecodeSequenceOf<OctetStringCodec, T::OctetString>(ref reader)
        };
    }

    public static T::AtomicReadFileAck.TAccessMethod.TRecordAccess Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileAckTAccessMethodTRecordAccessCodec, T::AtomicReadFileAck.TAccessMethod.TRecordAccess>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileAck.TAccessMethod.TRecordAccess value)
    {
        AsduElement.Encode<IntegerCodec, int>(ref writer, value.FileStartRecord);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.ReturnedRecordCount);
        AsduElement.EncodeSequenceOf<OctetStringCodec, T::OctetString>(ref writer, value.FileRecordData);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileAck.TAccessMethod.TRecordAccess value)
        => AsduConstructed.Encode<AtomicReadFileAckTAccessMethodTRecordAccessCodec, T::AtomicReadFileAck.TAccessMethod.TRecordAccess>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileAck.TAccessMethod.TRecordAccess value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(value.FileStartRecord);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.ReturnedRecordCount);
        length += AsduElement.GetSequenceOfEncodedLength<OctetStringCodec, T::OctetString>(value.FileRecordData);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileAck.TAccessMethod.TRecordAccess value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileAckTAccessMethodTRecordAccessCodec, T::AtomicReadFileAck.TAccessMethod.TRecordAccess>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return IntegerCodec.Matches(ref reader);
    }
}
