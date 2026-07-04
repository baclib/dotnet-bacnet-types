// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtSessionCodec :
    IAsduElementCodec<T::VtSession>,
    IAsduConstructedCodec<T::VtSession>
{
    public static T::VtSession Decode(ref AsduReader reader)
    {
        return new T::VtSession
        {
            LocalVtSessionId = AsduElement.Decode<Unsigned8Codec, byte>(ref reader),
            RemoteVtSessionId = AsduElement.Decode<Unsigned8Codec, byte>(ref reader),
            RemoteVtAddress = AsduElement.Decode<AddressCodec, T::Address>(ref reader)
        };
    }

    public static T::VtSession Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtSessionCodec, T::VtSession>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtSession value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.LocalVtSessionId);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.RemoteVtSessionId);
        AsduElement.Encode<AddressCodec, T::Address>(ref writer, value.RemoteVtAddress);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtSession value)
        => AsduConstructed.Encode<VtSessionCodec, T::VtSession>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtSession value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.LocalVtSessionId);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.RemoteVtSessionId);
        length += AsduElement.GetEncodedLength<AddressCodec, T::Address>(value.RemoteVtAddress);
        return length;
    }

    public static int GetEncodedLength(in T::VtSession value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtSessionCodec, T::VtSession>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned8Codec.Matches(ref reader);
    }
}
