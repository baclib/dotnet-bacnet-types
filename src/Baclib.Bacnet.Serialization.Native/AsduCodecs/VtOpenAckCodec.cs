// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtOpenAckCodec :
    IAsduElementCodec<T::VtOpenAck>,
    IAsduConstructedCodec<T::VtOpenAck>
{
    public static T::VtOpenAck Decode(ref AsduReader reader)
    {
        return new T::VtOpenAck
        {
            RemoteVtSessionIdentifier = AsduElement.Decode<Unsigned8Codec, byte>(ref reader)
        };
    }

    public static T::VtOpenAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtOpenAckCodec, T::VtOpenAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtOpenAck value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.RemoteVtSessionIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtOpenAck value)
        => AsduConstructed.Encode<VtOpenAckCodec, T::VtOpenAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtOpenAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.RemoteVtSessionIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::VtOpenAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtOpenAckCodec, T::VtOpenAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned8Codec.Matches(ref reader);
    }
}
