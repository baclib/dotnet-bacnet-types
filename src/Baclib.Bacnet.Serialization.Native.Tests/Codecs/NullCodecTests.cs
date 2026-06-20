// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class NullCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsNull()
    {
        // Application tag 0 (Null), length 0: 0x00
        var reader = new NativeReader([0x00]);
        var result = NullCodec.Instance.Decode(ref reader);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsNull()
    {
        // Context tag 0, length 0: 0x08
        var reader = new NativeReader([0x08]);
        var result = NullCodec.Instance.Decode(ref reader, tagNumber: 0);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void Decode_ContextTagged_Tag5_ReturnsNull()
    {
        // Context tag 5, length 0: (5 << 4) | 0x08 = 0x58
        var reader = new NativeReader([0x58]);
        var result = NullCodec.Instance.Decode(ref reader, tagNumber: 5);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void DecodeOptional_PresentValue_ReturnsNull()
    {
        var reader = new NativeReader([0x00]);
        Optional<Null> result = NullCodec.Instance.DecodeOptional(ref reader);
        Assert.True(result.HasValue);
        Assert.Equal(Null.Value, result.Value);
    }

    [Fact]
    public void DecodeOptional_AbsentValue_ReturnsEmpty()
    {
        // Boolean tag (0x11) — null decoder should not match.
        var reader = new NativeReader([0x11]);
        Optional<Null> result = NullCodec.Instance.DecodeOptional(ref reader);
        Assert.False(result.HasValue);
    }

    [Fact]
    public void DecodeOptional_ContextTagged_ReturnsNull()
    {
        // Context tag 2, length 0: (2 << 4) | 0x08 = 0x28
        var reader = new NativeReader([0x28]);
        Optional<Null> result = NullCodec.Instance.DecodeOptional(ref reader, tagNumber: 2);
        Assert.True(result.HasValue);
        Assert.Equal(Null.Value, result.Value);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_Returns1()
    {
        var result = NullCodec.Instance.GetEncodedSize(Null.Value);
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetEncodedSize_ContextTagged_Returns1()
    {
        var result = NullCodec.Instance.GetEncodedSize(tagNumber: 0, Null.Value);
        Assert.Equal(1, result);
    }
}
