// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class ChannelValueCodecTests
{
    [Fact]
    public void Decode_ApplicationTaggedUnsigned_ReturnsUnsignedChoice()
    {
        var reader = new AsduReader([0x21, 0x2A]);

        var result = ChannelValueCodec.Decode(ref reader);

        Assert.Equal(ChannelValue.Option.Unsigned, result.Choice);
        Assert.Equal(42u, result.Unsigned);
        Assert.True(reader.End);
    }

    [Fact]
    public void Decode_ContextTaggedLightingCommand_ReturnsLightingCommandChoice()
    {
        var reader = new AsduReader(
        [
            0x0E,
            0x09, 0x07,
            0x59, 0x08,
            0x0F
        ]);

        var result = ChannelValueCodec.Decode(ref reader);

        Assert.Equal(ChannelValue.Option.LightingCommand, result.Choice);
        Assert.Equal(LightingOperation.Warn, result.LightingCommand.Operation);
        Assert.False(result.LightingCommand.TargetLevel.HasValue);
        Assert.True(result.LightingCommand.Priority.HasValue);
        Assert.Equal((LightingCommand.TPriority)8, result.LightingCommand.Priority.Value);
        Assert.True(reader.End);
    }

    [Fact]
    public void Encode_ApplicationTaggedUnsigned_WritesExpected()
    {
        var value = ChannelValue.FromUnsigned(42u);
        byte[] expected = [0x21, 0x2A];
        var writer = new AsduWriter(expected.Length);

        ChannelValueCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }

    [Fact]
    public void Encode_ContextTaggedLightingCommand_WritesExpected()
    {
        var value = ChannelValue.FromLightingCommand(new LightingCommand
        {
            Operation = LightingOperation.Warn,
            TargetLevel = Optional<LightingCommand.TTargetLevel>.None,
            RampRate = Optional<LightingCommand.TRampRate>.None,
            StepIncrement = Optional<LightingCommand.TStepIncrement>.None,
            FadeTime = Optional<LightingCommand.TFadeTime>.None,
            Priority = new LightingCommand.TPriority(8)
        });
        byte[] expected =
        [
            0x0E,
            0x09, 0x07,
            0x59, 0x08,
            0x0F
        ];
        var writer = new AsduWriter(expected.Length);

        ChannelValueCodec.Encode(ref writer, value);

        Assert.Equal(expected, writer.ToArray());
    }
}