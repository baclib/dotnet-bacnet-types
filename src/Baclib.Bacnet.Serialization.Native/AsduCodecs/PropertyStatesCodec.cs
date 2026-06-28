// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyStatesCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.PropertyStates>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.PropertyStates>
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
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 27:
            case 28:
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 36:
            case 37:
            case 38:
            case 39:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
            case 58:
            case 59:
            case 60:
            case 63:
            case 258:
            case 259:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.PropertyStates Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _booleanValue = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBooleanValue(_booleanValue);
            case 1:
                var _binaryValue = Asdu.DecodePrimitive<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBinaryValue(_binaryValue);
            case 2:
                var _eventType = Asdu.DecodePrimitive<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEventType(_eventType);
            case 3:
                var _polarity = Asdu.DecodePrimitive<PolarityCodec, global::Baclib.Bacnet.Types.Application.Polarity>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromPolarity(_polarity);
            case 4:
                var _programChange = Asdu.DecodePrimitive<ProgramRequestCodec, global::Baclib.Bacnet.Types.Application.ProgramRequest>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProgramChange(_programChange);
            case 5:
                var _programState = Asdu.DecodePrimitive<ProgramStateCodec, global::Baclib.Bacnet.Types.Application.ProgramState>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProgramState(_programState);
            case 6:
                var _reasonForHalt = Asdu.DecodePrimitive<ProgramErrorCodec, global::Baclib.Bacnet.Types.Application.ProgramError>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromReasonForHalt(_reasonForHalt);
            case 7:
                var _reliability = Asdu.DecodePrimitive<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromReliability(_reliability);
            case 8:
                var _state = Asdu.DecodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromState(_state);
            case 9:
                var _systemStatus = Asdu.DecodePrimitive<DeviceStatusCodec, global::Baclib.Bacnet.Types.Application.DeviceStatus>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromSystemStatus(_systemStatus);
            case 10:
                var _units = Asdu.DecodePrimitive<EngineeringUnitsCodec, global::Baclib.Bacnet.Types.Application.EngineeringUnits>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromUnits(_units);
            case 11:
                var _unsignedValue = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromUnsignedValue(_unsignedValue);
            case 12:
                var _lifeSafetyMode = Asdu.DecodePrimitive<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyMode(_lifeSafetyMode);
            case 13:
                var _lifeSafetyState = Asdu.DecodePrimitive<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyState(_lifeSafetyState);
            case 14:
                var _restartReason = Asdu.DecodePrimitive<RestartReasonCodec, global::Baclib.Bacnet.Types.Application.RestartReason>(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromRestartReason(_restartReason);
            case 15:
                var _doorAlarmState = Asdu.DecodePrimitive<DoorAlarmStateCodec, global::Baclib.Bacnet.Types.Application.DoorAlarmState>(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorAlarmState(_doorAlarmState);
            case 16:
                var _action = Asdu.DecodePrimitive<ActionCodec, global::Baclib.Bacnet.Types.Application.Action>(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAction(_action);
            case 17:
                var _doorSecuredStatus = Asdu.DecodePrimitive<DoorSecuredStatusCodec, global::Baclib.Bacnet.Types.Application.DoorSecuredStatus>(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorSecuredStatus(_doorSecuredStatus);
            case 18:
                var _doorStatus = Asdu.DecodePrimitive<DoorStatusCodec, global::Baclib.Bacnet.Types.Application.DoorStatus>(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorStatus(_doorStatus);
            case 19:
                var _doorValue = Asdu.DecodePrimitive<DoorValueCodec, global::Baclib.Bacnet.Types.Application.DoorValue>(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorValue(_doorValue);
            case 20:
                var _fileAccessMethod = Asdu.DecodePrimitive<FileAccessMethodCodec, global::Baclib.Bacnet.Types.Application.FileAccessMethod>(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromFileAccessMethod(_fileAccessMethod);
            case 21:
                var _lockStatus = Asdu.DecodePrimitive<LockStatusCodec, global::Baclib.Bacnet.Types.Application.LockStatus>(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLockStatus(_lockStatus);
            case 22:
                var _lifeSafetyOperation = Asdu.DecodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyOperation(_lifeSafetyOperation);
            case 23:
                var _maintenance = Asdu.DecodePrimitive<MaintenanceCodec, global::Baclib.Bacnet.Types.Application.Maintenance>(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromMaintenance(_maintenance);
            case 24:
                var _nodeType = Asdu.DecodePrimitive<NodeTypeCodec, global::Baclib.Bacnet.Types.Application.NodeType>(ref reader, 24);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNodeType(_nodeType);
            case 25:
                var _notifyType = Asdu.DecodePrimitive<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(ref reader, 25);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNotifyType(_notifyType);
            case 27:
                var _shedState = Asdu.DecodePrimitive<ShedStateCodec, global::Baclib.Bacnet.Types.Application.ShedState>(ref reader, 27);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromShedState(_shedState);
            case 28:
                var _silencedState = Asdu.DecodePrimitive<SilencedStateCodec, global::Baclib.Bacnet.Types.Application.SilencedState>(ref reader, 28);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromSilencedState(_silencedState);
            case 30:
                var _accessEvent = Asdu.DecodePrimitive<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref reader, 30);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessEvent(_accessEvent);
            case 31:
                var _zoneOccupancyState = Asdu.DecodePrimitive<AccessZoneOccupancyStateCodec, global::Baclib.Bacnet.Types.Application.AccessZoneOccupancyState>(ref reader, 31);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromZoneOccupancyState(_zoneOccupancyState);
            case 32:
                var _accessCredentialDisableReason = Asdu.DecodePrimitive<AccessCredentialDisableReasonCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisableReason>(ref reader, 32);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessCredentialDisableReason(_accessCredentialDisableReason);
            case 33:
                var _accessCredentialDisable = Asdu.DecodePrimitive<AccessCredentialDisableCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisable>(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessCredentialDisable(_accessCredentialDisable);
            case 34:
                var _authenticationStatus = Asdu.DecodePrimitive<AuthenticationStatusCodec, global::Baclib.Bacnet.Types.Application.AuthenticationStatus>(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuthenticationStatus(_authenticationStatus);
            case 36:
                var _backupState = Asdu.DecodePrimitive<BackupStateCodec, global::Baclib.Bacnet.Types.Application.BackupState>(ref reader, 36);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBackupState(_backupState);
            case 37:
                var _writeStatus = Asdu.DecodePrimitive<WriteStatusCodec, global::Baclib.Bacnet.Types.Application.WriteStatus>(ref reader, 37);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromWriteStatus(_writeStatus);
            case 38:
                var _lightingInProgress = Asdu.DecodePrimitive<LightingInProgressCodec, global::Baclib.Bacnet.Types.Application.LightingInProgress>(ref reader, 38);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingInProgress(_lightingInProgress);
            case 39:
                var _lightingOperation = Asdu.DecodePrimitive<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(ref reader, 39);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingOperation(_lightingOperation);
            case 40:
                var _lightingTransition = Asdu.DecodePrimitive<LightingTransitionCodec, global::Baclib.Bacnet.Types.Application.LightingTransition>(ref reader, 40);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingTransition(_lightingTransition);
            case 41:
                var _integerValue = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 41);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromIntegerValue(_integerValue);
            case 42:
                var _binaryLightingValue = Asdu.DecodePrimitive<BinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.BinaryLightingPv>(ref reader, 42);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBinaryLightingValue(_binaryLightingValue);
            case 43:
                var _timerState = Asdu.DecodePrimitive<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref reader, 43);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromTimerState(_timerState);
            case 44:
                var _timerTransition = Asdu.DecodePrimitive<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(ref reader, 44);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromTimerTransition(_timerTransition);
            case 45:
                var _bacnetIpMode = Asdu.DecodePrimitive<IpModeCodec, global::Baclib.Bacnet.Types.Application.IpMode>(ref reader, 45);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBacnetIpMode(_bacnetIpMode);
            case 46:
                var _networkPortCommand = Asdu.DecodePrimitive<NetworkPortCommandCodec, global::Baclib.Bacnet.Types.Application.NetworkPortCommand>(ref reader, 46);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkPortCommand(_networkPortCommand);
            case 47:
                var _networkType = Asdu.DecodePrimitive<NetworkTypeCodec, global::Baclib.Bacnet.Types.Application.NetworkType>(ref reader, 47);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkType(_networkType);
            case 48:
                var _networkNumberQuality = Asdu.DecodePrimitive<NetworkNumberQualityCodec, global::Baclib.Bacnet.Types.Application.NetworkNumberQuality>(ref reader, 48);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkNumberQuality(_networkNumberQuality);
            case 49:
                var _escalatorOperationDirection = Asdu.DecodePrimitive<EscalatorOperationDirectionCodec, global::Baclib.Bacnet.Types.Application.EscalatorOperationDirection>(ref reader, 49);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorOperationDirection(_escalatorOperationDirection);
            case 50:
                var _escalatorFault = Asdu.DecodePrimitive<EscalatorFaultCodec, global::Baclib.Bacnet.Types.Application.EscalatorFault>(ref reader, 50);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorFault(_escalatorFault);
            case 51:
                var _escalatorMode = Asdu.DecodePrimitive<EscalatorModeCodec, global::Baclib.Bacnet.Types.Application.EscalatorMode>(ref reader, 51);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorMode(_escalatorMode);
            case 52:
                var _liftCarDirection = Asdu.DecodePrimitive<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(ref reader, 52);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDirection(_liftCarDirection);
            case 53:
                var _liftCarDoorCommand = Asdu.DecodePrimitive<LiftCarDoorCommandCodec, global::Baclib.Bacnet.Types.Application.LiftCarDoorCommand>(ref reader, 53);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDoorCommand(_liftCarDoorCommand);
            case 54:
                var _liftCarDriveStatus = Asdu.DecodePrimitive<LiftCarDriveStatusCodec, global::Baclib.Bacnet.Types.Application.LiftCarDriveStatus>(ref reader, 54);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDriveStatus(_liftCarDriveStatus);
            case 55:
                var _liftCarMode = Asdu.DecodePrimitive<LiftCarModeCodec, global::Baclib.Bacnet.Types.Application.LiftCarMode>(ref reader, 55);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarMode(_liftCarMode);
            case 56:
                var _liftGroupMode = Asdu.DecodePrimitive<LiftGroupModeCodec, global::Baclib.Bacnet.Types.Application.LiftGroupMode>(ref reader, 56);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftGroupMode(_liftGroupMode);
            case 57:
                var _liftFault = Asdu.DecodePrimitive<LiftFaultCodec, global::Baclib.Bacnet.Types.Application.LiftFault>(ref reader, 57);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftFault(_liftFault);
            case 58:
                var _protocolLevel = Asdu.DecodePrimitive<ProtocolLevelCodec, global::Baclib.Bacnet.Types.Application.ProtocolLevel>(ref reader, 58);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProtocolLevel(_protocolLevel);
            case 59:
                var _auditLevel = Asdu.DecodePrimitive<AuditLevelCodec, global::Baclib.Bacnet.Types.Application.AuditLevel>(ref reader, 59);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuditLevel(_auditLevel);
            case 60:
                var _auditOperation = Asdu.DecodePrimitive<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(ref reader, 60);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuditOperation(_auditOperation);
            case 63:
                var _extendedValue = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 63);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromExtendedValue(_extendedValue);
            case 258:
                var _scConnectionState = Asdu.DecodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref reader, 258);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromScConnectionState(_scConnectionState);
            case 259:
                var _scHubConnectorState = Asdu.DecodePrimitive<ScHubConnectorStateCodec, global::Baclib.Bacnet.Types.Application.ScHubConnectorState>(ref reader, 259);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromScHubConnectorState(_scHubConnectorState);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyStates Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.PropertyStates value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BooleanValue:
                Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 0, value.BooleanValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryValue:
                Asdu.EncodePrimitive<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(ref writer, 1, value.BinaryValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EventType:
                Asdu.EncodePrimitive<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref writer, 2, value.EventType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Polarity:
                Asdu.EncodePrimitive<PolarityCodec, global::Baclib.Bacnet.Types.Application.Polarity>(ref writer, 3, value.Polarity);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramChange:
                Asdu.EncodePrimitive<ProgramRequestCodec, global::Baclib.Bacnet.Types.Application.ProgramRequest>(ref writer, 4, value.ProgramChange);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramState:
                Asdu.EncodePrimitive<ProgramStateCodec, global::Baclib.Bacnet.Types.Application.ProgramState>(ref writer, 5, value.ProgramState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ReasonForHalt:
                Asdu.EncodePrimitive<ProgramErrorCodec, global::Baclib.Bacnet.Types.Application.ProgramError>(ref writer, 6, value.ReasonForHalt);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Reliability:
                Asdu.EncodePrimitive<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(ref writer, 7, value.Reliability);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.State:
                Asdu.EncodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref writer, 8, value.State);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SystemStatus:
                Asdu.EncodePrimitive<DeviceStatusCodec, global::Baclib.Bacnet.Types.Application.DeviceStatus>(ref writer, 9, value.SystemStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Units:
                Asdu.EncodePrimitive<EngineeringUnitsCodec, global::Baclib.Bacnet.Types.Application.EngineeringUnits>(ref writer, 10, value.Units);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.UnsignedValue:
                Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 11, value.UnsignedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyMode:
                Asdu.EncodePrimitive<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(ref writer, 12, value.LifeSafetyMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyState:
                Asdu.EncodePrimitive<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref writer, 13, value.LifeSafetyState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.RestartReason:
                Asdu.EncodePrimitive<RestartReasonCodec, global::Baclib.Bacnet.Types.Application.RestartReason>(ref writer, 14, value.RestartReason);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorAlarmState:
                Asdu.EncodePrimitive<DoorAlarmStateCodec, global::Baclib.Bacnet.Types.Application.DoorAlarmState>(ref writer, 15, value.DoorAlarmState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Action:
                Asdu.EncodePrimitive<ActionCodec, global::Baclib.Bacnet.Types.Application.Action>(ref writer, 16, value.Action);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorSecuredStatus:
                Asdu.EncodePrimitive<DoorSecuredStatusCodec, global::Baclib.Bacnet.Types.Application.DoorSecuredStatus>(ref writer, 17, value.DoorSecuredStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorStatus:
                Asdu.EncodePrimitive<DoorStatusCodec, global::Baclib.Bacnet.Types.Application.DoorStatus>(ref writer, 18, value.DoorStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorValue:
                Asdu.EncodePrimitive<DoorValueCodec, global::Baclib.Bacnet.Types.Application.DoorValue>(ref writer, 19, value.DoorValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.FileAccessMethod:
                Asdu.EncodePrimitive<FileAccessMethodCodec, global::Baclib.Bacnet.Types.Application.FileAccessMethod>(ref writer, 20, value.FileAccessMethod);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LockStatus:
                Asdu.EncodePrimitive<LockStatusCodec, global::Baclib.Bacnet.Types.Application.LockStatus>(ref writer, 21, value.LockStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyOperation:
                Asdu.EncodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref writer, 22, value.LifeSafetyOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Maintenance:
                Asdu.EncodePrimitive<MaintenanceCodec, global::Baclib.Bacnet.Types.Application.Maintenance>(ref writer, 23, value.Maintenance);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NodeType:
                Asdu.EncodePrimitive<NodeTypeCodec, global::Baclib.Bacnet.Types.Application.NodeType>(ref writer, 24, value.NodeType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NotifyType:
                Asdu.EncodePrimitive<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(ref writer, 25, value.NotifyType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ShedState:
                Asdu.EncodePrimitive<ShedStateCodec, global::Baclib.Bacnet.Types.Application.ShedState>(ref writer, 27, value.ShedState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SilencedState:
                Asdu.EncodePrimitive<SilencedStateCodec, global::Baclib.Bacnet.Types.Application.SilencedState>(ref writer, 28, value.SilencedState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessEvent:
                Asdu.EncodePrimitive<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref writer, 30, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ZoneOccupancyState:
                Asdu.EncodePrimitive<AccessZoneOccupancyStateCodec, global::Baclib.Bacnet.Types.Application.AccessZoneOccupancyState>(ref writer, 31, value.ZoneOccupancyState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisableReason:
                Asdu.EncodePrimitive<AccessCredentialDisableReasonCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisableReason>(ref writer, 32, value.AccessCredentialDisableReason);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisable:
                Asdu.EncodePrimitive<AccessCredentialDisableCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisable>(ref writer, 33, value.AccessCredentialDisable);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuthenticationStatus:
                Asdu.EncodePrimitive<AuthenticationStatusCodec, global::Baclib.Bacnet.Types.Application.AuthenticationStatus>(ref writer, 34, value.AuthenticationStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BackupState:
                Asdu.EncodePrimitive<BackupStateCodec, global::Baclib.Bacnet.Types.Application.BackupState>(ref writer, 36, value.BackupState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.WriteStatus:
                Asdu.EncodePrimitive<WriteStatusCodec, global::Baclib.Bacnet.Types.Application.WriteStatus>(ref writer, 37, value.WriteStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingInProgress:
                Asdu.EncodePrimitive<LightingInProgressCodec, global::Baclib.Bacnet.Types.Application.LightingInProgress>(ref writer, 38, value.LightingInProgress);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingOperation:
                Asdu.EncodePrimitive<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(ref writer, 39, value.LightingOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingTransition:
                Asdu.EncodePrimitive<LightingTransitionCodec, global::Baclib.Bacnet.Types.Application.LightingTransition>(ref writer, 40, value.LightingTransition);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.IntegerValue:
                Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 41, value.IntegerValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryLightingValue:
                Asdu.EncodePrimitive<BinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.BinaryLightingPv>(ref writer, 42, value.BinaryLightingValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerState:
                Asdu.EncodePrimitive<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref writer, 43, value.TimerState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerTransition:
                Asdu.EncodePrimitive<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(ref writer, 44, value.TimerTransition);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BacnetIpMode:
                Asdu.EncodePrimitive<IpModeCodec, global::Baclib.Bacnet.Types.Application.IpMode>(ref writer, 45, value.BacnetIpMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkPortCommand:
                Asdu.EncodePrimitive<NetworkPortCommandCodec, global::Baclib.Bacnet.Types.Application.NetworkPortCommand>(ref writer, 46, value.NetworkPortCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkType:
                Asdu.EncodePrimitive<NetworkTypeCodec, global::Baclib.Bacnet.Types.Application.NetworkType>(ref writer, 47, value.NetworkType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkNumberQuality:
                Asdu.EncodePrimitive<NetworkNumberQualityCodec, global::Baclib.Bacnet.Types.Application.NetworkNumberQuality>(ref writer, 48, value.NetworkNumberQuality);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorOperationDirection:
                Asdu.EncodePrimitive<EscalatorOperationDirectionCodec, global::Baclib.Bacnet.Types.Application.EscalatorOperationDirection>(ref writer, 49, value.EscalatorOperationDirection);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorFault:
                Asdu.EncodePrimitive<EscalatorFaultCodec, global::Baclib.Bacnet.Types.Application.EscalatorFault>(ref writer, 50, value.EscalatorFault);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorMode:
                Asdu.EncodePrimitive<EscalatorModeCodec, global::Baclib.Bacnet.Types.Application.EscalatorMode>(ref writer, 51, value.EscalatorMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDirection:
                Asdu.EncodePrimitive<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(ref writer, 52, value.LiftCarDirection);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDoorCommand:
                Asdu.EncodePrimitive<LiftCarDoorCommandCodec, global::Baclib.Bacnet.Types.Application.LiftCarDoorCommand>(ref writer, 53, value.LiftCarDoorCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDriveStatus:
                Asdu.EncodePrimitive<LiftCarDriveStatusCodec, global::Baclib.Bacnet.Types.Application.LiftCarDriveStatus>(ref writer, 54, value.LiftCarDriveStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarMode:
                Asdu.EncodePrimitive<LiftCarModeCodec, global::Baclib.Bacnet.Types.Application.LiftCarMode>(ref writer, 55, value.LiftCarMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftGroupMode:
                Asdu.EncodePrimitive<LiftGroupModeCodec, global::Baclib.Bacnet.Types.Application.LiftGroupMode>(ref writer, 56, value.LiftGroupMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftFault:
                Asdu.EncodePrimitive<LiftFaultCodec, global::Baclib.Bacnet.Types.Application.LiftFault>(ref writer, 57, value.LiftFault);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProtocolLevel:
                Asdu.EncodePrimitive<ProtocolLevelCodec, global::Baclib.Bacnet.Types.Application.ProtocolLevel>(ref writer, 58, value.ProtocolLevel);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditLevel:
                Asdu.EncodePrimitive<AuditLevelCodec, global::Baclib.Bacnet.Types.Application.AuditLevel>(ref writer, 59, value.AuditLevel);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditOperation:
                Asdu.EncodePrimitive<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(ref writer, 60, value.AuditOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ExtendedValue:
                Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 63, value.ExtendedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ScConnectionState:
                Asdu.EncodePrimitive<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(ref writer, 258, value.ScConnectionState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ScHubConnectorState:
                Asdu.EncodePrimitive<ScHubConnectorStateCodec, global::Baclib.Bacnet.Types.Application.ScHubConnectorState>(ref writer, 259, value.ScHubConnectorState);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.PropertyStates value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyStates value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BooleanValue:
                return Asdu.GetPrimitiveLength<BooleanCodec, bool>(0, value.BooleanValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryValue:
                return Asdu.GetPrimitiveLength<BinaryPvCodec, global::Baclib.Bacnet.Types.Application.BinaryPv>(1, value.BinaryValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EventType:
                return Asdu.GetPrimitiveLength<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(2, value.EventType);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Polarity:
                return Asdu.GetPrimitiveLength<PolarityCodec, global::Baclib.Bacnet.Types.Application.Polarity>(3, value.Polarity);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramChange:
                return Asdu.GetPrimitiveLength<ProgramRequestCodec, global::Baclib.Bacnet.Types.Application.ProgramRequest>(4, value.ProgramChange);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramState:
                return Asdu.GetPrimitiveLength<ProgramStateCodec, global::Baclib.Bacnet.Types.Application.ProgramState>(5, value.ProgramState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ReasonForHalt:
                return Asdu.GetPrimitiveLength<ProgramErrorCodec, global::Baclib.Bacnet.Types.Application.ProgramError>(6, value.ReasonForHalt);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Reliability:
                return Asdu.GetPrimitiveLength<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(7, value.Reliability);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.State:
                return Asdu.GetPrimitiveLength<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(8, value.State);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SystemStatus:
                return Asdu.GetPrimitiveLength<DeviceStatusCodec, global::Baclib.Bacnet.Types.Application.DeviceStatus>(9, value.SystemStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Units:
                return Asdu.GetPrimitiveLength<EngineeringUnitsCodec, global::Baclib.Bacnet.Types.Application.EngineeringUnits>(10, value.Units);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.UnsignedValue:
                return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(11, value.UnsignedValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyMode:
                return Asdu.GetPrimitiveLength<LifeSafetyModeCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyMode>(12, value.LifeSafetyMode);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyState:
                return Asdu.GetPrimitiveLength<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(13, value.LifeSafetyState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.RestartReason:
                return Asdu.GetPrimitiveLength<RestartReasonCodec, global::Baclib.Bacnet.Types.Application.RestartReason>(14, value.RestartReason);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorAlarmState:
                return Asdu.GetPrimitiveLength<DoorAlarmStateCodec, global::Baclib.Bacnet.Types.Application.DoorAlarmState>(15, value.DoorAlarmState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Action:
                return Asdu.GetPrimitiveLength<ActionCodec, global::Baclib.Bacnet.Types.Application.Action>(16, value.Action);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorSecuredStatus:
                return Asdu.GetPrimitiveLength<DoorSecuredStatusCodec, global::Baclib.Bacnet.Types.Application.DoorSecuredStatus>(17, value.DoorSecuredStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorStatus:
                return Asdu.GetPrimitiveLength<DoorStatusCodec, global::Baclib.Bacnet.Types.Application.DoorStatus>(18, value.DoorStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorValue:
                return Asdu.GetPrimitiveLength<DoorValueCodec, global::Baclib.Bacnet.Types.Application.DoorValue>(19, value.DoorValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.FileAccessMethod:
                return Asdu.GetPrimitiveLength<FileAccessMethodCodec, global::Baclib.Bacnet.Types.Application.FileAccessMethod>(20, value.FileAccessMethod);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LockStatus:
                return Asdu.GetPrimitiveLength<LockStatusCodec, global::Baclib.Bacnet.Types.Application.LockStatus>(21, value.LockStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyOperation:
                return Asdu.GetPrimitiveLength<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(22, value.LifeSafetyOperation);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Maintenance:
                return Asdu.GetPrimitiveLength<MaintenanceCodec, global::Baclib.Bacnet.Types.Application.Maintenance>(23, value.Maintenance);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NodeType:
                return Asdu.GetPrimitiveLength<NodeTypeCodec, global::Baclib.Bacnet.Types.Application.NodeType>(24, value.NodeType);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NotifyType:
                return Asdu.GetPrimitiveLength<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(25, value.NotifyType);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ShedState:
                return Asdu.GetPrimitiveLength<ShedStateCodec, global::Baclib.Bacnet.Types.Application.ShedState>(27, value.ShedState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SilencedState:
                return Asdu.GetPrimitiveLength<SilencedStateCodec, global::Baclib.Bacnet.Types.Application.SilencedState>(28, value.SilencedState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessEvent:
                return Asdu.GetPrimitiveLength<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(30, value.AccessEvent);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ZoneOccupancyState:
                return Asdu.GetPrimitiveLength<AccessZoneOccupancyStateCodec, global::Baclib.Bacnet.Types.Application.AccessZoneOccupancyState>(31, value.ZoneOccupancyState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisableReason:
                return Asdu.GetPrimitiveLength<AccessCredentialDisableReasonCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisableReason>(32, value.AccessCredentialDisableReason);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisable:
                return Asdu.GetPrimitiveLength<AccessCredentialDisableCodec, global::Baclib.Bacnet.Types.Application.AccessCredentialDisable>(33, value.AccessCredentialDisable);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuthenticationStatus:
                return Asdu.GetPrimitiveLength<AuthenticationStatusCodec, global::Baclib.Bacnet.Types.Application.AuthenticationStatus>(34, value.AuthenticationStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BackupState:
                return Asdu.GetPrimitiveLength<BackupStateCodec, global::Baclib.Bacnet.Types.Application.BackupState>(36, value.BackupState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.WriteStatus:
                return Asdu.GetPrimitiveLength<WriteStatusCodec, global::Baclib.Bacnet.Types.Application.WriteStatus>(37, value.WriteStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingInProgress:
                return Asdu.GetPrimitiveLength<LightingInProgressCodec, global::Baclib.Bacnet.Types.Application.LightingInProgress>(38, value.LightingInProgress);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingOperation:
                return Asdu.GetPrimitiveLength<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(39, value.LightingOperation);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingTransition:
                return Asdu.GetPrimitiveLength<LightingTransitionCodec, global::Baclib.Bacnet.Types.Application.LightingTransition>(40, value.LightingTransition);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.IntegerValue:
                return Asdu.GetPrimitiveLength<IntegerCodec, int>(41, value.IntegerValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryLightingValue:
                return Asdu.GetPrimitiveLength<BinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.BinaryLightingPv>(42, value.BinaryLightingValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerState:
                return Asdu.GetPrimitiveLength<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(43, value.TimerState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerTransition:
                return Asdu.GetPrimitiveLength<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(44, value.TimerTransition);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BacnetIpMode:
                return Asdu.GetPrimitiveLength<IpModeCodec, global::Baclib.Bacnet.Types.Application.IpMode>(45, value.BacnetIpMode);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkPortCommand:
                return Asdu.GetPrimitiveLength<NetworkPortCommandCodec, global::Baclib.Bacnet.Types.Application.NetworkPortCommand>(46, value.NetworkPortCommand);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkType:
                return Asdu.GetPrimitiveLength<NetworkTypeCodec, global::Baclib.Bacnet.Types.Application.NetworkType>(47, value.NetworkType);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkNumberQuality:
                return Asdu.GetPrimitiveLength<NetworkNumberQualityCodec, global::Baclib.Bacnet.Types.Application.NetworkNumberQuality>(48, value.NetworkNumberQuality);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorOperationDirection:
                return Asdu.GetPrimitiveLength<EscalatorOperationDirectionCodec, global::Baclib.Bacnet.Types.Application.EscalatorOperationDirection>(49, value.EscalatorOperationDirection);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorFault:
                return Asdu.GetPrimitiveLength<EscalatorFaultCodec, global::Baclib.Bacnet.Types.Application.EscalatorFault>(50, value.EscalatorFault);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorMode:
                return Asdu.GetPrimitiveLength<EscalatorModeCodec, global::Baclib.Bacnet.Types.Application.EscalatorMode>(51, value.EscalatorMode);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDirection:
                return Asdu.GetPrimitiveLength<LiftCarDirectionCodec, global::Baclib.Bacnet.Types.Application.LiftCarDirection>(52, value.LiftCarDirection);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDoorCommand:
                return Asdu.GetPrimitiveLength<LiftCarDoorCommandCodec, global::Baclib.Bacnet.Types.Application.LiftCarDoorCommand>(53, value.LiftCarDoorCommand);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDriveStatus:
                return Asdu.GetPrimitiveLength<LiftCarDriveStatusCodec, global::Baclib.Bacnet.Types.Application.LiftCarDriveStatus>(54, value.LiftCarDriveStatus);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarMode:
                return Asdu.GetPrimitiveLength<LiftCarModeCodec, global::Baclib.Bacnet.Types.Application.LiftCarMode>(55, value.LiftCarMode);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftGroupMode:
                return Asdu.GetPrimitiveLength<LiftGroupModeCodec, global::Baclib.Bacnet.Types.Application.LiftGroupMode>(56, value.LiftGroupMode);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftFault:
                return Asdu.GetPrimitiveLength<LiftFaultCodec, global::Baclib.Bacnet.Types.Application.LiftFault>(57, value.LiftFault);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProtocolLevel:
                return Asdu.GetPrimitiveLength<ProtocolLevelCodec, global::Baclib.Bacnet.Types.Application.ProtocolLevel>(58, value.ProtocolLevel);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditLevel:
                return Asdu.GetPrimitiveLength<AuditLevelCodec, global::Baclib.Bacnet.Types.Application.AuditLevel>(59, value.AuditLevel);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditOperation:
                return Asdu.GetPrimitiveLength<AuditOperationCodec, global::Baclib.Bacnet.Types.Application.AuditOperation>(60, value.AuditOperation);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ExtendedValue:
                return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(63, value.ExtendedValue);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ScConnectionState:
                return Asdu.GetPrimitiveLength<ScConnectionStateCodec, global::Baclib.Bacnet.Types.Application.ScConnectionState>(258, value.ScConnectionState);
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ScHubConnectorState:
                return Asdu.GetPrimitiveLength<ScHubConnectorStateCodec, global::Baclib.Bacnet.Types.Application.ScHubConnectorState>(259, value.ScHubConnectorState);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyStates value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}