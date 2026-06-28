// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedServiceRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _iAm = Asdu.DecodeConstructed<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromIAm(_iAm);
            case 1:
                var _iHave = Asdu.DecodeConstructed<IHaveRequestCodec, global::Baclib.Bacnet.Types.Application.IHaveRequest>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromIHave(_iHave);
            case 2:
                var _unconfirmedCovNotification = Asdu.DecodeConstructed<UnconfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationRequest>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedCovNotification(_unconfirmedCovNotification);
            case 3:
                var _unconfirmedEventNotification = Asdu.DecodeConstructed<UnconfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedEventNotificationRequest>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedEventNotification(_unconfirmedEventNotification);
            case 4:
                var _unconfirmedPrivateTransfer = Asdu.DecodeConstructed<UnconfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedPrivateTransfer(_unconfirmedPrivateTransfer);
            case 5:
                var _unconfirmedTextMessage = Asdu.DecodeConstructed<UnconfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedTextMessage(_unconfirmedTextMessage);
            case 6:
                var _timeSynchronization = Asdu.DecodeConstructed<TimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromTimeSynchronization(_timeSynchronization);
            case 7:
                var _whoHas = Asdu.DecodeConstructed<WhoHasRequestCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoHas(_whoHas);
            case 8:
                var _whoIs = Asdu.DecodeConstructed<WhoIsRequestCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoIs(_whoIs);
            case 9:
                var _utcTimeSynchronization = Asdu.DecodeConstructed<UtcTimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.UtcTimeSynchronizationRequest>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUtcTimeSynchronization(_utcTimeSynchronization);
            case 10:
                var _writeGroup = Asdu.DecodeConstructed<WriteGroupRequestCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWriteGroup(_writeGroup);
            case 11:
                var _unconfirmedCovNotificationMultiple = Asdu.DecodeConstructed<UnconfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationMultipleRequest>(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedCovNotificationMultiple(_unconfirmedCovNotificationMultiple);
            case 12:
                var _unconfirmedAuditNotification = Asdu.DecodeConstructed<UnconfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest>(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedAuditNotification(_unconfirmedAuditNotification);
            case 13:
                var _whoAmI = Asdu.DecodeConstructed<WhoAmIRequestCodec, global::Baclib.Bacnet.Types.Application.WhoAmIRequest>(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoAmI(_whoAmI);
            case 14:
                var _youAre = Asdu.DecodeConstructed<YouAreRequestCodec, global::Baclib.Bacnet.Types.Application.YouAreRequest>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromYouAre(_youAre);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IAm:
                Asdu.EncodeConstructed<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(ref writer, 0, value.IAm);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IHave:
                Asdu.EncodeConstructed<IHaveRequestCodec, global::Baclib.Bacnet.Types.Application.IHaveRequest>(ref writer, 1, value.IHave);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotification:
                Asdu.EncodeConstructed<UnconfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationRequest>(ref writer, 2, value.UnconfirmedCovNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedEventNotification:
                Asdu.EncodeConstructed<UnconfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedEventNotificationRequest>(ref writer, 3, value.UnconfirmedEventNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedPrivateTransfer:
                Asdu.EncodeConstructed<UnconfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest>(ref writer, 4, value.UnconfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedTextMessage:
                Asdu.EncodeConstructed<UnconfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest>(ref writer, 5, value.UnconfirmedTextMessage);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.TimeSynchronization:
                Asdu.EncodeConstructed<TimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest>(ref writer, 6, value.TimeSynchronization);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoHas:
                Asdu.EncodeConstructed<WhoHasRequestCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest>(ref writer, 7, value.WhoHas);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoIs:
                Asdu.EncodeConstructed<WhoIsRequestCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest>(ref writer, 8, value.WhoIs);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UtcTimeSynchronization:
                Asdu.EncodeConstructed<UtcTimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.UtcTimeSynchronizationRequest>(ref writer, 9, value.UtcTimeSynchronization);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WriteGroup:
                Asdu.EncodeConstructed<WriteGroupRequestCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest>(ref writer, 10, value.WriteGroup);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotificationMultiple:
                Asdu.EncodeConstructed<UnconfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationMultipleRequest>(ref writer, 11, value.UnconfirmedCovNotificationMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedAuditNotification:
                Asdu.EncodeConstructed<UnconfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest>(ref writer, 12, value.UnconfirmedAuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoAmI:
                Asdu.EncodeConstructed<WhoAmIRequestCodec, global::Baclib.Bacnet.Types.Application.WhoAmIRequest>(ref writer, 13, value.WhoAmI);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.YouAre:
                Asdu.EncodeConstructed<YouAreRequestCodec, global::Baclib.Bacnet.Types.Application.YouAreRequest>(ref writer, 14, value.YouAre);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IAm:
                return Asdu.GetConstructedLength<IAmRequestCodec, global::Baclib.Bacnet.Types.Application.IAmRequest>(0, value.IAm);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IHave:
                return Asdu.GetConstructedLength<IHaveRequestCodec, global::Baclib.Bacnet.Types.Application.IHaveRequest>(1, value.IHave);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotification:
                return Asdu.GetConstructedLength<UnconfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationRequest>(2, value.UnconfirmedCovNotification);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedEventNotification:
                return Asdu.GetConstructedLength<UnconfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedEventNotificationRequest>(3, value.UnconfirmedEventNotification);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedPrivateTransfer:
                return Asdu.GetConstructedLength<UnconfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest>(4, value.UnconfirmedPrivateTransfer);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedTextMessage:
                return Asdu.GetConstructedLength<UnconfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest>(5, value.UnconfirmedTextMessage);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.TimeSynchronization:
                return Asdu.GetConstructedLength<TimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest>(6, value.TimeSynchronization);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoHas:
                return Asdu.GetConstructedLength<WhoHasRequestCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest>(7, value.WhoHas);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoIs:
                return Asdu.GetConstructedLength<WhoIsRequestCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest>(8, value.WhoIs);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UtcTimeSynchronization:
                return Asdu.GetConstructedLength<UtcTimeSynchronizationRequestCodec, global::Baclib.Bacnet.Types.Application.UtcTimeSynchronizationRequest>(9, value.UtcTimeSynchronization);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WriteGroup:
                return Asdu.GetConstructedLength<WriteGroupRequestCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest>(10, value.WriteGroup);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotificationMultiple:
                return Asdu.GetConstructedLength<UnconfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedCovNotificationMultipleRequest>(11, value.UnconfirmedCovNotificationMultiple);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedAuditNotification:
                return Asdu.GetConstructedLength<UnconfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedAuditNotificationRequest>(12, value.UnconfirmedAuditNotification);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoAmI:
                return Asdu.GetConstructedLength<WhoAmIRequestCodec, global::Baclib.Bacnet.Types.Application.WhoAmIRequest>(13, value.WhoAmI);
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.YouAre:
                return Asdu.GetConstructedLength<YouAreRequestCodec, global::Baclib.Bacnet.Types.Application.YouAreRequest>(14, value.YouAre);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}