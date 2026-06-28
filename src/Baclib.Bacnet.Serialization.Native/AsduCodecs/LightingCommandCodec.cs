// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LightingCommandCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LightingCommand>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LightingCommand>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LightingCommand Decode(ref NativeReader reader)
    {
        var _operation = Asdu.DecodePrimitive<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(ref reader, 0);
        var _targetLevel = Asdu.DecodeOptional<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref reader, 1);
        var _rampRate = Asdu.DecodeOptional<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref reader, 2);
        var _stepIncrement = Asdu.DecodeOptional<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref reader, 3);
        var _fadeTime = Asdu.DecodeOptional<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref reader, 4);
        var _priority = Asdu.DecodeOptional<LightingCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TPriority>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.LightingCommand
        {
            Operation = _operation,
            TargetLevel = _targetLevel,
            RampRate = _rampRate,
            StepIncrement = _stepIncrement,
            FadeTime = _fadeTime,
            Priority = _priority
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LightingCommand Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LightingCommand value)
    {
        Asdu.EncodePrimitive<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(ref writer, 0, value.Operation);
        if (value.TargetLevel.HasValue)
        {
            Asdu.EncodePrimitive<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(ref writer, 1, value.TargetLevel.Value);
        }
        if (value.RampRate.HasValue)
        {
            Asdu.EncodePrimitive<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(ref writer, 2, value.RampRate.Value);
        }
        if (value.StepIncrement.HasValue)
        {
            Asdu.EncodePrimitive<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(ref writer, 3, value.StepIncrement.Value);
        }
        if (value.FadeTime.HasValue)
        {
            Asdu.EncodePrimitive<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(ref writer, 4, value.FadeTime.Value);
        }
        if (value.Priority.HasValue)
        {
            Asdu.EncodePrimitive<LightingCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TPriority>(ref writer, 5, value.Priority.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LightingCommand value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LightingCommand value)
    {
        return Asdu.GetPrimitiveLength<LightingOperationCodec, global::Baclib.Bacnet.Types.Application.LightingOperation>(0, value.Operation) + (value.TargetLevel.HasValue ? Asdu.GetPrimitiveLength<LightingCommandTTargetLevelCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TTargetLevel>(1, value.TargetLevel.Value) : 0) + (value.RampRate.HasValue ? Asdu.GetPrimitiveLength<LightingCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TRampRate>(2, value.RampRate.Value) : 0) + (value.StepIncrement.HasValue ? Asdu.GetPrimitiveLength<LightingCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TStepIncrement>(3, value.StepIncrement.Value) : 0) + (value.FadeTime.HasValue ? Asdu.GetPrimitiveLength<LightingCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TFadeTime>(4, value.FadeTime.Value) : 0) + (value.Priority.HasValue ? Asdu.GetPrimitiveLength<LightingCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.LightingCommand.TPriority>(5, value.Priority.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LightingCommand value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
