// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ColorCommandCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ColorCommand>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ColorCommand>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ColorCommand Decode(ref NativeReader reader)
    {
        var _operation = Asdu.DecodePrimitive<ColorOperationCodec, global::Baclib.Bacnet.Types.Application.ColorOperation>(ref reader, 0);
        var _targetColor = Asdu.DecodeOptionalElement<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(ref reader, 1);
        var _targetColorTemperature = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 2);
        var _fadeTime = Asdu.DecodeOptional<ColorCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TFadeTime>(ref reader, 3);
        var _rampRate = Asdu.DecodeOptional<ColorCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TRampRate>(ref reader, 4);
        var _stepIncrement = Asdu.DecodeOptional<ColorCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TStepIncrement>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.ColorCommand
        {
            Operation = _operation,
            TargetColor = _targetColor,
            TargetColorTemperature = _targetColorTemperature,
            FadeTime = _fadeTime,
            RampRate = _rampRate,
            StepIncrement = _stepIncrement
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ColorCommand Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ColorCommand value)
    {
        Asdu.EncodePrimitive<ColorOperationCodec, global::Baclib.Bacnet.Types.Application.ColorOperation>(ref writer, 0, value.Operation);
        if (value.TargetColor.HasValue)
        {
            Asdu.EncodeElement<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(ref writer, 1, value.TargetColor.Value);
        }
        if (value.TargetColorTemperature.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.TargetColorTemperature.Value);
        }
        if (value.FadeTime.HasValue)
        {
            Asdu.EncodePrimitive<ColorCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TFadeTime>(ref writer, 3, value.FadeTime.Value);
        }
        if (value.RampRate.HasValue)
        {
            Asdu.EncodePrimitive<ColorCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TRampRate>(ref writer, 4, value.RampRate.Value);
        }
        if (value.StepIncrement.HasValue)
        {
            Asdu.EncodePrimitive<ColorCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TStepIncrement>(ref writer, 5, value.StepIncrement.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ColorCommand value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ColorCommand value)
    {
        return Asdu.GetPrimitiveLength<ColorOperationCodec, global::Baclib.Bacnet.Types.Application.ColorOperation>(0, value.Operation) + (value.TargetColor.HasValue ? Asdu.GetElementLength<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(1, value.TargetColor.Value) : 0) + (value.TargetColorTemperature.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.TargetColorTemperature.Value) : 0) + (value.FadeTime.HasValue ? Asdu.GetPrimitiveLength<ColorCommandTFadeTimeCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TFadeTime>(3, value.FadeTime.Value) : 0) + (value.RampRate.HasValue ? Asdu.GetPrimitiveLength<ColorCommandTRampRateCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TRampRate>(4, value.RampRate.Value) : 0) + (value.StepIncrement.HasValue ? Asdu.GetPrimitiveLength<ColorCommandTStepIncrementCodec, global::Baclib.Bacnet.Types.Application.ColorCommand.TStepIncrement>(5, value.StepIncrement.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ColorCommand value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
