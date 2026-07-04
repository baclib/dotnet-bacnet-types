// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedTextMessageRequestCodec :
    IAsduElementCodec<T::UnconfirmedTextMessageRequest>,
    IAsduConstructedCodec<T::UnconfirmedTextMessageRequest>
{
    public static T::UnconfirmedTextMessageRequest Decode(ref AsduReader reader)
    {
        return new T::UnconfirmedTextMessageRequest
        {
            TextMessageSourceDevice = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            MessageClass = AsduElement.DecodeOptional<UnconfirmedTextMessageRequestTMessageClassCodec, T::UnconfirmedTextMessageRequest.TMessageClass>(ref reader, 1),
            MessagePriority = AsduElement.Decode<UnconfirmedTextMessageRequestTMessagePriorityCodec, T::UnconfirmedTextMessageRequest.TMessagePriority>(ref reader, 2),
            Message = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 3)
        };
    }

    public static T::UnconfirmedTextMessageRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedTextMessageRequestCodec, T::UnconfirmedTextMessageRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::UnconfirmedTextMessageRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.TextMessageSourceDevice);
        AsduElement.EncodeOptional<UnconfirmedTextMessageRequestTMessageClassCodec, T::UnconfirmedTextMessageRequest.TMessageClass>(ref writer, 1, value.MessageClass);
        AsduElement.Encode<UnconfirmedTextMessageRequestTMessagePriorityCodec, T::UnconfirmedTextMessageRequest.TMessagePriority>(ref writer, 2, value.MessagePriority);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 3, value.Message);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::UnconfirmedTextMessageRequest value)
        => AsduConstructed.Encode<UnconfirmedTextMessageRequestCodec, T::UnconfirmedTextMessageRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::UnconfirmedTextMessageRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.TextMessageSourceDevice);
        length += AsduElement.GetOptionalEncodedLength<UnconfirmedTextMessageRequestTMessageClassCodec, T::UnconfirmedTextMessageRequest.TMessageClass>(1, value.MessageClass);
        length += AsduElement.GetEncodedLength<UnconfirmedTextMessageRequestTMessagePriorityCodec, T::UnconfirmedTextMessageRequest.TMessagePriority>(2, value.MessagePriority);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(3, value.Message);
        return length;
    }

    public static int GetEncodedLength(in T::UnconfirmedTextMessageRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<UnconfirmedTextMessageRequestCodec, T::UnconfirmedTextMessageRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
