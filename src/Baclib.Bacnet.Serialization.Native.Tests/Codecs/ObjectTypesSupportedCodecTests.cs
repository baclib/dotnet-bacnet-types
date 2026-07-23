// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

// ObjectTypesSupported is a variable-array bit string (max 1024 bits, byte[] storage, length field).
public class ObjectTypesSupportedCodecTests
{
    public static TheoryData<byte[], ushort> Samples =>
        new()
        {
            { [0x03, 0x01, 0x00], 18 },
            { [0xFF, 0xFF, 0xFF], 24 },
            { [0xFF, 0xFF, 0xFF, 0xFF], 32 },
        };

    [Theory]
    [MemberData(nameof(Samples))]
    public void RoundTrip_EncodeValueDecodeValue_PreservesValue(byte[] flags, ushort count)
    {
        var original = new ObjectTypesSupported(flags, count);

        var buffer = new byte[ObjectTypesSupportedCodec.GetEncodedValueLength(original)];
        ObjectTypesSupportedCodec.EncodeValue(buffer, original);
        var decoded = ObjectTypesSupportedCodec.DecodeValue(buffer);

        Assert.Equal(original.Length, decoded.Length);
        Assert.True(original.Flags.AsSpan().SequenceEqual(decoded.Flags));
    }

    [Fact]
    public void RoundTrip_MultiByte_PreservesValue()
    {
        var original = new ObjectTypesSupported([0x0F, 0xF0, 0x0F, 0x0F], 28);

        var buffer = new byte[ObjectTypesSupportedCodec.GetEncodedValueLength(original)];
        ObjectTypesSupportedCodec.EncodeValue(buffer, original);
        var decoded = ObjectTypesSupportedCodec.DecodeValue(buffer);

        Assert.Equal(original.Length, decoded.Length);
        Assert.True(original.Flags.AsSpan().SequenceEqual(decoded.Flags));
    }
}
