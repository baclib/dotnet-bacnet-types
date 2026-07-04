// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LifeSafetyOperationInfoCodec :
    IAsduElementCodec<T::LifeSafetyOperationInfo>,
    IAsduConstructedCodec<T::LifeSafetyOperationInfo>
{
    public static T::LifeSafetyOperationInfo Decode(ref AsduReader reader)
    {
        return new T::LifeSafetyOperationInfo
        {
            RequestingProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            Request = AsduElement.Decode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref reader, 1)
        };
    }

    public static T::LifeSafetyOperationInfo Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LifeSafetyOperationInfoCodec, T::LifeSafetyOperationInfo>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LifeSafetyOperationInfo value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.RequestingProcessIdentifier);
        AsduElement.Encode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref writer, 1, value.Request);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LifeSafetyOperationInfo value)
        => AsduConstructed.Encode<LifeSafetyOperationInfoCodec, T::LifeSafetyOperationInfo>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LifeSafetyOperationInfo value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.RequestingProcessIdentifier);
        length += AsduElement.GetEncodedLength<LifeSafetyOperationCodec, T::LifeSafetyOperation>(1, value.Request);
        return length;
    }

    public static int GetEncodedLength(in T::LifeSafetyOperationInfo value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LifeSafetyOperationInfoCodec, T::LifeSafetyOperationInfo>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
