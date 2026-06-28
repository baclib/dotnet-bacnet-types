// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicWriteFileRequestTAccessMethodTRecordAccessCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(IntegerCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess Decode(ref NativeReader reader)
    {
        var _fileStartRecord = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader);
        var _recordCount = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader);
        var _fileRecordData = Asdu.DecodeSequenceOf<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess
        {
            FileStartRecord = _fileStartRecord,
            RecordCount = _recordCount,
            FileRecordData = _fileRecordData
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess value)
    {
        Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, value.FileStartRecord);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, value.RecordCount);
        foreach (var item in value.FileRecordData)
        {
            Asdu.EncodeElement<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, item);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess value)
    {
        return Asdu.GetEncodedLength<IntegerCodec, int>(value.FileStartRecord) + Asdu.GetEncodedLength<UnsignedCodec, uint>(value.RecordCount) + (value.FileRecordData.Items.Sum(static item => Asdu.GetElementLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(item)));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AtomicWriteFileRequest.TAccessMethod.TRecordAccess value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
