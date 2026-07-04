// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RouterEntryCodec :
    IAsduElementCodec<T::RouterEntry>,
    IAsduConstructedCodec<T::RouterEntry>
{
    public static T::RouterEntry Decode(ref AsduReader reader)
    {
        return new T::RouterEntry
        {
            NetworkNumber = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            MacAddress = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 1),
            Status = AsduElement.Decode<RouterEntryTStatusCodec, T::RouterEntry.TStatus>(ref reader, 2),
            PerformanceIndex = AsduElement.DecodeOptional<Unsigned8Codec, byte>(ref reader, 3)
        };
    }

    public static T::RouterEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<RouterEntryCodec, T::RouterEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::RouterEntry value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.NetworkNumber);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 1, value.MacAddress);
        AsduElement.Encode<RouterEntryTStatusCodec, T::RouterEntry.TStatus>(ref writer, 2, value.Status);
        AsduElement.EncodeOptional<Unsigned8Codec, byte>(ref writer, 3, value.PerformanceIndex);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::RouterEntry value)
        => AsduConstructed.Encode<RouterEntryCodec, T::RouterEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::RouterEntry value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.NetworkNumber);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(1, value.MacAddress);
        length += AsduElement.GetEncodedLength<RouterEntryTStatusCodec, T::RouterEntry.TStatus>(2, value.Status);
        length += AsduElement.GetOptionalEncodedLength<Unsigned8Codec, byte>(3, value.PerformanceIndex);
        return length;
    }

    public static int GetEncodedLength(in T::RouterEntry value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<RouterEntryCodec, T::RouterEntry>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
