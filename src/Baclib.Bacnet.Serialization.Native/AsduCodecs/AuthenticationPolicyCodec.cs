// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationPolicyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationPolicy>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationPolicy>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationPolicy Decode(ref NativeReader reader)
    {
        var _policy = Asdu.DecodeSequenceOf<AuthenticationPolicyTPolicyTPolicyItemCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPolicy.TPolicy.TPolicyItem>(ref reader, 0);
        var _orderEnforced = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);
        var _timeout = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationPolicy
        {
            Policy = _policy,
            OrderEnforced = _orderEnforced,
            Timeout = _timeout
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationPolicy Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationPolicy value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.Policy)
        {
            Asdu.EncodeElement<AuthenticationPolicyTPolicyTPolicyItemCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPolicy.TPolicy.TPolicyItem>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.OrderEnforced);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.Timeout);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationPolicy value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationPolicy value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.Policy.Items.Sum(static item => Asdu.GetElementLength<AuthenticationPolicyTPolicyTPolicyItemCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPolicy.TPolicy.TPolicyItem>(0, item))) + AsduLength.FromTagNumber((byte)0)) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.OrderEnforced) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.Timeout);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationPolicy value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
