// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest Decode(ref NativeReader reader)
    {
        var _auditLog = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _queryParameters = Asdu.DecodeConstructed<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(ref reader, 1);
        var _startAtSequenceNumber = Asdu.DecodeOptional<Unsigned64Codec, ulong>(ref reader, 2);
        var _requestedCount = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest
        {
            AuditLog = _auditLog,
            QueryParameters = _queryParameters,
            StartAtSequenceNumber = _startAtSequenceNumber,
            RequestedCount = _requestedCount
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.AuditLog);
        Asdu.EncodeElement<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(ref writer, 1, value.QueryParameters);
        if (value.StartAtSequenceNumber.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned64Codec, ulong>(ref writer, 2, value.StartAtSequenceNumber.Value);
        }
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 3, value.RequestedCount);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.AuditLog) + Asdu.GetElementLength<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(1, value.QueryParameters) + (value.StartAtSequenceNumber.HasValue ? Asdu.GetPrimitiveLength<Unsigned64Codec, ulong>(2, value.StartAtSequenceNumber.Value) : 0) + Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(3, value.RequestedCount);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
