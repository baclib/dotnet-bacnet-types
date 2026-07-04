// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestTObjectCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            2 or
            3 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 2:
                var @objectIdentifier = ObjectIdentifierCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.FromObjectIdentifier(@objectIdentifier);
            case 3:
                var @objectName = CharacterStringCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.FromObjectName(@objectName);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectIdentifier:
                ObjectIdentifierCodec.Encode(ref writer, 2, value.ObjectIdentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectName:
                CharacterStringCodec.Encode(ref writer, 3, value.ObjectName);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
        => AsduConstructed.Encode<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectIdentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.ObjectIdentifier, 2),
            global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject.Option.ObjectName
                => CharacterStringCodec.GetEncodedLength(value.ObjectName, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject value, byte tagNumber)
        => AsduElement.GetEncodedLength<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(tagNumber, value);
}
