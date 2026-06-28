// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEventInformationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetEventInformationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetEventInformationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return !reader.End;
    }

    public static global::Baclib.Bacnet.Types.Application.GetEventInformationRequest Decode(ref NativeReader reader)
    {
        var _lastReceivedObjectIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.GetEventInformationRequest
        {
            LastReceivedObjectIdentifier = _lastReceivedObjectIdentifier
        };
    }

    public static global::Baclib.Bacnet.Types.Application.GetEventInformationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.GetEventInformationRequest value)
    {
        if (value.LastReceivedObjectIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.LastReceivedObjectIdentifier.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetEventInformationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEventInformationRequest value)
    {
        return (value.LastReceivedObjectIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.LastReceivedObjectIdentifier.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEventInformationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
