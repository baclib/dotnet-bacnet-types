// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersTByTargetCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget Decode(ref NativeReader reader)
    {
        var _targetDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _targetDeviceAddress = Asdu.DecodeOptionalElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 1);
        var _targetObjectIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 2);
        var _targetPropertyIdentifier = Asdu.DecodeOptional<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 3);
        var _targetArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 4);
        var _targetPriority = Asdu.DecodeOptional<AuditLogQueryParametersTByTargetTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget.TTargetPriority>(ref reader, 5);
        var _operations = Asdu.DecodeOptional<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(ref reader, 6);
        var _successfulActionsOnly = Asdu.DecodePrimitive<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(ref reader, 7);

        return new global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget
        {
            TargetDeviceIdentifier = _targetDeviceIdentifier,
            TargetDeviceAddress = _targetDeviceAddress,
            TargetObjectIdentifier = _targetObjectIdentifier,
            TargetPropertyIdentifier = _targetPropertyIdentifier,
            TargetArrayIndex = _targetArrayIndex,
            TargetPriority = _targetPriority,
            Operations = _operations,
            SuccessfulActionsOnly = _successfulActionsOnly
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.TargetDeviceIdentifier);
        if (value.TargetDeviceAddress.HasValue)
        {
            Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 1, value.TargetDeviceAddress.Value);
        }
        if (value.TargetObjectIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 2, value.TargetObjectIdentifier.Value);
        }
        if (value.TargetPropertyIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 3, value.TargetPropertyIdentifier.Value);
        }
        if (value.TargetArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 4, value.TargetArrayIndex.Value);
        }
        if (value.TargetPriority.HasValue)
        {
            Asdu.EncodePrimitive<AuditLogQueryParametersTByTargetTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget.TTargetPriority>(ref writer, 5, value.TargetPriority.Value);
        }
        if (value.Operations.HasValue)
        {
            Asdu.EncodePrimitive<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(ref writer, 6, value.Operations.Value);
        }
        Asdu.EncodePrimitive<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(ref writer, 7, value.SuccessfulActionsOnly);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.TargetDeviceIdentifier) + (value.TargetDeviceAddress.HasValue ? Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(1, value.TargetDeviceAddress.Value) : 0) + (value.TargetObjectIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(2, value.TargetObjectIdentifier.Value) : 0) + (value.TargetPropertyIdentifier.HasValue ? Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(3, value.TargetPropertyIdentifier.Value) : 0) + (value.TargetArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(4, value.TargetArrayIndex.Value) : 0) + (value.TargetPriority.HasValue ? Asdu.GetPrimitiveLength<AuditLogQueryParametersTByTargetTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget.TTargetPriority>(5, value.TargetPriority.Value) : 0) + (value.Operations.HasValue ? Asdu.GetPrimitiveLength<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(6, value.Operations.Value) : 0) + Asdu.GetPrimitiveLength<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(7, value.SuccessfulActionsOnly);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
