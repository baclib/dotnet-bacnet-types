// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.Tests.AsduCodecs;

public class AnyCodecTests
{
	[Fact]
	public void Encode_ApplicationTaggedUnsigned_WritesExpectedAsdu()
	{
		var value = T.Any.FromValue(42u);
		byte[] expected = [0x21, 0x2A];
		var writer = new AsduWriter(expected.Length);

		AnyCodec.Encode(ref writer, value);

		Assert.Equal(expected, writer.ToArray());
		Assert.Equal(expected.Length, writer.WrittenLength);
	}

	[Fact]
	public void Encode_ContextTaggedUnsigned_WritesExpectedAsdu()
	{
		var value = T.Any.FromValue(42u);
		byte[] expected = [0x0E, 0x21, 0x2A, 0x0F];
		var writer = new AsduWriter(expected.Length);

		AnyCodec.Encode(ref writer, tagNumber: 0, value);

		Assert.Equal(expected, writer.ToArray());
		Assert.Equal(expected.Length, writer.WrittenLength);
	}

	[Fact]
	public void Encode_ConstructedDeviceObjectPropertyReference_WritesExpectedAsdu()
	{
		var value = T.Any.FromValue(new DeviceObjectPropertyReference
		{
			ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
			PropertyIdentifier = PropertyIdentifier.All,
			PropertyArrayIndex = Optional<uint>.None,
			DeviceIdentifier = Optional<ObjectIdentifier>.None
		});
		byte[] expected =
		[
			0x0C, 0x00, 0x00, 0x00, 0x02,
			0x19, 0x08
		];
		var writer = new AsduWriter(expected.Length);

		AnyCodec.Encode(ref writer, value);

		Assert.Equal(expected, writer.ToArray());
		Assert.Equal(expected.Length, writer.WrittenLength);
	}

	[Fact]
	public void Encode_ContextTaggedConstructedDeviceObjectPropertyReference_WritesExpectedAsdu()
	{
		var value = T.Any.FromValue(new DeviceObjectPropertyReference
		{
			ObjectIdentifier = new ObjectIdentifier(ObjectType.AnalogInput, 2),
			PropertyIdentifier = PropertyIdentifier.All,
			PropertyArrayIndex = Optional<uint>.None,
			DeviceIdentifier = Optional<ObjectIdentifier>.None
		});
		byte[] expected =
		[
			0x0E,
			0x0C, 0x00, 0x00, 0x00, 0x02,
			0x19, 0x08,
			0x0F
		];
		var writer = new AsduWriter(expected.Length);

		AnyCodec.Encode(ref writer, tagNumber: 0, value);

		Assert.Equal(expected, writer.ToArray());
		Assert.Equal(expected.Length, writer.WrittenLength);
	}

	[Fact]
	public void Decode_ApplicationTaggedBoolean_PreservesEncodedData()
	{
		byte[] bytes = [0x11];
		var reader = new AsduReader(bytes);

		var result = AnyCodec.Decode(ref reader);

		AssertEncoded(bytes, result);
		Assert.True(reader.End);
		Assert.Equal(bytes.Length, reader.Position);
	}

	[Fact]
	public void Decode_ApplicationTaggedCharacterString_PreservesEncodedData()
	{
		byte[] bytes = [0x75, 0x06, 0x00, 0x48, 0x65, 0x6C, 0x6C, 0x6F];
		var reader = new AsduReader(bytes);

		var result = AnyCodec.Decode(ref reader);

		AssertEncoded(bytes, result);
		Assert.True(reader.End);
		Assert.Equal(bytes.Length, reader.Position);
	}

	[Fact]
	public void Decode_ContextTaggedPrimitive_PreservesEncodedData()
	{
		byte[] bytes = [0x09, 0x2A];
		var reader = new AsduReader(bytes);

		var result = AnyCodec.Decode(ref reader);

		AssertEncoded(bytes, result);
		Assert.True(reader.End);
		Assert.Equal(bytes.Length, reader.Position);
	}

	[Fact]
	public void Decode_ContextTaggedDeviceObjectPropertyReference_PreservesEncodedData()
	{
		byte[] bytes =
		[
			0x0E,
			0x0C, 0x00, 0x00, 0x00, 0x02,
			0x19, 0x08,
			0x0F
		];
		var reader = new AsduReader(bytes);

		var result = AnyCodec.Decode(ref reader, 0);

		AssertEncoded(bytes, result);
		Assert.True(reader.End);
		Assert.Equal(bytes.Length, reader.Position);
	}

	[Fact]
	public void Decode_ContextTaggedAccumulatorRecord_PreservesEncodedData()
	{
		byte[] bytes =
		[
			0x0E,
			0x0E,
			0xA4, 0x7C, 0x06, 0x12, 0x02,
			0xB4, 0x0E, 0x1E, 0x05, 0x00,
			0x0F,
			0x19, 0x2A,
			0x2A, 0x01, 0x2C,
			0x39, 0x00,
			0x0F
		];
		var reader = new AsduReader(bytes);

		var result = AnyCodec.Decode(ref reader, 0);

		AssertEncoded(bytes, result);
		Assert.True(reader.End);
		Assert.Equal(bytes.Length, reader.Position);
	}

	private static void AssertEncoded(byte[] expected, T.Any value)
	{
		Assert.True(value.IsEncoded);
		Assert.True(value.TryGetValue<T.Any.AsduEncodedData>(out var encoded));
		Assert.Equal(typeof(T.Any.AsduEncodedData), value.ValueType);
		Assert.Equal(expected, encoded.Memory.ToArray());
		Assert.Equal(expected, value.EncodedData.Memory.ToArray());
	}
}
