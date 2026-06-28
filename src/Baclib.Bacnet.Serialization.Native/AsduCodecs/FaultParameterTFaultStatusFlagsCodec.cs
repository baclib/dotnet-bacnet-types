// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultStatusFlagsCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags Decode(ref NativeReader reader)
    {
        var _statusFlagsReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags
        {
            StatusFlagsReference = _statusFlagsReference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags value)
    {
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 0, value.StatusFlagsReference);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags value)
    {
        return Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(0, value.StatusFlagsReference);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultStatusFlags value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
