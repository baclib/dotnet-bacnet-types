// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned32Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime.
public sealed class LightingCommandTFadeTimeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>
{
    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime)Unsigned32Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value)
        => AsduPrimitive.Encode<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value)
        => AsduPrimitive.Encode<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value)
        => Unsigned32Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value)
        => Unsigned32Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned32Codec.TagNumber;
}
