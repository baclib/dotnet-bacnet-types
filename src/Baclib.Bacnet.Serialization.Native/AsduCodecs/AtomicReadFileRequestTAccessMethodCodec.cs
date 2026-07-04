// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileRequestTAccessMethodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod>
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

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @streamAccess = AtomicReadFileRequestTAccessMethodTStreamAccessCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.FromStreamAccess(@streamAccess);
            case 1:
                var @recordAccess = AtomicReadFileRequestTAccessMethodTRecordAccessCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.FromRecordAccess(@recordAccess);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.Option.StreamAccess:
                AtomicReadFileRequestTAccessMethodTStreamAccessCodec.Encode(ref writer, 0, value.StreamAccess);
                return;
            case global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.Option.RecordAccess:
                AtomicReadFileRequestTAccessMethodTRecordAccessCodec.Encode(ref writer, 1, value.RecordAccess);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod value)
        => AsduConstructed.Encode<AtomicReadFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.Option.StreamAccess
                => AtomicReadFileRequestTAccessMethodTStreamAccessCodec.GetEncodedLength(value.StreamAccess, 0),
            global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.Option.RecordAccess
                => AtomicReadFileRequestTAccessMethodTRecordAccessCodec.GetEncodedLength(value.RecordAccess, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod value, byte tagNumber)
        => AsduElement.GetEncodedLength<AtomicReadFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod>(tagNumber, value);
}
