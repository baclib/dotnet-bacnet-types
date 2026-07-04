// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileRequestTAccessMethodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>
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

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @streamAccess = AtomicWriteFileRequestTAccessMethodTStreamAccessCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.FromStreamAccess(@streamAccess);
            case 1:
                var @recordAccess = AtomicWriteFileRequestTAccessMethodTRecordAccessCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.FromRecordAccess(@recordAccess);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.Option.StreamAccess:
                AtomicWriteFileRequestTAccessMethodTStreamAccessCodec.Encode(ref writer, 0, value.StreamAccess);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.Option.RecordAccess:
                AtomicWriteFileRequestTAccessMethodTRecordAccessCodec.Encode(ref writer, 1, value.RecordAccess);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod value)
        => AsduConstructed.Encode<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.Option.StreamAccess
                => AtomicWriteFileRequestTAccessMethodTStreamAccessCodec.GetEncodedLength(value.StreamAccess, 0),
            global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.Option.RecordAccess
                => AtomicWriteFileRequestTAccessMethodTRecordAccessCodec.GetEncodedLength(value.RecordAccess, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod value, byte tagNumber)
        => AsduElement.GetEncodedLength<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(tagNumber, value);
}
