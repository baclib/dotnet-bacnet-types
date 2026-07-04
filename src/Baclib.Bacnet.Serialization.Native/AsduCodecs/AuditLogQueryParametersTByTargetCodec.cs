// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersTByTargetCodec :
    IAsduElementCodec<T::AuditLogQueryParameters.TByTarget>,
    IAsduConstructedCodec<T::AuditLogQueryParameters.TByTarget>
{
    public static T::AuditLogQueryParameters.TByTarget Decode(ref AsduReader reader)
    {
        return new T::AuditLogQueryParameters.TByTarget
        {
            TargetDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            TargetDeviceAddress = AsduElement.DecodeOptional<AddressCodec, T::Address>(ref reader, 1),
            TargetObjectIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 2),
            TargetPropertyIdentifier = AsduElement.DecodeOptional<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 3),
            TargetArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 4),
            TargetPriority = AsduElement.DecodeOptional<AuditLogQueryParametersTByTargetTTargetPriorityCodec, T::AuditLogQueryParameters.TByTarget.TTargetPriority>(ref reader, 5),
            Operations = AsduElement.DecodeOptional<AuditOperationFlagsCodec, T::AuditOperationFlags>(ref reader, 6),
            SuccessfulActionsOnly = AsduElement.Decode<SuccessFilterCodec, T::SuccessFilter>(ref reader, 7)
        };
    }

    public static T::AuditLogQueryParameters.TByTarget Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogQueryParametersTByTargetCodec, T::AuditLogQueryParameters.TByTarget>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogQueryParameters.TByTarget value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.TargetDeviceIdentifier);
        AsduElement.EncodeOptional<AddressCodec, T::Address>(ref writer, 1, value.TargetDeviceAddress);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 2, value.TargetObjectIdentifier);
        AsduElement.EncodeOptional<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 3, value.TargetPropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 4, value.TargetArrayIndex);
        AsduElement.EncodeOptional<AuditLogQueryParametersTByTargetTTargetPriorityCodec, T::AuditLogQueryParameters.TByTarget.TTargetPriority>(ref writer, 5, value.TargetPriority);
        AsduElement.EncodeOptional<AuditOperationFlagsCodec, T::AuditOperationFlags>(ref writer, 6, value.Operations);
        AsduElement.Encode<SuccessFilterCodec, T::SuccessFilter>(ref writer, 7, value.SuccessfulActionsOnly);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogQueryParameters.TByTarget value)
        => AsduConstructed.Encode<AuditLogQueryParametersTByTargetCodec, T::AuditLogQueryParameters.TByTarget>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogQueryParameters.TByTarget value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.TargetDeviceIdentifier);
        length += AsduElement.GetOptionalEncodedLength<AddressCodec, T::Address>(1, value.TargetDeviceAddress);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(2, value.TargetObjectIdentifier);
        length += AsduElement.GetOptionalEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(3, value.TargetPropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(4, value.TargetArrayIndex);
        length += AsduElement.GetOptionalEncodedLength<AuditLogQueryParametersTByTargetTTargetPriorityCodec, T::AuditLogQueryParameters.TByTarget.TTargetPriority>(5, value.TargetPriority);
        length += AsduElement.GetOptionalEncodedLength<AuditOperationFlagsCodec, T::AuditOperationFlags>(6, value.Operations);
        length += AsduElement.GetEncodedLength<SuccessFilterCodec, T::SuccessFilter>(7, value.SuccessfulActionsOnly);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogQueryParameters.TByTarget value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogQueryParametersTByTargetCodec, T::AuditLogQueryParameters.TByTarget>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
