// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class NullCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsNull()
    {
        // Application tag 0 (Null), length 0: 0x00
        var reader = new AsduReader([0x00]);
        var result = NullCodec.Decode(ref reader);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsNull()
    {
        // Context tag 0, length 0: 0x08
        var reader = new AsduReader([0x08]);
        var result = NullCodec.Decode(ref reader, tagNumber: 0);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void Decode_ContextTagged_Tag5_ReturnsNull()
    {
        // Context tag 5, length 0: (5 << 4) | 0x08 = 0x58
        var reader = new AsduReader([0x58]);
        var result = NullCodec.Decode(ref reader, tagNumber: 5);
        Assert.Equal(Null.Value, result);
    }

    [Fact]
    public void GetEncodedSize_ApplicationTagged_Returns1()
    {
        var result = NullCodec.GetEncodedLength(Null.Value);
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetEncodedSize_ContextTagged_Returns1()
    {
        var result = NullCodec.GetEncodedLength(Null.Value, tagNumber: 0);
        Assert.Equal(1, result);
    }
}
