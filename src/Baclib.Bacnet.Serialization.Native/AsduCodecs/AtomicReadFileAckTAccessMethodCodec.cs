// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckTAccessMethodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>
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

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @streamAccess = AtomicReadFileAckTAccessMethodTStreamAccessCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.FromStreamAccess(@streamAccess);
            case 1:
                var @recordAccess = AtomicReadFileAckTAccessMethodTRecordAccessCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.FromRecordAccess(@recordAccess);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.StreamAccess:
                AtomicReadFileAckTAccessMethodTStreamAccessCodec.Encode(ref writer, 0, value.StreamAccess);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.RecordAccess:
                AtomicReadFileAckTAccessMethodTRecordAccessCodec.Encode(ref writer, 1, value.RecordAccess);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
        => AsduConstructed.Encode<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.StreamAccess
                => AtomicReadFileAckTAccessMethodTStreamAccessCodec.GetEncodedLength(value.StreamAccess, 0),
            global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod.Option.RecordAccess
                => AtomicReadFileAckTAccessMethodTRecordAccessCodec.GetEncodedLength(value.RecordAccess, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod value, byte tagNumber)
        => AsduElement.GetEncodedLength<AtomicReadFileAckTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileAck.TAccessMethod>(tagNumber, value);
}
