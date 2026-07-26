// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Codec for the BACnet <c>ABSTRACT-SYNTAX.&amp;Type</c> ("Any").
/// </summary>
public sealed class AnyCodec : IAsduElementCodec<T.Any>
{
    /// <inheritdoc/>
    public static bool Matches(ref AsduReader reader) => true;

    /// <inheritdoc/>
    public static T.Any Decode(ref AsduReader reader)
    {
        var span = reader.ReadAny();
        var value = new AsduEncodedData(span);
        return new T.Any(value);
    }

    /// <inheritdoc/>
    public static T.Any Decode(ref AsduReader reader, byte tagNumber)
    {
        var span = reader.ReadAny(tagNumber);
        var value = new AsduEncodedData(span);
        return new T.Any(value);
    }

    /// <inheritdoc/>
    public static void Encode(ref AsduWriter writer, in T.Any value)
    {
        switch (value.Value)
        {
            case T::AbortReason varAbortReason:
                AbortReasonCodec.Encode(ref writer, varAbortReason);
                break;
            case T::AccessAuthenticationFactorDisable varAccessAuthenticationFactorDisable:
                AccessAuthenticationFactorDisableCodec.Encode(ref writer, varAccessAuthenticationFactorDisable);
                break;
            case T::AccessCredentialDisable varAccessCredentialDisable:
                AccessCredentialDisableCodec.Encode(ref writer, varAccessCredentialDisable);
                break;
            case T::AccessCredentialDisableReason varAccessCredentialDisableReason:
                AccessCredentialDisableReasonCodec.Encode(ref writer, varAccessCredentialDisableReason);
                break;
            case T::AccessEvent varAccessEvent:
                AccessEventCodec.Encode(ref writer, varAccessEvent);
                break;
            case T::AccessPassbackMode varAccessPassbackMode:
                AccessPassbackModeCodec.Encode(ref writer, varAccessPassbackMode);
                break;
            case T::AccessRule varAccessRule:
                AccessRuleCodec.Encode(ref writer, varAccessRule);
                break;
            case T::AccessRule.TLocationSpecifier varAccessRuleTLocationSpecifier:
                AccessRuleTLocationSpecifierCodec.Encode(ref writer, varAccessRuleTLocationSpecifier);
                break;
            case T::AccessRule.TTimeRangeSpecifier varAccessRuleTTimeRangeSpecifier:
                AccessRuleTTimeRangeSpecifierCodec.Encode(ref writer, varAccessRuleTTimeRangeSpecifier);
                break;
            case T::AccessThreatLevel varAccessThreatLevel:
                AccessThreatLevelCodec.Encode(ref writer, varAccessThreatLevel);
                break;
            case T::AccessToken varAccessToken:
                AccessTokenCodec.Encode(ref writer, varAccessToken);
                break;
            case T::AccessUserType varAccessUserType:
                AccessUserTypeCodec.Encode(ref writer, varAccessUserType);
                break;
            case T::AccessZoneOccupancyState varAccessZoneOccupancyState:
                AccessZoneOccupancyStateCodec.Encode(ref writer, varAccessZoneOccupancyState);
                break;
            case T::AccumulatorRecord varAccumulatorRecord:
                AccumulatorRecordCodec.Encode(ref writer, varAccumulatorRecord);
                break;
            case T::AccumulatorRecord.TAccumulatorStatus varAccumulatorRecordTAccumulatorStatus:
                AccumulatorRecordTAccumulatorStatusCodec.Encode(ref writer, varAccumulatorRecordTAccumulatorStatus);
                break;
            case T::AcknowledgeAlarmInfo varAcknowledgeAlarmInfo:
                AcknowledgeAlarmInfoCodec.Encode(ref writer, varAcknowledgeAlarmInfo);
                break;
            case T::AcknowledgeAlarmRequest varAcknowledgeAlarmRequest:
                AcknowledgeAlarmRequestCodec.Encode(ref writer, varAcknowledgeAlarmRequest);
                break;
            case T::Action varAction:
                ActionCodec.Encode(ref writer, varAction);
                break;
            case T::ActionCommand varActionCommand:
                ActionCommandCodec.Encode(ref writer, varActionCommand);
                break;
            case T::ActionCommand.TPriority varActionCommandTPriority:
                ActionCommandTPriorityCodec.Encode(ref writer, varActionCommandTPriority);
                break;
            case T::ActionList varActionList:
                ActionListCodec.Encode(ref writer, varActionList);
                break;
            case T::AddListElementRequest varAddListElementRequest:
                AddListElementRequestCodec.Encode(ref writer, varAddListElementRequest);
                break;
            case T::AddressBinding varAddressBinding:
                AddressBindingCodec.Encode(ref writer, varAddressBinding);
                break;
            case T::Address varAddress:
                AddressCodec.Encode(ref writer, varAddress);
                break;
            case T::AnyPrimitive varAnyPrimitive:
                AnyPrimitiveCodec.Encode(ref writer, varAnyPrimitive);
                break;
            case T::AssignedAccessRights varAssignedAccessRights:
                AssignedAccessRightsCodec.Encode(ref writer, varAssignedAccessRights);
                break;
            case T::AssignedLandingCalls varAssignedLandingCalls:
                AssignedLandingCallsCodec.Encode(ref writer, varAssignedLandingCalls);
                break;
            case T::AssignedLandingCalls.TLandingCallsItem varAssignedLandingCallsTLandingCallsItem:
                AssignedLandingCallsTLandingCallsItemCodec.Encode(ref writer, varAssignedLandingCallsTLandingCallsItem);
                break;
            case T::AtomicReadFileAck varAtomicReadFileAck:
                AtomicReadFileAckCodec.Encode(ref writer, varAtomicReadFileAck);
                break;
            case T::AtomicReadFileAck.TAccessMethod varAtomicReadFileAckTAccessMethod:
                AtomicReadFileAckTAccessMethodCodec.Encode(ref writer, varAtomicReadFileAckTAccessMethod);
                break;
            case T::AtomicReadFileAck.TAccessMethod.TRecordAccess varAtomicReadFileAckTAccessMethodTRecordAccess:
                AtomicReadFileAckTAccessMethodTRecordAccessCodec.Encode(ref writer, varAtomicReadFileAckTAccessMethodTRecordAccess);
                break;
            case T::AtomicReadFileAck.TAccessMethod.TStreamAccess varAtomicReadFileAckTAccessMethodTStreamAccess:
                AtomicReadFileAckTAccessMethodTStreamAccessCodec.Encode(ref writer, varAtomicReadFileAckTAccessMethodTStreamAccess);
                break;
            case T::AtomicReadFileRequest varAtomicReadFileRequest:
                AtomicReadFileRequestCodec.Encode(ref writer, varAtomicReadFileRequest);
                break;
            case T::AtomicReadFileRequest.TAccessMethod varAtomicReadFileRequestTAccessMethod:
                AtomicReadFileRequestTAccessMethodCodec.Encode(ref writer, varAtomicReadFileRequestTAccessMethod);
                break;
            case T::AtomicReadFileRequest.TAccessMethod.TRecordAccess varAtomicReadFileRequestTAccessMethodTRecordAccess:
                AtomicReadFileRequestTAccessMethodTRecordAccessCodec.Encode(ref writer, varAtomicReadFileRequestTAccessMethodTRecordAccess);
                break;
            case T::AtomicReadFileRequest.TAccessMethod.TStreamAccess varAtomicReadFileRequestTAccessMethodTStreamAccess:
                AtomicReadFileRequestTAccessMethodTStreamAccessCodec.Encode(ref writer, varAtomicReadFileRequestTAccessMethodTStreamAccess);
                break;
            case T::AtomicWriteFileAck varAtomicWriteFileAck:
                AtomicWriteFileAckCodec.Encode(ref writer, varAtomicWriteFileAck);
                break;
            case T::AtomicWriteFileRequest varAtomicWriteFileRequest:
                AtomicWriteFileRequestCodec.Encode(ref writer, varAtomicWriteFileRequest);
                break;
            case T::AtomicWriteFileRequest.TAccessMethod varAtomicWriteFileRequestTAccessMethod:
                AtomicWriteFileRequestTAccessMethodCodec.Encode(ref writer, varAtomicWriteFileRequestTAccessMethod);
                break;
            case T::AtomicWriteFileRequest.TAccessMethod.TRecordAccess varAtomicWriteFileRequestTAccessMethodTRecordAccess:
                AtomicWriteFileRequestTAccessMethodTRecordAccessCodec.Encode(ref writer, varAtomicWriteFileRequestTAccessMethodTRecordAccess);
                break;
            case T::AtomicWriteFileRequest.TAccessMethod.TStreamAccess varAtomicWriteFileRequestTAccessMethodTStreamAccess:
                AtomicWriteFileRequestTAccessMethodTStreamAccessCodec.Encode(ref writer, varAtomicWriteFileRequestTAccessMethodTStreamAccess);
                break;
            case T::AuditLevel varAuditLevel:
                AuditLevelCodec.Encode(ref writer, varAuditLevel);
                break;
            case T::AuditLogQueryAck varAuditLogQueryAck:
                AuditLogQueryAckCodec.Encode(ref writer, varAuditLogQueryAck);
                break;
            case T::AuditLogQueryParameters varAuditLogQueryParameters:
                AuditLogQueryParametersCodec.Encode(ref writer, varAuditLogQueryParameters);
                break;
            case T::AuditLogQueryParameters.TBySource varAuditLogQueryParametersTBySource:
                AuditLogQueryParametersTBySourceCodec.Encode(ref writer, varAuditLogQueryParametersTBySource);
                break;
            case T::AuditLogQueryParameters.TByTarget varAuditLogQueryParametersTByTarget:
                AuditLogQueryParametersTByTargetCodec.Encode(ref writer, varAuditLogQueryParametersTByTarget);
                break;
            case T::AuditLogQueryParameters.TByTarget.TTargetPriority varAuditLogQueryParametersTByTargetTTargetPriority:
                AuditLogQueryParametersTByTargetTTargetPriorityCodec.Encode(ref writer, varAuditLogQueryParametersTByTargetTTargetPriority);
                break;
            case T::AuditLogQueryRequest varAuditLogQueryRequest:
                AuditLogQueryRequestCodec.Encode(ref writer, varAuditLogQueryRequest);
                break;
            case T::AuditLogRecord varAuditLogRecord:
                AuditLogRecordCodec.Encode(ref writer, varAuditLogRecord);
                break;
            case T::AuditLogRecordResult varAuditLogRecordResult:
                AuditLogRecordResultCodec.Encode(ref writer, varAuditLogRecordResult);
                break;
            case T::AuditLogRecord.TLogDatum varAuditLogRecordTLogDatum:
                AuditLogRecordTLogDatumCodec.Encode(ref writer, varAuditLogRecordTLogDatum);
                break;
            case T::AuditNotification varAuditNotification:
                AuditNotificationCodec.Encode(ref writer, varAuditNotification);
                break;
            case T::AuditNotification.TTargetPriority varAuditNotificationTTargetPriority:
                AuditNotificationTTargetPriorityCodec.Encode(ref writer, varAuditNotificationTTargetPriority);
                break;
            case T::AuditOperation varAuditOperation:
                AuditOperationCodec.Encode(ref writer, varAuditOperation);
                break;
            case T::AuditOperationFlags varAuditOperationFlags:
                AuditOperationFlagsCodec.Encode(ref writer, varAuditOperationFlags);
                break;
            case T::AuthenticationClient varAuthenticationClient:
                AuthenticationClientCodec.Encode(ref writer, varAuthenticationClient);
                break;
            case T::AuthenticationDecision varAuthenticationDecision:
                AuthenticationDecisionCodec.Encode(ref writer, varAuthenticationDecision);
                break;
            case T::AuthenticationEvent varAuthenticationEvent:
                AuthenticationEventCodec.Encode(ref writer, varAuthenticationEvent);
                break;
            case T::AuthenticationFactor varAuthenticationFactor:
                AuthenticationFactorCodec.Encode(ref writer, varAuthenticationFactor);
                break;
            case T::AuthenticationFactorFormat varAuthenticationFactorFormat:
                AuthenticationFactorFormatCodec.Encode(ref writer, varAuthenticationFactorFormat);
                break;
            case T::AuthenticationFactorType varAuthenticationFactorType:
                AuthenticationFactorTypeCodec.Encode(ref writer, varAuthenticationFactorType);
                break;
            case T::AuthenticationPeer varAuthenticationPeer:
                AuthenticationPeerCodec.Encode(ref writer, varAuthenticationPeer);
                break;
            case T::AuthenticationPolicy varAuthenticationPolicy:
                AuthenticationPolicyCodec.Encode(ref writer, varAuthenticationPolicy);
                break;
            case T::AuthenticationPolicy.TPolicyItem varAuthenticationPolicyTPolicyItem:
                AuthenticationPolicyTPolicyItemCodec.Encode(ref writer, varAuthenticationPolicyTPolicyItem);
                break;
            case T::AuthenticationStatus varAuthenticationStatus:
                AuthenticationStatusCodec.Encode(ref writer, varAuthenticationStatus);
                break;
            case T::AuthorizationConstraint varAuthorizationConstraint:
                AuthorizationConstraintCodec.Encode(ref writer, varAuthorizationConstraint);
                break;
            case T::AuthorizationConstraint.TAuthentication varAuthorizationConstraintTAuthentication:
                AuthorizationConstraintTAuthenticationCodec.Encode(ref writer, varAuthorizationConstraintTAuthentication);
                break;
            case T::AuthorizationConstraint.TOrigin varAuthorizationConstraintTOrigin:
                AuthorizationConstraintTOriginCodec.Encode(ref writer, varAuthorizationConstraintTOrigin);
                break;
            case T::AuthorizationDecision varAuthorizationDecision:
                AuthorizationDecisionCodec.Encode(ref writer, varAuthorizationDecision);
                break;
            case T::AuthorizationEvent varAuthorizationEvent:
                AuthorizationEventCodec.Encode(ref writer, varAuthorizationEvent);
                break;
            case T::AuthorizationExemption varAuthorizationExemption:
                AuthorizationExemptionCodec.Encode(ref writer, varAuthorizationExemption);
                break;
            case T::AuthorizationMode varAuthorizationMode:
                AuthorizationModeCodec.Encode(ref writer, varAuthorizationMode);
                break;
            case T::AuthorizationPolicy varAuthorizationPolicy:
                AuthorizationPolicyCodec.Encode(ref writer, varAuthorizationPolicy);
                break;
            case T::AuthorizationPosture varAuthorizationPosture:
                AuthorizationPostureCodec.Encode(ref writer, varAuthorizationPosture);
                break;
            case T::AuthorizationScope varAuthorizationScope:
                AuthorizationScopeCodec.Encode(ref writer, varAuthorizationScope);
                break;
            case T::AuthorizationScopeDescription varAuthorizationScopeDescription:
                AuthorizationScopeDescriptionCodec.Encode(ref writer, varAuthorizationScopeDescription);
                break;
            case T::AuthorizationScope.TStandard varAuthorizationScopeTStandard:
                AuthorizationScopeTStandardCodec.Encode(ref writer, varAuthorizationScopeTStandard);
                break;
            case T::AuthorizationServer varAuthorizationServer:
                AuthorizationServerCodec.Encode(ref writer, varAuthorizationServer);
                break;
            case T::AuthorizationStatus varAuthorizationStatus:
                AuthorizationStatusCodec.Encode(ref writer, varAuthorizationStatus);
                break;
            case T::AuthRequestAck varAuthRequestAck:
                AuthRequestAckCodec.Encode(ref writer, varAuthRequestAck);
                break;
            case T::AuthRequestError varAuthRequestError:
                AuthRequestErrorCodec.Encode(ref writer, varAuthRequestError);
                break;
            case T::AuthRequestRequest varAuthRequestRequest:
                AuthRequestRequestCodec.Encode(ref writer, varAuthRequestRequest);
                break;
            case T::AuthRequestRequest.TTokenRequest varAuthRequestRequestTTokenRequest:
                AuthRequestRequestTTokenRequestCodec.Encode(ref writer, varAuthRequestRequestTTokenRequest);
                break;
            case T::BackupState varBackupState:
                BackupStateCodec.Encode(ref writer, varBackupState);
                break;
            case T::BdtEntry varBdtEntry:
                BdtEntryCodec.Encode(ref writer, varBdtEntry);
                break;
            case T::BinaryLightingPv varBinaryLightingPv:
                BinaryLightingPvCodec.Encode(ref writer, varBinaryLightingPv);
                break;
            case T::BinaryPv varBinaryPv:
                BinaryPvCodec.Encode(ref writer, varBinaryPv);
                break;
            case T::BitString16 varBitString16:
                BitString16Codec.Encode(ref writer, varBitString16);
                break;
            case T::BitString32 varBitString32:
                BitString32Codec.Encode(ref writer, varBitString32);
                break;
            case T::BitString64 varBitString64:
                BitString64Codec.Encode(ref writer, varBitString64);
                break;
            case T::BitString8 varBitString8:
                BitString8Codec.Encode(ref writer, varBitString8);
                break;
            case T::BitString varBitString:
                BitStringCodec.Encode(ref writer, varBitString);
                break;
            case bool varBoolean:
                BooleanCodec.Encode(ref writer, varBoolean);
                break;
            case T::CalendarEntry varCalendarEntry:
                CalendarEntryCodec.Encode(ref writer, varCalendarEntry);
                break;
            case T::ChangeListError varChangeListError:
                ChangeListErrorCodec.Encode(ref writer, varChangeListError);
                break;
            case T::ChannelValue varChannelValue:
                ChannelValueCodec.Encode(ref writer, varChannelValue);
                break;
            case T::CharacterString varCharacterString:
                CharacterStringCodec.Encode(ref writer, varCharacterString);
                break;
            case T::ClientCov varClientCov:
                ClientCovCodec.Encode(ref writer, varClientCov);
                break;
            case T::ColorCommand varColorCommand:
                ColorCommandCodec.Encode(ref writer, varColorCommand);
                break;
            case T::ColorCommand.TFadeTime varColorCommandTFadeTime:
                ColorCommandTFadeTimeCodec.Encode(ref writer, varColorCommandTFadeTime);
                break;
            case T::ColorCommand.TRampRate varColorCommandTRampRate:
                ColorCommandTRampRateCodec.Encode(ref writer, varColorCommandTRampRate);
                break;
            case T::ColorCommand.TStepIncrement varColorCommandTStepIncrement:
                ColorCommandTStepIncrementCodec.Encode(ref writer, varColorCommandTStepIncrement);
                break;
            case T::ColorOperation varColorOperation:
                ColorOperationCodec.Encode(ref writer, varColorOperation);
                break;
            case T::ColorOperationInProgress varColorOperationInProgress:
                ColorOperationInProgressCodec.Encode(ref writer, varColorOperationInProgress);
                break;
            case T::ColorTransition varColorTransition:
                ColorTransitionCodec.Encode(ref writer, varColorTransition);
                break;
            case T::CommandPriority varCommandPriority:
                CommandPriorityCodec.Encode(ref writer, varCommandPriority);
                break;
            case T::ConfirmedAuditNotificationRequest varConfirmedAuditNotificationRequest:
                ConfirmedAuditNotificationRequestCodec.Encode(ref writer, varConfirmedAuditNotificationRequest);
                break;
            case T::ConfirmedCovNotificationMultipleRequest varConfirmedCovNotificationMultipleRequest:
                ConfirmedCovNotificationMultipleRequestCodec.Encode(ref writer, varConfirmedCovNotificationMultipleRequest);
                break;
            case T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem:
                ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec.Encode(ref writer, varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem);
                break;
            case T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem:
                ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec.Encode(ref writer, varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem);
                break;
            case T::ConfirmedCovNotificationRequest varConfirmedCovNotificationRequest:
                ConfirmedCovNotificationRequestCodec.Encode(ref writer, varConfirmedCovNotificationRequest);
                break;
            case T::ConfirmedEventNotificationRequest varConfirmedEventNotificationRequest:
                ConfirmedEventNotificationRequestCodec.Encode(ref writer, varConfirmedEventNotificationRequest);
                break;
            case T::ConfirmedPrivateTransferAck varConfirmedPrivateTransferAck:
                ConfirmedPrivateTransferAckCodec.Encode(ref writer, varConfirmedPrivateTransferAck);
                break;
            case T::ConfirmedPrivateTransferError varConfirmedPrivateTransferError:
                ConfirmedPrivateTransferErrorCodec.Encode(ref writer, varConfirmedPrivateTransferError);
                break;
            case T::ConfirmedPrivateTransferRequest varConfirmedPrivateTransferRequest:
                ConfirmedPrivateTransferRequestCodec.Encode(ref writer, varConfirmedPrivateTransferRequest);
                break;
            case T::ConfirmedServiceAck varConfirmedServiceAck:
                ConfirmedServiceAckCodec.Encode(ref writer, varConfirmedServiceAck);
                break;
            case T::ConfirmedServiceChoice varConfirmedServiceChoice:
                ConfirmedServiceChoiceCodec.Encode(ref writer, varConfirmedServiceChoice);
                break;
            case T::ConfirmedServiceRequest varConfirmedServiceRequest:
                ConfirmedServiceRequestCodec.Encode(ref writer, varConfirmedServiceRequest);
                break;
            case T::ConfirmedTextMessageRequest varConfirmedTextMessageRequest:
                ConfirmedTextMessageRequestCodec.Encode(ref writer, varConfirmedTextMessageRequest);
                break;
            case T::ConfirmedTextMessageRequest.TMessageClass varConfirmedTextMessageRequestTMessageClass:
                ConfirmedTextMessageRequestTMessageClassCodec.Encode(ref writer, varConfirmedTextMessageRequestTMessageClass);
                break;
            case T::ConfirmedTextMessageRequest.TMessagePriority varConfirmedTextMessageRequestTMessagePriority:
                ConfirmedTextMessageRequestTMessagePriorityCodec.Encode(ref writer, varConfirmedTextMessageRequestTMessagePriority);
                break;
            case T::CovMultipleSubscription varCovMultipleSubscription:
                CovMultipleSubscriptionCodec.Encode(ref writer, varCovMultipleSubscription);
                break;
            case T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItem:
                CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec.Encode(ref writer, varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItem);
                break;
            case T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem:
                CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec.Encode(ref writer, varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem);
                break;
            case T::CovSubscription varCovSubscription:
                CovSubscriptionCodec.Encode(ref writer, varCovSubscription);
                break;
            case T::CreateObjectError varCreateObjectError:
                CreateObjectErrorCodec.Encode(ref writer, varCreateObjectError);
                break;
            case T::CreateObjectRequest varCreateObjectRequest:
                CreateObjectRequestCodec.Encode(ref writer, varCreateObjectRequest);
                break;
            case T::CreateObjectRequest.TObjectSpecifier varCreateObjectRequestTObjectSpecifier:
                CreateObjectRequestTObjectSpecifierCodec.Encode(ref writer, varCreateObjectRequestTObjectSpecifier);
                break;
            case T::CredentialAuthenticationFactor varCredentialAuthenticationFactor:
                CredentialAuthenticationFactorCodec.Encode(ref writer, varCredentialAuthenticationFactor);
                break;
            case T::DailySchedule varDailySchedule:
                DailyScheduleCodec.Encode(ref writer, varDailySchedule);
                break;
            case T::Date varDate:
                DateCodec.Encode(ref writer, varDate);
                break;
            case T::DatePattern varDatePattern:
                DatePatternCodec.Encode(ref writer, varDatePattern);
                break;
            case T::DateRange varDateRange:
                DateRangeCodec.Encode(ref writer, varDateRange);
                break;
            case T::DateTime varDateTime:
                DateTimeCodec.Encode(ref writer, varDateTime);
                break;
            case T::DateTimePattern varDateTimePattern:
                DateTimePatternCodec.Encode(ref writer, varDateTimePattern);
                break;
            case T::DaysOfWeek varDaysOfWeek:
                DaysOfWeekCodec.Encode(ref writer, varDaysOfWeek);
                break;
            case T::DeleteObjectRequest varDeleteObjectRequest:
                DeleteObjectRequestCodec.Encode(ref writer, varDeleteObjectRequest);
                break;
            case T::Destination varDestination:
                DestinationCodec.Encode(ref writer, varDestination);
                break;
            case T::DeviceAddressProxyTableEntry varDeviceAddressProxyTableEntry:
                DeviceAddressProxyTableEntryCodec.Encode(ref writer, varDeviceAddressProxyTableEntry);
                break;
            case T::DeviceCommunicationControlRequest varDeviceCommunicationControlRequest:
                DeviceCommunicationControlRequestCodec.Encode(ref writer, varDeviceCommunicationControlRequest);
                break;
            case T::DeviceCommunicationControlRequest.TEnableDisable varDeviceCommunicationControlRequestTEnableDisable:
                DeviceCommunicationControlRequestTEnableDisableCodec.Encode(ref writer, varDeviceCommunicationControlRequestTEnableDisable);
                break;
            case T::DeviceCommunicationControlRequest.TPassword varDeviceCommunicationControlRequestTPassword:
                DeviceCommunicationControlRequestTPasswordCodec.Encode(ref writer, varDeviceCommunicationControlRequestTPassword);
                break;
            case T::DeviceObjectPropertyReference varDeviceObjectPropertyReference:
                DeviceObjectPropertyReferenceCodec.Encode(ref writer, varDeviceObjectPropertyReference);
                break;
            case T::DeviceObjectPropertyValue varDeviceObjectPropertyValue:
                DeviceObjectPropertyValueCodec.Encode(ref writer, varDeviceObjectPropertyValue);
                break;
            case T::DeviceObjectReference varDeviceObjectReference:
                DeviceObjectReferenceCodec.Encode(ref writer, varDeviceObjectReference);
                break;
            case T::DeviceStatus varDeviceStatus:
                DeviceStatusCodec.Encode(ref writer, varDeviceStatus);
                break;
            case T::DoorAlarmState varDoorAlarmState:
                DoorAlarmStateCodec.Encode(ref writer, varDoorAlarmState);
                break;
            case T::DoorSecuredStatus varDoorSecuredStatus:
                DoorSecuredStatusCodec.Encode(ref writer, varDoorSecuredStatus);
                break;
            case T::DoorStatus varDoorStatus:
                DoorStatusCodec.Encode(ref writer, varDoorStatus);
                break;
            case T::DoorValue varDoorValue:
                DoorValueCodec.Encode(ref writer, varDoorValue);
                break;
            case double varDouble:
                DoubleCodec.Encode(ref writer, varDouble);
                break;
            case T::EngineeringUnits varEngineeringUnits:
                EngineeringUnitsCodec.Encode(ref writer, varEngineeringUnits);
                break;
            case T::Enumerated16 varEnumerated16:
                Enumerated16Codec.Encode(ref writer, varEnumerated16);
                break;
            case T::Enumerated32 varEnumerated32:
                Enumerated32Codec.Encode(ref writer, varEnumerated32);
                break;
            case T::Enumerated64 varEnumerated64:
                Enumerated64Codec.Encode(ref writer, varEnumerated64);
                break;
            case T::Enumerated8 varEnumerated8:
                Enumerated8Codec.Encode(ref writer, varEnumerated8);
                break;
            case T::Enumerated varEnumerated:
                EnumeratedCodec.Encode(ref writer, varEnumerated);
                break;
            case T::Error varError:
                ErrorCodec.Encode(ref writer, varError);
                break;
            case T::Error.TErrorClass varErrorTErrorClass:
                ErrorTErrorClassCodec.Encode(ref writer, varErrorTErrorClass);
                break;
            case T::Error.TErrorCode varErrorTErrorCode:
                ErrorTErrorCodeCodec.Encode(ref writer, varErrorTErrorCode);
                break;
            case T::EscalatorFault varEscalatorFault:
                EscalatorFaultCodec.Encode(ref writer, varEscalatorFault);
                break;
            case T::EscalatorMode varEscalatorMode:
                EscalatorModeCodec.Encode(ref writer, varEscalatorMode);
                break;
            case T::EscalatorOperationDirection varEscalatorOperationDirection:
                EscalatorOperationDirectionCodec.Encode(ref writer, varEscalatorOperationDirection);
                break;
            case T::EventLogRecord varEventLogRecord:
                EventLogRecordCodec.Encode(ref writer, varEventLogRecord);
                break;
            case T::EventLogRecord.TLogDatum varEventLogRecordTLogDatum:
                EventLogRecordTLogDatumCodec.Encode(ref writer, varEventLogRecordTLogDatum);
                break;
            case T::EventNotificationSubscription varEventNotificationSubscription:
                EventNotificationSubscriptionCodec.Encode(ref writer, varEventNotificationSubscription);
                break;
            case T::EventParameter varEventParameter:
                EventParameterCodec.Encode(ref writer, varEventParameter);
                break;
            case T::EventParameter.TAccessEvent varEventParameterTAccessEvent:
                EventParameterTAccessEventCodec.Encode(ref writer, varEventParameterTAccessEvent);
                break;
            case T::EventParameter.TBufferReady varEventParameterTBufferReady:
                EventParameterTBufferReadyCodec.Encode(ref writer, varEventParameterTBufferReady);
                break;
            case T::EventParameter.TChangeOfBitstring varEventParameterTChangeOfBitstring:
                EventParameterTChangeOfBitstringCodec.Encode(ref writer, varEventParameterTChangeOfBitstring);
                break;
            case T::EventParameter.TChangeOfCharacterstring varEventParameterTChangeOfCharacterstring:
                EventParameterTChangeOfCharacterstringCodec.Encode(ref writer, varEventParameterTChangeOfCharacterstring);
                break;
            case T::EventParameter.TChangeOfDiscreteValue varEventParameterTChangeOfDiscreteValue:
                EventParameterTChangeOfDiscreteValueCodec.Encode(ref writer, varEventParameterTChangeOfDiscreteValue);
                break;
            case T::EventParameter.TChangeOfDiscreteValue.TNewValue varEventParameterTChangeOfDiscreteValueTNewValue:
                EventParameterTChangeOfDiscreteValueTNewValueCodec.Encode(ref writer, varEventParameterTChangeOfDiscreteValueTNewValue);
                break;
            case T::EventParameter.TChangeOfLifeSafety varEventParameterTChangeOfLifeSafety:
                EventParameterTChangeOfLifeSafetyCodec.Encode(ref writer, varEventParameterTChangeOfLifeSafety);
                break;
            case T::EventParameter.TChangeOfState varEventParameterTChangeOfState:
                EventParameterTChangeOfStateCodec.Encode(ref writer, varEventParameterTChangeOfState);
                break;
            case T::EventParameter.TChangeOfStatusFlags varEventParameterTChangeOfStatusFlags:
                EventParameterTChangeOfStatusFlagsCodec.Encode(ref writer, varEventParameterTChangeOfStatusFlags);
                break;
            case T::EventParameter.TChangeOfTimer varEventParameterTChangeOfTimer:
                EventParameterTChangeOfTimerCodec.Encode(ref writer, varEventParameterTChangeOfTimer);
                break;
            case T::EventParameter.TChangeOfValue varEventParameterTChangeOfValue:
                EventParameterTChangeOfValueCodec.Encode(ref writer, varEventParameterTChangeOfValue);
                break;
            case T::EventParameter.TChangeOfValue.TCovCriteria varEventParameterTChangeOfValueTCovCriteria:
                EventParameterTChangeOfValueTCovCriteriaCodec.Encode(ref writer, varEventParameterTChangeOfValueTCovCriteria);
                break;
            case T::EventParameter.TCommandFailure varEventParameterTCommandFailure:
                EventParameterTCommandFailureCodec.Encode(ref writer, varEventParameterTCommandFailure);
                break;
            case T::EventParameter.TDoubleOutOfRange varEventParameterTDoubleOutOfRange:
                EventParameterTDoubleOutOfRangeCodec.Encode(ref writer, varEventParameterTDoubleOutOfRange);
                break;
            case T::EventParameter.TExtended varEventParameterTExtended:
                EventParameterTExtendedCodec.Encode(ref writer, varEventParameterTExtended);
                break;
            case T::EventParameter.TExtended.TParametersItem varEventParameterTExtendedTParametersItem:
                EventParameterTExtendedTParametersItemCodec.Encode(ref writer, varEventParameterTExtendedTParametersItem);
                break;
            case T::EventParameter.TFloatingLimit varEventParameterTFloatingLimit:
                EventParameterTFloatingLimitCodec.Encode(ref writer, varEventParameterTFloatingLimit);
                break;
            case T::EventParameter.TOutOfRange varEventParameterTOutOfRange:
                EventParameterTOutOfRangeCodec.Encode(ref writer, varEventParameterTOutOfRange);
                break;
            case T::EventParameter.TSignedOutOfRange varEventParameterTSignedOutOfRange:
                EventParameterTSignedOutOfRangeCodec.Encode(ref writer, varEventParameterTSignedOutOfRange);
                break;
            case T::EventParameter.TUnsignedOutOfRange varEventParameterTUnsignedOutOfRange:
                EventParameterTUnsignedOutOfRangeCodec.Encode(ref writer, varEventParameterTUnsignedOutOfRange);
                break;
            case T::EventParameter.TUnsignedRange varEventParameterTUnsignedRange:
                EventParameterTUnsignedRangeCodec.Encode(ref writer, varEventParameterTUnsignedRange);
                break;
            case T::EventState varEventState:
                EventStateCodec.Encode(ref writer, varEventState);
                break;
            case T::EventTransitionBits varEventTransitionBits:
                EventTransitionBitsCodec.Encode(ref writer, varEventTransitionBits);
                break;
            case T::EventType varEventType:
                EventTypeCodec.Encode(ref writer, varEventType);
                break;
            case T::FaultParameter varFaultParameter:
                FaultParameterCodec.Encode(ref writer, varFaultParameter);
                break;
            case T::FaultParameter.TFaultCharacterstring varFaultParameterTFaultCharacterstring:
                FaultParameterTFaultCharacterstringCodec.Encode(ref writer, varFaultParameterTFaultCharacterstring);
                break;
            case T::FaultParameter.TFaultExtended varFaultParameterTFaultExtended:
                FaultParameterTFaultExtendedCodec.Encode(ref writer, varFaultParameterTFaultExtended);
                break;
            case T::FaultParameter.TFaultExtended.TParametersItem varFaultParameterTFaultExtendedTParametersItem:
                FaultParameterTFaultExtendedTParametersItemCodec.Encode(ref writer, varFaultParameterTFaultExtendedTParametersItem);
                break;
            case T::FaultParameter.TFaultLifeSafety varFaultParameterTFaultLifeSafety:
                FaultParameterTFaultLifeSafetyCodec.Encode(ref writer, varFaultParameterTFaultLifeSafety);
                break;
            case T::FaultParameter.TFaultListed varFaultParameterTFaultListed:
                FaultParameterTFaultListedCodec.Encode(ref writer, varFaultParameterTFaultListed);
                break;
            case T::FaultParameter.TFaultOutOfRange varFaultParameterTFaultOutOfRange:
                FaultParameterTFaultOutOfRangeCodec.Encode(ref writer, varFaultParameterTFaultOutOfRange);
                break;
            case T::FaultParameter.TFaultOutOfRange.TMaxNormalValue varFaultParameterTFaultOutOfRangeTMaxNormalValue:
                FaultParameterTFaultOutOfRangeTMaxNormalValueCodec.Encode(ref writer, varFaultParameterTFaultOutOfRangeTMaxNormalValue);
                break;
            case T::FaultParameter.TFaultOutOfRange.TMinNormalValue varFaultParameterTFaultOutOfRangeTMinNormalValue:
                FaultParameterTFaultOutOfRangeTMinNormalValueCodec.Encode(ref writer, varFaultParameterTFaultOutOfRangeTMinNormalValue);
                break;
            case T::FaultParameter.TFaultState varFaultParameterTFaultState:
                FaultParameterTFaultStateCodec.Encode(ref writer, varFaultParameterTFaultState);
                break;
            case T::FaultParameter.TFaultStatusFlags varFaultParameterTFaultStatusFlags:
                FaultParameterTFaultStatusFlagsCodec.Encode(ref writer, varFaultParameterTFaultStatusFlags);
                break;
            case T::FaultType varFaultType:
                FaultTypeCodec.Encode(ref writer, varFaultType);
                break;
            case T::FdtEntry varFdtEntry:
                FdtEntryCodec.Encode(ref writer, varFdtEntry);
                break;
            case T::FileAccessMethod varFileAccessMethod:
                FileAccessMethodCodec.Encode(ref writer, varFileAccessMethod);
                break;
            case T::GetAlarmSummaryAck varGetAlarmSummaryAck:
                GetAlarmSummaryAckCodec.Encode(ref writer, varGetAlarmSummaryAck);
                break;
            case T::GetAlarmSummaryAck.TItem varGetAlarmSummaryAckTItem:
                GetAlarmSummaryAckTItemCodec.Encode(ref writer, varGetAlarmSummaryAckTItem);
                break;
            case T::GetEnrollmentSummaryAck varGetEnrollmentSummaryAck:
                GetEnrollmentSummaryAckCodec.Encode(ref writer, varGetEnrollmentSummaryAck);
                break;
            case T::GetEnrollmentSummaryAck.TItem varGetEnrollmentSummaryAckTItem:
                GetEnrollmentSummaryAckTItemCodec.Encode(ref writer, varGetEnrollmentSummaryAckTItem);
                break;
            case T::GetEnrollmentSummaryRequest varGetEnrollmentSummaryRequest:
                GetEnrollmentSummaryRequestCodec.Encode(ref writer, varGetEnrollmentSummaryRequest);
                break;
            case T::GetEnrollmentSummaryRequest.TAcknowledgmentFilter varGetEnrollmentSummaryRequestTAcknowledgmentFilter:
                GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec.Encode(ref writer, varGetEnrollmentSummaryRequestTAcknowledgmentFilter);
                break;
            case T::GetEnrollmentSummaryRequest.TEventStateFilter varGetEnrollmentSummaryRequestTEventStateFilter:
                GetEnrollmentSummaryRequestTEventStateFilterCodec.Encode(ref writer, varGetEnrollmentSummaryRequestTEventStateFilter);
                break;
            case T::GetEnrollmentSummaryRequest.TPriorityFilter varGetEnrollmentSummaryRequestTPriorityFilter:
                GetEnrollmentSummaryRequestTPriorityFilterCodec.Encode(ref writer, varGetEnrollmentSummaryRequestTPriorityFilter);
                break;
            case T::GetEventInformationAck varGetEventInformationAck:
                GetEventInformationAckCodec.Encode(ref writer, varGetEventInformationAck);
                break;
            case T::GetEventInformationAck.TListOfEventSummariesItem varGetEventInformationAckTListOfEventSummariesItem:
                GetEventInformationAckTListOfEventSummariesItemCodec.Encode(ref writer, varGetEventInformationAckTListOfEventSummariesItem);
                break;
            case T::GetEventInformationRequest varGetEventInformationRequest:
                GetEventInformationRequestCodec.Encode(ref writer, varGetEventInformationRequest);
                break;
            case T::GroupChannelValue varGroupChannelValue:
                GroupChannelValueCodec.Encode(ref writer, varGroupChannelValue);
                break;
            case T::GroupChannelValue.TOverridingPriority varGroupChannelValueTOverridingPriority:
                GroupChannelValueTOverridingPriorityCodec.Encode(ref writer, varGroupChannelValueTOverridingPriority);
                break;
            case T::Health varHealth:
                HealthCodec.Encode(ref writer, varHealth);
                break;
            case T::HostAddress varHostAddress:
                HostAddressCodec.Encode(ref writer, varHostAddress);
                break;
            case T::HostNPort varHostNPort:
                HostNPortCodec.Encode(ref writer, varHostNPort);
                break;
            case T::IAmRequest varIAmRequest:
                IAmRequestCodec.Encode(ref writer, varIAmRequest);
                break;
            case T::IHaveRequest varIHaveRequest:
                IHaveRequestCodec.Encode(ref writer, varIHaveRequest);
                break;
            case short varInteger16:
                Integer16Codec.Encode(ref writer, varInteger16);
                break;
            case int varInteger32:
                Integer32Codec.Encode(ref writer, varInteger32);
                break;
            case long varInteger64:
                Integer64Codec.Encode(ref writer, varInteger64);
                break;
            case sbyte varInteger8:
                Integer8Codec.Encode(ref writer, varInteger8);
                break;
            case T::IpMode varIpMode:
                IpModeCodec.Encode(ref writer, varIpMode);
                break;
            case T::LandingCallStatus varLandingCallStatus:
                LandingCallStatusCodec.Encode(ref writer, varLandingCallStatus);
                break;
            case T::LandingCallStatus.TCommand varLandingCallStatusTCommand:
                LandingCallStatusTCommandCodec.Encode(ref writer, varLandingCallStatusTCommand);
                break;
            case T::LandingDoorStatus varLandingDoorStatus:
                LandingDoorStatusCodec.Encode(ref writer, varLandingDoorStatus);
                break;
            case T::LandingDoorStatus.TLandingDoorsItem varLandingDoorStatusTLandingDoorsItem:
                LandingDoorStatusTLandingDoorsItemCodec.Encode(ref writer, varLandingDoorStatusTLandingDoorsItem);
                break;
            case T::LifeSafetyMode varLifeSafetyMode:
                LifeSafetyModeCodec.Encode(ref writer, varLifeSafetyMode);
                break;
            case T::LifeSafetyOperation varLifeSafetyOperation:
                LifeSafetyOperationCodec.Encode(ref writer, varLifeSafetyOperation);
                break;
            case T::LifeSafetyOperationInfo varLifeSafetyOperationInfo:
                LifeSafetyOperationInfoCodec.Encode(ref writer, varLifeSafetyOperationInfo);
                break;
            case T::LifeSafetyOperationRequest varLifeSafetyOperationRequest:
                LifeSafetyOperationRequestCodec.Encode(ref writer, varLifeSafetyOperationRequest);
                break;
            case T::LifeSafetyState varLifeSafetyState:
                LifeSafetyStateCodec.Encode(ref writer, varLifeSafetyState);
                break;
            case T::LiftCarCallList varLiftCarCallList:
                LiftCarCallListCodec.Encode(ref writer, varLiftCarCallList);
                break;
            case T::LiftCarDirection varLiftCarDirection:
                LiftCarDirectionCodec.Encode(ref writer, varLiftCarDirection);
                break;
            case T::LiftCarDoorCommand varLiftCarDoorCommand:
                LiftCarDoorCommandCodec.Encode(ref writer, varLiftCarDoorCommand);
                break;
            case T::LiftCarDriveStatus varLiftCarDriveStatus:
                LiftCarDriveStatusCodec.Encode(ref writer, varLiftCarDriveStatus);
                break;
            case T::LiftCarMode varLiftCarMode:
                LiftCarModeCodec.Encode(ref writer, varLiftCarMode);
                break;
            case T::LiftFault varLiftFault:
                LiftFaultCodec.Encode(ref writer, varLiftFault);
                break;
            case T::LiftGroupMode varLiftGroupMode:
                LiftGroupModeCodec.Encode(ref writer, varLiftGroupMode);
                break;
            case T::LightingCommand varLightingCommand:
                LightingCommandCodec.Encode(ref writer, varLightingCommand);
                break;
            case T::LightingCommand.TFadeTime varLightingCommandTFadeTime:
                LightingCommandTFadeTimeCodec.Encode(ref writer, varLightingCommandTFadeTime);
                break;
            case T::LightingCommand.TPriority varLightingCommandTPriority:
                LightingCommandTPriorityCodec.Encode(ref writer, varLightingCommandTPriority);
                break;
            case T::LightingCommand.TRampRate varLightingCommandTRampRate:
                LightingCommandTRampRateCodec.Encode(ref writer, varLightingCommandTRampRate);
                break;
            case T::LightingCommand.TStepIncrement varLightingCommandTStepIncrement:
                LightingCommandTStepIncrementCodec.Encode(ref writer, varLightingCommandTStepIncrement);
                break;
            case T::LightingCommand.TTargetLevel varLightingCommandTTargetLevel:
                LightingCommandTTargetLevelCodec.Encode(ref writer, varLightingCommandTTargetLevel);
                break;
            case T::LightingInProgress varLightingInProgress:
                LightingInProgressCodec.Encode(ref writer, varLightingInProgress);
                break;
            case T::LightingOperation varLightingOperation:
                LightingOperationCodec.Encode(ref writer, varLightingOperation);
                break;
            case T::LightingTransition varLightingTransition:
                LightingTransitionCodec.Encode(ref writer, varLightingTransition);
                break;
            case T::LimitEnable varLimitEnable:
                LimitEnableCodec.Encode(ref writer, varLimitEnable);
                break;
            case T::LockStatus varLockStatus:
                LockStatusCodec.Encode(ref writer, varLockStatus);
                break;
            case T::LogData varLogData:
                LogDataCodec.Encode(ref writer, varLogData);
                break;
            case T::LogData.TSeriesItem varLogDataTSeriesItem:
                LogDataTSeriesItemCodec.Encode(ref writer, varLogDataTSeriesItem);
                break;
            case T::LoggingType varLoggingType:
                LoggingTypeCodec.Encode(ref writer, varLoggingType);
                break;
            case T::LogMultipleRecord varLogMultipleRecord:
                LogMultipleRecordCodec.Encode(ref writer, varLogMultipleRecord);
                break;
            case T::LogRecord varLogRecord:
                LogRecordCodec.Encode(ref writer, varLogRecord);
                break;
            case T::LogRecord.TLogDatum varLogRecordTLogDatum:
                LogRecordTLogDatumCodec.Encode(ref writer, varLogRecordTLogDatum);
                break;
            case T::LogStatus varLogStatus:
                LogStatusCodec.Encode(ref writer, varLogStatus);
                break;
            case T::Maintenance varMaintenance:
                MaintenanceCodec.Encode(ref writer, varMaintenance);
                break;
            case T::NameValue varNameValue:
                NameValueCodec.Encode(ref writer, varNameValue);
                break;
            case T::NameValueCollection varNameValueCollection:
                NameValueCollectionCodec.Encode(ref writer, varNameValueCollection);
                break;
            case T::NetworkNumberQuality varNetworkNumberQuality:
                NetworkNumberQualityCodec.Encode(ref writer, varNetworkNumberQuality);
                break;
            case T::NetworkPortCommand varNetworkPortCommand:
                NetworkPortCommandCodec.Encode(ref writer, varNetworkPortCommand);
                break;
            case T::NetworkType varNetworkType:
                NetworkTypeCodec.Encode(ref writer, varNetworkType);
                break;
            case T::NodeType varNodeType:
                NodeTypeCodec.Encode(ref writer, varNodeType);
                break;
            case T::NotificationParameters varNotificationParameters:
                NotificationParametersCodec.Encode(ref writer, varNotificationParameters);
                break;
            case T::NotificationParameters.TAccessEvent varNotificationParametersTAccessEvent:
                NotificationParametersTAccessEventCodec.Encode(ref writer, varNotificationParametersTAccessEvent);
                break;
            case T::NotificationParameters.TBufferReady varNotificationParametersTBufferReady:
                NotificationParametersTBufferReadyCodec.Encode(ref writer, varNotificationParametersTBufferReady);
                break;
            case T::NotificationParameters.TChangeOfBitstring varNotificationParametersTChangeOfBitstring:
                NotificationParametersTChangeOfBitstringCodec.Encode(ref writer, varNotificationParametersTChangeOfBitstring);
                break;
            case T::NotificationParameters.TChangeOfCharacterstring varNotificationParametersTChangeOfCharacterstring:
                NotificationParametersTChangeOfCharacterstringCodec.Encode(ref writer, varNotificationParametersTChangeOfCharacterstring);
                break;
            case T::NotificationParameters.TChangeOfDiscreteValue varNotificationParametersTChangeOfDiscreteValue:
                NotificationParametersTChangeOfDiscreteValueCodec.Encode(ref writer, varNotificationParametersTChangeOfDiscreteValue);
                break;
            case T::NotificationParameters.TChangeOfDiscreteValue.TNewValue varNotificationParametersTChangeOfDiscreteValueTNewValue:
                NotificationParametersTChangeOfDiscreteValueTNewValueCodec.Encode(ref writer, varNotificationParametersTChangeOfDiscreteValueTNewValue);
                break;
            case T::NotificationParameters.TChangeOfLifeSafety varNotificationParametersTChangeOfLifeSafety:
                NotificationParametersTChangeOfLifeSafetyCodec.Encode(ref writer, varNotificationParametersTChangeOfLifeSafety);
                break;
            case T::NotificationParameters.TChangeOfReliability varNotificationParametersTChangeOfReliability:
                NotificationParametersTChangeOfReliabilityCodec.Encode(ref writer, varNotificationParametersTChangeOfReliability);
                break;
            case T::NotificationParameters.TChangeOfState varNotificationParametersTChangeOfState:
                NotificationParametersTChangeOfStateCodec.Encode(ref writer, varNotificationParametersTChangeOfState);
                break;
            case T::NotificationParameters.TChangeOfStatusFlags varNotificationParametersTChangeOfStatusFlags:
                NotificationParametersTChangeOfStatusFlagsCodec.Encode(ref writer, varNotificationParametersTChangeOfStatusFlags);
                break;
            case T::NotificationParameters.TChangeOfTimer varNotificationParametersTChangeOfTimer:
                NotificationParametersTChangeOfTimerCodec.Encode(ref writer, varNotificationParametersTChangeOfTimer);
                break;
            case T::NotificationParameters.TChangeOfValue varNotificationParametersTChangeOfValue:
                NotificationParametersTChangeOfValueCodec.Encode(ref writer, varNotificationParametersTChangeOfValue);
                break;
            case T::NotificationParameters.TChangeOfValue.TNewValue varNotificationParametersTChangeOfValueTNewValue:
                NotificationParametersTChangeOfValueTNewValueCodec.Encode(ref writer, varNotificationParametersTChangeOfValueTNewValue);
                break;
            case T::NotificationParameters.TCommandFailure varNotificationParametersTCommandFailure:
                NotificationParametersTCommandFailureCodec.Encode(ref writer, varNotificationParametersTCommandFailure);
                break;
            case T::NotificationParameters.TDoubleOutOfRange varNotificationParametersTDoubleOutOfRange:
                NotificationParametersTDoubleOutOfRangeCodec.Encode(ref writer, varNotificationParametersTDoubleOutOfRange);
                break;
            case T::NotificationParameters.TExtended varNotificationParametersTExtended:
                NotificationParametersTExtendedCodec.Encode(ref writer, varNotificationParametersTExtended);
                break;
            case T::NotificationParameters.TExtended.TParametersItem varNotificationParametersTExtendedTParametersItem:
                NotificationParametersTExtendedTParametersItemCodec.Encode(ref writer, varNotificationParametersTExtendedTParametersItem);
                break;
            case T::NotificationParameters.TFloatingLimit varNotificationParametersTFloatingLimit:
                NotificationParametersTFloatingLimitCodec.Encode(ref writer, varNotificationParametersTFloatingLimit);
                break;
            case T::NotificationParameters.TOutOfRange varNotificationParametersTOutOfRange:
                NotificationParametersTOutOfRangeCodec.Encode(ref writer, varNotificationParametersTOutOfRange);
                break;
            case T::NotificationParameters.TSignedOutOfRange varNotificationParametersTSignedOutOfRange:
                NotificationParametersTSignedOutOfRangeCodec.Encode(ref writer, varNotificationParametersTSignedOutOfRange);
                break;
            case T::NotificationParameters.TUnsignedOutOfRange varNotificationParametersTUnsignedOutOfRange:
                NotificationParametersTUnsignedOutOfRangeCodec.Encode(ref writer, varNotificationParametersTUnsignedOutOfRange);
                break;
            case T::NotificationParameters.TUnsignedRange varNotificationParametersTUnsignedRange:
                NotificationParametersTUnsignedRangeCodec.Encode(ref writer, varNotificationParametersTUnsignedRange);
                break;
            case T::NotifyType varNotifyType:
                NotifyTypeCodec.Encode(ref writer, varNotifyType);
                break;
            case T::Null varNull:
                NullCodec.Encode(ref writer, varNull);
                break;
            case T::ObjectIdentifier varObjectIdentifier:
                ObjectIdentifierCodec.Encode(ref writer, varObjectIdentifier);
                break;
            case T::ObjectPropertyReference varObjectPropertyReference:
                ObjectPropertyReferenceCodec.Encode(ref writer, varObjectPropertyReference);
                break;
            case T::ObjectPropertyValue varObjectPropertyValue:
                ObjectPropertyValueCodec.Encode(ref writer, varObjectPropertyValue);
                break;
            case T::ObjectPropertyValue.TPriority varObjectPropertyValueTPriority:
                ObjectPropertyValueTPriorityCodec.Encode(ref writer, varObjectPropertyValueTPriority);
                break;
            case T::ObjectSelector varObjectSelector:
                ObjectSelectorCodec.Encode(ref writer, varObjectSelector);
                break;
            case T::ObjectType varObjectType:
                ObjectTypeCodec.Encode(ref writer, varObjectType);
                break;
            case T::ObjectTypesSupported varObjectTypesSupported:
                ObjectTypesSupportedCodec.Encode(ref writer, varObjectTypesSupported);
                break;
            case T::OctetString varOctetString:
                OctetStringCodec.Encode(ref writer, varOctetString);
                break;
            case T::OptionalAny varOptionalAny:
                OptionalAnyCodec.Encode(ref writer, varOptionalAny);
                break;
            case T::OptionalBinaryLightingPv varOptionalBinaryLightingPv:
                OptionalBinaryLightingPvCodec.Encode(ref writer, varOptionalBinaryLightingPv);
                break;
            case T::OptionalBinaryPv varOptionalBinaryPv:
                OptionalBinaryPvCodec.Encode(ref writer, varOptionalBinaryPv);
                break;
            case T::OptionalBitString varOptionalBitString:
                OptionalBitStringCodec.Encode(ref writer, varOptionalBitString);
                break;
            case T::OptionalCharacterString varOptionalCharacterString:
                OptionalCharacterStringCodec.Encode(ref writer, varOptionalCharacterString);
                break;
            case T::OptionalDate varOptionalDate:
                OptionalDateCodec.Encode(ref writer, varOptionalDate);
                break;
            case T::OptionalDatePattern varOptionalDatePattern:
                OptionalDatePatternCodec.Encode(ref writer, varOptionalDatePattern);
                break;
            case T::OptionalDateTime varOptionalDateTime:
                OptionalDateTimeCodec.Encode(ref writer, varOptionalDateTime);
                break;
            case T::OptionalDateTimePattern varOptionalDateTimePattern:
                OptionalDateTimePatternCodec.Encode(ref writer, varOptionalDateTimePattern);
                break;
            case T::OptionalDoorValue varOptionalDoorValue:
                OptionalDoorValueCodec.Encode(ref writer, varOptionalDoorValue);
                break;
            case T::OptionalDouble varOptionalDouble:
                OptionalDoubleCodec.Encode(ref writer, varOptionalDouble);
                break;
            case T::OptionalInteger varOptionalInteger:
                OptionalIntegerCodec.Encode(ref writer, varOptionalInteger);
                break;
            case T::OptionalOctetString varOptionalOctetString:
                OptionalOctetStringCodec.Encode(ref writer, varOptionalOctetString);
                break;
            case T::OptionalPriorityFilter varOptionalPriorityFilter:
                OptionalPriorityFilterCodec.Encode(ref writer, varOptionalPriorityFilter);
                break;
            case T::OptionalReal varOptionalReal:
                OptionalRealCodec.Encode(ref writer, varOptionalReal);
                break;
            case T::OptionalTimePattern varOptionalTimePattern:
                OptionalTimePatternCodec.Encode(ref writer, varOptionalTimePattern);
                break;
            case T::OptionalUnsigned varOptionalUnsigned:
                OptionalUnsignedCodec.Encode(ref writer, varOptionalUnsigned);
                break;
            case T::Polarity varPolarity:
                PolarityCodec.Encode(ref writer, varPolarity);
                break;
            case T::PortPermission varPortPermission:
                PortPermissionCodec.Encode(ref writer, varPortPermission);
                break;
            case T::Prescale varPrescale:
                PrescaleCodec.Encode(ref writer, varPrescale);
                break;
            case T::PriorityFilter varPriorityFilter:
                PriorityFilterCodec.Encode(ref writer, varPriorityFilter);
                break;
            case T::ProcessIdSelection varProcessIdSelection:
                ProcessIdSelectionCodec.Encode(ref writer, varProcessIdSelection);
                break;
            case T::ProgramError varProgramError:
                ProgramErrorCodec.Encode(ref writer, varProgramError);
                break;
            case T::ProgramRequest varProgramRequest:
                ProgramRequestCodec.Encode(ref writer, varProgramRequest);
                break;
            case T::ProgramState varProgramState:
                ProgramStateCodec.Encode(ref writer, varProgramState);
                break;
            case T::PropertyAccessResult varPropertyAccessResult:
                PropertyAccessResultCodec.Encode(ref writer, varPropertyAccessResult);
                break;
            case T::PropertyAccessResult.TAccessResult varPropertyAccessResultTAccessResult:
                PropertyAccessResultTAccessResultCodec.Encode(ref writer, varPropertyAccessResultTAccessResult);
                break;
            case T::PropertyIdentifier varPropertyIdentifier:
                PropertyIdentifierCodec.Encode(ref writer, varPropertyIdentifier);
                break;
            case T::PropertyReference varPropertyReference:
                PropertyReferenceCodec.Encode(ref writer, varPropertyReference);
                break;
            case T::PropertyStates varPropertyStates:
                PropertyStatesCodec.Encode(ref writer, varPropertyStates);
                break;
            case T::PropertyValue varPropertyValue:
                PropertyValueCodec.Encode(ref writer, varPropertyValue);
                break;
            case T::PropertyValue.TPriority varPropertyValueTPriority:
                PropertyValueTPriorityCodec.Encode(ref writer, varPropertyValueTPriority);
                break;
            case T::ProtocolLevel varProtocolLevel:
                ProtocolLevelCodec.Encode(ref writer, varProtocolLevel);
                break;
            case T::ReadAccessResult varReadAccessResult:
                ReadAccessResultCodec.Encode(ref writer, varReadAccessResult);
                break;
            case T::ReadAccessResult.TListOfResultsItem varReadAccessResultTListOfResultsItem:
                ReadAccessResultTListOfResultsItemCodec.Encode(ref writer, varReadAccessResultTListOfResultsItem);
                break;
            case T::ReadAccessResult.TListOfResultsItem.TReadResult varReadAccessResultTListOfResultsItemTReadResult:
                ReadAccessResultTListOfResultsItemTReadResultCodec.Encode(ref writer, varReadAccessResultTListOfResultsItemTReadResult);
                break;
            case T::ReadAccessSpecification varReadAccessSpecification:
                ReadAccessSpecificationCodec.Encode(ref writer, varReadAccessSpecification);
                break;
            case T::ReadPropertyAck varReadPropertyAck:
                ReadPropertyAckCodec.Encode(ref writer, varReadPropertyAck);
                break;
            case T::ReadPropertyMultipleAck varReadPropertyMultipleAck:
                ReadPropertyMultipleAckCodec.Encode(ref writer, varReadPropertyMultipleAck);
                break;
            case T::ReadPropertyMultipleRequest varReadPropertyMultipleRequest:
                ReadPropertyMultipleRequestCodec.Encode(ref writer, varReadPropertyMultipleRequest);
                break;
            case T::ReadPropertyRequest varReadPropertyRequest:
                ReadPropertyRequestCodec.Encode(ref writer, varReadPropertyRequest);
                break;
            case T::ReadRangeAck varReadRangeAck:
                ReadRangeAckCodec.Encode(ref writer, varReadRangeAck);
                break;
            case T::ReadRangeRequest varReadRangeRequest:
                ReadRangeRequestCodec.Encode(ref writer, varReadRangeRequest);
                break;
            case T::ReadRangeRequest.TRange varReadRangeRequestTRange:
                ReadRangeRequestTRangeCodec.Encode(ref writer, varReadRangeRequestTRange);
                break;
            case T::ReadRangeRequest.TRange.TByPosition varReadRangeRequestTRangeTByPosition:
                ReadRangeRequestTRangeTByPositionCodec.Encode(ref writer, varReadRangeRequestTRangeTByPosition);
                break;
            case T::ReadRangeRequest.TRange.TBySequenceNumber varReadRangeRequestTRangeTBySequenceNumber:
                ReadRangeRequestTRangeTBySequenceNumberCodec.Encode(ref writer, varReadRangeRequestTRangeTBySequenceNumber);
                break;
            case T::ReadRangeRequest.TRange.TByTime varReadRangeRequestTRangeTByTime:
                ReadRangeRequestTRangeTByTimeCodec.Encode(ref writer, varReadRangeRequestTRangeTByTime);
                break;
            case float varReal:
                RealCodec.Encode(ref writer, varReal);
                break;
            case T::Recipient varRecipient:
                RecipientCodec.Encode(ref writer, varRecipient);
                break;
            case T::RecipientProcess varRecipientProcess:
                RecipientProcessCodec.Encode(ref writer, varRecipientProcess);
                break;
            case T::ReinitializeDeviceRequest varReinitializeDeviceRequest:
                ReinitializeDeviceRequestCodec.Encode(ref writer, varReinitializeDeviceRequest);
                break;
            case T::ReinitializeDeviceRequest.TPassword varReinitializeDeviceRequestTPassword:
                ReinitializeDeviceRequestTPasswordCodec.Encode(ref writer, varReinitializeDeviceRequestTPassword);
                break;
            case T::ReinitializeDeviceRequest.TReinitializedStateOfDevice varReinitializeDeviceRequestTReinitializedStateOfDevice:
                ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec.Encode(ref writer, varReinitializeDeviceRequestTReinitializedStateOfDevice);
                break;
            case T::RejectReason varRejectReason:
                RejectReasonCodec.Encode(ref writer, varRejectReason);
                break;
            case T::Relationship varRelationship:
                RelationshipCodec.Encode(ref writer, varRelationship);
                break;
            case T::Reliability varReliability:
                ReliabilityCodec.Encode(ref writer, varReliability);
                break;
            case T::RemoveListElementRequest varRemoveListElementRequest:
                RemoveListElementRequestCodec.Encode(ref writer, varRemoveListElementRequest);
                break;
            case T::RestartReason varRestartReason:
                RestartReasonCodec.Encode(ref writer, varRestartReason);
                break;
            case T::ResultFlags varResultFlags:
                ResultFlagsCodec.Encode(ref writer, varResultFlags);
                break;
            case T::RouterEntry varRouterEntry:
                RouterEntryCodec.Encode(ref writer, varRouterEntry);
                break;
            case T::RouterEntry.TStatus varRouterEntryTStatus:
                RouterEntryTStatusCodec.Encode(ref writer, varRouterEntryTStatus);
                break;
            case T::Scale varScale:
                ScaleCodec.Encode(ref writer, varScale);
                break;
            case T::ScConnectionState varScConnectionState:
                ScConnectionStateCodec.Encode(ref writer, varScConnectionState);
                break;
            case T::ScDirectConnection varScDirectConnection:
                ScDirectConnectionCodec.Encode(ref writer, varScDirectConnection);
                break;
            case T::ScDirectConnection.TPeerUuid varScDirectConnectionTPeerUuid:
                ScDirectConnectionTPeerUuidCodec.Encode(ref writer, varScDirectConnectionTPeerUuid);
                break;
            case T::ScDirectConnection.TPeerVmac varScDirectConnectionTPeerVmac:
                ScDirectConnectionTPeerVmacCodec.Encode(ref writer, varScDirectConnectionTPeerVmac);
                break;
            case T::ScFailedConnectionRequest varScFailedConnectionRequest:
                ScFailedConnectionRequestCodec.Encode(ref writer, varScFailedConnectionRequest);
                break;
            case T::ScFailedConnectionRequest.TPeerUuid varScFailedConnectionRequestTPeerUuid:
                ScFailedConnectionRequestTPeerUuidCodec.Encode(ref writer, varScFailedConnectionRequestTPeerUuid);
                break;
            case T::ScFailedConnectionRequest.TPeerVmac varScFailedConnectionRequestTPeerVmac:
                ScFailedConnectionRequestTPeerVmacCodec.Encode(ref writer, varScFailedConnectionRequestTPeerVmac);
                break;
            case T::ScHubConnection varScHubConnection:
                ScHubConnectionCodec.Encode(ref writer, varScHubConnection);
                break;
            case T::ScHubConnectorState varScHubConnectorState:
                ScHubConnectorStateCodec.Encode(ref writer, varScHubConnectorState);
                break;
            case T::ScHubFunctionConnection varScHubFunctionConnection:
                ScHubFunctionConnectionCodec.Encode(ref writer, varScHubFunctionConnection);
                break;
            case T::ScHubFunctionConnection.TPeerUuid varScHubFunctionConnectionTPeerUuid:
                ScHubFunctionConnectionTPeerUuidCodec.Encode(ref writer, varScHubFunctionConnectionTPeerUuid);
                break;
            case T::ScHubFunctionConnection.TPeerVmac varScHubFunctionConnectionTPeerVmac:
                ScHubFunctionConnectionTPeerVmacCodec.Encode(ref writer, varScHubFunctionConnectionTPeerVmac);
                break;
            case T::Segmentation varSegmentation:
                SegmentationCodec.Encode(ref writer, varSegmentation);
                break;
            case T::ServicesSupported varServicesSupported:
                ServicesSupportedCodec.Encode(ref writer, varServicesSupported);
                break;
            case T::SetpointReference varSetpointReference:
                SetpointReferenceCodec.Encode(ref writer, varSetpointReference);
                break;
            case T::ShedLevel varShedLevel:
                ShedLevelCodec.Encode(ref writer, varShedLevel);
                break;
            case T::ShedState varShedState:
                ShedStateCodec.Encode(ref writer, varShedState);
                break;
            case T::SilencedState varSilencedState:
                SilencedStateCodec.Encode(ref writer, varSilencedState);
                break;
            case T::SpecialEvent varSpecialEvent:
                SpecialEventCodec.Encode(ref writer, varSpecialEvent);
                break;
            case T::SpecialEvent.TEventPriority varSpecialEventTEventPriority:
                SpecialEventTEventPriorityCodec.Encode(ref writer, varSpecialEventTEventPriority);
                break;
            case T::SpecialEvent.TPeriod varSpecialEventTPeriod:
                SpecialEventTPeriodCodec.Encode(ref writer, varSpecialEventTPeriod);
                break;
            case T::StageLimitValue varStageLimitValue:
                StageLimitValueCodec.Encode(ref writer, varStageLimitValue);
                break;
            case T::StatusFlags varStatusFlags:
                StatusFlagsCodec.Encode(ref writer, varStatusFlags);
                break;
            case T::SubscribeCovPropertyMultipleError varSubscribeCovPropertyMultipleError:
                SubscribeCovPropertyMultipleErrorCodec.Encode(ref writer, varSubscribeCovPropertyMultipleError);
                break;
            case T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription varSubscribeCovPropertyMultipleErrorTFirstFailedSubscription:
                SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec.Encode(ref writer, varSubscribeCovPropertyMultipleErrorTFirstFailedSubscription);
                break;
            case T::SubscribeCovPropertyMultipleRequest varSubscribeCovPropertyMultipleRequest:
                SubscribeCovPropertyMultipleRequestCodec.Encode(ref writer, varSubscribeCovPropertyMultipleRequest);
                break;
            case T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItem:
                SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec.Encode(ref writer, varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItem);
                break;
            case T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem:
                SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec.Encode(ref writer, varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem);
                break;
            case T::SubscribeCovPropertyRequest varSubscribeCovPropertyRequest:
                SubscribeCovPropertyRequestCodec.Encode(ref writer, varSubscribeCovPropertyRequest);
                break;
            case T::SubscribeCovRequest varSubscribeCovRequest:
                SubscribeCovRequestCodec.Encode(ref writer, varSubscribeCovRequest);
                break;
            case T::SuccessFilter varSuccessFilter:
                SuccessFilterCodec.Encode(ref writer, varSuccessFilter);
                break;
            case T::Time varTime:
                TimeCodec.Encode(ref writer, varTime);
                break;
            case T::TimePattern varTimePattern:
                TimePatternCodec.Encode(ref writer, varTimePattern);
                break;
            case T::TimerStateChangeValue varTimerStateChangeValue:
                TimerStateChangeValueCodec.Encode(ref writer, varTimerStateChangeValue);
                break;
            case T::TimerState varTimerState:
                TimerStateCodec.Encode(ref writer, varTimerState);
                break;
            case T::TimerTransition varTimerTransition:
                TimerTransitionCodec.Encode(ref writer, varTimerTransition);
                break;
            case T::TimeStamp varTimeStamp:
                TimeStampCodec.Encode(ref writer, varTimeStamp);
                break;
            case T::TimeStamp.TSequenceNumber varTimeStampTSequenceNumber:
                TimeStampTSequenceNumberCodec.Encode(ref writer, varTimeStampTSequenceNumber);
                break;
            case T::TimeSynchronizationRequest varTimeSynchronizationRequest:
                TimeSynchronizationRequestCodec.Encode(ref writer, varTimeSynchronizationRequest);
                break;
            case T::TimeValue varTimeValue:
                TimeValueCodec.Encode(ref writer, varTimeValue);
                break;
            case T::UnconfirmedAuditNotificationRequest varUnconfirmedAuditNotificationRequest:
                UnconfirmedAuditNotificationRequestCodec.Encode(ref writer, varUnconfirmedAuditNotificationRequest);
                break;
            case T::UnconfirmedCovNotificationMultipleRequest varUnconfirmedCovNotificationMultipleRequest:
                UnconfirmedCovNotificationMultipleRequestCodec.Encode(ref writer, varUnconfirmedCovNotificationMultipleRequest);
                break;
            case T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem:
                UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec.Encode(ref writer, varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem);
                break;
            case T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem:
                UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec.Encode(ref writer, varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem);
                break;
            case T::UnconfirmedCovNotificationRequest varUnconfirmedCovNotificationRequest:
                UnconfirmedCovNotificationRequestCodec.Encode(ref writer, varUnconfirmedCovNotificationRequest);
                break;
            case T::UnconfirmedEventNotificationRequest varUnconfirmedEventNotificationRequest:
                UnconfirmedEventNotificationRequestCodec.Encode(ref writer, varUnconfirmedEventNotificationRequest);
                break;
            case T::UnconfirmedPrivateTransferRequest varUnconfirmedPrivateTransferRequest:
                UnconfirmedPrivateTransferRequestCodec.Encode(ref writer, varUnconfirmedPrivateTransferRequest);
                break;
            case T::UnconfirmedServiceChoice varUnconfirmedServiceChoice:
                UnconfirmedServiceChoiceCodec.Encode(ref writer, varUnconfirmedServiceChoice);
                break;
            case T::UnconfirmedServiceRequest varUnconfirmedServiceRequest:
                UnconfirmedServiceRequestCodec.Encode(ref writer, varUnconfirmedServiceRequest);
                break;
            case T::UnconfirmedTextMessageRequest varUnconfirmedTextMessageRequest:
                UnconfirmedTextMessageRequestCodec.Encode(ref writer, varUnconfirmedTextMessageRequest);
                break;
            case T::UnconfirmedTextMessageRequest.TMessageClass varUnconfirmedTextMessageRequestTMessageClass:
                UnconfirmedTextMessageRequestTMessageClassCodec.Encode(ref writer, varUnconfirmedTextMessageRequestTMessageClass);
                break;
            case T::UnconfirmedTextMessageRequest.TMessagePriority varUnconfirmedTextMessageRequestTMessagePriority:
                UnconfirmedTextMessageRequestTMessagePriorityCodec.Encode(ref writer, varUnconfirmedTextMessageRequestTMessagePriority);
                break;
            case ushort varUnsigned16:
                Unsigned16Codec.Encode(ref writer, varUnsigned16);
                break;
            case uint varUnsigned32:
                Unsigned32Codec.Encode(ref writer, varUnsigned32);
                break;
            case ulong varUnsigned64:
                Unsigned64Codec.Encode(ref writer, varUnsigned64);
                break;
            case byte varUnsigned8:
                Unsigned8Codec.Encode(ref writer, varUnsigned8);
                break;
            case T::UtcTimeSynchronizationRequest varUtcTimeSynchronizationRequest:
                UtcTimeSynchronizationRequestCodec.Encode(ref writer, varUtcTimeSynchronizationRequest);
                break;
            case T::ValueSource varValueSource:
                ValueSourceCodec.Encode(ref writer, varValueSource);
                break;
            case T::VmacEntry varVmacEntry:
                VmacEntryCodec.Encode(ref writer, varVmacEntry);
                break;
            case T::VtClass varVtClass:
                VtClassCodec.Encode(ref writer, varVtClass);
                break;
            case T::VtCloseError varVtCloseError:
                VtCloseErrorCodec.Encode(ref writer, varVtCloseError);
                break;
            case T::VtCloseRequest varVtCloseRequest:
                VtCloseRequestCodec.Encode(ref writer, varVtCloseRequest);
                break;
            case T::VtDataAck varVtDataAck:
                VtDataAckCodec.Encode(ref writer, varVtDataAck);
                break;
            case T::VtDataRequest varVtDataRequest:
                VtDataRequestCodec.Encode(ref writer, varVtDataRequest);
                break;
            case T::VtDataRequest.TVtDataFlag varVtDataRequestTVtDataFlag:
                VtDataRequestTVtDataFlagCodec.Encode(ref writer, varVtDataRequestTVtDataFlag);
                break;
            case T::VtOpenAck varVtOpenAck:
                VtOpenAckCodec.Encode(ref writer, varVtOpenAck);
                break;
            case T::VtOpenRequest varVtOpenRequest:
                VtOpenRequestCodec.Encode(ref writer, varVtOpenRequest);
                break;
            case T::VtSession varVtSession:
                VtSessionCodec.Encode(ref writer, varVtSession);
                break;
            case T::WeekNDay varWeekNDay:
                WeekNDayCodec.Encode(ref writer, varWeekNDay);
                break;
            case T::WhoAmIRequest varWhoAmIRequest:
                WhoAmIRequestCodec.Encode(ref writer, varWhoAmIRequest);
                break;
            case T::WhoHasRequest varWhoHasRequest:
                WhoHasRequestCodec.Encode(ref writer, varWhoHasRequest);
                break;
            case T::WhoHasRequest.TLimits varWhoHasRequestTLimits:
                WhoHasRequestTLimitsCodec.Encode(ref writer, varWhoHasRequestTLimits);
                break;
            case T::WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit varWhoHasRequestTLimitsTDeviceInstanceRangeHighLimit:
                WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec.Encode(ref writer, varWhoHasRequestTLimitsTDeviceInstanceRangeHighLimit);
                break;
            case T::WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit varWhoHasRequestTLimitsTDeviceInstanceRangeLowLimit:
                WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec.Encode(ref writer, varWhoHasRequestTLimitsTDeviceInstanceRangeLowLimit);
                break;
            case T::WhoHasRequest.TObject varWhoHasRequestTObject:
                WhoHasRequestTObjectCodec.Encode(ref writer, varWhoHasRequestTObject);
                break;
            case T::WhoIsRequest varWhoIsRequest:
                WhoIsRequestCodec.Encode(ref writer, varWhoIsRequest);
                break;
            case T::WhoIsRequest.TDeviceInstanceRangeHighLimit varWhoIsRequestTDeviceInstanceRangeHighLimit:
                WhoIsRequestTDeviceInstanceRangeHighLimitCodec.Encode(ref writer, varWhoIsRequestTDeviceInstanceRangeHighLimit);
                break;
            case T::WhoIsRequest.TDeviceInstanceRangeLowLimit varWhoIsRequestTDeviceInstanceRangeLowLimit:
                WhoIsRequestTDeviceInstanceRangeLowLimitCodec.Encode(ref writer, varWhoIsRequestTDeviceInstanceRangeLowLimit);
                break;
            case T::WriteAccessSpecification varWriteAccessSpecification:
                WriteAccessSpecificationCodec.Encode(ref writer, varWriteAccessSpecification);
                break;
            case T::WriteGroupRequest varWriteGroupRequest:
                WriteGroupRequestCodec.Encode(ref writer, varWriteGroupRequest);
                break;
            case T::WriteGroupRequest.TWritePriority varWriteGroupRequestTWritePriority:
                WriteGroupRequestTWritePriorityCodec.Encode(ref writer, varWriteGroupRequestTWritePriority);
                break;
            case T::WritePropertyMultipleError varWritePropertyMultipleError:
                WritePropertyMultipleErrorCodec.Encode(ref writer, varWritePropertyMultipleError);
                break;
            case T::WritePropertyMultipleRequest varWritePropertyMultipleRequest:
                WritePropertyMultipleRequestCodec.Encode(ref writer, varWritePropertyMultipleRequest);
                break;
            case T::WritePropertyRequest varWritePropertyRequest:
                WritePropertyRequestCodec.Encode(ref writer, varWritePropertyRequest);
                break;
            case T::WritePropertyRequest.TPriority varWritePropertyRequestTPriority:
                WritePropertyRequestTPriorityCodec.Encode(ref writer, varWritePropertyRequestTPriority);
                break;
            case T::WriteStatus varWriteStatus:
                WriteStatusCodec.Encode(ref writer, varWriteStatus);
                break;
            case T::XyColor varXyColor:
                XyColorCodec.Encode(ref writer, varXyColor);
                break;
            case T::YouAreRequest varYouAreRequest:
                YouAreRequestCodec.Encode(ref writer, varYouAreRequest);
                break;
            default:
                throw new NotSupportedException($"The type '{value.ValueType}' has no codec.");
        }
    }

