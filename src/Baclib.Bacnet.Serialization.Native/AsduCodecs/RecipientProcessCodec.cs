// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RecipientProcessCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.RecipientProcess>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.RecipientProcess>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.RecipientProcess Decode(ref NativeReader reader)
    {
        var _recipient = Asdu.DecodeConstructed<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader, 0);
        var _processIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.RecipientProcess
        {
            Recipient = _recipient,
            ProcessIdentifier = _processIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.RecipientProcess Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.RecipientProcess value)
    {
        Asdu.EncodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, 0, value.Recipient);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 1, value.ProcessIdentifier);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.RecipientProcess value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.RecipientProcess value)
    {
        return Asdu.GetElementLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(0, value.Recipient) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(1, value.ProcessIdentifier);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.RecipientProcess value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
