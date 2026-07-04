// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedTextMessageRequestCodec :
    IAsduElementCodec<T::ConfirmedTextMessageRequest>,
    IAsduConstructedCodec<T::ConfirmedTextMessageRequest>
{
    public static T::ConfirmedTextMessageRequest Decode(ref AsduReader reader)
    {
        return new T::ConfirmedTextMessageRequest
        {
            TextMessageSourceDevice = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            MessageClass = AsduElement.DecodeOptional<ConfirmedTextMessageRequestTMessageClassCodec, T::ConfirmedTextMessageRequest.TMessageClass>(ref reader, 1),
            MessagePriority = AsduElement.Decode<ConfirmedTextMessageRequestTMessagePriorityCodec, T::ConfirmedTextMessageRequest.TMessagePriority>(ref reader, 2),
            Message = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 3)
        };
    }

    public static T::ConfirmedTextMessageRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedTextMessageRequestCodec, T::ConfirmedTextMessageRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedTextMessageRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.TextMessageSourceDevice);
        AsduElement.EncodeOptional<ConfirmedTextMessageRequestTMessageClassCodec, T::ConfirmedTextMessageRequest.TMessageClass>(ref writer, 1, value.MessageClass);
        AsduElement.Encode<ConfirmedTextMessageRequestTMessagePriorityCodec, T::ConfirmedTextMessageRequest.TMessagePriority>(ref writer, 2, value.MessagePriority);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 3, value.Message);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedTextMessageRequest value)
        => AsduConstructed.Encode<ConfirmedTextMessageRequestCodec, T::ConfirmedTextMessageRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedTextMessageRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.TextMessageSourceDevice);
        length += AsduElement.GetOptionalEncodedLength<ConfirmedTextMessageRequestTMessageClassCodec, T::ConfirmedTextMessageRequest.TMessageClass>(1, value.MessageClass);
        length += AsduElement.GetEncodedLength<ConfirmedTextMessageRequestTMessagePriorityCodec, T::ConfirmedTextMessageRequest.TMessagePriority>(2, value.MessagePriority);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(3, value.Message);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedTextMessageRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedTextMessageRequestCodec, T::ConfirmedTextMessageRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
