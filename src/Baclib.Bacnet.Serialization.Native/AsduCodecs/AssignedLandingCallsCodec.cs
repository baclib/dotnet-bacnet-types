// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AssignedLandingCallsCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AssignedLandingCalls>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AssignedLandingCalls>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.AssignedLandingCalls Decode(ref NativeReader reader)
    {
        var _landingCalls = Asdu.DecodeSequenceOf<AssignedLandingCallsTLandingCallsTLandingCallsItemCodec, global::Baclib.Bacnet.Types.Application.AssignedLandingCalls.TLandingCalls.TLandingCallsItem>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.AssignedLandingCalls
        {
            LandingCalls = _landingCalls
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AssignedLandingCalls Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AssignedLandingCalls value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.LandingCalls)
        {
            Asdu.EncodeElement<AssignedLandingCallsTLandingCallsTLandingCallsItemCodec, global::Baclib.Bacnet.Types.Application.AssignedLandingCalls.TLandingCalls.TLandingCallsItem>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AssignedLandingCalls value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AssignedLandingCalls value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.LandingCalls.Items.Sum(static item => Asdu.GetElementLength<AssignedLandingCallsTLandingCallsTLandingCallsItemCodec, global::Baclib.Bacnet.Types.Application.AssignedLandingCalls.TLandingCalls.TLandingCallsItem>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AssignedLandingCalls value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
