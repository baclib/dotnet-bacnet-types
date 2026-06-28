// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedTextMessageRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest Decode(ref NativeReader reader)
    {
        var _textMessageSourceDevice = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _messageClass = Asdu.DecodeOptionalElement<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(ref reader, 1);
        var _messagePriority = Asdu.DecodePrimitive<UnconfirmedTextMessageRequestTMessagePriorityCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessagePriority>(ref reader, 2);
        var _message = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest
        {
            TextMessageSourceDevice = _textMessageSourceDevice,
            MessageClass = _messageClass,
            MessagePriority = _messagePriority,
            Message = _message
        };
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.TextMessageSourceDevice);
        if (value.MessageClass.HasValue)
        {
            Asdu.EncodeElement<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(ref writer, 1, value.MessageClass.Value);
        }
        Asdu.EncodePrimitive<UnconfirmedTextMessageRequestTMessagePriorityCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessagePriority>(ref writer, 2, value.MessagePriority);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 3, value.Message);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.TextMessageSourceDevice) + (value.MessageClass.HasValue ? Asdu.GetElementLength<UnconfirmedTextMessageRequestTMessageClassCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessageClass>(1, value.MessageClass.Value) : 0) + Asdu.GetPrimitiveLength<UnconfirmedTextMessageRequestTMessagePriorityCodec, global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest.TMessagePriority>(2, value.MessagePriority) + Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(3, value.Message);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedTextMessageRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
