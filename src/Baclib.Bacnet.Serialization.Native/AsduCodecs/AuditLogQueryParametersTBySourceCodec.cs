// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersTBySourceCodec :
    IAsduElementCodec<T::AuditLogQueryParameters.TBySource>,
    IAsduConstructedCodec<T::AuditLogQueryParameters.TBySource>
{
    public static T::AuditLogQueryParameters.TBySource Decode(ref AsduReader reader)
    {
        return new T::AuditLogQueryParameters.TBySource
        {
            SourceDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            SourceDeviceAddress = AsduElement.DecodeOptional<AddressCodec, T::Address>(ref reader, 1),
            SourceObjectIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 2),
            Operations = AsduElement.DecodeOptional<AuditOperationFlagsCodec, T::AuditOperationFlags>(ref reader, 3),
            SuccessfulActionsOnly = AsduElement.Decode<SuccessFilterCodec, T::SuccessFilter>(ref reader, 4)
        };
    }

    public static T::AuditLogQueryParameters.TBySource Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogQueryParametersTBySourceCodec, T::AuditLogQueryParameters.TBySource>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogQueryParameters.TBySource value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.SourceDeviceIdentifier);
        AsduElement.EncodeOptional<AddressCodec, T::Address>(ref writer, 1, value.SourceDeviceAddress);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 2, value.SourceObjectIdentifier);
        AsduElement.EncodeOptional<AuditOperationFlagsCodec, T::AuditOperationFlags>(ref writer, 3, value.Operations);
        AsduElement.Encode<SuccessFilterCodec, T::SuccessFilter>(ref writer, 4, value.SuccessfulActionsOnly);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogQueryParameters.TBySource value)
        => AsduConstructed.Encode<AuditLogQueryParametersTBySourceCodec, T::AuditLogQueryParameters.TBySource>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogQueryParameters.TBySource value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.SourceDeviceIdentifier);
        length += AsduElement.GetOptionalEncodedLength<AddressCodec, T::Address>(1, value.SourceDeviceAddress);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(2, value.SourceObjectIdentifier);
        length += AsduElement.GetOptionalEncodedLength<AuditOperationFlagsCodec, T::AuditOperationFlags>(3, value.Operations);
        length += AsduElement.GetEncodedLength<SuccessFilterCodec, T::SuccessFilter>(4, value.SuccessfulActionsOnly);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogQueryParameters.TBySource value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogQueryParametersTBySourceCodec, T::AuditLogQueryParameters.TBySource>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
