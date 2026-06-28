// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SetpointReferenceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SetpointReference>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SetpointReference>
{
    public static bool Matches(ref NativeReader reader)
    {
        return !reader.End;
    }

    public static global::Baclib.Bacnet.Types.Application.SetpointReference Decode(ref NativeReader reader)
    {
        var _reference = Asdu.DecodeOptionalElement<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.SetpointReference
        {
            Reference = _reference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SetpointReference Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SetpointReference value)
    {
        if (value.Reference.HasValue)
        {
            Asdu.EncodeElement<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref writer, 0, value.Reference.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SetpointReference value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SetpointReference value)
    {
        return (value.Reference.HasValue ? Asdu.GetElementLength<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(0, value.Reference.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SetpointReference value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
