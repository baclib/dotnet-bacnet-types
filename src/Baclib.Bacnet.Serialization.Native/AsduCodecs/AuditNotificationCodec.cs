// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditNotificationCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditNotification>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditNotification>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)2);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditNotification Decode(ref NativeReader reader)
    {
        var _sourceTimestamp = Asdu.DecodeOptionalElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 0);
        var _targetTimestamp = Asdu.DecodeOptionalElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 1);
        var _sourceDevice = Asdu.DecodeConstructed<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader, 2);
        var _sourceObject = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 3);
        var _operation = Asdu.DecodePrimitive<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(ref reader, 4);
        var _sourceComment = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 5);
        var _targetComment = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 6);
        var _invokeId = Asdu.DecodeOptional<Unsigned8Codec, byte>(ref reader, 7);
        var _sourceUserId = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 8);
        var _sourceUserRole = Asdu.DecodeOptional<Unsigned8Codec, byte>(ref reader, 9);
        var _targetDevice = Asdu.DecodeConstructed<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader, 10);
        var _targetObject = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 11);
        var _targetProperty = Asdu.DecodeOptionalElement<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(ref reader, 12);
        var _targetPriority = Asdu.DecodeOptional<AuditNotificationTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditNotification.TTargetPriority>(ref reader, 13);
        var _targetValue = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 14);
        var _currentValue = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 15);
        var _result = Asdu.DecodeOptionalElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 16);

        return new global::Baclib.Bacnet.Types.Application.AuditNotification
        {
            SourceTimestamp = _sourceTimestamp,
            TargetTimestamp = _targetTimestamp,
            SourceDevice = _sourceDevice,
            SourceObject = _sourceObject,
            Operation = _operation,
            SourceComment = _sourceComment,
            TargetComment = _targetComment,
            InvokeId = _invokeId,
            SourceUserId = _sourceUserId,
            SourceUserRole = _sourceUserRole,
            TargetDevice = _targetDevice,
            TargetObject = _targetObject,
            TargetProperty = _targetProperty,
            TargetPriority = _targetPriority,
            TargetValue = _targetValue,
            CurrentValue = _currentValue,
            Result = _result
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditNotification Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditNotification value)
    {
        if (value.SourceTimestamp.HasValue)
        {
            Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 0, value.SourceTimestamp.Value);
        }
        if (value.TargetTimestamp.HasValue)
        {
            Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 1, value.TargetTimestamp.Value);
        }
        Asdu.EncodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, 2, value.SourceDevice);
        if (value.SourceObject.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 3, value.SourceObject.Value);
        }
        Asdu.EncodePrimitive<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(ref writer, 4, value.Operation);
        if (value.SourceComment.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 5, value.SourceComment.Value);
        }
        if (value.TargetComment.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 6, value.TargetComment.Value);
        }
        if (value.InvokeId.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 7, value.InvokeId.Value);
        }
        if (value.SourceUserId.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 8, value.SourceUserId.Value);
        }
        if (value.SourceUserRole.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 9, value.SourceUserRole.Value);
        }
        Asdu.EncodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, 10, value.TargetDevice);
        if (value.TargetObject.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 11, value.TargetObject.Value);
        }
        if (value.TargetProperty.HasValue)
        {
            Asdu.EncodeElement<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(ref writer, 12, value.TargetProperty.Value);
        }
        if (value.TargetPriority.HasValue)
        {
            Asdu.EncodePrimitive<AuditNotificationTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditNotification.TTargetPriority>(ref writer, 13, value.TargetPriority.Value);
        }
        if (value.TargetValue.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 14, value.TargetValue.Value);
        }
        if (value.CurrentValue.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 15, value.CurrentValue.Value);
        }
        if (value.Result.HasValue)
        {
            Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 16, value.Result.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditNotification value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditNotification value)
    {
        return (value.SourceTimestamp.HasValue ? Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(0, value.SourceTimestamp.Value) : 0) + (value.TargetTimestamp.HasValue ? Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(1, value.TargetTimestamp.Value) : 0) + Asdu.GetElementLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(2, value.SourceDevice) + (value.SourceObject.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(3, value.SourceObject.Value) : 0) + Asdu.GetPrimitiveLength<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(4, value.Operation) + (value.SourceComment.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(5, value.SourceComment.Value) : 0) + (value.TargetComment.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(6, value.TargetComment.Value) : 0) + (value.InvokeId.HasValue ? Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(7, value.InvokeId.Value) : 0) + (value.SourceUserId.HasValue ? Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(8, value.SourceUserId.Value) : 0) + (value.SourceUserRole.HasValue ? Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(9, value.SourceUserRole.Value) : 0) + Asdu.GetElementLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(10, value.TargetDevice) + (value.TargetObject.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(11, value.TargetObject.Value) : 0) + (value.TargetProperty.HasValue ? Asdu.GetElementLength<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(12, value.TargetProperty.Value) : 0) + (value.TargetPriority.HasValue ? Asdu.GetPrimitiveLength<AuditNotificationTTargetPriorityCodec, global::Baclib.Bacnet.Types.Application.AuditNotification.TTargetPriority>(13, value.TargetPriority.Value) : 0) + (value.TargetValue.HasValue ? Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(14, value.TargetValue.Value) : 0) + (value.CurrentValue.HasValue ? Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(15, value.CurrentValue.Value) : 0) + (value.Result.HasValue ? Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(16, value.Result.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditNotification value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
