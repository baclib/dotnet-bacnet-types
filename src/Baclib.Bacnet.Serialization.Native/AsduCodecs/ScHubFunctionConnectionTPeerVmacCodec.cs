// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to OctetStringCodec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac.
public sealed class ScHubFunctionConnectionTPeerVmacCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>
{
    public static global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac)OctetStringCodec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value)
        => AsduPrimitive.Encode<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value)
        => AsduPrimitive.Encode<ScHubFunctionConnectionTPeerVmacCodec, global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value)
        => OctetStringCodec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value)
        => OctetStringCodec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ScHubFunctionConnection.TPeerVmac value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => OctetStringCodec.TagNumber;
}
