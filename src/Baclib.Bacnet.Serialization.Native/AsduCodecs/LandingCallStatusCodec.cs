// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LandingCallStatusCodec :
    IAsduElementCodec<T::LandingCallStatus>,
    IAsduConstructedCodec<T::LandingCallStatus>
{
    public static T::LandingCallStatus Decode(ref AsduReader reader)
    {
        return new T::LandingCallStatus
        {
            FloorNumber = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 0),
            Command = AsduElement.Decode<LandingCallStatusTCommandCodec, T::LandingCallStatus.TCommand>(ref reader),
            FloorText = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 3)
        };
    }

    public static T::LandingCallStatus Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LandingCallStatusCodec, T::LandingCallStatus>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LandingCallStatus value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 0, value.FloorNumber);
        AsduElement.Encode<LandingCallStatusTCommandCodec, T::LandingCallStatus.TCommand>(ref writer, value.Command);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 3, value.FloorText);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LandingCallStatus value)
        => AsduConstructed.Encode<LandingCallStatusCodec, T::LandingCallStatus>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LandingCallStatus value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(0, value.FloorNumber);
        length += AsduElement.GetEncodedLength<LandingCallStatusTCommandCodec, T::LandingCallStatus.TCommand>(value.Command);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(3, value.FloorText);
        return length;
    }

    public static int GetEncodedLength(in T::LandingCallStatus value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LandingCallStatusCodec, T::LandingCallStatus>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
