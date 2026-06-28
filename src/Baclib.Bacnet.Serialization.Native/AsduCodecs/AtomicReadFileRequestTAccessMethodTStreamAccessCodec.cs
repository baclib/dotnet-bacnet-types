// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileRequestTAccessMethodTStreamAccessCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(IntegerCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess Decode(ref NativeReader reader)
    {
        var _fileStartPosition = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader);
        var _requestedOctetCount = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess
        {
            FileStartPosition = _fileStartPosition,
            RequestedOctetCount = _requestedOctetCount
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
    {
        Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, value.FileStartPosition);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, value.RequestedOctetCount);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess value)
    {
        return Asdu.GetEncodedLength<IntegerCodec, int>(value.FileStartPosition) + Asdu.GetEncodedLength<UnsignedCodec, uint>(value.RequestedOctetCount);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicReadFileRequest.TAccessMethod.TStreamAccess value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
