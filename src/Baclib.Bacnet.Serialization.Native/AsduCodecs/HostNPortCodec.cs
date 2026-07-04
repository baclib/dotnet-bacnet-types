// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class HostNPortCodec :
    IAsduElementCodec<T::HostNPort>,
    IAsduConstructedCodec<T::HostNPort>
{
    public static T::HostNPort Decode(ref AsduReader reader)
    {
        return new T::HostNPort
        {
            Host = AsduElement.Decode<HostAddressCodec, T::HostAddress>(ref reader, 0),
            Port = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 1)
        };
    }

    public static T::HostNPort Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<HostNPortCodec, T::HostNPort>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::HostNPort value)
    {
        AsduElement.Encode<HostAddressCodec, T::HostAddress>(ref writer, 0, value.Host);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 1, value.Port);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::HostNPort value)
        => AsduConstructed.Encode<HostNPortCodec, T::HostNPort>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::HostNPort value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<HostAddressCodec, T::HostAddress>(0, value.Host);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(1, value.Port);
        return length;
    }

    public static int GetEncodedLength(in T::HostNPort value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<HostNPortCodec, T::HostNPort>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
