// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessResultTListOfResultsItemTReadResultCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            4 or
            5 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 4:
                var @propertyValue = AnyCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.FromPropertyValue(@propertyValue);
            case 5:
                var @propertyAccessError = ErrorCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.FromPropertyAccessError(@propertyAccessError);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadAccessResultTListOfResultsItemTReadResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyValue:
                AnyCodec.Encode(ref writer, 4, value.PropertyValue);
                return;
            case global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyAccessError:
                ErrorCodec.Encode(ref writer, 5, value.PropertyAccessError);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
        => AsduConstructed.Encode<ReadAccessResultTListOfResultsItemTReadResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyValue
                => AnyCodec.GetEncodedLength(value.PropertyValue, 4),
            global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult.Option.PropertyAccessError
                => ErrorCodec.GetEncodedLength(value.PropertyAccessError, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult value, byte tagNumber)
        => AsduElement.GetEncodedLength<ReadAccessResultTListOfResultsItemTReadResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem.TReadResult>(tagNumber, value);
}
