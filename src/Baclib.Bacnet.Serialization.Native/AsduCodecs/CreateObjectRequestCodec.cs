// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CreateObjectRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CreateObjectRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest Decode(ref NativeReader reader)
    {
        var _objectSpecifier = Asdu.DecodeConstructed<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(ref reader, 0);
        var _listOfInitialValues = reader.PeekOpeningTag(1) ? Asdu.DecodeSequenceOf<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref reader, 1) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.PropertyValue>>.None;

        return new global::Baclib.Bacnet.Types.Application.CreateObjectRequest
        {
            ObjectSpecifier = _objectSpecifier,
            ListOfInitialValues = _listOfInitialValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CreateObjectRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest value)
    {
        Asdu.EncodeElement<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(ref writer, 0, value.ObjectSpecifier);
        if (value.ListOfInitialValues.HasValue)
        {
            writer.WriteOpeningTag(1);
            foreach (var item in value.ListOfInitialValues.Value)
            {
                Asdu.EncodeElement<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref writer, 1, item);
            }
            writer.WriteClosingTag(1);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CreateObjectRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest value)
    {
        return Asdu.GetElementLength<CreateObjectRequestTObjectSpecifierCodec, global::Baclib.Bacnet.Types.Application.CreateObjectRequest.TObjectSpecifier>(0, value.ObjectSpecifier) + (value.ListOfInitialValues.HasValue ? (AsduLength.FromTagNumber((byte)1) + (value.ListOfInitialValues.Value.Items.Sum(static item => Asdu.GetElementLength<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(1, item))) + AsduLength.FromTagNumber((byte)1)) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CreateObjectRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
