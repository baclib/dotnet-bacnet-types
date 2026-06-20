// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;




public interface INativeCodec
{
};


/// <summary>
/// Encodes and decodes ASN.1 for a specific BACnet value type.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public interface INativeCodec<T> : INativeCodec
{

	/// <summary>
	/// Gets the exact encoded size in bytes for <paramref name="value"/>.
	/// </summary>
	int GetEncodedSize(in T value);

	/// <summary>
	/// Gets the exact encoded size in bytes for <paramref name="value"/> when encoded with a context tag.
	/// </summary>
	/// <param name="tagNumber">The context tag number.</param>
	int GetEncodedSize(byte tagNumber, in T value);

	/// <summary>
	/// Writes the ASN.1 encoding of <paramref name="value"/> to <paramref name="encoder"/>.
	/// </summary>
	void Encode(ref AsduEncoder encoder, in T value);

	/// <summary>
	/// Writes the ASN.1 encoding of <paramref name="value"/> as a context-tagged value to <paramref name="encoder"/>.
	/// </summary>
	/// <param name="tagNumber">The context tag number.</param>
	void Encode(ref AsduEncoder encoder, byte tagNumber, in T value);

	/// <summary>
	/// Decodes a value from the current reader position.
	/// </summary>
	T Decode(ref NativeReader decoder);

	/// <summary>
	/// Decodes a context-tagged value from the current reader position.
	/// </summary>
	/// <param name="tagNumber">The expected context tag number.</param>
	T Decode(ref NativeReader decoder, byte tagNumber);

	/// <summary>
	/// Decodes an optional value of type T from the current reader position.
	/// </summary>
	Optional<T> DecodeOptional(ref NativeReader decoder);

	/// <summary>
	/// Decodes an optional context-tagged value of type T from the current reader position.
	/// </summary>
	/// <param name="tagNumber">The expected context tag number.</param>
	Optional<T> DecodeOptional(ref NativeReader decoder, byte tagNumber);
}

