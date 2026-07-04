// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultStateCodec :
    IAsduElementCodec<T::FaultParameter.TFaultState>,
    IAsduConstructedCodec<T::FaultParameter.TFaultState>
{
    public static T::FaultParameter.TFaultState Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultState
        {
            ListOfFaultValues = AsduElement.DecodeSequenceOf<PropertyStatesCodec, T::PropertyStates>(ref reader, 0)
        };
    }

    public static T::FaultParameter.TFaultState Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultStateCodec, T::FaultParameter.TFaultState>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultState value)
    {
        AsduElement.EncodeSequenceOf<PropertyStatesCodec, T::PropertyStates>(ref writer, 0, value.ListOfFaultValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultState value)
        => AsduConstructed.Encode<FaultParameterTFaultStateCodec, T::FaultParameter.TFaultState>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultState value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<PropertyStatesCodec, T::PropertyStates>(0, value.ListOfFaultValues);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultState value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultStateCodec, T::FaultParameter.TFaultState>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
