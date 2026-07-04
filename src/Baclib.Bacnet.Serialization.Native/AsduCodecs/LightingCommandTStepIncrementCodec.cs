// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to RealCodec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement.
public sealed class LightingCommandTStepIncrementCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>
{
    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement)RealCodec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value)
        => AsduPrimitive.Encode<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value)
        => AsduPrimitive.Encode<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value)
        => RealCodec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value)
        => RealCodec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => RealCodec.TagNumber;
}
