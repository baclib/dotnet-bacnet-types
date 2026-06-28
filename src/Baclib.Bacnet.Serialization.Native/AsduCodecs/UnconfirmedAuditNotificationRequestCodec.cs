// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedAuditNotificationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest Decode(ref NativeReader reader)
    {
        var _notifications = Asdu.DecodeSequenceOf<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest
        {
            Notifications = _notifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.Notifications)
        {
            Asdu.EncodeElement<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.Notifications.Items.Sum(static item => Asdu.GetElementLength<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
