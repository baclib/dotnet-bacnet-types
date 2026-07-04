// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfStateCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfState>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfState>
{
    public static T::EventParameter.TChangeOfState Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfState
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            ListOfValues = AsduElement.DecodeSequenceOf<PropertyStatesCodec, T::PropertyStates>(ref reader, 1)
        };
    }

    public static T::EventParameter.TChangeOfState Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfStateCodec, T::EventParameter.TChangeOfState>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfState value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.EncodeSequenceOf<PropertyStatesCodec, T::PropertyStates>(ref writer, 1, value.ListOfValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfState value)
        => AsduConstructed.Encode<EventParameterTChangeOfStateCodec, T::EventParameter.TChangeOfState>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfState value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetSequenceOfEncodedLength<PropertyStatesCodec, T::PropertyStates>(1, value.ListOfValues);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfState value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfStateCodec, T::EventParameter.TChangeOfState>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
