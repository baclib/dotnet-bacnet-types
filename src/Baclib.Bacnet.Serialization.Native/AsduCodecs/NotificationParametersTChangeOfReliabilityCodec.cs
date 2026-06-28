// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfReliabilityCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability Decode(ref NativeReader reader)
    {
        var _reliability = Asdu.DecodePrimitive<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _propertyValues = Asdu.DecodeSequenceOf<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability
        {
            Reliability = _reliability,
            StatusFlags = _statusFlags,
            PropertyValues = _propertyValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability value)
    {
        Asdu.EncodePrimitive<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(ref writer, 0, value.Reliability);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        writer.WriteOpeningTag(2);
        foreach (var item in value.PropertyValues)
        {
            Asdu.EncodeElement<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability value)
    {
        return Asdu.GetPrimitiveLength<ReliabilityCodec, global::Baclib.Bacnet.Types.Application.Reliability>(0, value.Reliability) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + (AsduLength.FromTagNumber((byte)2) + (value.PropertyValues.Items.Sum(static item => Asdu.GetElementLength<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(2, item))) + AsduLength.FromTagNumber((byte)2));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfReliability value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
