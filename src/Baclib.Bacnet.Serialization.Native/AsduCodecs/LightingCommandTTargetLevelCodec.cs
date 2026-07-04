// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to RealCodec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel.
public sealed class LightingCommandTTargetLevelCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>
{
    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel)RealCodec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value)
        => AsduPrimitive.Encode<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value)
        => AsduPrimitive.Encode<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value)
        => RealCodec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value)
        => RealCodec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => RealCodec.TagNumber;
}
