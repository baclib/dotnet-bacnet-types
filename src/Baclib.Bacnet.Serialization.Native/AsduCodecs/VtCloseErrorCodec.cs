// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtCloseErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtCloseError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtCloseError>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.VtCloseError Decode(ref NativeReader reader)
    {
        var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 0);
        var _listOfVtSessionIdentifiers = reader.PeekOpeningTag(1) ? Asdu.DecodeSequenceOf<Unsigned8Codec, byte>(ref reader, 1) : Optional<SequenceOf<byte>>.None;

        return new global::Baclib.Bacnet.Types.Application.VtCloseError
        {
            ErrorType = _errorType,
            ListOfVtSessionIdentifiers = _listOfVtSessionIdentifiers
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtCloseError Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtCloseError value)
    {
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 0, value.ErrorType);
        if (value.ListOfVtSessionIdentifiers.HasValue)
        {
            writer.WriteOpeningTag(1);
            foreach (var item in value.ListOfVtSessionIdentifiers.Value)
            {
                Asdu.EncodeElement<Unsigned8Codec, byte>(ref writer, 1, item);
            }
            writer.WriteClosingTag(1);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtCloseError value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtCloseError value)
    {
        return Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(0, value.ErrorType) + (value.ListOfVtSessionIdentifiers.HasValue ? (AsduLength.FromTagNumber((byte)1) + (value.ListOfVtSessionIdentifiers.Value.Items.Sum(static item => Asdu.GetElementLength<Unsigned8Codec, byte>(1, item))) + AsduLength.FromTagNumber((byte)1)) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtCloseError value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
