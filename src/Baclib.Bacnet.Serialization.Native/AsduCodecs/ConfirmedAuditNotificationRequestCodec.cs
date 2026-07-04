// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedAuditNotificationRequestCodec :
    IAsduElementCodec<T::ConfirmedAuditNotificationRequest>,
    IAsduConstructedCodec<T::ConfirmedAuditNotificationRequest>
{
    public static T::ConfirmedAuditNotificationRequest Decode(ref AsduReader reader)
    {
        return new T::ConfirmedAuditNotificationRequest
        {
            Notifications = AsduElement.DecodeSequenceOf<AuditNotificationCodec, T::AuditNotification>(ref reader, 0)
        };
    }

    public static T::ConfirmedAuditNotificationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedAuditNotificationRequestCodec, T::ConfirmedAuditNotificationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedAuditNotificationRequest value)
    {
        AsduElement.EncodeSequenceOf<AuditNotificationCodec, T::AuditNotification>(ref writer, 0, value.Notifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedAuditNotificationRequest value)
        => AsduConstructed.Encode<ConfirmedAuditNotificationRequestCodec, T::ConfirmedAuditNotificationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedAuditNotificationRequest value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<AuditNotificationCodec, T::AuditNotification>(0, value.Notifications);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedAuditNotificationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedAuditNotificationRequestCodec, T::ConfirmedAuditNotificationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
