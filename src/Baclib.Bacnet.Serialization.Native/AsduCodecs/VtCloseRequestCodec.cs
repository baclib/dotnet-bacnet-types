// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtCloseRequestCodec :
    IAsduElementCodec<T::VtCloseRequest>,
    IAsduConstructedCodec<T::VtCloseRequest>
{
    public static T::VtCloseRequest Decode(ref AsduReader reader)
    {
        return new T::VtCloseRequest
        {
            ListOfRemoteVtSessionIdentifiers = AsduElement.DecodeSequenceOf<Unsigned8Codec, byte>(ref reader)
        };
    }

    public static T::VtCloseRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtCloseRequestCodec, T::VtCloseRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtCloseRequest value)
    {
        AsduElement.EncodeSequenceOf<Unsigned8Codec, byte>(ref writer, value.ListOfRemoteVtSessionIdentifiers);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtCloseRequest value)
        => AsduConstructed.Encode<VtCloseRequestCodec, T::VtCloseRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtCloseRequest value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<Unsigned8Codec, byte>(value.ListOfRemoteVtSessionIdentifiers);
        return length;
    }

    public static int GetEncodedLength(in T::VtCloseRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtCloseRequestCodec, T::VtCloseRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned8Codec.Matches(ref reader);
    }
}
