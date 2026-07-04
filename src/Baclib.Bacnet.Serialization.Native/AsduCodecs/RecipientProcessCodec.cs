// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class RecipientProcessCodec :
    IAsduElementCodec<T::RecipientProcess>,
    IAsduConstructedCodec<T::RecipientProcess>
{
    public static T::RecipientProcess Decode(ref AsduReader reader)
    {
        return new T::RecipientProcess
        {
            Recipient = AsduElement.Decode<RecipientCodec, T::Recipient>(ref reader, 0),
            ProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 1)
        };
    }

    public static T::RecipientProcess Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<RecipientProcessCodec, T::RecipientProcess>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::RecipientProcess value)
    {
        AsduElement.Encode<RecipientCodec, T::Recipient>(ref writer, 0, value.Recipient);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 1, value.ProcessIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::RecipientProcess value)
        => AsduConstructed.Encode<RecipientProcessCodec, T::RecipientProcess>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::RecipientProcess value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RecipientCodec, T::Recipient>(0, value.Recipient);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(1, value.ProcessIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::RecipientProcess value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<RecipientProcessCodec, T::RecipientProcess>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
