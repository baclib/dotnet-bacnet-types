// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ChangeListErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ChangeListError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ChangeListError>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ChangeListError Decode(ref NativeReader reader)
    {
        var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 0);
        var _firstFailedElementNumber = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.ChangeListError
        {
            ErrorType = _errorType,
            FirstFailedElementNumber = _firstFailedElementNumber
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ChangeListError Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ChangeListError value)
    {
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 0, value.ErrorType);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.FirstFailedElementNumber);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ChangeListError value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ChangeListError value)
    {
        return Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(0, value.ErrorType) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.FirstFailedElementNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ChangeListError value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
