// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CreateObjectRequestTObjectSpecifierCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _objectType = Asdu.DecodePrimitive<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.FromObjectType(_objectType);
            case 1:
                var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.FromObjectIdentifier(_objectIdentifier);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectType:
                Asdu.EncodePrimitive<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(ref writer, 0, value.ObjectType);
                return;
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectIdentifier:
                Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectType:
                return Asdu.GetPrimitiveLength<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(0, value.ObjectType);
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectIdentifier:
                return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.ObjectIdentifier);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}