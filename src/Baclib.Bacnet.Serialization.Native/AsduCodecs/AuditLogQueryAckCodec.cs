// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryAck Decode(ref NativeReader reader)
    {
        var _auditLog = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _records = Asdu.DecodeSequenceOf<AuditLogRecordResultCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecordResult>(ref reader, 1);
        var _noMoreItems = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuditLogQueryAck
        {
            AuditLog = _auditLog,
            Records = _records,
            NoMoreItems = _noMoreItems
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryAck value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.AuditLog);
        writer.WriteOpeningTag(1);
        foreach (var item in value.Records)
        {
            Asdu.EncodeElement<AuditLogRecordResultCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecordResult>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 2, value.NoMoreItems);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryAck value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.AuditLog) + (AsduLength.FromTagNumber((byte)1) + (value.Records.Items.Sum(static item => Asdu.GetElementLength<AuditLogRecordResultCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecordResult>(1, item))) + AsduLength.FromTagNumber((byte)1)) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(2, value.NoMoreItems);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
