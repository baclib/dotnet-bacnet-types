// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ObjectSelectorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ObjectSelector>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ObjectSelector>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Null or
            ApplicationTagNumber.ObjectIdentifier or
            ApplicationTagNumber.Enumerated => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ObjectSelector Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @none = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromNone(@none);
        }
        if (ObjectIdentifierCodec.Matches(ref reader))
        {
            var @object = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromObject(@object);
        }
        if (ObjectTypeCodec.Matches(ref reader))
        {
            var @objectType = ObjectTypeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromObjectType(@objectType);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ObjectSelector Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ObjectSelectorCodec, global::Baclib.Bacnet.Types.Application.ObjectSelector>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.None:
                NullCodec.Encode(ref writer, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.Object:
                ObjectIdentifierCodec.Encode(ref writer, value.Object);
                return;
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.ObjectType:
                ObjectTypeCodec.Encode(ref writer, value.ObjectType);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
        => AsduConstructed.Encode<ObjectSelectorCodec, global::Baclib.Bacnet.Types.Application.ObjectSelector>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.None
                => NullCodec.GetEncodedLength(value.None),
            global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.Object
                => ObjectIdentifierCodec.GetEncodedLength(value.Object),
            global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.ObjectType
                => ObjectTypeCodec.GetEncodedLength(value.ObjectType),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ObjectSelector value, byte tagNumber)
        => AsduElement.GetEncodedLength<ObjectSelectorCodec, global::Baclib.Bacnet.Types.Application.ObjectSelector>(tagNumber, value);
}
