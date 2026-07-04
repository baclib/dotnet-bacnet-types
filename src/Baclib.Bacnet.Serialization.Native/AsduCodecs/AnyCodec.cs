// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Placeholder implementation. Replace with full Any handling.
public sealed class AnyCodec :
    IAsduElementCodec<T.Any>,
    IAsduPrimitiveCodec<T.Any>
{
    public static T.Any Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<AnyCodec, T.Any>(ref reader);

    public static T.Any Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<AnyCodec, T.Any>(ref reader, tagNumber);

    public static T.Any DecodeValue(ReadOnlySpan<byte> source)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any decoder.");

    public static void Encode(ref AsduWriter writer, in T.Any value)
        => AsduPrimitive.Encode<AnyCodec, T.Any>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
        => AsduPrimitive.Encode<AnyCodec, T.Any>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any encoder.");

    public static int GetEncodedValueLength(in T.Any value)
        => throw new NotImplementedException("AnyCodec is a placeholder. Provide a full Any length calculator.");

    public static int GetEncodedLength(in T.Any value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in T.Any value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.Null;
}
