// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ObjectSelectorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ObjectSelector>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ObjectSelector>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.ObjectIdentifier:
            case ApplicationTagNumber.ObjectType:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ObjectSelector Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _none = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _none = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromNone(_none);
        }
        // info
        if (reader.PeekTag(ObjectIdentifierCodec.TagNumber))
        {
            //var _object = Asdu.Decode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
            var _object = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromObject(_object);
        }
        // info
        if (reader.PeekTag(ObjectTypeCodec.TagNumber))
        {
            //var _objectType = Asdu.Decode<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(ref reader);
            var _objectType = ObjectTypeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ObjectSelector.FromObjectType(_objectType);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ObjectSelector Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.None:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.None);
                NullCodec.Encode(ref writer, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.Object:
                //Asdu.Encode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.Object);
                ObjectIdentifierCodec.Encode(ref writer, value.Object);
                return;
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.ObjectType:
                //Asdu.Encode<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(ref writer, value.ObjectType);
                ObjectTypeCodec.Encode(ref writer, value.ObjectType);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ObjectSelector value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.None:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.None);
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.Object:
                return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.Object);
            case global::Baclib.Bacnet.Types.Application.ObjectSelector.Option.ObjectType:
                return Asdu.GetEncodedLength<ObjectTypeCodec, global::Baclib.Bacnet.Types.Application.ObjectType>(value.ObjectType);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ObjectSelector value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}