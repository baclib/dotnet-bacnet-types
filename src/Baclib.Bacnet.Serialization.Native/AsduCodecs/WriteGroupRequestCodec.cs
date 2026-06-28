// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WriteGroupRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WriteGroupRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WriteGroupRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.WriteGroupRequest Decode(ref NativeReader reader)
    {
        var _groupNumber = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _writePriority = Asdu.DecodePrimitive<WriteGroupRequestTWritePriorityCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest.TWritePriority>(ref reader, 1);
        var _changeList = Asdu.DecodeSequenceOf<GroupChannelValueCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue>(ref reader, 2);
        var _inhibitDelay = Asdu.DecodeOptional<BooleanCodec, bool>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.WriteGroupRequest
        {
            GroupNumber = _groupNumber,
            WritePriority = _writePriority,
            ChangeList = _changeList,
            InhibitDelay = _inhibitDelay
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WriteGroupRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WriteGroupRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.GroupNumber);
        Asdu.EncodePrimitive<WriteGroupRequestTWritePriorityCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest.TWritePriority>(ref writer, 1, value.WritePriority);
        writer.WriteOpeningTag(2);
        foreach (var item in value.ChangeList)
        {
            Asdu.EncodeElement<GroupChannelValueCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
        if (value.InhibitDelay.HasValue)
        {
            Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 3, value.InhibitDelay.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WriteGroupRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WriteGroupRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.GroupNumber) + Asdu.GetPrimitiveLength<WriteGroupRequestTWritePriorityCodec, global::Baclib.Bacnet.Types.Application.WriteGroupRequest.TWritePriority>(1, value.WritePriority) + (AsduLength.FromTagNumber((byte)2) + (value.ChangeList.Items.Sum(static item => Asdu.GetElementLength<GroupChannelValueCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue>(2, item))) + AsduLength.FromTagNumber((byte)2)) + (value.InhibitDelay.HasValue ? Asdu.GetPrimitiveLength<BooleanCodec, bool>(3, value.InhibitDelay.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WriteGroupRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
