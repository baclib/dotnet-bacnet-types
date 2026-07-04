// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WriteGroupRequestCodec :
    IAsduElementCodec<T::WriteGroupRequest>,
    IAsduConstructedCodec<T::WriteGroupRequest>
{
    public static T::WriteGroupRequest Decode(ref AsduReader reader)
    {
        return new T::WriteGroupRequest
        {
            GroupNumber = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            WritePriority = AsduElement.Decode<WriteGroupRequestTWritePriorityCodec, T::WriteGroupRequest.TWritePriority>(ref reader, 1),
            ChangeList = AsduElement.DecodeSequenceOf<GroupChannelValueCodec, T::GroupChannelValue>(ref reader, 2),
            InhibitDelay = AsduElement.DecodeOptional<BooleanCodec, bool>(ref reader, 3)
        };
    }

    public static T::WriteGroupRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WriteGroupRequestCodec, T::WriteGroupRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WriteGroupRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.GroupNumber);
        AsduElement.Encode<WriteGroupRequestTWritePriorityCodec, T::WriteGroupRequest.TWritePriority>(ref writer, 1, value.WritePriority);
        AsduElement.EncodeSequenceOf<GroupChannelValueCodec, T::GroupChannelValue>(ref writer, 2, value.ChangeList);
        AsduElement.EncodeOptional<BooleanCodec, bool>(ref writer, 3, value.InhibitDelay);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WriteGroupRequest value)
        => AsduConstructed.Encode<WriteGroupRequestCodec, T::WriteGroupRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WriteGroupRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.GroupNumber);
        length += AsduElement.GetEncodedLength<WriteGroupRequestTWritePriorityCodec, T::WriteGroupRequest.TWritePriority>(1, value.WritePriority);
        length += AsduElement.GetSequenceOfEncodedLength<GroupChannelValueCodec, T::GroupChannelValue>(2, value.ChangeList);
        length += AsduElement.GetOptionalEncodedLength<BooleanCodec, bool>(3, value.InhibitDelay);
        return length;
    }

    public static int GetEncodedLength(in T::WriteGroupRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WriteGroupRequestCodec, T::WriteGroupRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
