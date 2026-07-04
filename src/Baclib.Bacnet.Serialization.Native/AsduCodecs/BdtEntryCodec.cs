// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class BdtEntryCodec :
    IAsduElementCodec<T::BdtEntry>,
    IAsduConstructedCodec<T::BdtEntry>
{
    public static T::BdtEntry Decode(ref AsduReader reader)
    {
        return new T::BdtEntry
        {
            BbmdAddress = AsduElement.Decode<HostNPortCodec, T::HostNPort>(ref reader, 0),
            BroadcastMask = AsduElement.DecodeOptional<OctetStringCodec, T::OctetString>(ref reader, 1)
        };
    }

    public static T::BdtEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<BdtEntryCodec, T::BdtEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::BdtEntry value)
    {
        AsduElement.Encode<HostNPortCodec, T::HostNPort>(ref writer, 0, value.BbmdAddress);
        AsduElement.EncodeOptional<OctetStringCodec, T::OctetString>(ref writer, 1, value.BroadcastMask);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::BdtEntry value)
        => AsduConstructed.Encode<BdtEntryCodec, T::BdtEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::BdtEntry value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<HostNPortCodec, T::HostNPort>(0, value.BbmdAddress);
        length += AsduElement.GetOptionalEncodedLength<OctetStringCodec, T::OctetString>(1, value.BroadcastMask);
        return length;
    }

    public static int GetEncodedLength(in T::BdtEntry value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<BdtEntryCodec, T::BdtEntry>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
