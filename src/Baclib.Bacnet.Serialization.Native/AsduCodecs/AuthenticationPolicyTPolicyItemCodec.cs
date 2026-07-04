// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationPolicyTPolicyItemCodec :
    IAsduElementCodec<T::AuthenticationPolicy.TPolicyItem>,
    IAsduConstructedCodec<T::AuthenticationPolicy.TPolicyItem>
{
    public static T::AuthenticationPolicy.TPolicyItem Decode(ref AsduReader reader)
    {
        return new T::AuthenticationPolicy.TPolicyItem
        {
            CredentialDataInput = AsduElement.Decode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref reader, 0),
            Index = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1)
        };
    }

    public static T::AuthenticationPolicy.TPolicyItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationPolicy.TPolicyItem value)
    {
        AsduElement.Encode<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref writer, 0, value.CredentialDataInput);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.Index);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationPolicy.TPolicyItem value)
        => AsduConstructed.Encode<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationPolicy.TPolicyItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DeviceObjectReferenceCodec, T::DeviceObjectReference>(0, value.CredentialDataInput);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.Index);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationPolicy.TPolicyItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationPolicyTPolicyItemCodec, T::AuthenticationPolicy.TPolicyItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
