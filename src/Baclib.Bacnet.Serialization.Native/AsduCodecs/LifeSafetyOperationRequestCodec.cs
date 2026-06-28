// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LifeSafetyOperationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest Decode(ref NativeReader reader)
    {
        var _requestingProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _requestingSource = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 1);
        var _request = Asdu.DecodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref reader, 2);
        var _objectIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest
        {
            RequestingProcessIdentifier = _requestingProcessIdentifier,
            RequestingSource = _requestingSource,
            Request = _request,
            ObjectIdentifier = _objectIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.RequestingProcessIdentifier);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 1, value.RequestingSource);
        Asdu.EncodePrimitive<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(ref writer, 2, value.Request);
        if (value.ObjectIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 3, value.ObjectIdentifier.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.RequestingProcessIdentifier) + Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(1, value.RequestingSource) + Asdu.GetPrimitiveLength<LifeSafetyOperationCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyOperation>(2, value.Request) + (value.ObjectIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(3, value.ObjectIdentifier.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LifeSafetyOperationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
