// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultListedCodec :
    IAsduElementCodec<T::FaultParameter.TFaultListed>,
    IAsduConstructedCodec<T::FaultParameter.TFaultListed>
{
    public static T::FaultParameter.TFaultListed Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultListed
        {
            FaultListReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 0)
        };
    }

    public static T::FaultParameter.TFaultListed Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultListedCodec, T::FaultParameter.TFaultListed>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultListed value)
    {
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 0, value.FaultListReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultListed value)
        => AsduConstructed.Encode<FaultParameterTFaultListedCodec, T::FaultParameter.TFaultListed>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultListed value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(0, value.FaultListReference);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultListed value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultListedCodec, T::FaultParameter.TFaultListed>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
