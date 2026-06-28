// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class BdtEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.BdtEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.BdtEntry>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.BdtEntry Decode(ref NativeReader reader)
    {
        var _bbmdAddress = Asdu.DecodeConstructed<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref reader, 0);
        var _broadcastMask = Asdu.DecodeOptional<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.BdtEntry
        {
            BbmdAddress = _bbmdAddress,
            BroadcastMask = _broadcastMask
        };
    }

    public static global::Baclib.Bacnet.Types.Application.BdtEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.BdtEntry value)
    {
        Asdu.EncodeElement<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(ref writer, 0, value.BbmdAddress);
        if (value.BroadcastMask.HasValue)
        {
            Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 1, value.BroadcastMask.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.BdtEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.BdtEntry value)
    {
        return Asdu.GetElementLength<HostNPortCodec, global::Baclib.Bacnet.Types.Application.HostNPort>(0, value.BbmdAddress) + (value.BroadcastMask.HasValue ? Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(1, value.BroadcastMask.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.BdtEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
