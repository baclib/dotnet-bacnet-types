// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AcknowledgeAlarmInfoCodec :
    IAsduElementCodec<T::AcknowledgeAlarmInfo>,
    IAsduConstructedCodec<T::AcknowledgeAlarmInfo>
{
    public static T::AcknowledgeAlarmInfo Decode(ref AsduReader reader)
    {
        return new T::AcknowledgeAlarmInfo
        {
            EventStateAcknowledged = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader, 0),
            Timestamp = AsduElement.Decode<TimeStampCodec, T::TimeStamp>(ref reader, 1)
        };
    }

    public static T::AcknowledgeAlarmInfo Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AcknowledgeAlarmInfoCodec, T::AcknowledgeAlarmInfo>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AcknowledgeAlarmInfo value)
    {
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, 0, value.EventStateAcknowledged);
        AsduElement.Encode<TimeStampCodec, T::TimeStamp>(ref writer, 1, value.Timestamp);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AcknowledgeAlarmInfo value)
        => AsduConstructed.Encode<AcknowledgeAlarmInfoCodec, T::AcknowledgeAlarmInfo>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AcknowledgeAlarmInfo value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(0, value.EventStateAcknowledged);
        length += AsduElement.GetEncodedLength<TimeStampCodec, T::TimeStamp>(1, value.Timestamp);
        return length;
    }

    public static int GetEncodedLength(in T::AcknowledgeAlarmInfo value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AcknowledgeAlarmInfoCodec, T::AcknowledgeAlarmInfo>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
