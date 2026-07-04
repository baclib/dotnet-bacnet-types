// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtOpenRequestCodec :
    IAsduElementCodec<T::VtOpenRequest>,
    IAsduConstructedCodec<T::VtOpenRequest>
{
    public static T::VtOpenRequest Decode(ref AsduReader reader)
    {
        return new T::VtOpenRequest
        {
            VtClass = AsduElement.Decode<VtClassCodec, T::VtClass>(ref reader),
            LocalVtSessionIdentifier = AsduElement.Decode<Unsigned8Codec, byte>(ref reader)
        };
    }

    public static T::VtOpenRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtOpenRequestCodec, T::VtOpenRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtOpenRequest value)
    {
        AsduElement.Encode<VtClassCodec, T::VtClass>(ref writer, value.VtClass);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.LocalVtSessionIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtOpenRequest value)
        => AsduConstructed.Encode<VtOpenRequestCodec, T::VtOpenRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtOpenRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<VtClassCodec, T::VtClass>(value.VtClass);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.LocalVtSessionIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::VtOpenRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtOpenRequestCodec, T::VtOpenRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return VtClassCodec.Matches(ref reader);
    }
}
