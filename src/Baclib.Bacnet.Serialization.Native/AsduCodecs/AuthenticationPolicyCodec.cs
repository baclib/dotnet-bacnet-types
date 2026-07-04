// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationPolicyCodec :
    IAsduElementCodec<T::AuthenticationPolicy>,
    IAsduConstructedCodec<T::AuthenticationPolicy>
{
    public static T::AuthenticationPolicy Decode(ref AsduReader reader)
    {
        return new T::AuthenticationPolicy
        {
            Policy = AsduElement.DecodeSequenceOf<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(ref reader, 0),
            OrderEnforced = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1),
            Timeout = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2)
        };
    }

    public static T::AuthenticationPolicy Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationPolicyCodec, T::AuthenticationPolicy>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationPolicy value)
    {
        AsduElement.EncodeSequenceOf<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(ref writer, 0, value.Policy);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.OrderEnforced);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.Timeout);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationPolicy value)
        => AsduConstructed.Encode<AuthenticationPolicyCodec, T::AuthenticationPolicy>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationPolicy value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(0, value.Policy);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.OrderEnforced);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.Timeout);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationPolicy value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationPolicyCodec, T::AuthenticationPolicy>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
