// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LightingCommandCodec :
    IAsduElementCodec<T::LightingCommand>,
    IAsduConstructedCodec<T::LightingCommand>
{
    public static T::LightingCommand Decode(ref AsduReader reader)
    {
        return new T::LightingCommand
        {
            Operation = AsduElement.Decode<LightingOperationCodec, T::LightingOperation>(ref reader, 0),
            TargetLevel = AsduElement.DecodeOptional<LightingCommandTTargetLevelCodec, T::LightingCommand.TTargetLevel>(ref reader, 1),
            RampRate = AsduElement.DecodeOptional<LightingCommandTRampRateCodec, T::LightingCommand.TRampRate>(ref reader, 2),
            StepIncrement = AsduElement.DecodeOptional<LightingCommandTStepIncrementCodec, T::LightingCommand.TStepIncrement>(ref reader, 3),
            FadeTime = AsduElement.DecodeOptional<LightingCommandTFadeTimeCodec, T::LightingCommand.TFadeTime>(ref reader, 4),
            Priority = AsduElement.DecodeOptional<LightingCommandTPriorityCodec, T::LightingCommand.TPriority>(ref reader, 5)
        };
    }

    public static T::LightingCommand Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LightingCommandCodec, T::LightingCommand>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LightingCommand value)
    {
        AsduElement.Encode<LightingOperationCodec, T::LightingOperation>(ref writer, 0, value.Operation);
        AsduElement.EncodeOptional<LightingCommandTTargetLevelCodec, T::LightingCommand.TTargetLevel>(ref writer, 1, value.TargetLevel);
        AsduElement.EncodeOptional<LightingCommandTRampRateCodec, T::LightingCommand.TRampRate>(ref writer, 2, value.RampRate);
        AsduElement.EncodeOptional<LightingCommandTStepIncrementCodec, T::LightingCommand.TStepIncrement>(ref writer, 3, value.StepIncrement);
        AsduElement.EncodeOptional<LightingCommandTFadeTimeCodec, T::LightingCommand.TFadeTime>(ref writer, 4, value.FadeTime);
        AsduElement.EncodeOptional<LightingCommandTPriorityCodec, T::LightingCommand.TPriority>(ref writer, 5, value.Priority);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LightingCommand value)
        => AsduConstructed.Encode<LightingCommandCodec, T::LightingCommand>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LightingCommand value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<LightingOperationCodec, T::LightingOperation>(0, value.Operation);
        length += AsduElement.GetOptionalEncodedLength<LightingCommandTTargetLevelCodec, T::LightingCommand.TTargetLevel>(1, value.TargetLevel);
        length += AsduElement.GetOptionalEncodedLength<LightingCommandTRampRateCodec, T::LightingCommand.TRampRate>(2, value.RampRate);
        length += AsduElement.GetOptionalEncodedLength<LightingCommandTStepIncrementCodec, T::LightingCommand.TStepIncrement>(3, value.StepIncrement);
        length += AsduElement.GetOptionalEncodedLength<LightingCommandTFadeTimeCodec, T::LightingCommand.TFadeTime>(4, value.FadeTime);
        length += AsduElement.GetOptionalEncodedLength<LightingCommandTPriorityCodec, T::LightingCommand.TPriority>(5, value.Priority);
        return length;
    }

    public static int GetEncodedLength(in T::LightingCommand value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LightingCommandCodec, T::LightingCommand>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
