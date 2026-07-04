// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestCodec :
    IAsduElementCodec<T::WhoHasRequest>,
    IAsduConstructedCodec<T::WhoHasRequest>
{
    public static T::WhoHasRequest Decode(ref AsduReader reader)
    {
        return new T::WhoHasRequest
        {
            Limits = AsduElement.DecodeOptional<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(ref reader),
            Object = AsduElement.Decode<WhoHasRequestTObjectCodec, T::WhoHasRequest.TObject>(ref reader)
        };
    }

    public static T::WhoHasRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WhoHasRequestCodec, T::WhoHasRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WhoHasRequest value)
    {
        AsduElement.EncodeOptional<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(ref writer, value.Limits);
        AsduElement.Encode<WhoHasRequestTObjectCodec, T::WhoHasRequest.TObject>(ref writer, value.Object);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WhoHasRequest value)
        => AsduConstructed.Encode<WhoHasRequestCodec, T::WhoHasRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WhoHasRequest value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(value.Limits);
        length += AsduElement.GetEncodedLength<WhoHasRequestTObjectCodec, T::WhoHasRequest.TObject>(value.Object);
        return length;
    }

    public static int GetEncodedLength(in T::WhoHasRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WhoHasRequestCodec, T::WhoHasRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (WhoHasRequestTLimitsCodec.Matches(ref reader))
        {
            return true;
        }
        return WhoHasRequestTObjectCodec.Matches(ref reader);
    }
}
