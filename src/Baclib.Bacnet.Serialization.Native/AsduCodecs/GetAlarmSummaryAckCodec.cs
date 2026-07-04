// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

using System.Collections.Generic;

public sealed class GetAlarmSummaryAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck>
{
    public static bool Matches(ref AsduReader reader)
    {
        return !reader.End;
    }

    public static global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck Decode(ref AsduReader reader)
    {
        var items = new List<global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck.TItem>();
        while (!reader.End && GetAlarmSummaryAckTItemCodec.Matches(ref reader))
        {
            items.Add(GetAlarmSummaryAckTItemCodec.Decode(ref reader));
        }

        return new global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck(items);
    }

    public static global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck Decode(ref AsduReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck value)
    {
        foreach (var item in value)
        {
            GetAlarmSummaryAckTItemCodec.Encode(ref writer, item);
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck value)
    {
        var length = 0;
        foreach (var item in value)
        {
            length += GetAlarmSummaryAckTItemCodec.GetEncodedLength(item);
        }

        return length;
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GetAlarmSummaryAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber(tagNumber) + GetEncodedLength(value) + AsduLength.FromTagNumber(tagNumber);
    }
}
