// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(BooleanCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck Decode(ref NativeReader reader)
    {
        var _endOfFile = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);
        var _accessMethod = Asdu.DecodeElement<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AtomicReadFileAck
        {
            EndOfFile = _endOfFile,
            AccessMethod = _accessMethod
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck value)
    {
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.EndOfFile);
        Asdu.EncodeElement<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(ref writer, value.AccessMethod);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck value)
    {
        return Asdu.GetEncodedLength<BooleanCodec, bool>(value.EndOfFile) + Asdu.GetElementLength<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(value.AccessMethod);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
