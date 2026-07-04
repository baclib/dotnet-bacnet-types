// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LiftCarCallListCodec :
    IAsduElementCodec<T::LiftCarCallList>,
    IAsduConstructedCodec<T::LiftCarCallList>
{
    public static T::LiftCarCallList Decode(ref AsduReader reader)
    {
        return new T::LiftCarCallList
        {
            FloorNumbers = AsduElement.DecodeSequenceOf<Unsigned8Codec, byte>(ref reader, 0)
        };
    }

    public static T::LiftCarCallList Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LiftCarCallListCodec, T::LiftCarCallList>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LiftCarCallList value)
    {
        AsduElement.EncodeSequenceOf<Unsigned8Codec, byte>(ref writer, 0, value.FloorNumbers);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LiftCarCallList value)
        => AsduConstructed.Encode<LiftCarCallListCodec, T::LiftCarCallList>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LiftCarCallList value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<Unsigned8Codec, byte>(0, value.FloorNumbers);
        return length;
    }

    public static int GetEncodedLength(in T::LiftCarCallList value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LiftCarCallListCodec, T::LiftCarCallList>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
