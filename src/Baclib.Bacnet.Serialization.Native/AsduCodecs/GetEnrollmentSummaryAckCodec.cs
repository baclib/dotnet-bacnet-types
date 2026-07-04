// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

using System.Collections.Generic;

public sealed class GetEnrollmentSummaryAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck>
{
    public static bool Matches(ref AsduReader reader)
    {
        return !reader.End;
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck Decode(ref AsduReader reader)
    {
        var items = new List<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck.TItem>();
        while (!reader.End && GetEnrollmentSummaryAckTItemCodec.Matches(ref reader))
        {
            items.Add(GetEnrollmentSummaryAckTItemCodec.Decode(ref reader));
        }

        return new global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck(items);
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck Decode(ref AsduReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck value)
    {
        foreach (var item in value)
        {
            GetEnrollmentSummaryAckTItemCodec.Encode(ref writer, item);
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck value)
    {
        var length = 0;
        foreach (var item in value)
        {
            length += GetEnrollmentSummaryAckTItemCodec.GetEncodedLength(item);
        }

        return length;
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber(tagNumber) + GetEncodedLength(value) + AsduLength.FromTagNumber(tagNumber);
    }
}
