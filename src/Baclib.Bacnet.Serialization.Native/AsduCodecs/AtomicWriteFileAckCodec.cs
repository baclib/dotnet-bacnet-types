// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _fileStartPosition = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.FromFileStartPosition(_fileStartPosition);
            case 1:
                var _fileStartRecord = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.FromFileStartRecord(_fileStartRecord);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartPosition:
                Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 0, value.FileStartPosition);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartRecord:
                Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 1, value.FileStartRecord);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartPosition:
                return Asdu.GetPrimitiveLength<IntegerCodec, int>(0, value.FileStartPosition);
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartRecord:
                return Asdu.GetPrimitiveLength<IntegerCodec, int>(1, value.FileStartRecord);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}