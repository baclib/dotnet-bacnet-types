// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Placeholder implementation. Replace with full Any handling.
public sealed class AnyCodec :
    IAsduElementCodec<T.Any>,
    IAsduPrimitiveCodec<T.Any>
{
    public static T.Any Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<AnyCodec, T.Any>(ref reader);

    public static T.Any Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<AnyCodec, T.Any>(ref reader, tagNumber);

    public static T.Any DecodeValue(ReadOnlySpan<byte> source)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static void Encode(ref NativeWriter writer, in T.Any value)
        => Asdu.EncodePrimitive<AnyCodec, T.Any>(ref writer, value);

    public static void Encode(ref NativeWriter writer, byte tagNumber, in T.Any value)
        => Asdu.EncodePrimitive<AnyCodec, T.Any>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any encoder.");

    public static int GetEncodedValueLength(in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any length calculator.");

    public static int GetLength(in T.Any value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetLength(in T.Any value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref NativeReader reader)
        => reader.PeekPrimitiveTag(TagNumber);

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekPrimitiveTag(tagNumber);

    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.Null;
}
