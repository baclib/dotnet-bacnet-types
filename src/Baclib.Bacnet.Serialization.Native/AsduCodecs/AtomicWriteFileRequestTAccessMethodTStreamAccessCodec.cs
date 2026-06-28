// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileRequestTAccessMethodTStreamAccessCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(IntegerCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess Decode(ref NativeReader reader)
    {
        var _fileStartPosition = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader);
        var _fileData = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess
        {
            FileStartPosition = _fileStartPosition,
            FileData = _fileData
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess value)
    {
        Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, value.FileStartPosition);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.FileData);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess value)
    {
        return Asdu.GetEncodedLength<IntegerCodec, int>(value.FileStartPosition) + Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.FileData);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TStreamAccess value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
