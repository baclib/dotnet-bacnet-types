// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to RealCodec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate.
public sealed class LightingCommandTRampRateCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>
{
    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate)RealCodec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value)
        => AsduPrimitive.Encode<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value)
        => AsduPrimitive.Encode<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value)
        => RealCodec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value)
        => RealCodec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => RealCodec.TagNumber;
}
