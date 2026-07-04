// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditNotificationCodec :
    IAsduElementCodec<T::AuditNotification>,
    IAsduConstructedCodec<T::AuditNotification>
{
    public static T::AuditNotification Decode(ref AsduReader reader)
    {
        return new T::AuditNotification
        {
            SourceTimestamp = AsduElement.DecodeOptional<TimeStampCodec, T::TimeStamp>(ref reader, 0),
            TargetTimestamp = AsduElement.DecodeOptional<TimeStampCodec, T::TimeStamp>(ref reader, 1),
            SourceDevice = AsduElement.Decode<RecipientCodec, T::Recipient>(ref reader, 2),
            SourceObject = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 3),
            Operation = AsduElement.Decode<AuditOperationCodec, T::AuditOperation>(ref reader, 4),
            SourceComment = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 5),
            TargetComment = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 6),
            InvokeId = AsduElement.DecodeOptional<Unsigned8Codec, byte>(ref reader, 7),
            SourceUserId = AsduElement.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 8),
            SourceUserRole = AsduElement.DecodeOptional<Unsigned8Codec, byte>(ref reader, 9),
            TargetDevice = AsduElement.Decode<RecipientCodec, T::Recipient>(ref reader, 10),
            TargetObject = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 11),
            TargetProperty = AsduElement.DecodeOptional<PropertyReferenceCodec, T::PropertyReference>(ref reader, 12),
            TargetPriority = AsduElement.DecodeOptional<AuditNotificationTTargetPriorityCodec, T::AuditNotification.TTargetPriority>(ref reader, 13),
            TargetValue = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader, 14),
            CurrentValue = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader, 15),
            Result = AsduElement.DecodeOptional<ErrorCodec, T::Error>(ref reader, 16)
        };
    }

    public static T::AuditNotification Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditNotificationCodec, T::AuditNotification>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditNotification value)
    {
        AsduElement.EncodeOptional<TimeStampCodec, T::TimeStamp>(ref writer, 0, value.SourceTimestamp);
        AsduElement.EncodeOptional<TimeStampCodec, T::TimeStamp>(ref writer, 1, value.TargetTimestamp);
        AsduElement.Encode<RecipientCodec, T::Recipient>(ref writer, 2, value.SourceDevice);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 3, value.SourceObject);
        AsduElement.Encode<AuditOperationCodec, T::AuditOperation>(ref writer, 4, value.Operation);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 5, value.SourceComment);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 6, value.TargetComment);
        AsduElement.EncodeOptional<Unsigned8Codec, byte>(ref writer, 7, value.InvokeId);
        AsduElement.EncodeOptional<Unsigned16Codec, ushort>(ref writer, 8, value.SourceUserId);
        AsduElement.EncodeOptional<Unsigned8Codec, byte>(ref writer, 9, value.SourceUserRole);
        AsduElement.Encode<RecipientCodec, T::Recipient>(ref writer, 10, value.TargetDevice);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 11, value.TargetObject);
        AsduElement.EncodeOptional<PropertyReferenceCodec, T::PropertyReference>(ref writer, 12, value.TargetProperty);
        AsduElement.EncodeOptional<AuditNotificationTTargetPriorityCodec, T::AuditNotification.TTargetPriority>(ref writer, 13, value.TargetPriority);
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, 14, value.TargetValue);
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, 15, value.CurrentValue);
        AsduElement.EncodeOptional<ErrorCodec, T::Error>(ref writer, 16, value.Result);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditNotification value)
        => AsduConstructed.Encode<AuditNotificationCodec, T::AuditNotification>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditNotification value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<TimeStampCodec, T::TimeStamp>(0, value.SourceTimestamp);
        length += AsduElement.GetOptionalEncodedLength<TimeStampCodec, T::TimeStamp>(1, value.TargetTimestamp);
        length += AsduElement.GetEncodedLength<RecipientCodec, T::Recipient>(2, value.SourceDevice);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(3, value.SourceObject);
        length += AsduElement.GetEncodedLength<AuditOperationCodec, T::AuditOperation>(4, value.Operation);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(5, value.SourceComment);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(6, value.TargetComment);
        length += AsduElement.GetOptionalEncodedLength<Unsigned8Codec, byte>(7, value.InvokeId);
        length += AsduElement.GetOptionalEncodedLength<Unsigned16Codec, ushort>(8, value.SourceUserId);
        length += AsduElement.GetOptionalEncodedLength<Unsigned8Codec, byte>(9, value.SourceUserRole);
        length += AsduElement.GetEncodedLength<RecipientCodec, T::Recipient>(10, value.TargetDevice);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(11, value.TargetObject);
        length += AsduElement.GetOptionalEncodedLength<PropertyReferenceCodec, T::PropertyReference>(12, value.TargetProperty);
        length += AsduElement.GetOptionalEncodedLength<AuditNotificationTTargetPriorityCodec, T::AuditNotification.TTargetPriority>(13, value.TargetPriority);
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(14, value.TargetValue);
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(15, value.CurrentValue);
        length += AsduElement.GetOptionalEncodedLength<ErrorCodec, T::Error>(16, value.Result);
        return length;
    }

    public static int GetEncodedLength(in T::AuditNotification value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditNotificationCodec, T::AuditNotification>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        if (reader.PeekContextTag(1))
        {
            return true;
        }
        return reader.PeekContextTag(2);
    }
}
