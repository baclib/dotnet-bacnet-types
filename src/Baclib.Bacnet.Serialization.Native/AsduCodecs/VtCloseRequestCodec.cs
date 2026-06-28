// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtCloseRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtCloseRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtCloseRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned8Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.VtCloseRequest Decode(ref NativeReader reader)
    {
        var _listOfRemoteVtSessionIdentifiers = Asdu.DecodeSequenceOf<Unsigned8Codec, byte>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.VtCloseRequest
        {
            ListOfRemoteVtSessionIdentifiers = _listOfRemoteVtSessionIdentifiers
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtCloseRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtCloseRequest value)
    {
        foreach (var item in value.ListOfRemoteVtSessionIdentifiers)
        {
            Asdu.EncodeElement<Unsigned8Codec, byte>(ref writer, item);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtCloseRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtCloseRequest value)
    {
        return (value.ListOfRemoteVtSessionIdentifiers.Items.Sum(static item => Asdu.GetElementLength<Unsigned8Codec, byte>(item)));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtCloseRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
