// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultStatusFlagsCodec :
    IAsduElementCodec<T::FaultParameter.TFaultStatusFlags>,
    IAsduConstructedCodec<T::FaultParameter.TFaultStatusFlags>
{
    public static T::FaultParameter.TFaultStatusFlags Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultStatusFlags
        {
            StatusFlagsReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 0)
        };
    }

    public static T::FaultParameter.TFaultStatusFlags Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultStatusFlagsCodec, T::FaultParameter.TFaultStatusFlags>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultStatusFlags value)
    {
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 0, value.StatusFlagsReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultStatusFlags value)
        => AsduConstructed.Encode<FaultParameterTFaultStatusFlagsCodec, T::FaultParameter.TFaultStatusFlags>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultStatusFlags value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(0, value.StatusFlagsReference);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultStatusFlags value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultStatusFlagsCodec, T::FaultParameter.TFaultStatusFlags>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
