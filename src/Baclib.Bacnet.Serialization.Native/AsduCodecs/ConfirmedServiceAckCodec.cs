// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedServiceAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 3:
            case 4:
            case 29:
            case 6:
            case 7:
            case 10:
            case 12:
            case 14:
            case 26:
            case 33:
            case 18:
            case 34:
            case 21:
            case 23:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 3:
                var _getAlarmSummary = Asdu.DecodeConstructed<GetAlarmSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetAlarmSummary(_getAlarmSummary);
            case 4:
                var _getEnrollmentSummary = Asdu.DecodeConstructed<GetEnrollmentSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetEnrollmentSummary(_getEnrollmentSummary);
            case 29:
                var _getEventInformation = Asdu.DecodeConstructed<GetEventInformationAckCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck>(ref reader, 29);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromGetEventInformation(_getEventInformation);
            case 6:
                var _atomicReadFile = Asdu.DecodeConstructed<AtomicReadFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAtomicReadFile(_atomicReadFile);
            case 7:
                var _atomicWriteFile = Asdu.DecodeConstructed<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAtomicWriteFile(_atomicWriteFile);
            case 10:
                var _createObject = Asdu.DecodePrimitive<CreateObjectAckCodec, global::Baclib.Bacnet.Types.Application.CreateObjectAck>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromCreateObject(_createObject);
            case 12:
                var _readProperty = Asdu.DecodeConstructed<ReadPropertyAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyAck>(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadProperty(_readProperty);
            case 14:
                var _readPropertyMultiple = Asdu.DecodeConstructed<ReadPropertyMultipleAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadPropertyMultiple(_readPropertyMultiple);
            case 26:
                var _readRange = Asdu.DecodeConstructed<ReadRangeAckCodec, global::Baclib.Bacnet.Types.Application.ReadRangeAck>(ref reader, 26);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromReadRange(_readRange);
            case 33:
                var _auditLogQuery = Asdu.DecodeConstructed<AuditLogQueryAckCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryAck>(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAuditLogQuery(_auditLogQuery);
            case 18:
                var _confirmedPrivateTransfer = Asdu.DecodeConstructed<ConfirmedPrivateTransferAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck>(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromConfirmedPrivateTransfer(_confirmedPrivateTransfer);
            case 34:
                var _authRequest = Asdu.DecodeConstructed<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromAuthRequest(_authRequest);
            case 21:
                var _vtOpen = Asdu.DecodeConstructed<VtOpenAckCodec, global::Baclib.Bacnet.Types.Application.VtOpenAck>(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromVtOpen(_vtOpen);
            case 23:
                var _vtData = Asdu.DecodeConstructed<VtDataAckCodec, global::Baclib.Bacnet.Types.Application.VtDataAck>(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.FromVtData(_vtData);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetAlarmSummary:
                Asdu.EncodeConstructed<GetAlarmSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck>(ref writer, 3, value.GetAlarmSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEnrollmentSummary:
                Asdu.EncodeConstructed<GetEnrollmentSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck>(ref writer, 4, value.GetEnrollmentSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEventInformation:
                Asdu.EncodeConstructed<GetEventInformationAckCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck>(ref writer, 29, value.GetEventInformation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicReadFile:
                Asdu.EncodeConstructed<AtomicReadFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck>(ref writer, 6, value.AtomicReadFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicWriteFile:
                Asdu.EncodeConstructed<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(ref writer, 7, value.AtomicWriteFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.CreateObject:
                Asdu.EncodePrimitive<CreateObjectAckCodec, global::Baclib.Bacnet.Types.Application.CreateObjectAck>(ref writer, 10, value.CreateObject);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadProperty:
                Asdu.EncodeConstructed<ReadPropertyAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyAck>(ref writer, 12, value.ReadProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadPropertyMultiple:
                Asdu.EncodeConstructed<ReadPropertyMultipleAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck>(ref writer, 14, value.ReadPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadRange:
                Asdu.EncodeConstructed<ReadRangeAckCodec, global::Baclib.Bacnet.Types.Application.ReadRangeAck>(ref writer, 26, value.ReadRange);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuditLogQuery:
                Asdu.EncodeConstructed<AuditLogQueryAckCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryAck>(ref writer, 33, value.AuditLogQuery);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ConfirmedPrivateTransfer:
                Asdu.EncodeConstructed<ConfirmedPrivateTransferAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck>(ref writer, 18, value.ConfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuthRequest:
                Asdu.EncodeConstructed<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(ref writer, 34, value.AuthRequest);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtOpen:
                Asdu.EncodeConstructed<VtOpenAckCodec, global::Baclib.Bacnet.Types.Application.VtOpenAck>(ref writer, 21, value.VtOpen);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtData:
                Asdu.EncodeConstructed<VtDataAckCodec, global::Baclib.Bacnet.Types.Application.VtDataAck>(ref writer, 23, value.VtData);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetAlarmSummary:
                return Asdu.GetConstructedLength<GetAlarmSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck>(3, value.GetAlarmSummary);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEnrollmentSummary:
                return Asdu.GetConstructedLength<GetEnrollmentSummaryAckCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck>(4, value.GetEnrollmentSummary);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.GetEventInformation:
                return Asdu.GetConstructedLength<GetEventInformationAckCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck>(29, value.GetEventInformation);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicReadFile:
                return Asdu.GetConstructedLength<AtomicReadFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck>(6, value.AtomicReadFile);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AtomicWriteFile:
                return Asdu.GetConstructedLength<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(7, value.AtomicWriteFile);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.CreateObject:
                return Asdu.GetPrimitiveLength<CreateObjectAckCodec, global::Baclib.Bacnet.Types.Application.CreateObjectAck>(10, value.CreateObject);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadProperty:
                return Asdu.GetConstructedLength<ReadPropertyAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyAck>(12, value.ReadProperty);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadPropertyMultiple:
                return Asdu.GetConstructedLength<ReadPropertyMultipleAckCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck>(14, value.ReadPropertyMultiple);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ReadRange:
                return Asdu.GetConstructedLength<ReadRangeAckCodec, global::Baclib.Bacnet.Types.Application.ReadRangeAck>(26, value.ReadRange);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuditLogQuery:
                return Asdu.GetConstructedLength<AuditLogQueryAckCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryAck>(33, value.AuditLogQuery);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.ConfirmedPrivateTransfer:
                return Asdu.GetConstructedLength<ConfirmedPrivateTransferAckCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck>(18, value.ConfirmedPrivateTransfer);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.AuthRequest:
                return Asdu.GetConstructedLength<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(34, value.AuthRequest);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtOpen:
                return Asdu.GetConstructedLength<VtOpenAckCodec, global::Baclib.Bacnet.Types.Application.VtOpenAck>(21, value.VtOpen);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck.Option.VtData:
                return Asdu.GetConstructedLength<VtDataAckCodec, global::Baclib.Bacnet.Types.Application.VtDataAck>(23, value.VtData);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}