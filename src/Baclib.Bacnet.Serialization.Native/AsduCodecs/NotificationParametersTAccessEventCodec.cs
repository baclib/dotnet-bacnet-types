// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTAccessEventCodec :
    IAsduElementCodec<T::NotificationParameters.TAccessEvent>,
    IAsduConstructedCodec<T::NotificationParameters.TAccessEvent>
{
    public static T::NotificationParameters.TAccessEvent Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TAccessEvent
        {
            AccessEvent = AsduElement.Decode<AccessEventCodec, T::AccessEvent>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            AccessEventTag = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            AccessEventTime = AsduElement.Decode<TimeStampCodec, T::TimeStamp>(ref reader, 3),
            AccessCredential = AsduElement.Decode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref reader, 4),
            AuthenticationFactor = AsduElement.DecodeOptional<AuthenticationFactorCodec, T::AuthenticationFactor>(ref reader, 5)
        };
    }

    public static T::NotificationParameters.TAccessEvent Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTAccessEventCodec, T::NotificationParameters.TAccessEvent>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TAccessEvent value)
    {
        AsduElement.Encode<AccessEventCodec, T::AccessEvent>(ref writer, 0, value.AccessEvent);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.AccessEventTag);
        AsduElement.Encode<TimeStampCodec, T::TimeStamp>(ref writer, 3, value.AccessEventTime);
        AsduElement.Encode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref writer, 4, value.AccessCredential);
        AsduElement.EncodeOptional<AuthenticationFactorCodec, T::AuthenticationFactor>(ref writer, 5, value.AuthenticationFactor);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TAccessEvent value)
        => AsduConstructed.Encode<NotificationParametersTAccessEventCodec, T::NotificationParameters.TAccessEvent>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TAccessEvent value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AccessEventCodec, T::AccessEvent>(0, value.AccessEvent);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.AccessEventTag);
        length += AsduElement.GetEncodedLength<TimeStampCodec, T::TimeStamp>(3, value.AccessEventTime);
        length += AsduElement.GetEncodedLength<DeviceObjectReferenceCodec, T::DeviceObjectReference>(4, value.AccessCredential);
        length += AsduElement.GetOptionalEncodedLength<AuthenticationFactorCodec, T::AuthenticationFactor>(5, value.AuthenticationFactor);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TAccessEvent value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTAccessEventCodec, T::NotificationParameters.TAccessEvent>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
