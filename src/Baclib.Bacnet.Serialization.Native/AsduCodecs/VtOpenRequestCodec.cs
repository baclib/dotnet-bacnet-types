// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtOpenRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtOpenRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtOpenRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(VtClassCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.VtOpenRequest Decode(ref NativeReader reader)
    {
        var _vtClass = Asdu.DecodePrimitive<VtClassCodec, global::Baclib.Bacnet.Types.Application.VtClass>(ref reader);
        var _localVtSessionIdentifier = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.VtOpenRequest
        {
            VtClass = _vtClass,
            LocalVtSessionIdentifier = _localVtSessionIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtOpenRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtOpenRequest value)
    {
        Asdu.EncodePrimitive<VtClassCodec, global::Baclib.Bacnet.Types.Application.VtClass>(ref writer, value.VtClass);
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, value.LocalVtSessionIdentifier);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtOpenRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtOpenRequest value)
    {
        return Asdu.GetEncodedLength<VtClassCodec, global::Baclib.Bacnet.Types.Application.VtClass>(value.VtClass) + Asdu.GetEncodedLength<Unsigned8Codec, byte>(value.LocalVtSessionIdentifier);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtOpenRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
