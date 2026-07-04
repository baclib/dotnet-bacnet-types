// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CreateObjectRequestTObjectSpecifierCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @objectType = ObjectTypeCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.FromObjectType(@objectType);
            case 1:
                var @objectIdentifier = ObjectIdentifierCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.FromObjectIdentifier(@objectIdentifier);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectType:
                ObjectTypeCodec.Encode(ref writer, 0, value.ObjectType);
                return;
            case global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectIdentifier:
                ObjectIdentifierCodec.Encode(ref writer, 1, value.ObjectIdentifier);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
        => AsduConstructed.Encode<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectType
                => ObjectTypeCodec.GetEncodedLength(value.ObjectType, 0),
            global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier.Option.ObjectIdentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.ObjectIdentifier, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier value, byte tagNumber)
        => AsduElement.GetEncodedLength<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(tagNumber, value);
}
