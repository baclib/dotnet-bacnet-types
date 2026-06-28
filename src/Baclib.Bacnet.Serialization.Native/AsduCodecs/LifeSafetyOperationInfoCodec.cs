// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LifeSafetyOperationInfoCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo Decode(ref NativeReader reader)
    {
        var _requestingProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _request = Asdu.DecodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo
        {
            RequestingProcessIdentifier = _requestingProcessIdentifier,
            Request = _request
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.RequestingProcessIdentifier);
        Asdu.EncodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref writer, 1, value.Request);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.RequestingProcessIdentifier) + Asdu.GetPrimitiveLength<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(1, value.Request);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationInfo value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
