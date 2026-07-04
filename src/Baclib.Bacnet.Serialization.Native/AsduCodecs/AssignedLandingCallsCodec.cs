// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AssignedLandingCallsCodec :
    IAsduElementCodec<T::AssignedLandingCalls>,
    IAsduConstructedCodec<T::AssignedLandingCalls>
{
    public static T::AssignedLandingCalls Decode(ref AsduReader reader)
    {
        return new T::AssignedLandingCalls
        {
            LandingCalls = AsduElement.DecodeSequenceOf<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(ref reader, 0)
        };
    }

    public static T::AssignedLandingCalls Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AssignedLandingCallsCodec, T::AssignedLandingCalls>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AssignedLandingCalls value)
    {
        AsduElement.EncodeSequenceOf<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(ref writer, 0, value.LandingCalls);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AssignedLandingCalls value)
        => AsduConstructed.Encode<AssignedLandingCallsCodec, T::AssignedLandingCalls>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AssignedLandingCalls value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(0, value.LandingCalls);
        return length;
    }

    public static int GetEncodedLength(in T::AssignedLandingCalls value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AssignedLandingCallsCodec, T::AssignedLandingCalls>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
