// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LiftCarCallListCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LiftCarCallList>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LiftCarCallList>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.LiftCarCallList Decode(ref NativeReader reader)
    {
        var _floorNumbers = Asdu.DecodeSequenceOf<Unsigned8Codec, byte>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.LiftCarCallList
        {
            FloorNumbers = _floorNumbers
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LiftCarCallList Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LiftCarCallList value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.FloorNumbers)
        {
            Asdu.EncodeElement<Unsigned8Codec, byte>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LiftCarCallList value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LiftCarCallList value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.FloorNumbers.Items.Sum(static item => Asdu.GetElementLength<Unsigned8Codec, byte>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LiftCarCallList value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