    /// <inheritdoc/>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value)
    {
        return value.Value switch
        {
            T::AbortReason varAbortReason => AbortReasonCodec.GetEncodedLength(varAbortReason),
            T::AccessAuthenticationFactorDisable varAccessAuthenticationFactorDisable => AccessAuthenticationFactorDisableCodec.GetEncodedLength(varAccessAuthenticationFactorDisable),
            T::AccessCredentialDisable varAccessCredentialDisable => AccessCredentialDisableCodec.GetEncodedLength(varAccessCredentialDisable),
            T::AccessCredentialDisableReason varAccessCredentialDisableReason => AccessCredentialDisableReasonCodec.GetEncodedLength(varAccessCredentialDisableReason),
            T::AccessEvent varAccessEvent => AccessEventCodec.GetEncodedLength(varAccessEvent),
            T::AccessPassbackMode varAccessPassbackMode => AccessPassbackModeCodec.GetEncodedLength(varAccessPassbackMode),
            T::AccessRule varAccessRule => AccessRuleCodec.GetEncodedLength(varAccessRule),
            T::AccessRule.TLocationSpecifier varAccessRuleTLocationSpecifier => AccessRuleTLocationSpecifierCodec.GetEncodedLength(varAccessRuleTLocationSpecifier),
            T::AccessRule.TTimeRangeSpecifier varAccessRuleTTimeRangeSpecifier => AccessRuleTTimeRangeSpecifierCodec.GetEncodedLength(varAccessRuleTTimeRangeSpecifier),
            T::AccessThreatLevel varAccessThreatLevel => AccessThreatLevelCodec.GetEncodedLength(varAccessThreatLevel),
            T::AccessToken varAccessToken => AccessTokenCodec.GetEncodedLength(varAccessToken),
            T::AccessUserType varAccessUserType => AccessUserTypeCodec.GetEncodedLength(varAccessUserType),
            T::AccessZoneOccupancyState varAccessZoneOccupancyState => AccessZoneOccupancyStateCodec.GetEncodedLength(varAccessZoneOccupancyState),
            T::AccumulatorRecord varAccumulatorRecord => AccumulatorRecordCodec.GetEncodedLength(varAccumulatorRecord),
            T::AccumulatorRecord.TAccumulatorStatus varAccumulatorRecordTAccumulatorStatus => AccumulatorRecordTAccumulatorStatusCodec.GetEncodedLength(varAccumulatorRecordTAccumulatorStatus),
            T::AcknowledgeAlarmInfo varAcknowledgeAlarmInfo => AcknowledgeAlarmInfoCodec.GetEncodedLength(varAcknowledgeAlarmInfo),
            T::AcknowledgeAlarmRequest varAcknowledgeAlarmRequest => AcknowledgeAlarmRequestCodec.GetEncodedLength(varAcknowledgeAlarmRequest),
            T::Action varAction => ActionCodec.GetEncodedLength(varAction),
            T::ActionCommand varActionCommand => ActionCommandCodec.GetEncodedLength(varActionCommand),
            T::ActionCommand.TPriority varActionCommandTPriority => ActionCommandTPriorityCodec.GetEncodedLength(varActionCommandTPriority),
            T::ActionList varActionList => ActionListCodec.GetEncodedLength(varActionList),
            T::AddListElementRequest varAddListElementRequest => AddListElementRequestCodec.GetEncodedLength(varAddListElementRequest),
            T::AddressBinding varAddressBinding => AddressBindingCodec.GetEncodedLength(varAddressBinding),
            T::Address varAddress => AddressCodec.GetEncodedLength(varAddress),
            T::AnyPrimitive varAnyPrimitive => AnyPrimitiveCodec.GetEncodedLength(varAnyPrimitive),
            T::AssignedAccessRights varAssignedAccessRights => AssignedAccessRightsCodec.GetEncodedLength(varAssignedAccessRights),
            T::AssignedLandingCalls varAssignedLandingCalls => AssignedLandingCallsCodec.GetEncodedLength(varAssignedLandingCalls),
            T::AssignedLandingCalls.TLandingCallsItem varAssignedLandingCallsTLandingCallsItem => AssignedLandingCallsTLandingCallsItemCodec.GetEncodedLength(varAssignedLandingCallsTLandingCallsItem),
            T::AtomicReadFileAck varAtomicReadFileAck => AtomicReadFileAckCodec.GetEncodedLength(varAtomicReadFileAck),
            T::AtomicReadFileAck.TAccessMethod varAtomicReadFileAckTAccessMethod => AtomicReadFileAckTAccessMethodCodec.GetEncodedLength(varAtomicReadFileAckTAccessMethod),
            T::AtomicReadFileAck.TAccessMethod.TRecordAccess varAtomicReadFileAckTAccessMethodTRecordAccess => AtomicReadFileAckTAccessMethodTRecordAccessCodec.GetEncodedLength(varAtomicReadFileAckTAccessMethodTRecordAccess),
            T::AtomicReadFileAck.TAccessMethod.TStreamAccess varAtomicReadFileAckTAccessMethodTStreamAccess => AtomicReadFileAckTAccessMethodTStreamAccessCodec.GetEncodedLength(varAtomicReadFileAckTAccessMethodTStreamAccess),
            T::AtomicReadFileRequest varAtomicReadFileRequest => AtomicReadFileRequestCodec.GetEncodedLength(varAtomicReadFileRequest),
            T::AtomicReadFileRequest.TAccessMethod varAtomicReadFileRequestTAccessMethod => AtomicReadFileRequestTAccessMethodCodec.GetEncodedLength(varAtomicReadFileRequestTAccessMethod),
            T::AtomicReadFileRequest.TAccessMethod.TRecordAccess varAtomicReadFileRequestTAccessMethodTRecordAccess => AtomicReadFileRequestTAccessMethodTRecordAccessCodec.GetEncodedLength(varAtomicReadFileRequestTAccessMethodTRecordAccess),
            T::AtomicReadFileRequest.TAccessMethod.TStreamAccess varAtomicReadFileRequestTAccessMethodTStreamAccess => AtomicReadFileRequestTAccessMethodTStreamAccessCodec.GetEncodedLength(varAtomicReadFileRequestTAccessMethodTStreamAccess),
            T::AtomicWriteFileAck varAtomicWriteFileAck => AtomicWriteFileAckCodec.GetEncodedLength(varAtomicWriteFileAck),
            T::AtomicWriteFileRequest varAtomicWriteFileRequest => AtomicWriteFileRequestCodec.GetEncodedLength(varAtomicWriteFileRequest),
            T::AtomicWriteFileRequest.TAccessMethod varAtomicWriteFileRequestTAccessMethod => AtomicWriteFileRequestTAccessMethodCodec.GetEncodedLength(varAtomicWriteFileRequestTAccessMethod),
            T::AtomicWriteFileRequest.TAccessMethod.TRecordAccess varAtomicWriteFileRequestTAccessMethodTRecordAccess => AtomicWriteFileRequestTAccessMethodTRecordAccessCodec.GetEncodedLength(varAtomicWriteFileRequestTAccessMethodTRecordAccess),
            T::AtomicWriteFileRequest.TAccessMethod.TStreamAccess varAtomicWriteFileRequestTAccessMethodTStreamAccess => AtomicWriteFileRequestTAccessMethodTStreamAccessCodec.GetEncodedLength(varAtomicWriteFileRequestTAccessMethodTStreamAccess),
            T::AuditLevel varAuditLevel => AuditLevelCodec.GetEncodedLength(varAuditLevel),
            T::AuditLogQueryAck varAuditLogQueryAck => AuditLogQueryAckCodec.GetEncodedLength(varAuditLogQueryAck),
            T::AuditLogQueryParameters varAuditLogQueryParameters => AuditLogQueryParametersCodec.GetEncodedLength(varAuditLogQueryParameters),
            T::AuditLogQueryParameters.TBySource varAuditLogQueryParametersTBySource => AuditLogQueryParametersTBySourceCodec.GetEncodedLength(varAuditLogQueryParametersTBySource),
            T::AuditLogQueryParameters.TByTarget varAuditLogQueryParametersTByTarget => AuditLogQueryParametersTByTargetCodec.GetEncodedLength(varAuditLogQueryParametersTByTarget),
            T::AuditLogQueryParameters.TByTarget.TTargetPriority varAuditLogQueryParametersTByTargetTTargetPriority => AuditLogQueryParametersTByTargetTTargetPriorityCodec.GetEncodedLength(varAuditLogQueryParametersTByTargetTTargetPriority),
            T::AuditLogQueryRequest varAuditLogQueryRequest => AuditLogQueryRequestCodec.GetEncodedLength(varAuditLogQueryRequest),
            T::AuditLogRecord varAuditLogRecord => AuditLogRecordCodec.GetEncodedLength(varAuditLogRecord),
            T::AuditLogRecordResult varAuditLogRecordResult => AuditLogRecordResultCodec.GetEncodedLength(varAuditLogRecordResult),
            T::AuditLogRecord.TLogDatum varAuditLogRecordTLogDatum => AuditLogRecordTLogDatumCodec.GetEncodedLength(varAuditLogRecordTLogDatum),
            T::AuditNotification varAuditNotification => AuditNotificationCodec.GetEncodedLength(varAuditNotification),
            T::AuditNotification.TTargetPriority varAuditNotificationTTargetPriority => AuditNotificationTTargetPriorityCodec.GetEncodedLength(varAuditNotificationTTargetPriority),
            T::AuditOperation varAuditOperation => AuditOperationCodec.GetEncodedLength(varAuditOperation),
            T::AuditOperationFlags varAuditOperationFlags => AuditOperationFlagsCodec.GetEncodedLength(varAuditOperationFlags),
            T::AuthenticationClient varAuthenticationClient => AuthenticationClientCodec.GetEncodedLength(varAuthenticationClient),
            T::AuthenticationDecision varAuthenticationDecision => AuthenticationDecisionCodec.GetEncodedLength(varAuthenticationDecision),
            T::AuthenticationEvent varAuthenticationEvent => AuthenticationEventCodec.GetEncodedLength(varAuthenticationEvent),
            T::AuthenticationFactor varAuthenticationFactor => AuthenticationFactorCodec.GetEncodedLength(varAuthenticationFactor),
            T::AuthenticationFactorFormat varAuthenticationFactorFormat => AuthenticationFactorFormatCodec.GetEncodedLength(varAuthenticationFactorFormat),
            T::AuthenticationFactorType varAuthenticationFactorType => AuthenticationFactorTypeCodec.GetEncodedLength(varAuthenticationFactorType),
            T::AuthenticationPeer varAuthenticationPeer => AuthenticationPeerCodec.GetEncodedLength(varAuthenticationPeer),
            T::AuthenticationPolicy varAuthenticationPolicy => AuthenticationPolicyCodec.GetEncodedLength(varAuthenticationPolicy),
            T::AuthenticationPolicy.TPolicyItem varAuthenticationPolicyTPolicyItem => AuthenticationPolicyTPolicyItemCodec.GetEncodedLength(varAuthenticationPolicyTPolicyItem),
            T::AuthenticationStatus varAuthenticationStatus => AuthenticationStatusCodec.GetEncodedLength(varAuthenticationStatus),
            T::AuthorizationConstraint varAuthorizationConstraint => AuthorizationConstraintCodec.GetEncodedLength(varAuthorizationConstraint),
            T::AuthorizationConstraint.TAuthentication varAuthorizationConstraintTAuthentication => AuthorizationConstraintTAuthenticationCodec.GetEncodedLength(varAuthorizationConstraintTAuthentication),
            T::AuthorizationConstraint.TOrigin varAuthorizationConstraintTOrigin => AuthorizationConstraintTOriginCodec.GetEncodedLength(varAuthorizationConstraintTOrigin),
            T::AuthorizationDecision varAuthorizationDecision => AuthorizationDecisionCodec.GetEncodedLength(varAuthorizationDecision),
            T::AuthorizationEvent varAuthorizationEvent => AuthorizationEventCodec.GetEncodedLength(varAuthorizationEvent),
            T::AuthorizationExemption varAuthorizationExemption => AuthorizationExemptionCodec.GetEncodedLength(varAuthorizationExemption),
            T::AuthorizationMode varAuthorizationMode => AuthorizationModeCodec.GetEncodedLength(varAuthorizationMode),
            T::AuthorizationPolicy varAuthorizationPolicy => AuthorizationPolicyCodec.GetEncodedLength(varAuthorizationPolicy),
            T::AuthorizationPosture varAuthorizationPosture => AuthorizationPostureCodec.GetEncodedLength(varAuthorizationPosture),
            T::AuthorizationScope varAuthorizationScope => AuthorizationScopeCodec.GetEncodedLength(varAuthorizationScope),
            T::AuthorizationScopeDescription varAuthorizationScopeDescription => AuthorizationScopeDescriptionCodec.GetEncodedLength(varAuthorizationScopeDescription),
            T::AuthorizationScope.TStandard varAuthorizationScopeTStandard => AuthorizationScopeTStandardCodec.GetEncodedLength(varAuthorizationScopeTStandard),
            T::AuthorizationServer varAuthorizationServer => AuthorizationServerCodec.GetEncodedLength(varAuthorizationServer),
            T::AuthorizationStatus varAuthorizationStatus => AuthorizationStatusCodec.GetEncodedLength(varAuthorizationStatus),
            T::AuthRequestAck varAuthRequestAck => AuthRequestAckCodec.GetEncodedLength(varAuthRequestAck),
            T::AuthRequestError varAuthRequestError => AuthRequestErrorCodec.GetEncodedLength(varAuthRequestError),
            T::AuthRequestRequest varAuthRequestRequest => AuthRequestRequestCodec.GetEncodedLength(varAuthRequestRequest),
            T::AuthRequestRequest.TTokenRequest varAuthRequestRequestTTokenRequest => AuthRequestRequestTTokenRequestCodec.GetEncodedLength(varAuthRequestRequestTTokenRequest),
            T::BackupState varBackupState => BackupStateCodec.GetEncodedLength(varBackupState),
            T::BdtEntry varBdtEntry => BdtEntryCodec.GetEncodedLength(varBdtEntry),
            T::BinaryLightingPv varBinaryLightingPv => BinaryLightingPvCodec.GetEncodedLength(varBinaryLightingPv),
            T::BinaryPv varBinaryPv => BinaryPvCodec.GetEncodedLength(varBinaryPv),
            T::BitString16 varBitString16 => BitString16Codec.GetEncodedLength(varBitString16),
            T::BitString32 varBitString32 => BitString32Codec.GetEncodedLength(varBitString32),
            T::BitString64 varBitString64 => BitString64Codec.GetEncodedLength(varBitString64),
            T::BitString8 varBitString8 => BitString8Codec.GetEncodedLength(varBitString8),
            T::BitString varBitString => BitStringCodec.GetEncodedLength(varBitString),
            bool varBoolean => BooleanCodec.GetEncodedLength(varBoolean),
            T::CalendarEntry varCalendarEntry => CalendarEntryCodec.GetEncodedLength(varCalendarEntry),
            T::ChangeListError varChangeListError => ChangeListErrorCodec.GetEncodedLength(varChangeListError),
            T::ChannelValue varChannelValue => ChannelValueCodec.GetEncodedLength(varChannelValue),
            T::CharacterString varCharacterString => CharacterStringCodec.GetEncodedLength(varCharacterString),
            T::ClientCov varClientCov => ClientCovCodec.GetEncodedLength(varClientCov),
            T::ColorCommand varColorCommand => ColorCommandCodec.GetEncodedLength(varColorCommand),
            T::ColorCommand.TFadeTime varColorCommandTFadeTime => ColorCommandTFadeTimeCodec.GetEncodedLength(varColorCommandTFadeTime),
            T::ColorCommand.TRampRate varColorCommandTRampRate => ColorCommandTRampRateCodec.GetEncodedLength(varColorCommandTRampRate),
            T::ColorCommand.TStepIncrement varColorCommandTStepIncrement => ColorCommandTStepIncrementCodec.GetEncodedLength(varColorCommandTStepIncrement),
            T::ColorOperation varColorOperation => ColorOperationCodec.GetEncodedLength(varColorOperation),
            T::ColorOperationInProgress varColorOperationInProgress => ColorOperationInProgressCodec.GetEncodedLength(varColorOperationInProgress),
            T::ColorTransition varColorTransition => ColorTransitionCodec.GetEncodedLength(varColorTransition),
            T::CommandPriority varCommandPriority => CommandPriorityCodec.GetEncodedLength(varCommandPriority),
            T::ConfirmedAuditNotificationRequest varConfirmedAuditNotificationRequest => ConfirmedAuditNotificationRequestCodec.GetEncodedLength(varConfirmedAuditNotificationRequest),
            T::ConfirmedCovNotificationMultipleRequest varConfirmedCovNotificationMultipleRequest => ConfirmedCovNotificationMultipleRequestCodec.GetEncodedLength(varConfirmedCovNotificationMultipleRequest),
            T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem => ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec.GetEncodedLength(varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem),
            T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem => ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec.GetEncodedLength(varConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem),
            T::ConfirmedCovNotificationRequest varConfirmedCovNotificationRequest => ConfirmedCovNotificationRequestCodec.GetEncodedLength(varConfirmedCovNotificationRequest),
            T::ConfirmedEventNotificationRequest varConfirmedEventNotificationRequest => ConfirmedEventNotificationRequestCodec.GetEncodedLength(varConfirmedEventNotificationRequest),
            T::ConfirmedPrivateTransferAck varConfirmedPrivateTransferAck => ConfirmedPrivateTransferAckCodec.GetEncodedLength(varConfirmedPrivateTransferAck),
            T::ConfirmedPrivateTransferError varConfirmedPrivateTransferError => ConfirmedPrivateTransferErrorCodec.GetEncodedLength(varConfirmedPrivateTransferError),
            T::ConfirmedPrivateTransferRequest varConfirmedPrivateTransferRequest => ConfirmedPrivateTransferRequestCodec.GetEncodedLength(varConfirmedPrivateTransferRequest),
            T::ConfirmedServiceAck varConfirmedServiceAck => ConfirmedServiceAckCodec.GetEncodedLength(varConfirmedServiceAck),
            T::ConfirmedServiceChoice varConfirmedServiceChoice => ConfirmedServiceChoiceCodec.GetEncodedLength(varConfirmedServiceChoice),
            T::ConfirmedServiceRequest varConfirmedServiceRequest => ConfirmedServiceRequestCodec.GetEncodedLength(varConfirmedServiceRequest),
            T::ConfirmedTextMessageRequest varConfirmedTextMessageRequest => ConfirmedTextMessageRequestCodec.GetEncodedLength(varConfirmedTextMessageRequest),
            T::ConfirmedTextMessageRequest.TMessageClass varConfirmedTextMessageRequestTMessageClass => ConfirmedTextMessageRequestTMessageClassCodec.GetEncodedLength(varConfirmedTextMessageRequestTMessageClass),
            T::ConfirmedTextMessageRequest.TMessagePriority varConfirmedTextMessageRequestTMessagePriority => ConfirmedTextMessageRequestTMessagePriorityCodec.GetEncodedLength(varConfirmedTextMessageRequestTMessagePriority),
            T::CovMultipleSubscription varCovMultipleSubscription => CovMultipleSubscriptionCodec.GetEncodedLength(varCovMultipleSubscription),
            T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItem => CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec.GetEncodedLength(varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItem),
            T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem => CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec.GetEncodedLength(varCovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem),
            T::CovSubscription varCovSubscription => CovSubscriptionCodec.GetEncodedLength(varCovSubscription),
            T::CreateObjectError varCreateObjectError => CreateObjectErrorCodec.GetEncodedLength(varCreateObjectError),
            T::CreateObjectRequest varCreateObjectRequest => CreateObjectRequestCodec.GetEncodedLength(varCreateObjectRequest),
            T::CreateObjectRequest.TObjectSpecifier varCreateObjectRequestTObjectSpecifier => CreateObjectRequestTObjectSpecifierCodec.GetEncodedLength(varCreateObjectRequestTObjectSpecifier),
            T::CredentialAuthenticationFactor varCredentialAuthenticationFactor => CredentialAuthenticationFactorCodec.GetEncodedLength(varCredentialAuthenticationFactor),
            T::DailySchedule varDailySchedule => DailyScheduleCodec.GetEncodedLength(varDailySchedule),
            T::Date varDate => DateCodec.GetEncodedLength(varDate),
            T::DatePattern varDatePattern => DatePatternCodec.GetEncodedLength(varDatePattern),
            T::DateRange varDateRange => DateRangeCodec.GetEncodedLength(varDateRange),
            T::DateTime varDateTime => DateTimeCodec.GetEncodedLength(varDateTime),
            T::DateTimePattern varDateTimePattern => DateTimePatternCodec.GetEncodedLength(varDateTimePattern),
            T::DaysOfWeek varDaysOfWeek => DaysOfWeekCodec.GetEncodedLength(varDaysOfWeek),
            T::DeleteObjectRequest varDeleteObjectRequest => DeleteObjectRequestCodec.GetEncodedLength(varDeleteObjectRequest),
            T::Destination varDestination => DestinationCodec.GetEncodedLength(varDestination),
            T::DeviceAddressProxyTableEntry varDeviceAddressProxyTableEntry => DeviceAddressProxyTableEntryCodec.GetEncodedLength(varDeviceAddressProxyTableEntry),
            T::DeviceCommunicationControlRequest varDeviceCommunicationControlRequest => DeviceCommunicationControlRequestCodec.GetEncodedLength(varDeviceCommunicationControlRequest),
            T::DeviceCommunicationControlRequest.TEnableDisable varDeviceCommunicationControlRequestTEnableDisable => DeviceCommunicationControlRequestTEnableDisableCodec.GetEncodedLength(varDeviceCommunicationControlRequestTEnableDisable),
            T::DeviceCommunicationControlRequest.TPassword varDeviceCommunicationControlRequestTPassword => DeviceCommunicationControlRequestTPasswordCodec.GetEncodedLength(varDeviceCommunicationControlRequestTPassword),
            T::DeviceObjectPropertyReference varDeviceObjectPropertyReference => DeviceObjectPropertyReferenceCodec.GetEncodedLength(varDeviceObjectPropertyReference),
            T::DeviceObjectPropertyValue varDeviceObjectPropertyValue => DeviceObjectPropertyValueCodec.GetEncodedLength(varDeviceObjectPropertyValue),
            T::DeviceObjectReference varDeviceObjectReference => DeviceObjectReferenceCodec.GetEncodedLength(varDeviceObjectReference),
            T::DeviceStatus varDeviceStatus => DeviceStatusCodec.GetEncodedLength(varDeviceStatus),
            T::DoorAlarmState varDoorAlarmState => DoorAlarmStateCodec.GetEncodedLength(varDoorAlarmState),
            T::DoorSecuredStatus varDoorSecuredStatus => DoorSecuredStatusCodec.GetEncodedLength(varDoorSecuredStatus),
            T::DoorStatus varDoorStatus => DoorStatusCodec.GetEncodedLength(varDoorStatus),
            T::DoorValue varDoorValue => DoorValueCodec.GetEncodedLength(varDoorValue),
            double varDouble => DoubleCodec.GetEncodedLength(varDouble),
            T::EngineeringUnits varEngineeringUnits => EngineeringUnitsCodec.GetEncodedLength(varEngineeringUnits),
            T::Enumerated16 varEnumerated16 => Enumerated16Codec.GetEncodedLength(varEnumerated16),
            T::Enumerated32 varEnumerated32 => Enumerated32Codec.GetEncodedLength(varEnumerated32),
            T::Enumerated64 varEnumerated64 => Enumerated64Codec.GetEncodedLength(varEnumerated64),
            T::Enumerated8 varEnumerated8 => Enumerated8Codec.GetEncodedLength(varEnumerated8),
            T::Enumerated varEnumerated => EnumeratedCodec.GetEncodedLength(varEnumerated),
            T::Error varError => ErrorCodec.GetEncodedLength(varError),
            T::Error.TErrorClass varErrorTErrorClass => ErrorTErrorClassCodec.GetEncodedLength(varErrorTErrorClass),
            T::Error.TErrorCode varErrorTErrorCode => ErrorTErrorCodeCodec.GetEncodedLength(varErrorTErrorCode),
            T::EscalatorFault varEscalatorFault => EscalatorFaultCodec.GetEncodedLength(varEscalatorFault),
            T::EscalatorMode varEscalatorMode => EscalatorModeCodec.GetEncodedLength(varEscalatorMode),
            T::EscalatorOperationDirection varEscalatorOperationDirection => EscalatorOperationDirectionCodec.GetEncodedLength(varEscalatorOperationDirection),
            T::EventLogRecord varEventLogRecord => EventLogRecordCodec.GetEncodedLength(varEventLogRecord),
            T::EventLogRecord.TLogDatum varEventLogRecordTLogDatum => EventLogRecordTLogDatumCodec.GetEncodedLength(varEventLogRecordTLogDatum),
            T::EventNotificationSubscription varEventNotificationSubscription => EventNotificationSubscriptionCodec.GetEncodedLength(varEventNotificationSubscription),
            T::EventParameter varEventParameter => EventParameterCodec.GetEncodedLength(varEventParameter),
            T::EventParameter.TAccessEvent varEventParameterTAccessEvent => EventParameterTAccessEventCodec.GetEncodedLength(varEventParameterTAccessEvent),
            T::EventParameter.TBufferReady varEventParameterTBufferReady => EventParameterTBufferReadyCodec.GetEncodedLength(varEventParameterTBufferReady),
            T::EventParameter.TChangeOfBitstring varEventParameterTChangeOfBitstring => EventParameterTChangeOfBitstringCodec.GetEncodedLength(varEventParameterTChangeOfBitstring),
            T::EventParameter.TChangeOfCharacterstring varEventParameterTChangeOfCharacterstring => EventParameterTChangeOfCharacterstringCodec.GetEncodedLength(varEventParameterTChangeOfCharacterstring),
            T::EventParameter.TChangeOfDiscreteValue varEventParameterTChangeOfDiscreteValue => EventParameterTChangeOfDiscreteValueCodec.GetEncodedLength(varEventParameterTChangeOfDiscreteValue),
            T::EventParameter.TChangeOfDiscreteValue.TNewValue varEventParameterTChangeOfDiscreteValueTNewValue => EventParameterTChangeOfDiscreteValueTNewValueCodec.GetEncodedLength(varEventParameterTChangeOfDiscreteValueTNewValue),
            T::EventParameter.TChangeOfLifeSafety varEventParameterTChangeOfLifeSafety => EventParameterTChangeOfLifeSafetyCodec.GetEncodedLength(varEventParameterTChangeOfLifeSafety),
            T::EventParameter.TChangeOfState varEventParameterTChangeOfState => EventParameterTChangeOfStateCodec.GetEncodedLength(varEventParameterTChangeOfState),
            T::EventParameter.TChangeOfStatusFlags varEventParameterTChangeOfStatusFlags => EventParameterTChangeOfStatusFlagsCodec.GetEncodedLength(varEventParameterTChangeOfStatusFlags),
            T::EventParameter.TChangeOfTimer varEventParameterTChangeOfTimer => EventParameterTChangeOfTimerCodec.GetEncodedLength(varEventParameterTChangeOfTimer),
            T::EventParameter.TChangeOfValue varEventParameterTChangeOfValue => EventParameterTChangeOfValueCodec.GetEncodedLength(varEventParameterTChangeOfValue),
            T::EventParameter.TChangeOfValue.TCovCriteria varEventParameterTChangeOfValueTCovCriteria => EventParameterTChangeOfValueTCovCriteriaCodec.GetEncodedLength(varEventParameterTChangeOfValueTCovCriteria),
            T::EventParameter.TCommandFailure varEventParameterTCommandFailure => EventParameterTCommandFailureCodec.GetEncodedLength(varEventParameterTCommandFailure),
            T::EventParameter.TDoubleOutOfRange varEventParameterTDoubleOutOfRange => EventParameterTDoubleOutOfRangeCodec.GetEncodedLength(varEventParameterTDoubleOutOfRange),
            T::EventParameter.TExtended varEventParameterTExtended => EventParameterTExtendedCodec.GetEncodedLength(varEventParameterTExtended),
            T::EventParameter.TExtended.TParametersItem varEventParameterTExtendedTParametersItem => EventParameterTExtendedTParametersItemCodec.GetEncodedLength(varEventParameterTExtendedTParametersItem),
            T::EventParameter.TFloatingLimit varEventParameterTFloatingLimit => EventParameterTFloatingLimitCodec.GetEncodedLength(varEventParameterTFloatingLimit),
            T::EventParameter.TOutOfRange varEventParameterTOutOfRange => EventParameterTOutOfRangeCodec.GetEncodedLength(varEventParameterTOutOfRange),
            T::EventParameter.TSignedOutOfRange varEventParameterTSignedOutOfRange => EventParameterTSignedOutOfRangeCodec.GetEncodedLength(varEventParameterTSignedOutOfRange),
            T::EventParameter.TUnsignedOutOfRange varEventParameterTUnsignedOutOfRange => EventParameterTUnsignedOutOfRangeCodec.GetEncodedLength(varEventParameterTUnsignedOutOfRange),
            T::EventParameter.TUnsignedRange varEventParameterTUnsignedRange => EventParameterTUnsignedRangeCodec.GetEncodedLength(varEventParameterTUnsignedRange),
            T::EventState varEventState => EventStateCodec.GetEncodedLength(varEventState),
            T::EventTransitionBits varEventTransitionBits => EventTransitionBitsCodec.GetEncodedLength(varEventTransitionBits),
            T::EventType varEventType => EventTypeCodec.GetEncodedLength(varEventType),
            T::FaultParameter varFaultParameter => FaultParameterCodec.GetEncodedLength(varFaultParameter),
            T::FaultParameter.TFaultCharacterstring varFaultParameterTFaultCharacterstring => FaultParameterTFaultCharacterstringCodec.GetEncodedLength(varFaultParameterTFaultCharacterstring),
            T::FaultParameter.TFaultExtended varFaultParameterTFaultExtended => FaultParameterTFaultExtendedCodec.GetEncodedLength(varFaultParameterTFaultExtended),
            T::FaultParameter.TFaultExtended.TParametersItem varFaultParameterTFaultExtendedTParametersItem => FaultParameterTFaultExtendedTParametersItemCodec.GetEncodedLength(varFaultParameterTFaultExtendedTParametersItem),
            T::FaultParameter.TFaultLifeSafety varFaultParameterTFaultLifeSafety => FaultParameterTFaultLifeSafetyCodec.GetEncodedLength(varFaultParameterTFaultLifeSafety),
            T::FaultParameter.TFaultListed varFaultParameterTFaultListed => FaultParameterTFaultListedCodec.GetEncodedLength(varFaultParameterTFaultListed),
            T::FaultParameter.TFaultOutOfRange varFaultParameterTFaultOutOfRange => FaultParameterTFaultOutOfRangeCodec.GetEncodedLength(varFaultParameterTFaultOutOfRange),
            T::FaultParameter.TFaultOutOfRange.TMaxNormalValue varFaultParameterTFaultOutOfRangeTMaxNormalValue => FaultParameterTFaultOutOfRangeTMaxNormalValueCodec.GetEncodedLength(varFaultParameterTFaultOutOfRangeTMaxNormalValue),
            T::FaultParameter.TFaultOutOfRange.TMinNormalValue varFaultParameterTFaultOutOfRangeTMinNormalValue => FaultParameterTFaultOutOfRangeTMinNormalValueCodec.GetEncodedLength(varFaultParameterTFaultOutOfRangeTMinNormalValue),
            T::FaultParameter.TFaultState varFaultParameterTFaultState => FaultParameterTFaultStateCodec.GetEncodedLength(varFaultParameterTFaultState),
            T::FaultParameter.TFaultStatusFlags varFaultParameterTFaultStatusFlags => FaultParameterTFaultStatusFlagsCodec.GetEncodedLength(varFaultParameterTFaultStatusFlags),
            T::FaultType varFaultType => FaultTypeCodec.GetEncodedLength(varFaultType),
            T::FdtEntry varFdtEntry => FdtEntryCodec.GetEncodedLength(varFdtEntry),
            T::FileAccessMethod varFileAccessMethod => FileAccessMethodCodec.GetEncodedLength(varFileAccessMethod),
            T::GetAlarmSummaryAck varGetAlarmSummaryAck => GetAlarmSummaryAckCodec.GetEncodedLength(varGetAlarmSummaryAck),
            T::GetAlarmSummaryAck.TItem varGetAlarmSummaryAckTItem => GetAlarmSummaryAckTItemCodec.GetEncodedLength(varGetAlarmSummaryAckTItem),
            T::GetEnrollmentSummaryAck varGetEnrollmentSummaryAck => GetEnrollmentSummaryAckCodec.GetEncodedLength(varGetEnrollmentSummaryAck),
            T::GetEnrollmentSummaryAck.TItem varGetEnrollmentSummaryAckTItem => GetEnrollmentSummaryAckTItemCodec.GetEncodedLength(varGetEnrollmentSummaryAckTItem),
            T::GetEnrollmentSummaryRequest varGetEnrollmentSummaryRequest => GetEnrollmentSummaryRequestCodec.GetEncodedLength(varGetEnrollmentSummaryRequest),
            T::GetEnrollmentSummaryRequest.TAcknowledgmentFilter varGetEnrollmentSummaryRequestTAcknowledgmentFilter => GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec.GetEncodedLength(varGetEnrollmentSummaryRequestTAcknowledgmentFilter),
            T::GetEnrollmentSummaryRequest.TEventStateFilter varGetEnrollmentSummaryRequestTEventStateFilter => GetEnrollmentSummaryRequestTEventStateFilterCodec.GetEncodedLength(varGetEnrollmentSummaryRequestTEventStateFilter),
            T::GetEnrollmentSummaryRequest.TPriorityFilter varGetEnrollmentSummaryRequestTPriorityFilter => GetEnrollmentSummaryRequestTPriorityFilterCodec.GetEncodedLength(varGetEnrollmentSummaryRequestTPriorityFilter),
            T::GetEventInformationAck varGetEventInformationAck => GetEventInformationAckCodec.GetEncodedLength(varGetEventInformationAck),
            T::GetEventInformationAck.TListOfEventSummariesItem varGetEventInformationAckTListOfEventSummariesItem => GetEventInformationAckTListOfEventSummariesItemCodec.GetEncodedLength(varGetEventInformationAckTListOfEventSummariesItem),
            T::GetEventInformationRequest varGetEventInformationRequest => GetEventInformationRequestCodec.GetEncodedLength(varGetEventInformationRequest),
            T::GroupChannelValue varGroupChannelValue => GroupChannelValueCodec.GetEncodedLength(varGroupChannelValue),
            T::GroupChannelValue.TOverridingPriority varGroupChannelValueTOverridingPriority => GroupChannelValueTOverridingPriorityCodec.GetEncodedLength(varGroupChannelValueTOverridingPriority),
            T::Health varHealth => HealthCodec.GetEncodedLength(varHealth),
            T::HostAddress varHostAddress => HostAddressCodec.GetEncodedLength(varHostAddress),
            T::HostNPort varHostNPort => HostNPortCodec.GetEncodedLength(varHostNPort),
            T::IAmRequest varIAmRequest => IAmRequestCodec.GetEncodedLength(varIAmRequest),
            T::IHaveRequest varIHaveRequest => IHaveRequestCodec.GetEncodedLength(varIHaveRequest),
            short varInteger16 => Integer16Codec.GetEncodedLength(varInteger16),
            int varInteger32 => Integer32Codec.GetEncodedLength(varInteger32),
            long varInteger64 => Integer64Codec.GetEncodedLength(varInteger64),
            sbyte varInteger8 => Integer8Codec.GetEncodedLength(varInteger8),
            T::IpMode varIpMode => IpModeCodec.GetEncodedLength(varIpMode),
            T::LandingCallStatus varLandingCallStatus => LandingCallStatusCodec.GetEncodedLength(varLandingCallStatus),
            T::LandingCallStatus.TCommand varLandingCallStatusTCommand => LandingCallStatusTCommandCodec.GetEncodedLength(varLandingCallStatusTCommand),
            T::LandingDoorStatus varLandingDoorStatus => LandingDoorStatusCodec.GetEncodedLength(varLandingDoorStatus),
            T::LandingDoorStatus.TLandingDoorsItem varLandingDoorStatusTLandingDoorsItem => LandingDoorStatusTLandingDoorsItemCodec.GetEncodedLength(varLandingDoorStatusTLandingDoorsItem),
            T::LifeSafetyMode varLifeSafetyMode => LifeSafetyModeCodec.GetEncodedLength(varLifeSafetyMode),
            T::LifeSafetyOperation varLifeSafetyOperation => LifeSafetyOperationCodec.GetEncodedLength(varLifeSafetyOperation),
            T::LifeSafetyOperationInfo varLifeSafetyOperationInfo => LifeSafetyOperationInfoCodec.GetEncodedLength(varLifeSafetyOperationInfo),
            T::LifeSafetyOperationRequest varLifeSafetyOperationRequest => LifeSafetyOperationRequestCodec.GetEncodedLength(varLifeSafetyOperationRequest),
            T::LifeSafetyState varLifeSafetyState => LifeSafetyStateCodec.GetEncodedLength(varLifeSafetyState),
            T::LiftCarCallList varLiftCarCallList => LiftCarCallListCodec.GetEncodedLength(varLiftCarCallList),
            T::LiftCarDirection varLiftCarDirection => LiftCarDirectionCodec.GetEncodedLength(varLiftCarDirection),
            T::LiftCarDoorCommand varLiftCarDoorCommand => LiftCarDoorCommandCodec.GetEncodedLength(varLiftCarDoorCommand),
            T::LiftCarDriveStatus varLiftCarDriveStatus => LiftCarDriveStatusCodec.GetEncodedLength(varLiftCarDriveStatus),
            T::LiftCarMode varLiftCarMode => LiftCarModeCodec.GetEncodedLength(varLiftCarMode),
            T::LiftFault varLiftFault => LiftFaultCodec.GetEncodedLength(varLiftFault),
            T::LiftGroupMode varLiftGroupMode => LiftGroupModeCodec.GetEncodedLength(varLiftGroupMode),
            T::LightingCommand varLightingCommand => LightingCommandCodec.GetEncodedLength(varLightingCommand),
            T::LightingCommand.TFadeTime varLightingCommandTFadeTime => LightingCommandTFadeTimeCodec.GetEncodedLength(varLightingCommandTFadeTime),
            T::LightingCommand.TPriority varLightingCommandTPriority => LightingCommandTPriorityCodec.GetEncodedLength(varLightingCommandTPriority),
            T::LightingCommand.TRampRate varLightingCommandTRampRate => LightingCommandTRampRateCodec.GetEncodedLength(varLightingCommandTRampRate),
            T::LightingCommand.TStepIncrement varLightingCommandTStepIncrement => LightingCommandTStepIncrementCodec.GetEncodedLength(varLightingCommandTStepIncrement),
            T::LightingCommand.TTargetLevel varLightingCommandTTargetLevel => LightingCommandTTargetLevelCodec.GetEncodedLength(varLightingCommandTTargetLevel),
            T::LightingInProgress varLightingInProgress => LightingInProgressCodec.GetEncodedLength(varLightingInProgress),
            T::LightingOperation varLightingOperation => LightingOperationCodec.GetEncodedLength(varLightingOperation),
            T::LightingTransition varLightingTransition => LightingTransitionCodec.GetEncodedLength(varLightingTransition),
            T::LimitEnable varLimitEnable => LimitEnableCodec.GetEncodedLength(varLimitEnable),
            T::LockStatus varLockStatus => LockStatusCodec.GetEncodedLength(varLockStatus),
            T::LogData varLogData => LogDataCodec.GetEncodedLength(varLogData),
            T::LogData.TSeriesItem varLogDataTSeriesItem => LogDataTSeriesItemCodec.GetEncodedLength(varLogDataTSeriesItem),
            T::LoggingType varLoggingType => LoggingTypeCodec.GetEncodedLength(varLoggingType),
            T::LogMultipleRecord varLogMultipleRecord => LogMultipleRecordCodec.GetEncodedLength(varLogMultipleRecord),
            T::LogRecord varLogRecord => LogRecordCodec.GetEncodedLength(varLogRecord),
            T::LogRecord.TLogDatum varLogRecordTLogDatum => LogRecordTLogDatumCodec.GetEncodedLength(varLogRecordTLogDatum),
            T::LogStatus varLogStatus => LogStatusCodec.GetEncodedLength(varLogStatus),
            T::Maintenance varMaintenance => MaintenanceCodec.GetEncodedLength(varMaintenance),
            T::NameValue varNameValue => NameValueCodec.GetEncodedLength(varNameValue),
            T::NameValueCollection varNameValueCollection => NameValueCollectionCodec.GetEncodedLength(varNameValueCollection),
            T::NetworkNumberQuality varNetworkNumberQuality => NetworkNumberQualityCodec.GetEncodedLength(varNetworkNumberQuality),
            T::NetworkPortCommand varNetworkPortCommand => NetworkPortCommandCodec.GetEncodedLength(varNetworkPortCommand),
            T::NetworkType varNetworkType => NetworkTypeCodec.GetEncodedLength(varNetworkType),
            T::NodeType varNodeType => NodeTypeCodec.GetEncodedLength(varNodeType),
            T::NotificationParameters varNotificationParameters => NotificationParametersCodec.GetEncodedLength(varNotificationParameters),
            T::NotificationParameters.TAccessEvent varNotificationParametersTAccessEvent => NotificationParametersTAccessEventCodec.GetEncodedLength(varNotificationParametersTAccessEvent),
            T::NotificationParameters.TBufferReady varNotificationParametersTBufferReady => NotificationParametersTBufferReadyCodec.GetEncodedLength(varNotificationParametersTBufferReady),
            T::NotificationParameters.TChangeOfBitstring varNotificationParametersTChangeOfBitstring => NotificationParametersTChangeOfBitstringCodec.GetEncodedLength(varNotificationParametersTChangeOfBitstring),
            T::NotificationParameters.TChangeOfCharacterstring varNotificationParametersTChangeOfCharacterstring => NotificationParametersTChangeOfCharacterstringCodec.GetEncodedLength(varNotificationParametersTChangeOfCharacterstring),
            T::NotificationParameters.TChangeOfDiscreteValue varNotificationParametersTChangeOfDiscreteValue => NotificationParametersTChangeOfDiscreteValueCodec.GetEncodedLength(varNotificationParametersTChangeOfDiscreteValue),
            T::NotificationParameters.TChangeOfDiscreteValue.TNewValue varNotificationParametersTChangeOfDiscreteValueTNewValue => NotificationParametersTChangeOfDiscreteValueTNewValueCodec.GetEncodedLength(varNotificationParametersTChangeOfDiscreteValueTNewValue),
            T::NotificationParameters.TChangeOfLifeSafety varNotificationParametersTChangeOfLifeSafety => NotificationParametersTChangeOfLifeSafetyCodec.GetEncodedLength(varNotificationParametersTChangeOfLifeSafety),
            T::NotificationParameters.TChangeOfReliability varNotificationParametersTChangeOfReliability => NotificationParametersTChangeOfReliabilityCodec.GetEncodedLength(varNotificationParametersTChangeOfReliability),
            T::NotificationParameters.TChangeOfState varNotificationParametersTChangeOfState => NotificationParametersTChangeOfStateCodec.GetEncodedLength(varNotificationParametersTChangeOfState),
            T::NotificationParameters.TChangeOfStatusFlags varNotificationParametersTChangeOfStatusFlags => NotificationParametersTChangeOfStatusFlagsCodec.GetEncodedLength(varNotificationParametersTChangeOfStatusFlags),
            T::NotificationParameters.TChangeOfTimer varNotificationParametersTChangeOfTimer => NotificationParametersTChangeOfTimerCodec.GetEncodedLength(varNotificationParametersTChangeOfTimer),
            T::NotificationParameters.TChangeOfValue varNotificationParametersTChangeOfValue => NotificationParametersTChangeOfValueCodec.GetEncodedLength(varNotificationParametersTChangeOfValue),
            T::NotificationParameters.TChangeOfValue.TNewValue varNotificationParametersTChangeOfValueTNewValue => NotificationParametersTChangeOfValueTNewValueCodec.GetEncodedLength(varNotificationParametersTChangeOfValueTNewValue),
            T::NotificationParameters.TCommandFailure varNotificationParametersTCommandFailure => NotificationParametersTCommandFailureCodec.GetEncodedLength(varNotificationParametersTCommandFailure),
            T::NotificationParameters.TDoubleOutOfRange varNotificationParametersTDoubleOutOfRange => NotificationParametersTDoubleOutOfRangeCodec.GetEncodedLength(varNotificationParametersTDoubleOutOfRange),
            T::NotificationParameters.TExtended varNotificationParametersTExtended => NotificationParametersTExtendedCodec.GetEncodedLength(varNotificationParametersTExtended),
            T::NotificationParameters.TExtended.TParametersItem varNotificationParametersTExtendedTParametersItem => NotificationParametersTExtendedTParametersItemCodec.GetEncodedLength(varNotificationParametersTExtendedTParametersItem),
            T::NotificationParameters.TFloatingLimit varNotificationParametersTFloatingLimit => NotificationParametersTFloatingLimitCodec.GetEncodedLength(varNotificationParametersTFloatingLimit),
            T::NotificationParameters.TOutOfRange varNotificationParametersTOutOfRange => NotificationParametersTOutOfRangeCodec.GetEncodedLength(varNotificationParametersTOutOfRange),
            T::NotificationParameters.TSignedOutOfRange varNotificationParametersTSignedOutOfRange => NotificationParametersTSignedOutOfRangeCodec.GetEncodedLength(varNotificationParametersTSignedOutOfRange),
            T::NotificationParameters.TUnsignedOutOfRange varNotificationParametersTUnsignedOutOfRange => NotificationParametersTUnsignedOutOfRangeCodec.GetEncodedLength(varNotificationParametersTUnsignedOutOfRange),
            T::NotificationParameters.TUnsignedRange varNotificationParametersTUnsignedRange => NotificationParametersTUnsignedRangeCodec.GetEncodedLength(varNotificationParametersTUnsignedRange),
            T::NotifyType varNotifyType => NotifyTypeCodec.GetEncodedLength(varNotifyType),
            T::Null varNull => NullCodec.GetEncodedLength(varNull),
            T::ObjectIdentifier varObjectIdentifier => ObjectIdentifierCodec.GetEncodedLength(varObjectIdentifier),
            T::ObjectPropertyReference varObjectPropertyReference => ObjectPropertyReferenceCodec.GetEncodedLength(varObjectPropertyReference),
            T::ObjectPropertyValue varObjectPropertyValue => ObjectPropertyValueCodec.GetEncodedLength(varObjectPropertyValue),
            T::ObjectPropertyValue.TPriority varObjectPropertyValueTPriority => ObjectPropertyValueTPriorityCodec.GetEncodedLength(varObjectPropertyValueTPriority),
            T::ObjectSelector varObjectSelector => ObjectSelectorCodec.GetEncodedLength(varObjectSelector),
            T::ObjectType varObjectType => ObjectTypeCodec.GetEncodedLength(varObjectType),
            T::ObjectTypesSupported varObjectTypesSupported => ObjectTypesSupportedCodec.GetEncodedLength(varObjectTypesSupported),
            T::OctetString varOctetString => OctetStringCodec.GetEncodedLength(varOctetString),
            T::OptionalAny varOptionalAny => OptionalAnyCodec.GetEncodedLength(varOptionalAny),
            T::OptionalBinaryLightingPv varOptionalBinaryLightingPv => OptionalBinaryLightingPvCodec.GetEncodedLength(varOptionalBinaryLightingPv),
            T::OptionalBinaryPv varOptionalBinaryPv => OptionalBinaryPvCodec.GetEncodedLength(varOptionalBinaryPv),
            T::OptionalBitString varOptionalBitString => OptionalBitStringCodec.GetEncodedLength(varOptionalBitString),
            T::OptionalCharacterString varOptionalCharacterString => OptionalCharacterStringCodec.GetEncodedLength(varOptionalCharacterString),
            T::OptionalDate varOptionalDate => OptionalDateCodec.GetEncodedLength(varOptionalDate),
            T::OptionalDatePattern varOptionalDatePattern => OptionalDatePatternCodec.GetEncodedLength(varOptionalDatePattern),
            T::OptionalDateTime varOptionalDateTime => OptionalDateTimeCodec.GetEncodedLength(varOptionalDateTime),
            T::OptionalDateTimePattern varOptionalDateTimePattern => OptionalDateTimePatternCodec.GetEncodedLength(varOptionalDateTimePattern),
            T::OptionalDoorValue varOptionalDoorValue => OptionalDoorValueCodec.GetEncodedLength(varOptionalDoorValue),
            T::OptionalDouble varOptionalDouble => OptionalDoubleCodec.GetEncodedLength(varOptionalDouble),
            T::OptionalInteger varOptionalInteger => OptionalIntegerCodec.GetEncodedLength(varOptionalInteger),
            T::OptionalOctetString varOptionalOctetString => OptionalOctetStringCodec.GetEncodedLength(varOptionalOctetString),
            T::OptionalPriorityFilter varOptionalPriorityFilter => OptionalPriorityFilterCodec.GetEncodedLength(varOptionalPriorityFilter),
            T::OptionalReal varOptionalReal => OptionalRealCodec.GetEncodedLength(varOptionalReal),
            T::OptionalTimePattern varOptionalTimePattern => OptionalTimePatternCodec.GetEncodedLength(varOptionalTimePattern),
            T::OptionalUnsigned varOptionalUnsigned => OptionalUnsignedCodec.GetEncodedLength(varOptionalUnsigned),
            T::Polarity varPolarity => PolarityCodec.GetEncodedLength(varPolarity),
            T::PortPermission varPortPermission => PortPermissionCodec.GetEncodedLength(varPortPermission),
            T::Prescale varPrescale => PrescaleCodec.GetEncodedLength(varPrescale),
            T::PriorityFilter varPriorityFilter => PriorityFilterCodec.GetEncodedLength(varPriorityFilter),
            T::ProcessIdSelection varProcessIdSelection => ProcessIdSelectionCodec.GetEncodedLength(varProcessIdSelection),
            T::ProgramError varProgramError => ProgramErrorCodec.GetEncodedLength(varProgramError),
            T::ProgramRequest varProgramRequest => ProgramRequestCodec.GetEncodedLength(varProgramRequest),
            T::ProgramState varProgramState => ProgramStateCodec.GetEncodedLength(varProgramState),
            T::PropertyAccessResult varPropertyAccessResult => PropertyAccessResultCodec.GetEncodedLength(varPropertyAccessResult),
            T::PropertyAccessResult.TAccessResult varPropertyAccessResultTAccessResult => PropertyAccessResultTAccessResultCodec.GetEncodedLength(varPropertyAccessResultTAccessResult),
            T::PropertyIdentifier varPropertyIdentifier => PropertyIdentifierCodec.GetEncodedLength(varPropertyIdentifier),
            T::PropertyReference varPropertyReference => PropertyReferenceCodec.GetEncodedLength(varPropertyReference),
            T::PropertyStates varPropertyStates => PropertyStatesCodec.GetEncodedLength(varPropertyStates),
            T::PropertyValue varPropertyValue => PropertyValueCodec.GetEncodedLength(varPropertyValue),
            T::PropertyValue.TPriority varPropertyValueTPriority => PropertyValueTPriorityCodec.GetEncodedLength(varPropertyValueTPriority),
            T::ProtocolLevel varProtocolLevel => ProtocolLevelCodec.GetEncodedLength(varProtocolLevel),
            T::ReadAccessResult varReadAccessResult => ReadAccessResultCodec.GetEncodedLength(varReadAccessResult),
            T::ReadAccessResult.TListOfResultsItem varReadAccessResultTListOfResultsItem => ReadAccessResultTListOfResultsItemCodec.GetEncodedLength(varReadAccessResultTListOfResultsItem),
            T::ReadAccessResult.TListOfResultsItem.TReadResult varReadAccessResultTListOfResultsItemTReadResult => ReadAccessResultTListOfResultsItemTReadResultCodec.GetEncodedLength(varReadAccessResultTListOfResultsItemTReadResult),
            T::ReadAccessSpecification varReadAccessSpecification => ReadAccessSpecificationCodec.GetEncodedLength(varReadAccessSpecification),
            T::ReadPropertyAck varReadPropertyAck => ReadPropertyAckCodec.GetEncodedLength(varReadPropertyAck),
            T::ReadPropertyMultipleAck varReadPropertyMultipleAck => ReadPropertyMultipleAckCodec.GetEncodedLength(varReadPropertyMultipleAck),
            T::ReadPropertyMultipleRequest varReadPropertyMultipleRequest => ReadPropertyMultipleRequestCodec.GetEncodedLength(varReadPropertyMultipleRequest),
            T::ReadPropertyRequest varReadPropertyRequest => ReadPropertyRequestCodec.GetEncodedLength(varReadPropertyRequest),
            T::ReadRangeAck varReadRangeAck => ReadRangeAckCodec.GetEncodedLength(varReadRangeAck),
            T::ReadRangeRequest varReadRangeRequest => ReadRangeRequestCodec.GetEncodedLength(varReadRangeRequest),
            T::ReadRangeRequest.TRange varReadRangeRequestTRange => ReadRangeRequestTRangeCodec.GetEncodedLength(varReadRangeRequestTRange),
            T::ReadRangeRequest.TRange.TByPosition varReadRangeRequestTRangeTByPosition => ReadRangeRequestTRangeTByPositionCodec.GetEncodedLength(varReadRangeRequestTRangeTByPosition),
            T::ReadRangeRequest.TRange.TBySequenceNumber varReadRangeRequestTRangeTBySequenceNumber => ReadRangeRequestTRangeTBySequenceNumberCodec.GetEncodedLength(varReadRangeRequestTRangeTBySequenceNumber),
            T::ReadRangeRequest.TRange.TByTime varReadRangeRequestTRangeTByTime => ReadRangeRequestTRangeTByTimeCodec.GetEncodedLength(varReadRangeRequestTRangeTByTime),
            float varReal => RealCodec.GetEncodedLength(varReal),
            T::Recipient varRecipient => RecipientCodec.GetEncodedLength(varRecipient),
            T::RecipientProcess varRecipientProcess => RecipientProcessCodec.GetEncodedLength(varRecipientProcess),
            T::ReinitializeDeviceRequest varReinitializeDeviceRequest => ReinitializeDeviceRequestCodec.GetEncodedLength(varReinitializeDeviceRequest),
            T::ReinitializeDeviceRequest.TPassword varReinitializeDeviceRequestTPassword => ReinitializeDeviceRequestTPasswordCodec.GetEncodedLength(varReinitializeDeviceRequestTPassword),
            T::ReinitializeDeviceRequest.TReinitializedStateOfDevice varReinitializeDeviceRequestTReinitializedStateOfDevice => ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec.GetEncodedLength(varReinitializeDeviceRequestTReinitializedStateOfDevice),
            T::RejectReason varRejectReason => RejectReasonCodec.GetEncodedLength(varRejectReason),
            T::Relationship varRelationship => RelationshipCodec.GetEncodedLength(varRelationship),
            T::Reliability varReliability => ReliabilityCodec.GetEncodedLength(varReliability),
            T::RemoveListElementRequest varRemoveListElementRequest => RemoveListElementRequestCodec.GetEncodedLength(varRemoveListElementRequest),
            T::RestartReason varRestartReason => RestartReasonCodec.GetEncodedLength(varRestartReason),
            T::ResultFlags varResultFlags => ResultFlagsCodec.GetEncodedLength(varResultFlags),
            T::RouterEntry varRouterEntry => RouterEntryCodec.GetEncodedLength(varRouterEntry),
            T::RouterEntry.TStatus varRouterEntryTStatus => RouterEntryTStatusCodec.GetEncodedLength(varRouterEntryTStatus),
            T::Scale varScale => ScaleCodec.GetEncodedLength(varScale),
            T::ScConnectionState varScConnectionState => ScConnectionStateCodec.GetEncodedLength(varScConnectionState),
            T::ScDirectConnection varScDirectConnection => ScDirectConnectionCodec.GetEncodedLength(varScDirectConnection),
            T::ScDirectConnection.TPeerUuid varScDirectConnectionTPeerUuid => ScDirectConnectionTPeerUuidCodec.GetEncodedLength(varScDirectConnectionTPeerUuid),
            T::ScDirectConnection.TPeerVmac varScDirectConnectionTPeerVmac => ScDirectConnectionTPeerVmacCodec.GetEncodedLength(varScDirectConnectionTPeerVmac),
            T::ScFailedConnectionRequest varScFailedConnectionRequest => ScFailedConnectionRequestCodec.GetEncodedLength(varScFailedConnectionRequest),
            T::ScFailedConnectionRequest.TPeerUuid varScFailedConnectionRequestTPeerUuid => ScFailedConnectionRequestTPeerUuidCodec.GetEncodedLength(varScFailedConnectionRequestTPeerUuid),
            T::ScFailedConnectionRequest.TPeerVmac varScFailedConnectionRequestTPeerVmac => ScFailedConnectionRequestTPeerVmacCodec.GetEncodedLength(varScFailedConnectionRequestTPeerVmac),
            T::ScHubConnection varScHubConnection => ScHubConnectionCodec.GetEncodedLength(varScHubConnection),
            T::ScHubConnectorState varScHubConnectorState => ScHubConnectorStateCodec.GetEncodedLength(varScHubConnectorState),
            T::ScHubFunctionConnection varScHubFunctionConnection => ScHubFunctionConnectionCodec.GetEncodedLength(varScHubFunctionConnection),
            T::ScHubFunctionConnection.TPeerUuid varScHubFunctionConnectionTPeerUuid => ScHubFunctionConnectionTPeerUuidCodec.GetEncodedLength(varScHubFunctionConnectionTPeerUuid),
            T::ScHubFunctionConnection.TPeerVmac varScHubFunctionConnectionTPeerVmac => ScHubFunctionConnectionTPeerVmacCodec.GetEncodedLength(varScHubFunctionConnectionTPeerVmac),
            T::Segmentation varSegmentation => SegmentationCodec.GetEncodedLength(varSegmentation),
            T::ServicesSupported varServicesSupported => ServicesSupportedCodec.GetEncodedLength(varServicesSupported),
            T::SetpointReference varSetpointReference => SetpointReferenceCodec.GetEncodedLength(varSetpointReference),
            T::ShedLevel varShedLevel => ShedLevelCodec.GetEncodedLength(varShedLevel),
            T::ShedState varShedState => ShedStateCodec.GetEncodedLength(varShedState),
            T::SilencedState varSilencedState => SilencedStateCodec.GetEncodedLength(varSilencedState),
            T::SpecialEvent varSpecialEvent => SpecialEventCodec.GetEncodedLength(varSpecialEvent),
            T::SpecialEvent.TEventPriority varSpecialEventTEventPriority => SpecialEventTEventPriorityCodec.GetEncodedLength(varSpecialEventTEventPriority),
            T::SpecialEvent.TPeriod varSpecialEventTPeriod => SpecialEventTPeriodCodec.GetEncodedLength(varSpecialEventTPeriod),
            T::StageLimitValue varStageLimitValue => StageLimitValueCodec.GetEncodedLength(varStageLimitValue),
            T::StatusFlags varStatusFlags => StatusFlagsCodec.GetEncodedLength(varStatusFlags),
            T::SubscribeCovPropertyMultipleError varSubscribeCovPropertyMultipleError => SubscribeCovPropertyMultipleErrorCodec.GetEncodedLength(varSubscribeCovPropertyMultipleError),
            T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription varSubscribeCovPropertyMultipleErrorTFirstFailedSubscription => SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec.GetEncodedLength(varSubscribeCovPropertyMultipleErrorTFirstFailedSubscription),
            T::SubscribeCovPropertyMultipleRequest varSubscribeCovPropertyMultipleRequest => SubscribeCovPropertyMultipleRequestCodec.GetEncodedLength(varSubscribeCovPropertyMultipleRequest),
            T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItem => SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec.GetEncodedLength(varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItem),
            T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem => SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec.GetEncodedLength(varSubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItem),
            T::SubscribeCovPropertyRequest varSubscribeCovPropertyRequest => SubscribeCovPropertyRequestCodec.GetEncodedLength(varSubscribeCovPropertyRequest),
            T::SubscribeCovRequest varSubscribeCovRequest => SubscribeCovRequestCodec.GetEncodedLength(varSubscribeCovRequest),
            T::SuccessFilter varSuccessFilter => SuccessFilterCodec.GetEncodedLength(varSuccessFilter),
            T::Time varTime => TimeCodec.GetEncodedLength(varTime),
            T::TimePattern varTimePattern => TimePatternCodec.GetEncodedLength(varTimePattern),
            T::TimerStateChangeValue varTimerStateChangeValue => TimerStateChangeValueCodec.GetEncodedLength(varTimerStateChangeValue),
            T::TimerState varTimerState => TimerStateCodec.GetEncodedLength(varTimerState),
            T::TimerTransition varTimerTransition => TimerTransitionCodec.GetEncodedLength(varTimerTransition),
            T::TimeStamp varTimeStamp => TimeStampCodec.GetEncodedLength(varTimeStamp),
            T::TimeStamp.TSequenceNumber varTimeStampTSequenceNumber => TimeStampTSequenceNumberCodec.GetEncodedLength(varTimeStampTSequenceNumber),
            T::TimeSynchronizationRequest varTimeSynchronizationRequest => TimeSynchronizationRequestCodec.GetEncodedLength(varTimeSynchronizationRequest),
            T::TimeValue varTimeValue => TimeValueCodec.GetEncodedLength(varTimeValue),
            T::UnconfirmedAuditNotificationRequest varUnconfirmedAuditNotificationRequest => UnconfirmedAuditNotificationRequestCodec.GetEncodedLength(varUnconfirmedAuditNotificationRequest),
            T::UnconfirmedCovNotificationMultipleRequest varUnconfirmedCovNotificationMultipleRequest => UnconfirmedCovNotificationMultipleRequestCodec.GetEncodedLength(varUnconfirmedCovNotificationMultipleRequest),
            T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem => UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec.GetEncodedLength(varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItem),
            T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem => UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec.GetEncodedLength(varUnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItem),
            T::UnconfirmedCovNotificationRequest varUnconfirmedCovNotificationRequest => UnconfirmedCovNotificationRequestCodec.GetEncodedLength(varUnconfirmedCovNotificationRequest),
            T::UnconfirmedEventNotificationRequest varUnconfirmedEventNotificationRequest => UnconfirmedEventNotificationRequestCodec.GetEncodedLength(varUnconfirmedEventNotificationRequest),
            T::UnconfirmedPrivateTransferRequest varUnconfirmedPrivateTransferRequest => UnconfirmedPrivateTransferRequestCodec.GetEncodedLength(varUnconfirmedPrivateTransferRequest),
            T::UnconfirmedServiceChoice varUnconfirmedServiceChoice => UnconfirmedServiceChoiceCodec.GetEncodedLength(varUnconfirmedServiceChoice),
            T::UnconfirmedServiceRequest varUnconfirmedServiceRequest => UnconfirmedServiceRequestCodec.GetEncodedLength(varUnconfirmedServiceRequest),
            T::UnconfirmedTextMessageRequest varUnconfirmedTextMessageRequest => UnconfirmedTextMessageRequestCodec.GetEncodedLength(varUnconfirmedTextMessageRequest),
            T::UnconfirmedTextMessageRequest.TMessageClass varUnconfirmedTextMessageRequestTMessageClass => UnconfirmedTextMessageRequestTMessageClassCodec.GetEncodedLength(varUnconfirmedTextMessageRequestTMessageClass),
            T::UnconfirmedTextMessageRequest.TMessagePriority varUnconfirmedTextMessageRequestTMessagePriority => UnconfirmedTextMessageRequestTMessagePriorityCodec.GetEncodedLength(varUnconfirmedTextMessageRequestTMessagePriority),
            ushort varUnsigned16 => Unsigned16Codec.GetEncodedLength(varUnsigned16),
            uint varUnsigned32 => Unsigned32Codec.GetEncodedLength(varUnsigned32),
            ulong varUnsigned64 => Unsigned64Codec.GetEncodedLength(varUnsigned64),
            byte varUnsigned8 => Unsigned8Codec.GetEncodedLength(varUnsigned8),
            T::UtcTimeSynchronizationRequest varUtcTimeSynchronizationRequest => UtcTimeSynchronizationRequestCodec.GetEncodedLength(varUtcTimeSynchronizationRequest),
            T::ValueSource varValueSource => ValueSourceCodec.GetEncodedLength(varValueSource),
            T::VmacEntry varVmacEntry => VmacEntryCodec.GetEncodedLength(varVmacEntry),
            T::VtClass varVtClass => VtClassCodec.GetEncodedLength(varVtClass),
            T::VtCloseError varVtCloseError => VtCloseErrorCodec.GetEncodedLength(varVtCloseError),
            T::VtCloseRequest varVtCloseRequest => VtCloseRequestCodec.GetEncodedLength(varVtCloseRequest),
            T::VtDataAck varVtDataAck => VtDataAckCodec.GetEncodedLength(varVtDataAck),
            T::VtDataRequest varVtDataRequest => VtDataRequestCodec.GetEncodedLength(varVtDataRequest),
            T::VtDataRequest.TVtDataFlag varVtDataRequestTVtDataFlag => VtDataRequestTVtDataFlagCodec.GetEncodedLength(varVtDataRequestTVtDataFlag),
            T::VtOpenAck varVtOpenAck => VtOpenAckCodec.GetEncodedLength(varVtOpenAck),
            T::VtOpenRequest varVtOpenRequest => VtOpenRequestCodec.GetEncodedLength(varVtOpenRequest),
            T::VtSession varVtSession => VtSessionCodec.GetEncodedLength(varVtSession),
            T::WeekNDay varWeekNDay => WeekNDayCodec.GetEncodedLength(varWeekNDay),
            T::WhoAmIRequest varWhoAmIRequest => WhoAmIRequestCodec.GetEncodedLength(varWhoAmIRequest),
            T::WhoHasRequest varWhoHasRequest => WhoHasRequestCodec.GetEncodedLength(varWhoHasRequest),
            T::WhoHasRequest.TLimits varWhoHasRequestTLimits => WhoHasRequestTLimitsCodec.GetEncodedLength(varWhoHasRequestTLimits),
            T::WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit varWhoHasRequestTLimitsTDeviceInstanceRangeHighLimit => WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec.GetEncodedLength(varWhoHasRequestTLimitsTDeviceInstanceRangeHighLimit),
            T::WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit varWhoHasRequestTLimitsTDeviceInstanceRangeLowLimit => WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec.GetEncodedLength(varWhoHasRequestTLimitsTDeviceInstanceRangeLowLimit),
            T::WhoHasRequest.TObject varWhoHasRequestTObject => WhoHasRequestTObjectCodec.GetEncodedLength(varWhoHasRequestTObject),
            T::WhoIsRequest varWhoIsRequest => WhoIsRequestCodec.GetEncodedLength(varWhoIsRequest),
            T::WhoIsRequest.TDeviceInstanceRangeHighLimit varWhoIsRequestTDeviceInstanceRangeHighLimit => WhoIsRequestTDeviceInstanceRangeHighLimitCodec.GetEncodedLength(varWhoIsRequestTDeviceInstanceRangeHighLimit),
            T::WhoIsRequest.TDeviceInstanceRangeLowLimit varWhoIsRequestTDeviceInstanceRangeLowLimit => WhoIsRequestTDeviceInstanceRangeLowLimitCodec.GetEncodedLength(varWhoIsRequestTDeviceInstanceRangeLowLimit),
            T::WriteAccessSpecification varWriteAccessSpecification => WriteAccessSpecificationCodec.GetEncodedLength(varWriteAccessSpecification),
            T::WriteGroupRequest varWriteGroupRequest => WriteGroupRequestCodec.GetEncodedLength(varWriteGroupRequest),
            T::WriteGroupRequest.TWritePriority varWriteGroupRequestTWritePriority => WriteGroupRequestTWritePriorityCodec.GetEncodedLength(varWriteGroupRequestTWritePriority),
            T::WritePropertyMultipleError varWritePropertyMultipleError => WritePropertyMultipleErrorCodec.GetEncodedLength(varWritePropertyMultipleError),
            T::WritePropertyMultipleRequest varWritePropertyMultipleRequest => WritePropertyMultipleRequestCodec.GetEncodedLength(varWritePropertyMultipleRequest),
            T::WritePropertyRequest varWritePropertyRequest => WritePropertyRequestCodec.GetEncodedLength(varWritePropertyRequest),
            T::WritePropertyRequest.TPriority varWritePropertyRequestTPriority => WritePropertyRequestTPriorityCodec.GetEncodedLength(varWritePropertyRequestTPriority),
            T::WriteStatus varWriteStatus => WriteStatusCodec.GetEncodedLength(varWriteStatus),
            T::XyColor varXyColor => XyColorCodec.GetEncodedLength(varXyColor),
            T::YouAreRequest varYouAreRequest => YouAreRequestCodec.GetEncodedLength(varYouAreRequest),
            _ => throw new NotSupportedException($"The type '{value.ValueType}' has no codec.")
        };
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value, byte tagNumber)
    {
        var tagLength = AsduLength.FromTagNumber(tagNumber);
        return tagLength + GetEncodedLength(value) + tagLength;
    }
}
