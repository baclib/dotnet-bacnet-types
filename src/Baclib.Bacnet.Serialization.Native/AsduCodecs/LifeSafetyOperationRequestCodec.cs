// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LifeSafetyOperationRequestCodec :
    IAsduElementCodec<T::LifeSafetyOperationRequest>,
    IAsduConstructedCodec<T::LifeSafetyOperationRequest>
{
    public static T::LifeSafetyOperationRequest Decode(ref AsduReader reader)
    {
        return new T::LifeSafetyOperationRequest
        {
            RequestingProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            RequestingSource = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 1),
            Request = AsduElement.Decode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref reader, 2),
            ObjectIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 3)
        };
    }

    public static T::LifeSafetyOperationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LifeSafetyOperationRequestCodec, T::LifeSafetyOperationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LifeSafetyOperationRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.RequestingProcessIdentifier);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 1, value.RequestingSource);
        AsduElement.Encode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref writer, 2, value.Request);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 3, value.ObjectIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LifeSafetyOperationRequest value)
        => AsduConstructed.Encode<LifeSafetyOperationRequestCodec, T::LifeSafetyOperationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LifeSafetyOperationRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.RequestingProcessIdentifier);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(1, value.RequestingSource);
        length += AsduElement.GetEncodedLength<LifeSafetyOperationCodec, T::LifeSafetyOperation>(2, value.Request);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(3, value.ObjectIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::LifeSafetyOperationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LifeSafetyOperationRequestCodec, T::LifeSafetyOperationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
