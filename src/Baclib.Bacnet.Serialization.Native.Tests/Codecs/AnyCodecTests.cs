// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Tests.Codecs;

public class AnyCodecTests
{
    [Fact]
    public void GetEncodedLength_StaticFastPath_ForBoolean_UsesBooleanCodec()
    {
        var any = Any.FromValue(true);

        var length = AnyCodec.GetEncodedLength(any);

        Assert.Equal(BooleanCodec.GetEncodedLength(true), length);
    }

    [Fact]
    public void Encode_DynamicRegistryFallback_ForCustomType_WritesExpectedBytes()
    {
        var registry = AnyCodecRegistry.Build(builder =>
            builder.RegisterDynamic(new CustomCounterCodec()));

        var any = Any.FromValue(new CustomCounter(7));
        var writer = new AsduWriter(AnyCodec.GetEncodedLength(any, registry));

        AnyCodec.Encode(ref writer, any, registry);

        Assert.Equal([0x21, 0x07], writer.WrittenSpan.ToArray());
    }

    [Fact]
    public void Materialize_StaticType_FromEncodedBytes_Succeeds()
    {
        var any = Any.FromEncoded([0x11]);

        var success = AnyMaterializer.TryDecodeAs(any, out bool value);

        Assert.True(success);
        Assert.True(value);
    }

    [Fact]
    public void Materialize_DynamicType_FromEncodedBytes_UsesRegistry()
    {
        var registry = AnyCodecRegistry.Build(builder =>
            builder.RegisterDynamic(new CustomCounterCodec()));

        var any = Any.FromEncoded([0x21, 0x09]);

        var success = AnyMaterializer.TryDecodeAs(any, typeof(CustomCounter), out var value, registry);

        Assert.True(success);
        Assert.NotNull(value);
        Assert.IsType<CustomCounter>(value);
        Assert.Equal((byte)9, ((CustomCounter)value).Value);
    }

    private readonly record struct CustomCounter(byte Value);

    private sealed class CustomCounterCodec : IAsduElementDynamicCodec<CustomCounter>
    {
        public CustomCounter Decode(ref AsduReader reader)
        {
            var element = reader.ReadElement();
            if (element.Length != 2 || element[0] != 0x21)
            {
                throw new InvalidDataException("Expected one-byte unsigned element.");
            }

            return new CustomCounter(element[1]);
        }

        public void Encode(ref AsduWriter writer, in CustomCounter value)
        {
            writer.WriteByte(0x21);
            writer.WriteByte(value.Value);
        }

        public int GetLength(in CustomCounter value)
            => 2;

        public bool Matches(ref AsduReader reader)
            => reader.PeekApplicationTag(ApplicationTagNumber.Unsigned);
    }
}
