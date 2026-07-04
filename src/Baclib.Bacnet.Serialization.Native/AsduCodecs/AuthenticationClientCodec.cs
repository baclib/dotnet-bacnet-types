// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationClientCodec :
    IAsduElementCodec<T::AuthenticationClient>,
    IAsduConstructedCodec<T::AuthenticationClient>
{
    public static T::AuthenticationClient Decode(ref AsduReader reader)
    {
        return new T::AuthenticationClient
        {
            Authenticated = AsduElement.Decode<BooleanCodec, bool>(ref reader),
            Device = AsduElement.Decode<Unsigned32Codec, uint>(ref reader)
        };
    }

    public static T::AuthenticationClient Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationClientCodec, T::AuthenticationClient>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationClient value)
    {
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.Authenticated);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, value.Device);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationClient value)
        => AsduConstructed.Encode<AuthenticationClientCodec, T::AuthenticationClient>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationClient value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.Authenticated);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(value.Device);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationClient value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationClientCodec, T::AuthenticationClient>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return BooleanCodec.Matches(ref reader);
    }
}
