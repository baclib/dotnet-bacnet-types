// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyStatesCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.PropertyStates>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.PropertyStates>
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
            14 or
            15 or
            16 or
            17 or
            18 or
            19 or
            20 or
            21 or
            22 or
            23 or
            24 or
            25 or
            27 or
            28 or
            30 or
            31 or
            32 or
            33 or
            34 or
            36 or
            37 or
            38 or
            39 or
            40 or
            41 or
            42 or
            43 or
            44 or
            45 or
            46 or
            47 or
            48 or
            49 or
            50 or
            51 or
            52 or
            53 or
            54 or
            55 or
            56 or
            57 or
            58 or
            59 or
            60 or
            63 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyStates Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @booleanValue = BooleanCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBooleanValue(@booleanValue);
            case 1:
                var @binaryValue = BinaryPvCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBinaryValue(@binaryValue);
            case 2:
                var @eventType = EventTypeCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEventType(@eventType);
            case 3:
                var @polarity = PolarityCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromPolarity(@polarity);
            case 4:
                var @programChange = ProgramRequestCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProgramChange(@programChange);
            case 5:
                var @programState = ProgramStateCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProgramState(@programState);
            case 6:
                var @reasonForHalt = ProgramErrorCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromReasonForHalt(@reasonForHalt);
            case 7:
                var @reliability = ReliabilityCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromReliability(@reliability);
            case 8:
                var @state = EventStateCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromState(@state);
            case 9:
                var @systemStatus = DeviceStatusCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromSystemStatus(@systemStatus);
            case 10:
                var @units = EngineeringUnitsCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromUnits(@units);
            case 11:
                var @unsignedValue = UnsignedCodec.Decode(ref reader, 11);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromUnsignedValue(@unsignedValue);
            case 12:
                var @lifeSafetyMode = LifeSafetyModeCodec.Decode(ref reader, 12);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyMode(@lifeSafetyMode);
            case 13:
                var @lifeSafetyState = LifeSafetyStateCodec.Decode(ref reader, 13);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyState(@lifeSafetyState);
            case 14:
                var @restartReason = RestartReasonCodec.Decode(ref reader, 14);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromRestartReason(@restartReason);
            case 15:
                var @doorAlarmState = DoorAlarmStateCodec.Decode(ref reader, 15);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorAlarmState(@doorAlarmState);
            case 16:
                var @action = ActionCodec.Decode(ref reader, 16);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAction(@action);
            case 17:
                var @doorSecuredStatus = DoorSecuredStatusCodec.Decode(ref reader, 17);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorSecuredStatus(@doorSecuredStatus);
            case 18:
                var @doorStatus = DoorStatusCodec.Decode(ref reader, 18);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorStatus(@doorStatus);
            case 19:
                var @doorValue = DoorValueCodec.Decode(ref reader, 19);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromDoorValue(@doorValue);
            case 20:
                var @fileAccessMethod = FileAccessMethodCodec.Decode(ref reader, 20);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromFileAccessMethod(@fileAccessMethod);
            case 21:
                var @lockStatus = LockStatusCodec.Decode(ref reader, 21);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLockStatus(@lockStatus);
            case 22:
                var @lifeSafetyOperation = LifeSafetyOperationCodec.Decode(ref reader, 22);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLifeSafetyOperation(@lifeSafetyOperation);
            case 23:
                var @maintenance = MaintenanceCodec.Decode(ref reader, 23);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromMaintenance(@maintenance);
            case 24:
                var @nodeType = NodeTypeCodec.Decode(ref reader, 24);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNodeType(@nodeType);
            case 25:
                var @notifyType = NotifyTypeCodec.Decode(ref reader, 25);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNotifyType(@notifyType);
            case 27:
                var @shedState = ShedStateCodec.Decode(ref reader, 27);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromShedState(@shedState);
            case 28:
                var @silencedState = SilencedStateCodec.Decode(ref reader, 28);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromSilencedState(@silencedState);
            case 30:
                var @accessEvent = AccessEventCodec.Decode(ref reader, 30);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessEvent(@accessEvent);
            case 31:
                var @zoneOccupancyState = AccessZoneOccupancyStateCodec.Decode(ref reader, 31);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromZoneOccupancyState(@zoneOccupancyState);
            case 32:
                var @accessCredentialDisableReason = AccessCredentialDisableReasonCodec.Decode(ref reader, 32);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessCredentialDisableReason(@accessCredentialDisableReason);
            case 33:
                var @accessCredentialDisable = AccessCredentialDisableCodec.Decode(ref reader, 33);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAccessCredentialDisable(@accessCredentialDisable);
            case 34:
                var @authenticationStatus = AuthenticationStatusCodec.Decode(ref reader, 34);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuthenticationStatus(@authenticationStatus);
            case 36:
                var @backupState = BackupStateCodec.Decode(ref reader, 36);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBackupState(@backupState);
            case 37:
                var @writeStatus = WriteStatusCodec.Decode(ref reader, 37);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromWriteStatus(@writeStatus);
            case 38:
                var @lightingInProgress = LightingInProgressCodec.Decode(ref reader, 38);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingInProgress(@lightingInProgress);
            case 39:
                var @lightingOperation = LightingOperationCodec.Decode(ref reader, 39);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingOperation(@lightingOperation);
            case 40:
                var @lightingTransition = LightingTransitionCodec.Decode(ref reader, 40);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLightingTransition(@lightingTransition);
            case 41:
                var @integerValue = IntegerCodec.Decode(ref reader, 41);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromIntegerValue(@integerValue);
            case 42:
                var @binaryLightingValue = BinaryLightingPvCodec.Decode(ref reader, 42);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBinaryLightingValue(@binaryLightingValue);
            case 43:
                var @timerState = TimerStateCodec.Decode(ref reader, 43);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromTimerState(@timerState);
            case 44:
                var @timerTransition = TimerTransitionCodec.Decode(ref reader, 44);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromTimerTransition(@timerTransition);
            case 45:
                var @bacnetIpMode = IpModeCodec.Decode(ref reader, 45);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromBacnetIpMode(@bacnetIpMode);
            case 46:
                var @networkPortCommand = NetworkPortCommandCodec.Decode(ref reader, 46);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkPortCommand(@networkPortCommand);
            case 47:
                var @networkType = NetworkTypeCodec.Decode(ref reader, 47);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkType(@networkType);
            case 48:
                var @networkNumberQuality = NetworkNumberQualityCodec.Decode(ref reader, 48);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromNetworkNumberQuality(@networkNumberQuality);
            case 49:
                var @escalatorOperationDirection = EscalatorOperationDirectionCodec.Decode(ref reader, 49);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorOperationDirection(@escalatorOperationDirection);
            case 50:
                var @escalatorFault = EscalatorFaultCodec.Decode(ref reader, 50);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorFault(@escalatorFault);
            case 51:
                var @escalatorMode = EscalatorModeCodec.Decode(ref reader, 51);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromEscalatorMode(@escalatorMode);
            case 52:
                var @liftCarDirection = LiftCarDirectionCodec.Decode(ref reader, 52);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDirection(@liftCarDirection);
            case 53:
                var @liftCarDoorCommand = LiftCarDoorCommandCodec.Decode(ref reader, 53);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDoorCommand(@liftCarDoorCommand);
            case 54:
                var @liftCarDriveStatus = LiftCarDriveStatusCodec.Decode(ref reader, 54);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarDriveStatus(@liftCarDriveStatus);
            case 55:
                var @liftCarMode = LiftCarModeCodec.Decode(ref reader, 55);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftCarMode(@liftCarMode);
            case 56:
                var @liftGroupMode = LiftGroupModeCodec.Decode(ref reader, 56);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftGroupMode(@liftGroupMode);
            case 57:
                var @liftFault = LiftFaultCodec.Decode(ref reader, 57);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromLiftFault(@liftFault);
            case 58:
                var @protocolLevel = ProtocolLevelCodec.Decode(ref reader, 58);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromProtocolLevel(@protocolLevel);
            case 59:
                var @auditLevel = AuditLevelCodec.Decode(ref reader, 59);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuditLevel(@auditLevel);
            case 60:
                var @auditOperation = AuditOperationCodec.Decode(ref reader, 60);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromAuditOperation(@auditOperation);
            case 63:
                var @extendedValue = Unsigned32Codec.Decode(ref reader, 63);
                return global::Baclib.Bacnet.Types.Application.PropertyStates.FromExtendedValue(@extendedValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyStates Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.PropertyStates value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BooleanValue:
                BooleanCodec.Encode(ref writer, 0, value.BooleanValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryValue:
                BinaryPvCodec.Encode(ref writer, 1, value.BinaryValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EventType:
                EventTypeCodec.Encode(ref writer, 2, value.EventType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Polarity:
                PolarityCodec.Encode(ref writer, 3, value.Polarity);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramChange:
                ProgramRequestCodec.Encode(ref writer, 4, value.ProgramChange);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramState:
                ProgramStateCodec.Encode(ref writer, 5, value.ProgramState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ReasonForHalt:
                ProgramErrorCodec.Encode(ref writer, 6, value.ReasonForHalt);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Reliability:
                ReliabilityCodec.Encode(ref writer, 7, value.Reliability);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.State:
                EventStateCodec.Encode(ref writer, 8, value.State);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SystemStatus:
                DeviceStatusCodec.Encode(ref writer, 9, value.SystemStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Units:
                EngineeringUnitsCodec.Encode(ref writer, 10, value.Units);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.UnsignedValue:
                UnsignedCodec.Encode(ref writer, 11, value.UnsignedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyMode:
                LifeSafetyModeCodec.Encode(ref writer, 12, value.LifeSafetyMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyState:
                LifeSafetyStateCodec.Encode(ref writer, 13, value.LifeSafetyState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.RestartReason:
                RestartReasonCodec.Encode(ref writer, 14, value.RestartReason);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorAlarmState:
                DoorAlarmStateCodec.Encode(ref writer, 15, value.DoorAlarmState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Action:
                ActionCodec.Encode(ref writer, 16, value.Action);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorSecuredStatus:
                DoorSecuredStatusCodec.Encode(ref writer, 17, value.DoorSecuredStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorStatus:
                DoorStatusCodec.Encode(ref writer, 18, value.DoorStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorValue:
                DoorValueCodec.Encode(ref writer, 19, value.DoorValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.FileAccessMethod:
                FileAccessMethodCodec.Encode(ref writer, 20, value.FileAccessMethod);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LockStatus:
                LockStatusCodec.Encode(ref writer, 21, value.LockStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyOperation:
                LifeSafetyOperationCodec.Encode(ref writer, 22, value.LifeSafetyOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Maintenance:
                MaintenanceCodec.Encode(ref writer, 23, value.Maintenance);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NodeType:
                NodeTypeCodec.Encode(ref writer, 24, value.NodeType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NotifyType:
                NotifyTypeCodec.Encode(ref writer, 25, value.NotifyType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ShedState:
                ShedStateCodec.Encode(ref writer, 27, value.ShedState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SilencedState:
                SilencedStateCodec.Encode(ref writer, 28, value.SilencedState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessEvent:
                AccessEventCodec.Encode(ref writer, 30, value.AccessEvent);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ZoneOccupancyState:
                AccessZoneOccupancyStateCodec.Encode(ref writer, 31, value.ZoneOccupancyState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisableReason:
                AccessCredentialDisableReasonCodec.Encode(ref writer, 32, value.AccessCredentialDisableReason);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisable:
                AccessCredentialDisableCodec.Encode(ref writer, 33, value.AccessCredentialDisable);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuthenticationStatus:
                AuthenticationStatusCodec.Encode(ref writer, 34, value.AuthenticationStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BackupState:
                BackupStateCodec.Encode(ref writer, 36, value.BackupState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.WriteStatus:
                WriteStatusCodec.Encode(ref writer, 37, value.WriteStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingInProgress:
                LightingInProgressCodec.Encode(ref writer, 38, value.LightingInProgress);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingOperation:
                LightingOperationCodec.Encode(ref writer, 39, value.LightingOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingTransition:
                LightingTransitionCodec.Encode(ref writer, 40, value.LightingTransition);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.IntegerValue:
                IntegerCodec.Encode(ref writer, 41, value.IntegerValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryLightingValue:
                BinaryLightingPvCodec.Encode(ref writer, 42, value.BinaryLightingValue);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerState:
                TimerStateCodec.Encode(ref writer, 43, value.TimerState);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerTransition:
                TimerTransitionCodec.Encode(ref writer, 44, value.TimerTransition);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BacnetIpMode:
                IpModeCodec.Encode(ref writer, 45, value.BacnetIpMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkPortCommand:
                NetworkPortCommandCodec.Encode(ref writer, 46, value.NetworkPortCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkType:
                NetworkTypeCodec.Encode(ref writer, 47, value.NetworkType);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkNumberQuality:
                NetworkNumberQualityCodec.Encode(ref writer, 48, value.NetworkNumberQuality);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorOperationDirection:
                EscalatorOperationDirectionCodec.Encode(ref writer, 49, value.EscalatorOperationDirection);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorFault:
                EscalatorFaultCodec.Encode(ref writer, 50, value.EscalatorFault);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorMode:
                EscalatorModeCodec.Encode(ref writer, 51, value.EscalatorMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDirection:
                LiftCarDirectionCodec.Encode(ref writer, 52, value.LiftCarDirection);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDoorCommand:
                LiftCarDoorCommandCodec.Encode(ref writer, 53, value.LiftCarDoorCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDriveStatus:
                LiftCarDriveStatusCodec.Encode(ref writer, 54, value.LiftCarDriveStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarMode:
                LiftCarModeCodec.Encode(ref writer, 55, value.LiftCarMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftGroupMode:
                LiftGroupModeCodec.Encode(ref writer, 56, value.LiftGroupMode);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftFault:
                LiftFaultCodec.Encode(ref writer, 57, value.LiftFault);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProtocolLevel:
                ProtocolLevelCodec.Encode(ref writer, 58, value.ProtocolLevel);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditLevel:
                AuditLevelCodec.Encode(ref writer, 59, value.AuditLevel);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditOperation:
                AuditOperationCodec.Encode(ref writer, 60, value.AuditOperation);
                return;
            case global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ExtendedValue:
                Unsigned32Codec.Encode(ref writer, 63, value.ExtendedValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.PropertyStates value)
        => AsduConstructed.Encode<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.PropertyStates value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BooleanValue
                => BooleanCodec.GetEncodedLength(value.BooleanValue, 0),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryValue
                => BinaryPvCodec.GetEncodedLength(value.BinaryValue, 1),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EventType
                => EventTypeCodec.GetEncodedLength(value.EventType, 2),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Polarity
                => PolarityCodec.GetEncodedLength(value.Polarity, 3),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramChange
                => ProgramRequestCodec.GetEncodedLength(value.ProgramChange, 4),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProgramState
                => ProgramStateCodec.GetEncodedLength(value.ProgramState, 5),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ReasonForHalt
                => ProgramErrorCodec.GetEncodedLength(value.ReasonForHalt, 6),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Reliability
                => ReliabilityCodec.GetEncodedLength(value.Reliability, 7),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.State
                => EventStateCodec.GetEncodedLength(value.State, 8),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SystemStatus
                => DeviceStatusCodec.GetEncodedLength(value.SystemStatus, 9),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Units
                => EngineeringUnitsCodec.GetEncodedLength(value.Units, 10),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.UnsignedValue
                => UnsignedCodec.GetEncodedLength(value.UnsignedValue, 11),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyMode
                => LifeSafetyModeCodec.GetEncodedLength(value.LifeSafetyMode, 12),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyState
                => LifeSafetyStateCodec.GetEncodedLength(value.LifeSafetyState, 13),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.RestartReason
                => RestartReasonCodec.GetEncodedLength(value.RestartReason, 14),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorAlarmState
                => DoorAlarmStateCodec.GetEncodedLength(value.DoorAlarmState, 15),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Action
                => ActionCodec.GetEncodedLength(value.Action, 16),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorSecuredStatus
                => DoorSecuredStatusCodec.GetEncodedLength(value.DoorSecuredStatus, 17),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorStatus
                => DoorStatusCodec.GetEncodedLength(value.DoorStatus, 18),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.DoorValue
                => DoorValueCodec.GetEncodedLength(value.DoorValue, 19),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.FileAccessMethod
                => FileAccessMethodCodec.GetEncodedLength(value.FileAccessMethod, 20),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LockStatus
                => LockStatusCodec.GetEncodedLength(value.LockStatus, 21),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LifeSafetyOperation
                => LifeSafetyOperationCodec.GetEncodedLength(value.LifeSafetyOperation, 22),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.Maintenance
                => MaintenanceCodec.GetEncodedLength(value.Maintenance, 23),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NodeType
                => NodeTypeCodec.GetEncodedLength(value.NodeType, 24),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NotifyType
                => NotifyTypeCodec.GetEncodedLength(value.NotifyType, 25),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ShedState
                => ShedStateCodec.GetEncodedLength(value.ShedState, 27),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.SilencedState
                => SilencedStateCodec.GetEncodedLength(value.SilencedState, 28),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessEvent
                => AccessEventCodec.GetEncodedLength(value.AccessEvent, 30),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ZoneOccupancyState
                => AccessZoneOccupancyStateCodec.GetEncodedLength(value.ZoneOccupancyState, 31),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisableReason
                => AccessCredentialDisableReasonCodec.GetEncodedLength(value.AccessCredentialDisableReason, 32),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AccessCredentialDisable
                => AccessCredentialDisableCodec.GetEncodedLength(value.AccessCredentialDisable, 33),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuthenticationStatus
                => AuthenticationStatusCodec.GetEncodedLength(value.AuthenticationStatus, 34),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BackupState
                => BackupStateCodec.GetEncodedLength(value.BackupState, 36),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.WriteStatus
                => WriteStatusCodec.GetEncodedLength(value.WriteStatus, 37),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingInProgress
                => LightingInProgressCodec.GetEncodedLength(value.LightingInProgress, 38),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingOperation
                => LightingOperationCodec.GetEncodedLength(value.LightingOperation, 39),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LightingTransition
                => LightingTransitionCodec.GetEncodedLength(value.LightingTransition, 40),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.IntegerValue
                => IntegerCodec.GetEncodedLength(value.IntegerValue, 41),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BinaryLightingValue
                => BinaryLightingPvCodec.GetEncodedLength(value.BinaryLightingValue, 42),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerState
                => TimerStateCodec.GetEncodedLength(value.TimerState, 43),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.TimerTransition
                => TimerTransitionCodec.GetEncodedLength(value.TimerTransition, 44),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.BacnetIpMode
                => IpModeCodec.GetEncodedLength(value.BacnetIpMode, 45),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkPortCommand
                => NetworkPortCommandCodec.GetEncodedLength(value.NetworkPortCommand, 46),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkType
                => NetworkTypeCodec.GetEncodedLength(value.NetworkType, 47),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.NetworkNumberQuality
                => NetworkNumberQualityCodec.GetEncodedLength(value.NetworkNumberQuality, 48),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorOperationDirection
                => EscalatorOperationDirectionCodec.GetEncodedLength(value.EscalatorOperationDirection, 49),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorFault
                => EscalatorFaultCodec.GetEncodedLength(value.EscalatorFault, 50),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.EscalatorMode
                => EscalatorModeCodec.GetEncodedLength(value.EscalatorMode, 51),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDirection
                => LiftCarDirectionCodec.GetEncodedLength(value.LiftCarDirection, 52),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDoorCommand
                => LiftCarDoorCommandCodec.GetEncodedLength(value.LiftCarDoorCommand, 53),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarDriveStatus
                => LiftCarDriveStatusCodec.GetEncodedLength(value.LiftCarDriveStatus, 54),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftCarMode
                => LiftCarModeCodec.GetEncodedLength(value.LiftCarMode, 55),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftGroupMode
                => LiftGroupModeCodec.GetEncodedLength(value.LiftGroupMode, 56),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.LiftFault
                => LiftFaultCodec.GetEncodedLength(value.LiftFault, 57),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ProtocolLevel
                => ProtocolLevelCodec.GetEncodedLength(value.ProtocolLevel, 58),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditLevel
                => AuditLevelCodec.GetEncodedLength(value.AuditLevel, 59),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.AuditOperation
                => AuditOperationCodec.GetEncodedLength(value.AuditOperation, 60),
            global::Baclib.Bacnet.Types.Application.PropertyStates.Option.ExtendedValue
                => Unsigned32Codec.GetEncodedLength(value.ExtendedValue, 63),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.PropertyStates value, byte tagNumber)
        => AsduElement.GetEncodedLength<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(tagNumber, value);
}
