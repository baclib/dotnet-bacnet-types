// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryRequestCodec :
    IAsduElementCodec<T::AuditLogQueryRequest>,
    IAsduConstructedCodec<T::AuditLogQueryRequest>
{
    public static T::AuditLogQueryRequest Decode(ref AsduReader reader)
    {
        return new T::AuditLogQueryRequest
        {
            AuditLog = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            QueryParameters = AsduElement.Decode<AuditLogQueryParametersCodec, T::AuditLogQueryParameters>(ref reader, 1),
            StartAtSequenceNumber = AsduElement.DecodeOptional<Unsigned64Codec, ulong>(ref reader, 2),
            RequestedCount = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 3)
        };
    }

    public static T::AuditLogQueryRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogQueryRequestCodec, T::AuditLogQueryRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogQueryRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.AuditLog);
        AsduElement.Encode<AuditLogQueryParametersCodec, T::AuditLogQueryParameters>(ref writer, 1, value.QueryParameters);
        AsduElement.EncodeOptional<Unsigned64Codec, ulong>(ref writer, 2, value.StartAtSequenceNumber);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 3, value.RequestedCount);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogQueryRequest value)
        => AsduConstructed.Encode<AuditLogQueryRequestCodec, T::AuditLogQueryRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogQueryRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.AuditLog);
        length += AsduElement.GetEncodedLength<AuditLogQueryParametersCodec, T::AuditLogQueryParameters>(1, value.QueryParameters);
        length += AsduElement.GetOptionalEncodedLength<Unsigned64Codec, ulong>(2, value.StartAtSequenceNumber);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(3, value.RequestedCount);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogQueryRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogQueryRequestCodec, T::AuditLogQueryRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
