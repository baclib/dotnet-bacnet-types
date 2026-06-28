// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessResultTListOfResultsItemTReadResultCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 4:
            case 5:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 4:
                var _propertyValue = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.FromPropertyValue(_propertyValue);
            case 5:
                var _propertyAccessError = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.FromPropertyAccessError(_propertyAccessError);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyValue:
                Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 4, value.PropertyValue);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyAccessError:
                Asdu.EncodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 5, value.PropertyAccessError);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyValue:
                return Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(4, value.PropertyValue);
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyAccessError:
                return Asdu.GetConstructedLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(5, value.PropertyAccessError);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}