// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GroupChannelValueCodec :
    IAsduElementCodec<T::GroupChannelValue>,
    IAsduConstructedCodec<T::GroupChannelValue>
{
    public static T::GroupChannelValue Decode(ref AsduReader reader)
    {
        return new T::GroupChannelValue
        {
            Channel = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            Value = AsduElement.Decode<ChannelValueCodec, T::ChannelValue>(ref reader, 1),
            OverridingPriority = AsduElement.DecodeOptional<GroupChannelValueTOverridingPriorityCodec, T::GroupChannelValue.TOverridingPriority>(ref reader, 2)
        };
    }

    public static T::GroupChannelValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GroupChannelValueCodec, T::GroupChannelValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GroupChannelValue value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.Channel);
        AsduElement.Encode<ChannelValueCodec, T::ChannelValue>(ref writer, 1, value.Value);
        AsduElement.EncodeOptional<GroupChannelValueTOverridingPriorityCodec, T::GroupChannelValue.TOverridingPriority>(ref writer, 2, value.OverridingPriority);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GroupChannelValue value)
        => AsduConstructed.Encode<GroupChannelValueCodec, T::GroupChannelValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GroupChannelValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.Channel);
        length += AsduElement.GetEncodedLength<ChannelValueCodec, T::ChannelValue>(1, value.Value);
        length += AsduElement.GetOptionalEncodedLength<GroupChannelValueTOverridingPriorityCodec, T::GroupChannelValue.TOverridingPriority>(2, value.OverridingPriority);
        return length;
    }

    public static int GetEncodedLength(in T::GroupChannelValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GroupChannelValueCodec, T::GroupChannelValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
