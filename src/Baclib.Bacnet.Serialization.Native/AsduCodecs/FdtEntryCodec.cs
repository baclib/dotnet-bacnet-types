// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FdtEntryCodec :
    IAsduElementCodec<T::FdtEntry>,
    IAsduConstructedCodec<T::FdtEntry>
{
    public static T::FdtEntry Decode(ref AsduReader reader)
    {
        return new T::FdtEntry
        {
            BacnetipAddress = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 0),
            TimeToLive = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 1),
            RemainingTimeToLive = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 2)
        };
    }

    public static T::FdtEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FdtEntryCodec, T::FdtEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FdtEntry value)
    {
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 0, value.BacnetipAddress);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 1, value.TimeToLive);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 2, value.RemainingTimeToLive);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FdtEntry value)
        => AsduConstructed.Encode<FdtEntryCodec, T::FdtEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FdtEntry value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(0, value.BacnetipAddress);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(1, value.TimeToLive);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(2, value.RemainingTimeToLive);
        return length;
    }

    public static int GetEncodedLength(in T::FdtEntry value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FdtEntryCodec, T::FdtEntry>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
