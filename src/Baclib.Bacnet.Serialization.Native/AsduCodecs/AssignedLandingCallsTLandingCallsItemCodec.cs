// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AssignedLandingCallsTLandingCallsItemCodec :
    IAsduElementCodec<T::AssignedLandingCalls.TLandingCallsItem>,
    IAsduConstructedCodec<T::AssignedLandingCalls.TLandingCallsItem>
{
    public static T::AssignedLandingCalls.TLandingCallsItem Decode(ref AsduReader reader)
    {
        return new T::AssignedLandingCalls.TLandingCallsItem
        {
            FloorNumber = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 0),
            Direction = AsduElement.Decode<LiftCarDirectionCodec, T::LiftCarDirection>(ref reader, 1)
        };
    }

    public static T::AssignedLandingCalls.TLandingCallsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AssignedLandingCalls.TLandingCallsItem value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 0, value.FloorNumber);
        AsduElement.Encode<LiftCarDirectionCodec, T::LiftCarDirection>(ref writer, 1, value.Direction);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AssignedLandingCalls.TLandingCallsItem value)
        => AsduConstructed.Encode<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AssignedLandingCalls.TLandingCallsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(0, value.FloorNumber);
        length += AsduElement.GetEncodedLength<LiftCarDirectionCodec, T::LiftCarDirection>(1, value.Direction);
        return length;
    }

    public static int GetEncodedLength(in T::AssignedLandingCalls.TLandingCallsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AssignedLandingCallsTLandingCallsItemCodec, T::AssignedLandingCalls.TLandingCallsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
