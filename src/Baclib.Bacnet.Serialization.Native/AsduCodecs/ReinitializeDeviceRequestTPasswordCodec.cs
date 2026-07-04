// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to CharacterStringCodec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword.
public sealed class ReinitializeDeviceRequestTPasswordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>
{
    public static global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword)CharacterStringCodec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value)
        => AsduPrimitive.Encode<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value)
        => AsduPrimitive.Encode<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value)
        => CharacterStringCodec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value)
        => CharacterStringCodec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => CharacterStringCodec.TagNumber;
}
