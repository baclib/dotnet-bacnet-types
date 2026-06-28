// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTFloatingLimitCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _setpointReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 1);
        var _lowDiffLimit = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
        var _highDiffLimit = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 3);
        var _deadband = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit
        {
            TimeDelay = _timeDelay,
            SetpointReference = _setpointReference,
            LowDiffLimit = _lowDiffLimit,
            HighDiffLimit = _highDiffLimit,
            Deadband = _deadband
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 1, value.SetpointReference);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.LowDiffLimit);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 3, value.HighDiffLimit);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 4, value.Deadband);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(1, value.SetpointReference) + Asdu.GetPrimitiveLength<RealCodec, float>(2, value.LowDiffLimit) + Asdu.GetPrimitiveLength<RealCodec, float>(3, value.HighDiffLimit) + Asdu.GetPrimitiveLength<RealCodec, float>(4, value.Deadband);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TFloatingLimit value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
