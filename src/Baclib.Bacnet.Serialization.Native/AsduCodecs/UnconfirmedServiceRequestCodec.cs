// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedServiceRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 or
            3 or
            4 or
            5 or
            6 or
            7 or
            8 or
            9 or
            10 or
            11 or
            12 or
            13 or
            14 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @iAm = IAmRequestCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromIAm(@iAm);
            case 1:
                var @iHave = IHaveRequestCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromIHave(@iHave);
            case 2:
                var @unconfirmedCovNotification = UnconfirmedCovNotificationRequestCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedCovNotification(@unconfirmedCovNotification);
            case 3:
                var @unconfirmedEventNotification = UnconfirmedEventNotificationRequestCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedEventNotification(@unconfirmedEventNotification);
            case 4:
                var @unconfirmedPrivateTransfer = UnconfirmedPrivateTransferRequestCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedPrivateTransfer(@unconfirmedPrivateTransfer);
            case 5:
                var @unconfirmedTextMessage = UnconfirmedTextMessageRequestCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedTextMessage(@unconfirmedTextMessage);
            case 6:
                var @timeSynchronization = TimeSynchronizationRequestCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromTimeSynchronization(@timeSynchronization);
            case 7:
                var @whoHas = WhoHasRequestCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoHas(@whoHas);
            case 8:
                var @whoIs = WhoIsRequestCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoIs(@whoIs);
            case 9:
                var @utcTimeSynchronization = UtcTimeSynchronizationRequestCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUtcTimeSynchronization(@utcTimeSynchronization);
            case 10:
                var @writeGroup = WriteGroupRequestCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWriteGroup(@writeGroup);
            case 11:
                var @unconfirmedCovNotificationMultiple = UnconfirmedCovNotificationMultipleRequestCodec.Decode(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedCovNotificationMultiple(@unconfirmedCovNotificationMultiple);
            case 12:
                var @unconfirmedAuditNotification = UnconfirmedAuditNotificationRequestCodec.Decode(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromUnconfirmedAuditNotification(@unconfirmedAuditNotification);
            case 13:
                var @whoAmI = WhoAmIRequestCodec.Decode(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromWhoAmI(@whoAmI);
            case 14:
                var @youAre = YouAreRequestCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.FromYouAre(@youAre);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IAm:
                IAmRequestCodec.Encode(ref writer, 0, value.IAm);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IHave:
                IHaveRequestCodec.Encode(ref writer, 1, value.IHave);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotification:
                UnconfirmedCovNotificationRequestCodec.Encode(ref writer, 2, value.UnconfirmedCovNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedEventNotification:
                UnconfirmedEventNotificationRequestCodec.Encode(ref writer, 3, value.UnconfirmedEventNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedPrivateTransfer:
                UnconfirmedPrivateTransferRequestCodec.Encode(ref writer, 4, value.UnconfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedTextMessage:
                UnconfirmedTextMessageRequestCodec.Encode(ref writer, 5, value.UnconfirmedTextMessage);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.TimeSynchronization:
                TimeSynchronizationRequestCodec.Encode(ref writer, 6, value.TimeSynchronization);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoHas:
                WhoHasRequestCodec.Encode(ref writer, 7, value.WhoHas);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoIs:
                WhoIsRequestCodec.Encode(ref writer, 8, value.WhoIs);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UtcTimeSynchronization:
                UtcTimeSynchronizationRequestCodec.Encode(ref writer, 9, value.UtcTimeSynchronization);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WriteGroup:
                WriteGroupRequestCodec.Encode(ref writer, 10, value.WriteGroup);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotificationMultiple:
                UnconfirmedCovNotificationMultipleRequestCodec.Encode(ref writer, 11, value.UnconfirmedCovNotificationMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedAuditNotification:
                UnconfirmedAuditNotificationRequestCodec.Encode(ref writer, 12, value.UnconfirmedAuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoAmI:
                WhoAmIRequestCodec.Encode(ref writer, 13, value.WhoAmI);
                return;
            case global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.YouAre:
                YouAreRequestCodec.Encode(ref writer, 14, value.YouAre);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
        => AsduConstructed.Encode<UnconfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IAm
                => IAmRequestCodec.GetEncodedLength(value.IAm, 0),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.IHave
                => IHaveRequestCodec.GetEncodedLength(value.IHave, 1),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotification
                => UnconfirmedCovNotificationRequestCodec.GetEncodedLength(value.UnconfirmedCovNotification, 2),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedEventNotification
                => UnconfirmedEventNotificationRequestCodec.GetEncodedLength(value.UnconfirmedEventNotification, 3),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedPrivateTransfer
                => UnconfirmedPrivateTransferRequestCodec.GetEncodedLength(value.UnconfirmedPrivateTransfer, 4),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedTextMessage
                => UnconfirmedTextMessageRequestCodec.GetEncodedLength(value.UnconfirmedTextMessage, 5),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.TimeSynchronization
                => TimeSynchronizationRequestCodec.GetEncodedLength(value.TimeSynchronization, 6),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoHas
                => WhoHasRequestCodec.GetEncodedLength(value.WhoHas, 7),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoIs
                => WhoIsRequestCodec.GetEncodedLength(value.WhoIs, 8),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UtcTimeSynchronization
                => UtcTimeSynchronizationRequestCodec.GetEncodedLength(value.UtcTimeSynchronization, 9),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WriteGroup
                => WriteGroupRequestCodec.GetEncodedLength(value.WriteGroup, 10),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedCovNotificationMultiple
                => UnconfirmedCovNotificationMultipleRequestCodec.GetEncodedLength(value.UnconfirmedCovNotificationMultiple, 11),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.UnconfirmedAuditNotification
                => UnconfirmedAuditNotificationRequestCodec.GetEncodedLength(value.UnconfirmedAuditNotification, 12),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.WhoAmI
                => WhoAmIRequestCodec.GetEncodedLength(value.WhoAmI, 13),
            global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest.Option.YouAre
                => YouAreRequestCodec.GetEncodedLength(value.YouAre, 14),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest value, byte tagNumber)
        => AsduElement.GetEncodedLength<UnconfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedServiceRequest>(tagNumber, value);
}
