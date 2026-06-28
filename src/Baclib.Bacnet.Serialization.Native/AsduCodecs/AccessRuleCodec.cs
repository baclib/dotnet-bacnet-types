// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccessRuleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AccessRule>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AccessRule>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AccessRule Decode(ref NativeReader reader)
    {
        var _timeRangeSpecifier = Asdu.DecodePrimitive<AccessRuleTTimeRangeSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TTimeRangeSpecifier>(ref reader, 0);
        var _timeRange = Asdu.DecodeOptionalElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 1);
        var _locationSpecifier = Asdu.DecodePrimitive<AccessRuleTLocationSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TLocationSpecifier>(ref reader, 2);
        var _location = Asdu.DecodeOptionalElement<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref reader, 3);
        var _enable = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.AccessRule
        {
            TimeRangeSpecifier = _timeRangeSpecifier,
            TimeRange = _timeRange,
            LocationSpecifier = _locationSpecifier,
            Location = _location,
            Enable = _enable
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AccessRule Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AccessRule value)
    {
        Asdu.EncodePrimitive<AccessRuleTTimeRangeSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TTimeRangeSpecifier>(ref writer, 0, value.TimeRangeSpecifier);
        if (value.TimeRange.HasValue)
        {
            Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 1, value.TimeRange.Value);
        }
        Asdu.EncodePrimitive<AccessRuleTLocationSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TLocationSpecifier>(ref writer, 2, value.LocationSpecifier);
        if (value.Location.HasValue)
        {
            Asdu.EncodeElement<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(ref writer, 3, value.Location.Value);
        }
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 4, value.Enable);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AccessRule value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccessRule value)
    {
        return Asdu.GetPrimitiveLength<AccessRuleTTimeRangeSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TTimeRangeSpecifier>(0, value.TimeRangeSpecifier) + (value.TimeRange.HasValue ? Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(1, value.TimeRange.Value) : 0) + Asdu.GetPrimitiveLength<AccessRuleTLocationSpecifierCodec, global::Baclib.Bacnet.Types.Application.AccessRule.TLocationSpecifier>(2, value.LocationSpecifier) + (value.Location.HasValue ? Asdu.GetElementLength<DeviceObjectReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectReference>(3, value.Location.Value) : 0) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(4, value.Enable);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccessRule value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
