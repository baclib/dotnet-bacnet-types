// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationPeerCodec :
    IAsduElementCodec<T::AuthenticationPeer>,
    IAsduConstructedCodec<T::AuthenticationPeer>
{
    public static T::AuthenticationPeer Decode(ref AsduReader reader)
    {
        return new T::AuthenticationPeer
        {
            Host = AsduElement.Decode<HostNPortCodec, T::HostNPort>(ref reader),
            Device = AsduElement.Decode<Unsigned32Codec, uint>(ref reader),
            AuthAware = AsduElement.Decode<BooleanCodec, bool>(ref reader),
            Router = AsduElement.Decode<BooleanCodec, bool>(ref reader),
            Hub = AsduElement.Decode<BooleanCodec, bool>(ref reader)
        };
    }

    public static T::AuthenticationPeer Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationPeerCodec, T::AuthenticationPeer>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationPeer value)
    {
        AsduElement.Encode<HostNPortCodec, T::HostNPort>(ref writer, value.Host);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, value.Device);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.AuthAware);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.Router);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.Hub);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationPeer value)
        => AsduConstructed.Encode<AuthenticationPeerCodec, T::AuthenticationPeer>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationPeer value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<HostNPortCodec, T::HostNPort>(value.Host);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(value.Device);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.AuthAware);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.Router);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.Hub);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationPeer value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationPeerCodec, T::AuthenticationPeer>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return HostNPortCodec.Matches(ref reader);
    }
}
