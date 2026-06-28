// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersTBySourceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource Decode(ref NativeReader reader)
    {
        var _sourceDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _sourceDeviceAddress = Asdu.DecodeOptionalElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 1);
        var _sourceObjectIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 2);
        var _operations = Asdu.DecodeOptional<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(ref reader, 3);
        var _successfulActionsOnly = Asdu.DecodePrimitive<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource
        {
            SourceDeviceIdentifier = _sourceDeviceIdentifier,
            SourceDeviceAddress = _sourceDeviceAddress,
            SourceObjectIdentifier = _sourceObjectIdentifier,
            Operations = _operations,
            SuccessfulActionsOnly = _successfulActionsOnly
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.SourceDeviceIdentifier);
        if (value.SourceDeviceAddress.HasValue)
        {
            Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 1, value.SourceDeviceAddress.Value);
        }
        if (value.SourceObjectIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 2, value.SourceObjectIdentifier.Value);
        }
        if (value.Operations.HasValue)
        {
            Asdu.EncodePrimitive<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(ref writer, 3, value.Operations.Value);
        }
        Asdu.EncodePrimitive<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(ref writer, 4, value.SuccessfulActionsOnly);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.SourceDeviceIdentifier) + (value.SourceDeviceAddress.HasValue ? Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(1, value.SourceDeviceAddress.Value) : 0) + (value.SourceObjectIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(2, value.SourceObjectIdentifier.Value) : 0) + (value.Operations.HasValue ? Asdu.GetPrimitiveLength<AuditOperationFlagsCodec, global::Baclib.Bacnet.Types.Application.AuditOperationFlags>(3, value.Operations.Value) : 0) + Asdu.GetPrimitiveLength<SuccessFilterCodec, global::Baclib.Bacnet.Types.Application.SuccessFilter>(4, value.SuccessfulActionsOnly);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
