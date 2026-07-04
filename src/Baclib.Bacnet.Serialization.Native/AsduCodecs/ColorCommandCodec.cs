// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ColorCommandCodec :
    IAsduElementCodec<T::ColorCommand>,
    IAsduConstructedCodec<T::ColorCommand>
{
    public static T::ColorCommand Decode(ref AsduReader reader)
    {
        return new T::ColorCommand
        {
            Operation = AsduElement.Decode<ColorOperationCodec, T::ColorOperation>(ref reader, 0),
            TargetColor = AsduElement.DecodeOptional<XyColorCodec, T::XyColor>(ref reader, 1),
            TargetColorTemperature = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            FadeTime = AsduElement.DecodeOptional<ColorCommandTFadeTimeCodec, T::ColorCommand.TFadeTime>(ref reader, 3),
            RampRate = AsduElement.DecodeOptional<ColorCommandTRampRateCodec, T::ColorCommand.TRampRate>(ref reader, 4),
            StepIncrement = AsduElement.DecodeOptional<ColorCommandTStepIncrementCodec, T::ColorCommand.TStepIncrement>(ref reader, 5)
        };
    }

    public static T::ColorCommand Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ColorCommandCodec, T::ColorCommand>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ColorCommand value)
    {
        AsduElement.Encode<ColorOperationCodec, T::ColorOperation>(ref writer, 0, value.Operation);
        AsduElement.EncodeOptional<XyColorCodec, T::XyColor>(ref writer, 1, value.TargetColor);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.TargetColorTemperature);
        AsduElement.EncodeOptional<ColorCommandTFadeTimeCodec, T::ColorCommand.TFadeTime>(ref writer, 3, value.FadeTime);
        AsduElement.EncodeOptional<ColorCommandTRampRateCodec, T::ColorCommand.TRampRate>(ref writer, 4, value.RampRate);
        AsduElement.EncodeOptional<ColorCommandTStepIncrementCodec, T::ColorCommand.TStepIncrement>(ref writer, 5, value.StepIncrement);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ColorCommand value)
        => AsduConstructed.Encode<ColorCommandCodec, T::ColorCommand>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ColorCommand value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ColorOperationCodec, T::ColorOperation>(0, value.Operation);
        length += AsduElement.GetOptionalEncodedLength<XyColorCodec, T::XyColor>(1, value.TargetColor);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.TargetColorTemperature);
        length += AsduElement.GetOptionalEncodedLength<ColorCommandTFadeTimeCodec, T::ColorCommand.TFadeTime>(3, value.FadeTime);
        length += AsduElement.GetOptionalEncodedLength<ColorCommandTRampRateCodec, T::ColorCommand.TRampRate>(4, value.RampRate);
        length += AsduElement.GetOptionalEncodedLength<ColorCommandTStepIncrementCodec, T::ColorCommand.TStepIncrement>(5, value.StepIncrement);
        return length;
    }

    public static int GetEncodedLength(in T::ColorCommand value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ColorCommandCodec, T::ColorCommand>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
