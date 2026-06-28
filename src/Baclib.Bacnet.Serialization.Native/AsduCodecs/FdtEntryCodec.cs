// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FdtEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FdtEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FdtEntry>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.FdtEntry Decode(ref NativeReader reader)
    {
        var _bacnetipAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 0);
        var _timeToLive = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 1);
        var _remainingTimeToLive = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.FdtEntry
        {
            BacnetipAddress = _bacnetipAddress,
            TimeToLive = _timeToLive,
            RemainingTimeToLive = _remainingTimeToLive
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FdtEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FdtEntry value)
    {
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 0, value.BacnetipAddress);
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 1, value.TimeToLive);
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 2, value.RemainingTimeToLive);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FdtEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FdtEntry value)
    {
        return Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(0, value.BacnetipAddress) + Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(1, value.TimeToLive) + Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(2, value.RemainingTimeToLive);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FdtEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
