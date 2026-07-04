// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedServiceRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>
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
            31 or
            2 or
            4 or
            29 or
            27 or
            5 or
            28 or
            30 or
            32 or
            6 or
            7 or
            8 or
            9 or
            10 or
            11 or
            12 or
            14 or
            26 or
            15 or
            16 or
            33 or
            17 or
            18 or
            19 or
            20 or
            34 or
            21 or
            22 or
            23 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @acknowledgeAlarm = AcknowledgeAlarmRequestCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAcknowledgeAlarm(@acknowledgeAlarm);
            case 1:
                var @confirmedCovNotification = ConfirmedCovNotificationRequestCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedCovNotification(@confirmedCovNotification);
            case 31:
                var @confirmedCovNotificationMultiple = ConfirmedCovNotificationMultipleRequestCodec.Decode(ref reader, 31);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedCovNotificationMultiple(@confirmedCovNotificationMultiple);
            case 2:
                var @confirmedEventNotification = ConfirmedEventNotificationRequestCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedEventNotification(@confirmedEventNotification);
            case 4:
                var @getEnrollmentSummary = GetEnrollmentSummaryRequestCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromGetEnrollmentSummary(@getEnrollmentSummary);
            case 29:
                var @getEventInformation = GetEventInformationRequestCodec.Decode(ref reader, 29);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromGetEventInformation(@getEventInformation);
            case 27:
                var @lifeSafetyOperation = LifeSafetyOperationRequestCodec.Decode(ref reader, 27);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromLifeSafetyOperation(@lifeSafetyOperation);
            case 5:
                var @subscribeCov = SubscribeCovRequestCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCov(@subscribeCov);
            case 28:
                var @subscribeCovProperty = SubscribeCovPropertyRequestCodec.Decode(ref reader, 28);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCovProperty(@subscribeCovProperty);
            case 30:
                var @subscribeCovPropertyMultiple = SubscribeCovPropertyMultipleRequestCodec.Decode(ref reader, 30);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromSubscribeCovPropertyMultiple(@subscribeCovPropertyMultiple);
            case 32:
                var @confirmedAuditNotification = ConfirmedAuditNotificationRequestCodec.Decode(ref reader, 32);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedAuditNotification(@confirmedAuditNotification);
            case 6:
                var @atomicReadFile = AtomicReadFileRequestCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAtomicReadFile(@atomicReadFile);
            case 7:
                var @atomicWriteFile = AtomicWriteFileRequestCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAtomicWriteFile(@atomicWriteFile);
            case 8:
                var @addListElement = AddListElementRequestCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAddListElement(@addListElement);
            case 9:
                var @removeListElement = RemoveListElementRequestCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromRemoveListElement(@removeListElement);
            case 10:
                var @createObject = CreateObjectRequestCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromCreateObject(@createObject);
            case 11:
                var @deleteObject = DeleteObjectRequestCodec.Decode(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromDeleteObject(@deleteObject);
            case 12:
                var @readProperty = ReadPropertyRequestCodec.Decode(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadProperty(@readProperty);
            case 14:
                var @readPropertyMultiple = ReadPropertyMultipleRequestCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadPropertyMultiple(@readPropertyMultiple);
            case 26:
                var @readRange = ReadRangeRequestCodec.Decode(ref reader, 26);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReadRange(@readRange);
            case 15:
                var @writeProperty = WritePropertyRequestCodec.Decode(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromWriteProperty(@writeProperty);
            case 16:
                var @writePropertyMultiple = WritePropertyMultipleRequestCodec.Decode(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromWritePropertyMultiple(@writePropertyMultiple);
            case 33:
                var @auditLogQuery = AuditLogQueryRequestCodec.Decode(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAuditLogQuery(@auditLogQuery);
            case 17:
                var @deviceCommunicationControl = DeviceCommunicationControlRequestCodec.Decode(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromDeviceCommunicationControl(@deviceCommunicationControl);
            case 18:
                var @confirmedPrivateTransfer = ConfirmedPrivateTransferRequestCodec.Decode(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedPrivateTransfer(@confirmedPrivateTransfer);
            case 19:
                var @confirmedTextMessage = ConfirmedTextMessageRequestCodec.Decode(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromConfirmedTextMessage(@confirmedTextMessage);
            case 20:
                var @reinitializeDevice = ReinitializeDeviceRequestCodec.Decode(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromReinitializeDevice(@reinitializeDevice);
            case 34:
                var @authRequest = AuthRequestRequestCodec.Decode(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromAuthRequest(@authRequest);
            case 21:
                var @vtOpen = VtOpenRequestCodec.Decode(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtOpen(@vtOpen);
            case 22:
                var @vtClose = VtCloseRequestCodec.Decode(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtClose(@vtClose);
            case 23:
                var @vtData = VtDataRequestCodec.Decode(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.FromVtData(@vtData);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AcknowledgeAlarm:
                AcknowledgeAlarmRequestCodec.Encode(ref writer, 0, value.AcknowledgeAlarm);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotification:
                ConfirmedCovNotificationRequestCodec.Encode(ref writer, 1, value.ConfirmedCovNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotificationMultiple:
                ConfirmedCovNotificationMultipleRequestCodec.Encode(ref writer, 31, value.ConfirmedCovNotificationMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedEventNotification:
                ConfirmedEventNotificationRequestCodec.Encode(ref writer, 2, value.ConfirmedEventNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEnrollmentSummary:
                GetEnrollmentSummaryRequestCodec.Encode(ref writer, 4, value.GetEnrollmentSummary);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEventInformation:
                GetEventInformationRequestCodec.Encode(ref writer, 29, value.GetEventInformation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.LifeSafetyOperation:
                LifeSafetyOperationRequestCodec.Encode(ref writer, 27, value.LifeSafetyOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCov:
                SubscribeCovRequestCodec.Encode(ref writer, 5, value.SubscribeCov);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovProperty:
                SubscribeCovPropertyRequestCodec.Encode(ref writer, 28, value.SubscribeCovProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovPropertyMultiple:
                SubscribeCovPropertyMultipleRequestCodec.Encode(ref writer, 30, value.SubscribeCovPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedAuditNotification:
                ConfirmedAuditNotificationRequestCodec.Encode(ref writer, 32, value.ConfirmedAuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicReadFile:
                AtomicReadFileRequestCodec.Encode(ref writer, 6, value.AtomicReadFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicWriteFile:
                AtomicWriteFileRequestCodec.Encode(ref writer, 7, value.AtomicWriteFile);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AddListElement:
                AddListElementRequestCodec.Encode(ref writer, 8, value.AddListElement);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.RemoveListElement:
                RemoveListElementRequestCodec.Encode(ref writer, 9, value.RemoveListElement);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.CreateObject:
                CreateObjectRequestCodec.Encode(ref writer, 10, value.CreateObject);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeleteObject:
                DeleteObjectRequestCodec.Encode(ref writer, 11, value.DeleteObject);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadProperty:
                ReadPropertyRequestCodec.Encode(ref writer, 12, value.ReadProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadPropertyMultiple:
                ReadPropertyMultipleRequestCodec.Encode(ref writer, 14, value.ReadPropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadRange:
                ReadRangeRequestCodec.Encode(ref writer, 26, value.ReadRange);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WriteProperty:
                WritePropertyRequestCodec.Encode(ref writer, 15, value.WriteProperty);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WritePropertyMultiple:
                WritePropertyMultipleRequestCodec.Encode(ref writer, 16, value.WritePropertyMultiple);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuditLogQuery:
                AuditLogQueryRequestCodec.Encode(ref writer, 33, value.AuditLogQuery);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeviceCommunicationControl:
                DeviceCommunicationControlRequestCodec.Encode(ref writer, 17, value.DeviceCommunicationControl);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedPrivateTransfer:
                ConfirmedPrivateTransferRequestCodec.Encode(ref writer, 18, value.ConfirmedPrivateTransfer);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedTextMessage:
                ConfirmedTextMessageRequestCodec.Encode(ref writer, 19, value.ConfirmedTextMessage);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReinitializeDevice:
                ReinitializeDeviceRequestCodec.Encode(ref writer, 20, value.ReinitializeDevice);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuthRequest:
                AuthRequestRequestCodec.Encode(ref writer, 34, value.AuthRequest);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtOpen:
                VtOpenRequestCodec.Encode(ref writer, 21, value.VtOpen);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtClose:
                VtCloseRequestCodec.Encode(ref writer, 22, value.VtClose);
                return;
            case global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtData:
                VtDataRequestCodec.Encode(ref writer, 23, value.VtData);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
        => AsduConstructed.Encode<ConfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AcknowledgeAlarm
                => AcknowledgeAlarmRequestCodec.GetEncodedLength(value.AcknowledgeAlarm, 0),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotification
                => ConfirmedCovNotificationRequestCodec.GetEncodedLength(value.ConfirmedCovNotification, 1),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedCovNotificationMultiple
                => ConfirmedCovNotificationMultipleRequestCodec.GetEncodedLength(value.ConfirmedCovNotificationMultiple, 31),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedEventNotification
                => ConfirmedEventNotificationRequestCodec.GetEncodedLength(value.ConfirmedEventNotification, 2),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEnrollmentSummary
                => GetEnrollmentSummaryRequestCodec.GetEncodedLength(value.GetEnrollmentSummary, 4),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.GetEventInformation
                => GetEventInformationRequestCodec.GetEncodedLength(value.GetEventInformation, 29),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.LifeSafetyOperation
                => LifeSafetyOperationRequestCodec.GetEncodedLength(value.LifeSafetyOperation, 27),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCov
                => SubscribeCovRequestCodec.GetEncodedLength(value.SubscribeCov, 5),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovProperty
                => SubscribeCovPropertyRequestCodec.GetEncodedLength(value.SubscribeCovProperty, 28),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.SubscribeCovPropertyMultiple
                => SubscribeCovPropertyMultipleRequestCodec.GetEncodedLength(value.SubscribeCovPropertyMultiple, 30),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedAuditNotification
                => ConfirmedAuditNotificationRequestCodec.GetEncodedLength(value.ConfirmedAuditNotification, 32),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicReadFile
                => AtomicReadFileRequestCodec.GetEncodedLength(value.AtomicReadFile, 6),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AtomicWriteFile
                => AtomicWriteFileRequestCodec.GetEncodedLength(value.AtomicWriteFile, 7),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AddListElement
                => AddListElementRequestCodec.GetEncodedLength(value.AddListElement, 8),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.RemoveListElement
                => RemoveListElementRequestCodec.GetEncodedLength(value.RemoveListElement, 9),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.CreateObject
                => CreateObjectRequestCodec.GetEncodedLength(value.CreateObject, 10),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeleteObject
                => DeleteObjectRequestCodec.GetEncodedLength(value.DeleteObject, 11),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadProperty
                => ReadPropertyRequestCodec.GetEncodedLength(value.ReadProperty, 12),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadPropertyMultiple
                => ReadPropertyMultipleRequestCodec.GetEncodedLength(value.ReadPropertyMultiple, 14),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReadRange
                => ReadRangeRequestCodec.GetEncodedLength(value.ReadRange, 26),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WriteProperty
                => WritePropertyRequestCodec.GetEncodedLength(value.WriteProperty, 15),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.WritePropertyMultiple
                => WritePropertyMultipleRequestCodec.GetEncodedLength(value.WritePropertyMultiple, 16),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuditLogQuery
                => AuditLogQueryRequestCodec.GetEncodedLength(value.AuditLogQuery, 33),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.DeviceCommunicationControl
                => DeviceCommunicationControlRequestCodec.GetEncodedLength(value.DeviceCommunicationControl, 17),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedPrivateTransfer
                => ConfirmedPrivateTransferRequestCodec.GetEncodedLength(value.ConfirmedPrivateTransfer, 18),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ConfirmedTextMessage
                => ConfirmedTextMessageRequestCodec.GetEncodedLength(value.ConfirmedTextMessage, 19),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.ReinitializeDevice
                => ReinitializeDeviceRequestCodec.GetEncodedLength(value.ReinitializeDevice, 20),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.AuthRequest
                => AuthRequestRequestCodec.GetEncodedLength(value.AuthRequest, 34),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtOpen
                => VtOpenRequestCodec.GetEncodedLength(value.VtOpen, 21),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtClose
                => VtCloseRequestCodec.GetEncodedLength(value.VtClose, 22),
            global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest.Option.VtData
                => VtDataRequestCodec.GetEncodedLength(value.VtData, 23),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest value, byte tagNumber)
        => AsduElement.GetEncodedLength<ConfirmedServiceRequestCodec, global::Baclib.Bacnet.Types.Application.ConfirmedServiceRequest>(tagNumber, value);
}
