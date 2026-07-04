// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryAckCodec :
    IAsduElementCodec<T::AuditLogQueryAck>,
    IAsduConstructedCodec<T::AuditLogQueryAck>
{
    public static T::AuditLogQueryAck Decode(ref AsduReader reader)
    {
        return new T::AuditLogQueryAck
        {
            AuditLog = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            Records = AsduElement.DecodeSequenceOf<AuditLogRecordResultCodec, T::AuditLogRecordResult>(ref reader, 1),
            NoMoreItems = AsduElement.Decode<BooleanCodec, bool>(ref reader, 2)
        };
    }

    public static T::AuditLogQueryAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogQueryAckCodec, T::AuditLogQueryAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogQueryAck value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.AuditLog);
        AsduElement.EncodeSequenceOf<AuditLogRecordResultCodec, T::AuditLogRecordResult>(ref writer, 1, value.Records);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 2, value.NoMoreItems);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogQueryAck value)
        => AsduConstructed.Encode<AuditLogQueryAckCodec, T::AuditLogQueryAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogQueryAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.AuditLog);
        length += AsduElement.GetSequenceOfEncodedLength<AuditLogRecordResultCodec, T::AuditLogRecordResult>(1, value.Records);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(2, value.NoMoreItems);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogQueryAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogQueryAckCodec, T::AuditLogQueryAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
