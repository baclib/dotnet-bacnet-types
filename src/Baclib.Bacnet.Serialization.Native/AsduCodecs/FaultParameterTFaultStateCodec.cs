// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultStateCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState Decode(ref NativeReader reader)
    {
        var _listOfFaultValues = Asdu.DecodeSequenceOf<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState
        {
            ListOfFaultValues = _listOfFaultValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.ListOfFaultValues)
        {
            Asdu.EncodeElement<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.ListOfFaultValues.Items.Sum(static item => Asdu.GetElementLength<PropertyStatesCodec, global::Baclib.Bacnet.Types.Application.PropertyStates>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultState value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
