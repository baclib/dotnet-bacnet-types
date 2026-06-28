// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return WhoHasRequestTObjectCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest Decode(ref NativeReader reader)
    {
        var _limits = Asdu.DecodeOptionalElement<WhoHasRequestTLimitsCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits>(ref reader);
        var _object = Asdu.DecodeElement<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.WhoHasRequest
        {
            Limits = _limits,
            Object = _object
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WhoHasRequest value)
    {
        if (value.Limits.HasValue)
        {
            Asdu.EncodeElement<WhoHasRequestTLimitsCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits>(ref writer, value.Limits.Value);
        }
        Asdu.EncodeElement<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(ref writer, value.Object);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoHasRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest value)
    {
        return (value.Limits.HasValue ? Asdu.GetElementLength<WhoHasRequestTLimitsCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits>(value.Limits.Value) : 0) + Asdu.GetElementLength<WhoHasRequestTObjectCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TObject>(value.Object);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
