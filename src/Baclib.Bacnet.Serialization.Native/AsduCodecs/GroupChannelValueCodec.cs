// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GroupChannelValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GroupChannelValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GroupChannelValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.GroupChannelValue Decode(ref NativeReader reader)
    {
        var _channel = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _value = Asdu.DecodeConstructed<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(ref reader, 1);
        var _overridingPriority = Asdu.DecodeOptional<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.GroupChannelValue
        {
            Channel = _channel,
            Value = _value,
            OverridingPriority = _overridingPriority
        };
    }

    public static global::Baclib.Bacnet.Types.Application.GroupChannelValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.GroupChannelValue value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.Channel);
        Asdu.EncodeElement<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(ref writer, 1, value.Value);
        if (value.OverridingPriority.HasValue)
        {
            Asdu.EncodePrimitive<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref writer, 2, value.OverridingPriority.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GroupChannelValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GroupChannelValue value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.Channel) + Asdu.GetElementLength<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(1, value.Value) + (value.OverridingPriority.HasValue ? Asdu.GetPrimitiveLength<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(2, value.OverridingPriority.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GroupChannelValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
