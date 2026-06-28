// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(ObjectIdentifierCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest Decode(ref NativeReader reader)
    {
        var _fileIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
        var _accessMethod = Asdu.DecodeElement<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest
        {
            FileIdentifier = _fileIdentifier,
            AccessMethod = _accessMethod
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.FileIdentifier);
        Asdu.EncodeElement<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(ref writer, value.AccessMethod);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest value)
    {
        return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.FileIdentifier) + Asdu.GetElementLength<AtomicWriteFileRequestTAccessMethodCodec, global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod>(value.AccessMethod);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
