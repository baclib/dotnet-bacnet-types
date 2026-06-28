// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckTAccessMethodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>
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

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _streamAccess = Asdu.DecodeConstructed<AtomicReadFileAckTAccessMethodTStreamAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TStreamAccess>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.FromStreamAccess(_streamAccess);
            case 1:
                var _recordAccess = Asdu.DecodeConstructed<AtomicReadFileAckTAccessMethodTRecordAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TRecordAccess>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.FromRecordAccess(_recordAccess);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.StreamAccess:
                Asdu.EncodeConstructed<AtomicReadFileAckTAccessMethodTStreamAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TStreamAccess>(ref writer, 0, value.StreamAccess);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.RecordAccess:
                Asdu.EncodeConstructed<AtomicReadFileAckTAccessMethodTRecordAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TRecordAccess>(ref writer, 1, value.RecordAccess);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.StreamAccess:
                return Asdu.GetConstructedLength<AtomicReadFileAckTAccessMethodTStreamAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TStreamAccess>(0, value.StreamAccess);
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.RecordAccess:
                return Asdu.GetConstructedLength<AtomicReadFileAckTAccessMethodTRecordAccessCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.TRecordAccess>(1, value.RecordAccess);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}