// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultLifeSafetyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety Decode(ref NativeReader reader)
    {
        var _listOfFaultValues = Asdu.DecodeSequenceOf<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref reader, 0);
        var _modePropertyReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety
        {
            ListOfFaultValues = _listOfFaultValues,
            ModePropertyReference = _modePropertyReference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.ListOfFaultValues)
        {
            Asdu.EncodeElement<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 1, value.ModePropertyReference);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.ListOfFaultValues.Items.Sum(static item => Asdu.GetElementLength<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(0, item))) + AsduLength.FromTagNumber((byte)0)) + Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(1, value.ModePropertyReference);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultLifeSafety value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
