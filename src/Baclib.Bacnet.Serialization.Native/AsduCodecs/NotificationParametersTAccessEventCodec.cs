// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTAccessEventCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent Decode(ref NativeReader reader)
    {
        var _accessEvent = Asdu.DecodePrimitive<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _accessEventTag = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _accessEventTime = Asdu.DecodeConstructed<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 3);
        var _accessCredential = Asdu.DecodeConstructed<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref reader, 4);
        var _authenticationFactor = Asdu.DecodeOptionalElement<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent
        {
            AccessEvent = _accessEvent,
            StatusFlags = _statusFlags,
            AccessEventTag = _accessEventTag,
            AccessEventTime = _accessEventTime,
            AccessCredential = _accessCredential,
            AuthenticationFactor = _authenticationFactor
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent value)
    {
        Asdu.EncodePrimitive<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref writer, 0, value.AccessEvent);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.AccessEventTag);
        Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 3, value.AccessEventTime);
        Asdu.EncodeElement<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref writer, 4, value.AccessCredential);
        if (value.AuthenticationFactor.HasValue)
        {
            Asdu.EncodeElement<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(ref writer, 5, value.AuthenticationFactor.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent value)
    {
        return Asdu.GetPrimitiveLength<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(0, value.AccessEvent) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.AccessEventTag) + Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(3, value.AccessEventTime) + Asdu.GetElementLength<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(4, value.AccessCredential) + (value.AuthenticationFactor.HasValue ? Asdu.GetElementLength<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(5, value.AuthenticationFactor.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TAccessEvent value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
