// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestTObjectCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 2:
            case 3:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 2:
                var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.FromObjectIdentifier(_objectIdentifier);
            case 3:
                var _objectName = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.FromObjectName(_objectName);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectIdentifier:
                Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 2, value.ObjectIdentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectName:
                Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 3, value.ObjectName);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectIdentifier:
                return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(2, value.ObjectIdentifier);
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectName:
                return Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(3, value.ObjectName);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}