// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AtomicReadFileAckCodec :
    IAsduElementCodec<T::AtomicReadFileAck>,
    IAsduConstructedCodec<T::AtomicReadFileAck>
{
    public static T::AtomicReadFileAck Decode(ref AsduReader reader)
    {
        return new T::AtomicReadFileAck
        {
            EndOfFile = AsduElement.Decode<BooleanCodec, bool>(ref reader),
            AccessMethod = AsduElement.Decode<AtomicReadFileAckTAccessMethodCodec, T::AtomicReadFileAck.TAccessMethod>(ref reader)
        };
    }

    public static T::AtomicReadFileAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AtomicReadFileAckCodec, T::AtomicReadFileAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AtomicReadFileAck value)
    {
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.EndOfFile);
        AsduElement.Encode<AtomicReadFileAckTAccessMethodCodec, T::AtomicReadFileAck.TAccessMethod>(ref writer, value.AccessMethod);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AtomicReadFileAck value)
        => AsduConstructed.Encode<AtomicReadFileAckCodec, T::AtomicReadFileAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AtomicReadFileAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.EndOfFile);
        length += AsduElement.GetEncodedLength<AtomicReadFileAckTAccessMethodCodec, T::AtomicReadFileAck.TAccessMethod>(value.AccessMethod);
        return length;
    }

    public static int GetEncodedLength(in T::AtomicReadFileAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AtomicReadFileAckCodec, T::AtomicReadFileAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return BooleanCodec.Matches(ref reader);
    }
}
