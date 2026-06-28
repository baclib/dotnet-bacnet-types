// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RouterEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.RouterEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.RouterEntry>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.RouterEntry Decode(ref NativeReader reader)
    {
        var _networkNumber = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _macAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 1);
        var _status = Asdu.DecodePrimitive<RouterEntryTStatusCodec, global::Baclib.Bacnet.Types.Application.RouterEntry.TStatus>(ref reader, 2);
        var _performanceIndex = Asdu.DecodeOptional<Unsigned8Codec, byte>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.RouterEntry
        {
            NetworkNumber = _networkNumber,
            MacAddress = _macAddress,
            Status = _status,
            PerformanceIndex = _performanceIndex
        };
    }

    public static global::Baclib.Bacnet.Types.Application.RouterEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.RouterEntry value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.NetworkNumber);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 1, value.MacAddress);
        Asdu.EncodePrimitive<RouterEntryTStatusCodec, global::Baclib.Bacnet.Types.Application.RouterEntry.TStatus>(ref writer, 2, value.Status);
        if (value.PerformanceIndex.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 3, value.PerformanceIndex.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.RouterEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.RouterEntry value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.NetworkNumber) + Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(1, value.MacAddress) + Asdu.GetPrimitiveLength<RouterEntryTStatusCodec, global::Baclib.Bacnet.Types.Application.RouterEntry.TStatus>(2, value.Status) + (value.PerformanceIndex.HasValue ? Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(3, value.PerformanceIndex.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.RouterEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
