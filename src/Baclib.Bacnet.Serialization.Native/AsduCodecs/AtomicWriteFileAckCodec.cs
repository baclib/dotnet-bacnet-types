// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @fileStartPosition = IntegerCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.FromFileStartPosition(@fileStartPosition);
            case 1:
                var @fileStartRecord = IntegerCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.FromFileStartRecord(@fileStartRecord);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartPosition:
                IntegerCodec.Encode(ref writer, 0, value.FileStartPosition);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartRecord:
                IntegerCodec.Encode(ref writer, 1, value.FileStartRecord);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
        => AsduConstructed.Encode<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartPosition
                => IntegerCodec.GetEncodedLength(value.FileStartPosition, 0),
            global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck.Option.FileStartRecord
                => IntegerCodec.GetEncodedLength(value.FileStartRecord, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck value, byte tagNumber)
        => AsduElement.GetEncodedLength<AtomicWriteFileAckCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileAck>(tagNumber, value);
}
