// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// Application-tagged ObjectIdentifier: tag 12 (0xC), always 4 data bytes.
//   Tag byte: (12 << 4) | 4 = 0xC4
//   Packed layout: objectType (10 bits) | instanceNumber (22 bits)
public class ObjectIdentifierCodecTests
{
    [Fact]
    public void Decode_ApplicationTagged_ReturnsObjectIdentifier()
    {
        // objectType=0, instance=1 → packed 0x00000001
        var reader = new AsduReader([0xC4, 0x00, 0x00, 0x00, 0x01]);
        ObjectIdentifier result = ObjectIdentifierCodec.Decode(ref reader);
        Assert.Equal(new ObjectIdentifier(0x00000001), result);
    }

    [Fact]
    public void Decode_ApplicationTagged_WithKnownPackedValue_RoundTrips()
    {
        // objectType=3 (AnalogValue), instance=1 → (3 << 22) | 1 = 0x00C00001
        var reader = new AsduReader([0xC4, 0x00, 0xC0, 0x00, 0x01]);
        ObjectIdentifier result = ObjectIdentifierCodec.Decode(ref reader);
        Assert.Equal(new ObjectIdentifier(0x00C00001), result);
    }

    [Fact]
    public void Decode_ContextTagged_ReturnsObjectIdentifier()
    {
        // Context tag 0, length 4: (0 << 4) | 0x08 | 4 = 0x0C, then 4 data bytes
        var reader = new AsduReader([0x0C, 0x00, 0x00, 0x00, 0x01]);
        ObjectIdentifier result = ObjectIdentifierCodec.Decode(ref reader, tagNumber: 0);
        Assert.Equal(new ObjectIdentifier(0x00000001), result);
    }
}
