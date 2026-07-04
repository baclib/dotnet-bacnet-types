// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ActionListCodec :
    IAsduElementCodec<T::ActionList>,
    IAsduConstructedCodec<T::ActionList>
{
    public static T::ActionList Decode(ref AsduReader reader)
    {
        return new T::ActionList
        {
            Action = AsduElement.DecodeSequenceOf<ActionCommandCodec, T::ActionCommand>(ref reader, 0)
        };
    }

    public static T::ActionList Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ActionListCodec, T::ActionList>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ActionList value)
    {
        AsduElement.EncodeSequenceOf<ActionCommandCodec, T::ActionCommand>(ref writer, 0, value.Action);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ActionList value)
        => AsduConstructed.Encode<ActionListCodec, T::ActionList>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ActionList value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<ActionCommandCodec, T::ActionCommand>(0, value.Action);
        return length;
    }

    public static int GetEncodedLength(in T::ActionList value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ActionListCodec, T::ActionList>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
