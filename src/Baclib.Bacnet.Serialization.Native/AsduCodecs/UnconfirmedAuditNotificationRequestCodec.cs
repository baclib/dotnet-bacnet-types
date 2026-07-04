// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedAuditNotificationRequestCodec :
    IAsduElementCodec<T::UnconfirmedAuditNotificationRequest>,
    IAsduConstructedCodec<T::UnconfirmedAuditNotificationRequest>
{
    public static T::UnconfirmedAuditNotificationRequest Decode(ref AsduReader reader)
    {
        return new T::UnconfirmedAuditNotificationRequest
        {
            Notifications = AsduElement.DecodeSequenceOf<AuditNotificationCodec, T::AuditNotification>(ref reader, 0)
        };
    }

    public static T::UnconfirmedAuditNotificationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedAuditNotificationRequestCodec, T::UnconfirmedAuditNotificationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::UnconfirmedAuditNotificationRequest value)
    {
        AsduElement.EncodeSequenceOf<AuditNotificationCodec, T::AuditNotification>(ref writer, 0, value.Notifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::UnconfirmedAuditNotificationRequest value)
        => AsduConstructed.Encode<UnconfirmedAuditNotificationRequestCodec, T::UnconfirmedAuditNotificationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::UnconfirmedAuditNotificationRequest value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<AuditNotificationCodec, T::AuditNotification>(0, value.Notifications);
        return length;
    }

    public static int GetEncodedLength(in T::UnconfirmedAuditNotificationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<UnconfirmedAuditNotificationRequestCodec, T::UnconfirmedAuditNotificationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
