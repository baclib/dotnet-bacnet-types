// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NameValueCollectionCodec :
    IAsduElementCodec<T::NameValueCollection>,
    IAsduConstructedCodec<T::NameValueCollection>
{
    public static T::NameValueCollection Decode(ref AsduReader reader)
    {
        return new T::NameValueCollection
        {
            Members = AsduElement.DecodeSequenceOf<NameValueCodec, T::NameValue>(ref reader, 0)
        };
    }

    public static T::NameValueCollection Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NameValueCollectionCodec, T::NameValueCollection>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NameValueCollection value)
    {
        AsduElement.EncodeSequenceOf<NameValueCodec, T::NameValue>(ref writer, 0, value.Members);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NameValueCollection value)
        => AsduConstructed.Encode<NameValueCollectionCodec, T::NameValueCollection>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NameValueCollection value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<NameValueCodec, T::NameValue>(0, value.Members);
        return length;
    }

    public static int GetEncodedLength(in T::NameValueCollection value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NameValueCollectionCodec, T::NameValueCollection>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
