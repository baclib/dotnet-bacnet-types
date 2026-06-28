// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedServiceRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 31:
            case 2:
            case 4:
            case 29:
            case 27:
            case 5:
            case 28:
            case 30:
            case 32:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 14:
            case 26:
            case 15:
            case 16:
            case 33:
            case 17:
            case 18:
            case 19:
            case 20:
            case 34:
            case 21:
            case 22:
            case 23:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _acknowledgeAlarm = Asdu.DecodeConstructed<AcknowledgeAlarmRequestCodec, global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAcknowledgeAlarm(_acknowledgeAlarm);
            case 1:
                var _confirmedCovNotification = Asdu.DecodeConstructed<ConfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedCovNotification(_confirmedCovNotification);
            case 31:
                var _confirmedCovNotificationMultiple = Asdu.DecodeConstructed<ConfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest>(ref reader, 31);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedCovNotificationMultiple(_confirmedCovNotificationMultiple);
            case 2:
                var _confirmedEventNotification = Asdu.DecodeConstructed<ConfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedEventNotification(_confirmedEventNotification);
            case 4:
                var _getEnrollmentSummary = Asdu.DecodeConstructed<GetEnrollmentSummaryRequestCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromGetEnrollmentSummary(_getEnrollmentSummary);
            case 29:
                var _getEventInformation = Asdu.DecodeConstructed<GetEventInformationRequestCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationRequest>(ref reader, 29);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromGetEventInformation(_getEventInformation);
            case 27:
                var _lifeSafetyOperation = Asdu.DecodeConstructed<LifeSafetyOperationRequestCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest>(ref reader, 27);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromLifeSafetyOperation(_lifeSafetyOperation);
            case 5:
                var _subscribeCov = Asdu.DecodeConstructed<SubscribeCovRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovRequest>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCov(_subscribeCov);
            case 28:
                var _subscribeCovProperty = Asdu.DecodeConstructed<SubscribeCovPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyRequest>(ref reader, 28);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCovProperty(_subscribeCovProperty);
            case 30:
                var _subscribeCovPropertyMultiple = Asdu.DecodeConstructed<SubscribeCovPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest>(ref reader, 30);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCovPropertyMultiple(_subscribeCovPropertyMultiple);
            case 32:
                var _confirmedAuditNotification = Asdu.DecodeConstructed<ConfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedAuditNotificationRequest>(ref reader, 32);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedAuditNotification(_confirmedAuditNotification);
            case 6:
                var _atomicReadFile = Asdu.DecodeConstructed<AtomicReadFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAtomicReadFile(_atomicReadFile);
            case 7:
                var _atomicWriteFile = Asdu.DecodeConstructed<AtomicWriteFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAtomicWriteFile(_atomicWriteFile);
            case 8:
                var _addListElement = Asdu.DecodeConstructed<AddListElementRequestCodec, global::Baclib.Bacnet.Types.Application.AddListElementRequest>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAddListElement(_addListElement);
            case 9:
                var _removeListElement = Asdu.DecodeConstructed<RemoveListElementRequestCodec, global::Baclib.Bacnet.Types.Application.RemoveListElementRequest>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromRemoveListElement(_removeListElement);
            case 10:
                var _createObject = Asdu.DecodeConstructed<CreateObjectRequestCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromCreateObject(_createObject);
            case 11:
                var _deleteObject = Asdu.DecodeConstructed<DeleteObjectRequestCodec, global::Baclib.Bacnet.Types.Application.DeleteObjectRequest>(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromDeleteObject(_deleteObject);
            case 12:
                var _readProperty = Asdu.DecodeConstructed<ReadPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyRequest>(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadProperty(_readProperty);
            case 14:
                var _readPropertyMultiple = Asdu.DecodeConstructed<ReadPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadPropertyMultiple(_readPropertyMultiple);
            case 26:
                var _readRange = Asdu.DecodeConstructed<ReadRangeRequestCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest>(ref reader, 26);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadRange(_readRange);
            case 15:
                var _writeProperty = Asdu.DecodeConstructed<WritePropertyRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest>(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromWriteProperty(_writeProperty);
            case 16:
                var _writePropertyMultiple = Asdu.DecodeConstructed<WritePropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest>(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromWritePropertyMultiple(_writePropertyMultiple);
            case 33:
                var _auditLogQuery = Asdu.DecodeConstructed<AuditLogQueryRequestCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest>(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAuditLogQuery(_auditLogQuery);
            case 17:
                var _deviceCommunicationControl = Asdu.DecodeConstructed<DeviceCommunicationControlRequestCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest>(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromDeviceCommunicationControl(_deviceCommunicationControl);
            case 18:
                var _confirmedPrivateTransfer = Asdu.DecodeConstructed<ConfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferRequest>(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedPrivateTransfer(_confirmedPrivateTransfer);
            case 19:
                var _confirmedTextMessage = Asdu.DecodeConstructed<ConfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest>(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedTextMessage(_confirmedTextMessage);
            case 20:
                var _reinitializeDevice = Asdu.DecodeConstructed<ReinitializeDeviceRequestCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest>(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReinitializeDevice(_reinitializeDevice);
            case 34:
                var _authRequest = Asdu.DecodeConstructed<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAuthRequest(_authRequest);
            case 21:
                var _vtOpen = Asdu.DecodeConstructed<VtOpenRequestCodec, global::Baclib.Bacnet.Types.Application.VtOpenRequest>(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtOpen(_vtOpen);
            case 22:
                var _vtClose = Asdu.DecodeConstructed<VtCloseRequestCodec, global::Baclib.Bacnet.Types.Application.VtCloseRequest>(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtClose(_vtClose);
            case 23:
                var _vtData = Asdu.DecodeConstructed<VtDataRequestCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest>(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtData(_vtData);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AcknowledgeAlarm:
                Asdu.EncodeConstructed<AcknowledgeAlarmRequestCodec, global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest>(ref writer, 0, value.AcknowledgeAlarm);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotification:
                Asdu.EncodeConstructed<ConfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest>(ref writer, 1, value.ConfirmedCovNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotificationMultiple:
                Asdu.EncodeConstructed<ConfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest>(ref writer, 31, value.ConfirmedCovNotificationMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedEventNotification:
                Asdu.EncodeConstructed<ConfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest>(ref writer, 2, value.ConfirmedEventNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEnrollmentSummary:
                Asdu.EncodeConstructed<GetEnrollmentSummaryRequestCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest>(ref writer, 4, value.GetEnrollmentSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEventInformation:
                Asdu.EncodeConstructed<GetEventInformationRequestCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationRequest>(ref writer, 29, value.GetEventInformation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.LifeSafetyOperation:
                Asdu.EncodeConstructed<LifeSafetyOperationRequestCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest>(ref writer, 27, value.LifeSafetyOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCov:
                Asdu.EncodeConstructed<SubscribeCovRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovRequest>(ref writer, 5, value.SubscribeCov);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovProperty:
                Asdu.EncodeConstructed<SubscribeCovPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyRequest>(ref writer, 28, value.SubscribeCovProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovPropertyMultiple:
                Asdu.EncodeConstructed<SubscribeCovPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest>(ref writer, 30, value.SubscribeCovPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedAuditNotification:
                Asdu.EncodeConstructed<ConfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedAuditNotificationRequest>(ref writer, 32, value.ConfirmedAuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicReadFile:
                Asdu.EncodeConstructed<AtomicReadFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest>(ref writer, 6, value.AtomicReadFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicWriteFile:
                Asdu.EncodeConstructed<AtomicWriteFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest>(ref writer, 7, value.AtomicWriteFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AddListElement:
                Asdu.EncodeConstructed<AddListElementRequestCodec, global::Baclib.Bacnet.Types.Application.AddListElementRequest>(ref writer, 8, value.AddListElement);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.RemoveListElement:
                Asdu.EncodeConstructed<RemoveListElementRequestCodec, global::Baclib.Bacnet.Types.Application.RemoveListElementRequest>(ref writer, 9, value.RemoveListElement);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.CreateObject:
                Asdu.EncodeConstructed<CreateObjectRequestCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest>(ref writer, 10, value.CreateObject);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeleteObject:
                Asdu.EncodeConstructed<DeleteObjectRequestCodec, global::Baclib.Bacnet.Types.Application.DeleteObjectRequest>(ref writer, 11, value.DeleteObject);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadProperty:
                Asdu.EncodeConstructed<ReadPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyRequest>(ref writer, 12, value.ReadProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadPropertyMultiple:
                Asdu.EncodeConstructed<ReadPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest>(ref writer, 14, value.ReadPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadRange:
                Asdu.EncodeConstructed<ReadRangeRequestCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest>(ref writer, 26, value.ReadRange);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WriteProperty:
                Asdu.EncodeConstructed<WritePropertyRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest>(ref writer, 15, value.WriteProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WritePropertyMultiple:
                Asdu.EncodeConstructed<WritePropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest>(ref writer, 16, value.WritePropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuditLogQuery:
                Asdu.EncodeConstructed<AuditLogQueryRequestCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest>(ref writer, 33, value.AuditLogQuery);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeviceCommunicationControl:
                Asdu.EncodeConstructed<DeviceCommunicationControlRequestCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest>(ref writer, 17, value.DeviceCommunicationControl);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedPrivateTransfer:
                Asdu.EncodeConstructed<ConfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferRequest>(ref writer, 18, value.ConfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedTextMessage:
                Asdu.EncodeConstructed<ConfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest>(ref writer, 19, value.ConfirmedTextMessage);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReinitializeDevice:
                Asdu.EncodeConstructed<ReinitializeDeviceRequestCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest>(ref writer, 20, value.ReinitializeDevice);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuthRequest:
                Asdu.EncodeConstructed<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(ref writer, 34, value.AuthRequest);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtOpen:
                Asdu.EncodeConstructed<VtOpenRequestCodec, global::Baclib.Bacnet.Types.Application.VtOpenRequest>(ref writer, 21, value.VtOpen);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtClose:
                Asdu.EncodeConstructed<VtCloseRequestCodec, global::Baclib.Bacnet.Types.Application.VtCloseRequest>(ref writer, 22, value.VtClose);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtData:
                Asdu.EncodeConstructed<VtDataRequestCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest>(ref writer, 23, value.VtData);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AcknowledgeAlarm:
                return Asdu.GetConstructedLength<AcknowledgeAlarmRequestCodec, global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest>(0, value.AcknowledgeAlarm);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotification:
                return Asdu.GetConstructedLength<ConfirmedCovNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest>(1, value.ConfirmedCovNotification);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotificationMultiple:
                return Asdu.GetConstructedLength<ConfirmedCovNotificationMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest>(31, value.ConfirmedCovNotificationMultiple);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedEventNotification:
                return Asdu.GetConstructedLength<ConfirmedEventNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest>(2, value.ConfirmedEventNotification);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEnrollmentSummary:
                return Asdu.GetConstructedLength<GetEnrollmentSummaryRequestCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest>(4, value.GetEnrollmentSummary);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEventInformation:
                return Asdu.GetConstructedLength<GetEventInformationRequestCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationRequest>(29, value.GetEventInformation);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.LifeSafetyOperation:
                return Asdu.GetConstructedLength<LifeSafetyOperationRequestCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest>(27, value.LifeSafetyOperation);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCov:
                return Asdu.GetConstructedLength<SubscribeCovRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovRequest>(5, value.SubscribeCov);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovProperty:
                return Asdu.GetConstructedLength<SubscribeCovPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyRequest>(28, value.SubscribeCovProperty);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovPropertyMultiple:
                return Asdu.GetConstructedLength<SubscribeCovPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest>(30, value.SubscribeCovPropertyMultiple);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedAuditNotification:
                return Asdu.GetConstructedLength<ConfirmedAuditNotificationRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedAuditNotificationRequest>(32, value.ConfirmedAuditNotification);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicReadFile:
                return Asdu.GetConstructedLength<AtomicReadFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest>(6, value.AtomicReadFile);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicWriteFile:
                return Asdu.GetConstructedLength<AtomicWriteFileRequestCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest>(7, value.AtomicWriteFile);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AddListElement:
                return Asdu.GetConstructedLength<AddListElementRequestCodec, global::Baclib.Bacnet.Types.Application.AddListElementRequest>(8, value.AddListElement);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.RemoveListElement:
                return Asdu.GetConstructedLength<RemoveListElementRequestCodec, global::Baclib.Bacnet.Types.Application.RemoveListElementRequest>(9, value.RemoveListElement);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.CreateObject:
                return Asdu.GetConstructedLength<CreateObjectRequestCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest>(10, value.CreateObject);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeleteObject:
                return Asdu.GetConstructedLength<DeleteObjectRequestCodec, global::Baclib.Bacnet.Types.Application.DeleteObjectRequest>(11, value.DeleteObject);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadProperty:
                return Asdu.GetConstructedLength<ReadPropertyRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyRequest>(12, value.ReadProperty);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadPropertyMultiple:
                return Asdu.GetConstructedLength<ReadPropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest>(14, value.ReadPropertyMultiple);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadRange:
                return Asdu.GetConstructedLength<ReadRangeRequestCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest>(26, value.ReadRange);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WriteProperty:
                return Asdu.GetConstructedLength<WritePropertyRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest>(15, value.WriteProperty);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WritePropertyMultiple:
                return Asdu.GetConstructedLength<WritePropertyMultipleRequestCodec, global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest>(16, value.WritePropertyMultiple);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuditLogQuery:
                return Asdu.GetConstructedLength<AuditLogQueryRequestCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryRequest>(33, value.AuditLogQuery);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeviceCommunicationControl:
                return Asdu.GetConstructedLength<DeviceCommunicationControlRequestCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest>(17, value.DeviceCommunicationControl);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedPrivateTransfer:
                return Asdu.GetConstructedLength<ConfirmedPrivateTransferRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferRequest>(18, value.ConfirmedPrivateTransfer);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedTextMessage:
                return Asdu.GetConstructedLength<ConfirmedTextMessageRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedTextMessageRequest>(19, value.ConfirmedTextMessage);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReinitializeDevice:
                return Asdu.GetConstructedLength<ReinitializeDeviceRequestCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest>(20, value.ReinitializeDevice);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuthRequest:
                return Asdu.GetConstructedLength<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(34, value.AuthRequest);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtOpen:
                return Asdu.GetConstructedLength<VtOpenRequestCodec, global::Baclib.Bacnet.Types.Application.VtOpenRequest>(21, value.VtOpen);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtClose:
                return Asdu.GetConstructedLength<VtCloseRequestCodec, global::Baclib.Bacnet.Types.Application.VtCloseRequest>(22, value.VtClose);
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtData:
                return Asdu.GetConstructedLength<VtDataRequestCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest>(23, value.VtData);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}