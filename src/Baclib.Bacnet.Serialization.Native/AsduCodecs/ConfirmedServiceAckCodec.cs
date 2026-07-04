// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedServiceAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            3 or
            4 or
            29 or
            6 or
            7 or
            12 or
            14 or
            26 or
            33 or
            18 or
            34 or
            21 or
            23 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 3:
                var @getAlarmSummary = GetAlarmSummaryAckCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetAlarmSummary(@getAlarmSummary);
            case 4:
                var @getEnrollmentSummary = GetEnrollmentSummaryAckCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetEnrollmentSummary(@getEnrollmentSummary);
            case 29:
                var @getEventInformation = GetEventInformationAckCodec.Decode(ref reader, 29);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetEventInformation(@getEventInformation);
            case 6:
                var @atomicReadFile = AtomicReadFileAckCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAtomicReadFile(@atomicReadFile);
            case 7:
                var @atomicWriteFile = AtomicWriteFileAckCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAtomicWriteFile(@atomicWriteFile);
            case 12:
                var @readProperty = ReadPropertyAckCodec.Decode(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadProperty(@readProperty);
            case 14:
                var @readPropertyMultiple = ReadPropertyMultipleAckCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadPropertyMultiple(@readPropertyMultiple);
            case 26:
                var @readRange = ReadRangeAckCodec.Decode(ref reader, 26);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadRange(@readRange);
            case 33:
                var @auditLogQuery = AuditLogQueryAckCodec.Decode(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAuditLogQuery(@auditLogQuery);
            case 18:
                var @confirmedPrivateTransfer = ConfirmedPrivateTransferAckCodec.Decode(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromConfirmedPrivateTransfer(@confirmedPrivateTransfer);
            case 34:
                var @authRequest = AuthRequestAckCodec.Decode(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAuthRequest(@authRequest);
            case 21:
                var @vtOpen = VtOpenAckCodec.Decode(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromVtOpen(@vtOpen);
            case 23:
                var @vtData = VtDataAckCodec.Decode(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromVtData(@vtData);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedServiceAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetAlarmSummary:
                GetAlarmSummaryAckCodec.Encode(ref writer, 3, value.GetAlarmSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEnrollmentSummary:
                GetEnrollmentSummaryAckCodec.Encode(ref writer, 4, value.GetEnrollmentSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEventInformation:
                GetEventInformationAckCodec.Encode(ref writer, 29, value.GetEventInformation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicReadFile:
                AtomicReadFileAckCodec.Encode(ref writer, 6, value.AtomicReadFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicWriteFile:
                AtomicWriteFileAckCodec.Encode(ref writer, 7, value.AtomicWriteFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadProperty:
                ReadPropertyAckCodec.Encode(ref writer, 12, value.ReadProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadPropertyMultiple:
                ReadPropertyMultipleAckCodec.Encode(ref writer, 14, value.ReadPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadRange:
                ReadRangeAckCodec.Encode(ref writer, 26, value.ReadRange);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuditLogQuery:
                AuditLogQueryAckCodec.Encode(ref writer, 33, value.AuditLogQuery);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ConfirmedPrivateTransfer:
                ConfirmedPrivateTransferAckCodec.Encode(ref writer, 18, value.ConfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuthRequest:
                AuthRequestAckCodec.Encode(ref writer, 34, value.AuthRequest);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtOpen:
                VtOpenAckCodec.Encode(ref writer, 21, value.VtOpen);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtData:
                VtDataAckCodec.Encode(ref writer, 23, value.VtData);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
        => AsduConstructed.Encode<ConfirmedServiceAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetAlarmSummary
                => GetAlarmSummaryAckCodec.GetEncodedLength(value.GetAlarmSummary, 3),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEnrollmentSummary
                => GetEnrollmentSummaryAckCodec.GetEncodedLength(value.GetEnrollmentSummary, 4),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEventInformation
                => GetEventInformationAckCodec.GetEncodedLength(value.GetEventInformation, 29),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicReadFile
                => AtomicReadFileAckCodec.GetEncodedLength(value.AtomicReadFile, 6),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicWriteFile
                => AtomicWriteFileAckCodec.GetEncodedLength(value.AtomicWriteFile, 7),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadProperty
                => ReadPropertyAckCodec.GetEncodedLength(value.ReadProperty, 12),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadPropertyMultiple
                => ReadPropertyMultipleAckCodec.GetEncodedLength(value.ReadPropertyMultiple, 14),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadRange
                => ReadRangeAckCodec.GetEncodedLength(value.ReadRange, 26),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuditLogQuery
                => AuditLogQueryAckCodec.GetEncodedLength(value.AuditLogQuery, 33),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ConfirmedPrivateTransfer
                => ConfirmedPrivateTransferAckCodec.GetEncodedLength(value.ConfirmedPrivateTransfer, 18),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuthRequest
                => AuthRequestAckCodec.GetEncodedLength(value.AuthRequest, 34),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtOpen
                => VtOpenAckCodec.GetEncodedLength(value.VtOpen, 21),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtData
                => VtDataAckCodec.GetEncodedLength(value.VtData, 23),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value, byte tagNumber)
        => AsduElement.GetEncodedLength<ConfirmedServiceAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>(tagNumber, value);
}
